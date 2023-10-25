using LabBook.ADO;
using LabBook.Commons;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LabBook.Repository
{
    public class LoginRepository
    {
        private readonly SqlConnection _connection;
        private readonly string _programData = "Select id, date, column_2, column_3, column_4, column_5 From LabBook.dbo.ProgramData " + 
                                                "Where column_2 = 'dates' and column_3 = 'XXXX'";
        private readonly string _updateToExpire = "Update LabBook.dbo.ProgramData Set column_4 = 'Expire'";
        private readonly string _getUserByLoginAndPassword = "Select id, name, surname, e_mail, login, permission, " +
                                                            "identifier, active, date from LabBook.dbo.Users Where login = 'XXXX' and password = 'YYYY'";
        private readonly string _saveUser = "Insert Into LabBook.dbo.Users(name, surname, e_mail, login, password, permission, identifier, active, date) " +
                                            "Values(@name, @surname, @e_mail, @login, @password, @permission, @identifier, @active, @date);";
        private readonly string _userExist = "Select count(*) as exist From LabBook.dbo.Users Where login = 'XXXX'";

        public LoginRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public ProgramData GetProgramData(string password)
        {
            ProgramData result = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                string query = _programData.Replace("XXXX", password);
                cmd.CommandText = query;
                _connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (rdr.HasRows)
                {
                    result = new ProgramData();
                    rdr.Read();
                    result.Id = rdr.GetInt64(0);
                    result.Date = rdr.GetDateTime(1);
                    result.ColumnTwo = CommonFunction.DBNullToStringConv(rdr.GetValue(2));
                    result.ColumnThree = CommonFunction.DBNullToStringConv(rdr.GetValue(3));
                    result.ColumnFour = CommonFunction.DBNullToStringConv(rdr.GetValue(4));
                    result.ColumnFive = CommonFunction.DBNullToDoubleConv(rdr.GetValue(5));
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu Load ProgramData.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu Load ProgramData.",
                    "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }

            return result;
        }

        public User GetUserByLoginAndPassword(string login, string password)
        {
            User user = null;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                string query = _getUserByLoginAndPassword.Replace("XXXX", login);
                query = query.Replace("YYYY", password);
                cmd.CommandText = query;
                _connection.Open();
                SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                if (rdr.HasRows)
                {
                    user = new User();
                    rdr.Read();
                    user.Id = rdr.GetInt64(0);
                    user.Name = CommonFunction.DBNullToStringConv(rdr.GetValue(1));
                    user.Surname = CommonFunction.DBNullToStringConv(rdr.GetValue(2));
                    user.Email = CommonFunction.DBNullToStringConv(rdr.GetValue(3));
                    user.Login = rdr.GetString(4);
                    user.Permission = rdr.GetString(5);
                    user.Identifier = rdr.GetString(6);
                    user.Active = rdr.GetBoolean(7);
                    user.Date = rdr.GetDateTime(8);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu Load User.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu Load User.",
                    "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }

            return user;
        }

        public void SaveUser(User user)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = _connection;
                cmd.CommandText = _saveUser;
                cmd.Parameters.AddWithValue("@name", user.Name);
                cmd.Parameters.AddWithValue("@surname", user.Surname);
                cmd.Parameters.AddWithValue("@e_mail", user.Email);
                cmd.Parameters.AddWithValue("@login", user.Login.ToLower());
                cmd.Parameters.AddWithValue("@password", user.Password);
                cmd.Parameters.AddWithValue("@permission", user.Permission);
                cmd.Parameters.AddWithValue("@identifier", user.Identifier);
                cmd.Parameters.AddWithValue("@active", user.Active);
                cmd.Parameters.AddWithValue("@date", user.Date);

                _connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu Save Users.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu Save Users.",
                    "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }

        }

        public bool UserExist(string login)
        {
            bool result = false;

            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = _connection;
                string query = _userExist.Replace("XXXX", login);
                cmd.CommandText = query;
                _connection.Open();
                result = Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu Is Users exist.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu Is Users exist.",
                    "Błąd połączenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_connection.State == ConnectionState.Open)
                    _connection.Close();
            }

            return result;
        }

        public void UpdateToExpire()
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                cmd.Connection = _connection;
                cmd.CommandText = _updateToExpire;
                _connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony, błąd w nazwie serwera lub dostępie do bazy: '" + ex.Message + "'. Błąd z poziomu Set ProgramData to expire.",
                    "Błąd połaczenia", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem z połączeniem z serwerem. Prawdopodobnie serwer jest wyłączony: '" + ex.Message + "'. Błąd z poziomu Set ProgramData to expire.",
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
