using LabBook.ADO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LabBook.Repository
{
    public class LabBookRepository
    {
        private readonly string _getAllLabBookQuery = "Select l.id, l.title, l.density, l.observation, l.remarks, l.user_id, u.identifier, " + 
                "l.cycle_id, c.name as cyc_name, l.project_id, l.created, l.modified, l.deleted From LabBook.dbo.ExpLabBook l left join " +
                "LabBook.dbo.Users u on l.user_id=u.id left join LabBook.dbo.ExpCycle c on l.cycle_id= c.id Order By l.id";

        private readonly User _user;
        private readonly SqlConnection _connection;

        public LabBookRepository(User user, SqlConnection connection)
        {
            _user = user;
            _connection = connection;
        }

        public DataTable GetAllLabBook()
        {
            DataTable table = null;

            try
            {
                table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter(_getAllLabBookQuery, _connection);
                adapter.Fill(table);

                DataColumn primaryKeyColumn = new DataColumn();
                primaryKeyColumn = table.Columns["id"];
                DataColumn[] key = new DataColumn[1];
                key[0] = primaryKeyColumn;
                table.PrimaryKey = key;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu Load ExpLabBook.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu Load ExpLabBook.",
                    "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }

            return table;
        }
    }
}
