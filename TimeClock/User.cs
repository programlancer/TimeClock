using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Windows;

namespace Programlancer
{
    public class User
    {
        public int Id { get; private set; }
        public string Login { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool IsAdmin { get; private set; }

        public User(int id, string login, string firstName, string lastName, bool isAdmin)
        {
            Id = id;
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            IsAdmin = isAdmin;
        }

        public static User Create(string login, string password, bool passwordRequired)
        {
            User user = null;

            string command = "select id, login, firstname, lastname, isadmin from users where login=@login";
            if (passwordRequired)
            {
                command += " and coalesce(password, '', '')=@password";
            }

            using (SqlCeConnection con = new SqlCeConnection(global::Programlancer.Properties.Settings.Default.ShopConnectionString))
            {
                SqlCeCommand com = new SqlCeCommand(command, con);
                com.Parameters.AddWithValue("login", login);
                //com.Parameters.Add("login", login);

                if (passwordRequired)
                {
                    com.Parameters.AddWithValue("password", password);
                    //com.Parameters.Add("password", password);
                }

                try
                {
                    con.Open();
                    SqlCeDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        user = new User(
                            (int)reader.GetDecimal(0), reader.GetString(1)
                            , reader.IsDBNull(2) ? "" : reader.GetString(2)
                            , reader.IsDBNull(3) ? "" : reader.GetString(3)
                            , reader.IsDBNull(4) ? false : reader.GetBoolean(4));
                    }
                }
                catch (System.Data.SqlServerCe.SqlCeException se)
                {
                    MessageBox.Show("Perhaps you need to update the database. Use the UPDATE parameter. Bye!");
                    Environment.Exit(1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return user;
        }

        public static User CreateUserFromId(int id)
        {
            User user = null;

            string command = "select id, login, firstname, lastname, isadmin from users where id=@id";

            using (SqlCeConnection con = new SqlCeConnection(global::Programlancer.Properties.Settings.Default.ShopConnectionString))
            {
                SqlCeCommand com = new SqlCeCommand(command, con);
                com.Parameters.Add("id", id);

                try
                {
                    con.Open();
                    SqlCeDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        user = new User(
                            (int)reader.GetDecimal(0), reader.GetString(1)
                            , reader.IsDBNull(2) ? "" : reader.GetString(2)
                            , reader.IsDBNull(3) ? "" : reader.GetString(3)
                            , reader.IsDBNull(4) ? false : reader.GetBoolean(4));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return user;
        }

        public bool IsWorking()
        {
            bool result = false;

            string command = "SELECT id,[When],[What] FROM log WHERE id=@id AND DATEPART(yy, [When])=@year AND DATEPART(mm, [When])=@month AND DATEPART(dd, [When])=@day ORDER BY [When]";

            using (SqlCeConnection con = new SqlCeConnection(global::Programlancer.Properties.Settings.Default.ShopConnectionString))
            {
                SqlCeCommand com = new SqlCeCommand(command, con);

                com.Parameters.AddWithValue("id", this.Id);
                com.Parameters.AddWithValue("year", DateTime.Now.Year);
                com.Parameters.AddWithValue("month", DateTime.Now.Month);
                com.Parameters.AddWithValue("day", DateTime.Now.Day);

                //com.Parameters.Add("id", this.Id);
                //com.Parameters.Add("year", DateTime.Now.Year);
                //com.Parameters.Add("month", DateTime.Now.Month);
                //com.Parameters.Add("day", DateTime.Now.Day);

                try
                {
                    con.Open();
                    SqlCeDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        switch (reader.GetString(2).Trim().ToUpper())
                        {
                            case "IN":
                                result = true;
                                break;

                            case "OUT":
                                result = false;
                                break;

                            default:
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return result;
        }
    }
}
