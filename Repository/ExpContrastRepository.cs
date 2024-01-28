using LabBook.ADO;
using LabBook.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LabBook.Repository
{
    public class ExpContrastRepository
    {
        private const string GET_CONTRASTBY_LABBOOK_ID = "Select c.id, c.labbook_id, c.applicator_name, c.position, c.substrate, " +
            "c.contrast, c.tw, c.sp, c.comments, c.date_created, c.date_updated from LabBook.dbo.ExpContrast c Where c.labbook_id=XXXX " +
            "Order by c.position";
        private const string SAVE = "Insert Into LabBook.dbo.ExpContrast(labbook_id, applicator_name, position, substrate, " +
            "contrast, tw, sp, comments, date_created, date_updated) Values(@a, @b, @c, @d, @e, @f, @g, @h, @i, @j)";
        private const string UPDATE = "Update LabBook.dbo.ExpContrast Set applicator_name=@a, position=@b, substrate=@c, " +
            "contrast=@d, tw=@e, sp=@f, comments=@g, date_created=@h, date_updated=@i Where id=@j";

        private readonly SqlConnection _connection;

        public ExpContrastRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public IList<ExpContrast> GetContrastListByLabBookId(long labBookId)
        {
            IList<ExpContrast> result = new List<ExpContrast>();
            SqlDataReader reader = null;


            try
            {
                string query = GET_CONTRASTBY_LABBOOK_ID.Replace("XXXX", labBookId.ToString());
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    int i = 1;
                    while (reader.Read())
                    {
                        long id = reader.GetInt64(0);
                        long labId = reader.GetInt64(1);
                        string appName = CommonFunction.DBNullToStringConv(reader.GetValue(2));
                        int position = reader.GetInt32(3);
                        string substrate = CommonFunction.DBNullToStringConv(reader.GetValue(4));
                        double? contrast = CommonFunction.DBNullToDoubleConv(reader.GetValue(5));
                        double? tw = CommonFunction.DBNullToDoubleConv(reader.GetValue(6));
                        double? sp = CommonFunction.DBNullToDoubleConv(reader.GetValue(7));
                        string comment = CommonFunction.DBNullToStringConv(reader.GetValue(8));
                        DateTime dateStart = reader.GetDateTime(9);
                        DateTime dateMeasure = reader.GetDateTime(10);

                        ExpContrast expContrast;
                        if (position != i)
                        {
                            expContrast = new ExpContrast(id, labId, appName, i, substrate, contrast, tw, sp, comment, dateStart, dateMeasure)
                            {
                                State = States.Modified
                            };
                        }
                        else
                        {
                            expContrast = new ExpContrast(id, labId, appName, position, substrate, contrast, tw, sp, comment, dateStart, dateMeasure);
                        }

                        result.Add(expContrast);
                        i++;
                    }
                    reader.Close();
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu Load Contrast.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu Load Contrast.",
                    "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (reader != null)
                    ((IDisposable)reader).Dispose();
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }


            return result;
        }

        public bool Save(ExpContrast expContrast)
        {
            bool result = true;
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = SAVE;
                cmd.Connection = _connection;
                cmd.Parameters.AddWithValue("@a", expContrast.LabBookId);
                cmd.Parameters.AddWithValue("@b", CommonFunction.NullStringToDBNullConv(expContrast.ApplicatorName));
                cmd.Parameters.AddWithValue("@c", expContrast.Position);
                cmd.Parameters.AddWithValue("@d", CommonFunction.NullStringToDBNullConv(expContrast.Substrate));
                cmd.Parameters.AddWithValue("@e", CommonFunction.NullDoubleToDBNullConv(expContrast.Contrast));
                cmd.Parameters.AddWithValue("@f", CommonFunction.NullDoubleToDBNullConv(expContrast.Tw));
                cmd.Parameters.AddWithValue("@g", CommonFunction.NullDoubleToDBNullConv(expContrast.Sp));
                cmd.Parameters.AddWithValue("@h", CommonFunction.NullStringToDBNullConv(expContrast.Comments));
                cmd.Parameters.AddWithValue("@i", expContrast.DateCreated);
                cmd.Parameters.AddWithValue("@j", expContrast.DateUpdated);
                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu Save Contrast.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu Save Contrast.",
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

        public bool Update(ExpContrast expContrast)
        {
            bool result = true;
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.CommandText = UPDATE;
                cmd.Connection = _connection;
                cmd.Parameters.AddWithValue("@a", CommonFunction.NullStringToDBNullConv(expContrast.ApplicatorName));
                cmd.Parameters.AddWithValue("@b", expContrast.Position);
                cmd.Parameters.AddWithValue("@c", CommonFunction.NullStringToDBNullConv(expContrast.Substrate));
                cmd.Parameters.AddWithValue("@d", CommonFunction.NullDoubleToDBNullConv(expContrast.Contrast));
                cmd.Parameters.AddWithValue("@e", CommonFunction.NullDoubleToDBNullConv(expContrast.Tw));
                cmd.Parameters.AddWithValue("@f", CommonFunction.NullDoubleToDBNullConv(expContrast.Sp));
                cmd.Parameters.AddWithValue("@g", CommonFunction.NullStringToDBNullConv(expContrast.Comments));
                cmd.Parameters.AddWithValue("@h", expContrast.DateCreated);
                cmd.Parameters.AddWithValue("@i", expContrast.DateUpdated);
                cmd.Parameters.AddWithValue("@j", expContrast.Id);
                _connection.Open();
                cmd.ExecuteNonQuery();
                _connection.Close();
                cmd.Dispose();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu Update Contrast.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                result = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu Update Contrast.",
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
    }

}
