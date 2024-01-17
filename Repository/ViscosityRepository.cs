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
    public class ViscosityRepository
    {
        private const string GET_VISCOSITY_BY_ID = "Select id, labbook_id, date_created, date_update, DATEDIFF(day, date_created, date_update) " +
            "as days_distance, temp, pH, vis_type, brook_1, brook_5, brook_10, brook_20, brook_30, brook_40, brook_50, brook_60, brook_70, " +
            "brook_80, brook_90, brook_100, brook_disc, brook_comment, brook_x_vis, brook_x_rpm, brook_x_disc, krebs, krebs_comment, ici, " +
            "ici_disc, ici_comment From LabBook.dbo.ExpViscosity Where labbook_id=XXXX Order by date_created, date_update";
        
        private readonly SqlConnection _connection;

        public ViscosityRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public DataTable GetViscosityByLabBookId(long id)
        {
            DataTable viscosity = new DataTable();

            try
            {
                string kwer = GET_VISCOSITY_BY_ID.Replace("XXXX", id.ToString());
                SqlDataAdapter adapter = new SqlDataAdapter(kwer, _connection);
                adapter.Fill(viscosity);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu Load Viscosity.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu Load Viscosity.",
                    "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }

            return viscosity;
        }

        public void LoadViscosityByLabBookId(DataTable viscosity, long id)
        {
            try
            {
                string kwer = GET_VISCOSITY_BY_ID.Replace("XXXX", id.ToString());
                SqlDataAdapter adapter = new SqlDataAdapter(kwer, _connection);
                adapter.Fill(viscosity);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu Load Viscosity.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu Load Viscosity.",
                    "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }
        }
    }
}
