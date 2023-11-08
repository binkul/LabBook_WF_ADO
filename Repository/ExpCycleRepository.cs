using LabBook.ADO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabBook.Repository
{
    public class ExpCycleRepository
    {
        private readonly string _getAllCycle = "Select id, name, user_id, date From ExpCycle Order By name";
        private readonly SqlConnection _connection;

        public ExpCycleRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IList<ExpCycle> GetAllExpCycles()
        {
            IList<ExpCycle> list = new List<ExpCycle>();
            SqlDataReader reader = null;

            try
            {
                SqlCommand command = new SqlCommand(_getAllCycle, _connection);
                _connection.Open();
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        long id = reader.GetInt64(0);
                        string name = reader.GetString(1);
                        long userId = reader.GetInt64(2);
                        DateTime date = reader.GetDateTime(3);

                        ExpCycle expCycle = new ExpCycle(id, name, userId, date);
                        list.Add(expCycle);
                    }
                    reader.Close();
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu GetExpCycles.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu GetExpCycles.",
                    "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }

            return list;
        }

    }
}
