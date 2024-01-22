using LabBook.ADO;
using LabBook.Commons;
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
        private const string GET_VISCOSITY_COLUMNS_BY_ID = "Select id, labBook_id, type, fields From LabBook.dbo.ExpViscosityColumns Where labBook_id=";
        private const string SAVE = "Insert Into LabBook.dbo.ExpViscosity(labbook_id, date_created, date_update, temp, pH, vis_type, brook_1, brook_5, brook_10, " +
            "brook_20, brook_30, brook_40, brook_50, brook_60, brook_70, brook_80, brook_90, brook_100, brook_disc, brook_comment, brook_x_vis, brook_x_rpm, " +
            "brook_x_disc, krebs, krebs_comment, ici, ici_disc, ici_comment) Values(@a, @b, @c, @d, @e, @f, @g, @h, @i, @j, @k, @l, @m, @n, @o, @p, @r, @s, " +
            "@t, @u, @v, @w, @x, @y, @z, @aa, @ab, @ac)";
        private const string UPDATE = "Update LabBook.dbo.ExpViscosity Set labbook_id=@a, date_created=@b, date_update=@c, temp=@d, pH=@e, vis_type=@f, brook_1=@g, brook_5=@h, " +
            "brook_10=@i, brook_20=@j, brook_30=@k, brook_40=@l, brook_50=@m, brook_60=@n, brook_70=@o, brook_80=@p, brook_90=@r, brook_100=@s, brook_disc=@t, brook_comment=@u, " +
            "brook_x_vis=@v, brook_x_rpm=@w, brook_x_disc=@x, krebs=@y, krebs_comment=@z, ici=@aa, ici_disc=@ab, ici_comment=@ac WHERE id=@id";
        private const string SAVE_VIS_COLUMNS = "Insert Into LabBook.dbo.ExpViscosityColumns(labBook_id, type, fields) values(@a, @b, @c)";
        private const string Delete_VIS_COLUMNS = "Delete From LabBook.dbo.ExpViscosityColumns Where labBook_id=";

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

        public ViscosityColumn GetViscosityColumnById(long id)
        {
            ViscosityColumn columns = new ViscosityColumn(-1, id, ViscosityType.STD, "");

                try
                {
                    string query = GET_VISCOSITY_COLUMNS_BY_ID + id.ToString();
                    SqlCommand command = new SqlCommand(query, _connection);
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();

                        long nr = reader.GetInt64(0);
                        long labId = reader.GetInt64(1);
                        string type = reader.GetString(2);
                        string fields = CommonFunction.DBNullToStringConv(reader.GetValue(3));

                        columns.Id = nr;
                        columns.LabBookId = labId;
                        ViscosityType visType = Enum.TryParse<ViscosityType>(type, out visType) ? visType : ViscosityType.STD;
                        columns.Type = visType;
                        columns.Fields = fields;

                        reader.Close();
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu Load Viscosity Fields.",
                        "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu Load Viscosity Fields.",
                        "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (_connection.State == ConnectionState.Open)
                        _connection.Close();
                }

            return columns;
        }

        public bool SaveViscosity(DataRow row)
        {
            bool result = true;
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = SAVE;
                cmd.Connection = _connection;
                cmd.Parameters.AddWithValue("@a", row["labbook_id"]);
                cmd.Parameters.AddWithValue("@b", row["date_created"]);
                cmd.Parameters.AddWithValue("@c", row["date_update"]);
                cmd.Parameters.AddWithValue("@d", row["temp"]);
                cmd.Parameters.AddWithValue("@e", row["pH"]);
                cmd.Parameters.AddWithValue("@f", row["vis_type"]);
                cmd.Parameters.AddWithValue("@g", row["brook_1"]);
                cmd.Parameters.AddWithValue("@h", row["brook_5"]);
                cmd.Parameters.AddWithValue("@i", row["brook_10"]);
                cmd.Parameters.AddWithValue("@j", row["brook_20"]);
                cmd.Parameters.AddWithValue("@k", row["brook_30"]);
                cmd.Parameters.AddWithValue("@l", row["brook_40"]);
                cmd.Parameters.AddWithValue("@m", row["brook_50"]);
                cmd.Parameters.AddWithValue("@n", row["brook_60"]);
                cmd.Parameters.AddWithValue("@o", row["brook_70"]);
                cmd.Parameters.AddWithValue("@p", row["brook_80"]);
                cmd.Parameters.AddWithValue("@r", row["brook_90"]);
                cmd.Parameters.AddWithValue("@s", row["brook_100"]);
                cmd.Parameters.AddWithValue("@t", row["brook_disc"]);
                cmd.Parameters.AddWithValue("@u", row["brook_comment"]);
                cmd.Parameters.AddWithValue("@v", row["brook_x_vis"]);
                cmd.Parameters.AddWithValue("@w", row["brook_x_rpm"]);
                cmd.Parameters.AddWithValue("@x", row["brook_x_disc"]);
                cmd.Parameters.AddWithValue("@y", row["krebs"]);
                cmd.Parameters.AddWithValue("@z", row["krebs_comment"]);
                cmd.Parameters.AddWithValue("@aa", row["ici"]);
                cmd.Parameters.AddWithValue("@ab", row["ici_disc"]);
                cmd.Parameters.AddWithValue("@ac", row["ici_comment"]);
                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu Save Viscosity.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu Save Viscosity.",
                    "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }

            return result;
        }

        public bool UpdateViscosity(DataRow row)
        {
            bool result = true;
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = UPDATE;
                cmd.Connection = _connection;
                cmd.Parameters.AddWithValue("@a", row["labbook_id"]);
                cmd.Parameters.AddWithValue("@b", row["date_created"]);
                cmd.Parameters.AddWithValue("@c", row["date_update"]);
                cmd.Parameters.AddWithValue("@d", row["temp"]);
                cmd.Parameters.AddWithValue("@e", row["pH"]);
                cmd.Parameters.AddWithValue("@f", row["vis_type"]);
                cmd.Parameters.AddWithValue("@g", row["brook_1"]);
                cmd.Parameters.AddWithValue("@h", row["brook_5"]);
                cmd.Parameters.AddWithValue("@i", row["brook_10"]);
                cmd.Parameters.AddWithValue("@j", row["brook_20"]);
                cmd.Parameters.AddWithValue("@k", row["brook_30"]);
                cmd.Parameters.AddWithValue("@l", row["brook_40"]);
                cmd.Parameters.AddWithValue("@m", row["brook_50"]);
                cmd.Parameters.AddWithValue("@n", row["brook_60"]);
                cmd.Parameters.AddWithValue("@o", row["brook_70"]);
                cmd.Parameters.AddWithValue("@p", row["brook_80"]);
                cmd.Parameters.AddWithValue("@r", row["brook_90"]);
                cmd.Parameters.AddWithValue("@s", row["brook_100"]);
                cmd.Parameters.AddWithValue("@t", row["brook_disc"]);
                cmd.Parameters.AddWithValue("@u", row["brook_comment"]);
                cmd.Parameters.AddWithValue("@v", row["brook_x_vis"]);
                cmd.Parameters.AddWithValue("@w", row["brook_x_rpm"]);
                cmd.Parameters.AddWithValue("@x", row["brook_x_disc"]);
                cmd.Parameters.AddWithValue("@y", row["krebs"]);
                cmd.Parameters.AddWithValue("@z", row["krebs_comment"]);
                cmd.Parameters.AddWithValue("@aa", row["ici"]);
                cmd.Parameters.AddWithValue("@ab", row["ici_disc"]);
                cmd.Parameters.AddWithValue("@ac", row["ici_comment"]);
                cmd.Parameters.AddWithValue("@id", row["id"]);
                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu Update Viscosity.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu Update Viscosity.",
                    "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }

            return result;
        }

        public bool SaveViscosityColumn(ViscosityColumn viscosityColumn)
        {
            bool result = true;

            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = SAVE_VIS_COLUMNS;
                cmd.Connection = _connection;
                cmd.Parameters.AddWithValue("@a", viscosityColumn.LabBookId);
                cmd.Parameters.AddWithValue("@b", viscosityColumn.Type);
                cmd.Parameters.AddWithValue("@c", CommonFunction.NullToDBNullConv(viscosityColumn.Fields));
                _connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu Save Viscosity Columns.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu Save Viscosity Columns.",
                    "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }


            return result;
        }

        public void DeleteViscosityColumn(long labBook)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = Delete_VIS_COLUMNS + labBook.ToString();
                cmd.Connection = _connection;
                _connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu Delete Viscosity Column.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu Delete Viscosity Column.",
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
