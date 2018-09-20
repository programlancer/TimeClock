using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Data;
using System.Globalization;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;

namespace Programlancer
{

    public class Library
    {

        const int ALLUSERS = 0;

        public static string ToShortDate(DateTime theDate)
        {
            System.Text.StringBuilder dateString = new System.Text.StringBuilder();

            dateString.Append(String.Format("{0:d2}", theDate.Day));
            dateString.Append("/");
            dateString.Append(String.Format("{0:d2}", theDate.Month));
            dateString.Append("/");
            dateString.Append(theDate.Year.ToString().Substring(2));
            dateString.Append(" ");
            dateString.Append(String.Format("{0:d2}", theDate.Hour));
            dateString.Append(":");
            dateString.Append(String.Format("{0:d2}", theDate.Minute));

            return dateString.ToString();
        }

        public static void FillComboUsers(ComboBox combo)
        {
            string command = "select id,login from users where showinlist='true' order by login";

            using (SqlCeConnection connection = new SqlCeConnection(global::Programlancer.Properties.Settings.Default.ShopConnectionString))
            {
                SqlCeCommand sqlCommand = new SqlCeCommand(command, connection);

                try
                {
                    connection.Open();
                    SqlCeDataReader reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        combo.Items.Add(new ComboBoxItem(reader.GetString(1), (int)reader.GetDecimal(0)));
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static bool SaveToLog(string userId, string what)
        {
            string command = "insert into log (id,[when],what) values (@id,@when,@what)";

            using (SqlCeConnection con = new SqlCeConnection(global::Programlancer.Properties.Settings.Default.ShopConnectionString))
            {
                SqlCeCommand com = new SqlCeCommand(command, con);
                com.Parameters.Add("id", userId);
                com.Parameters.Add("when", DateTime.Now);
                com.Parameters.Add("what", what);

                try
                {
                    con.Open();
                    int affectedRows = com.ExecuteNonQuery();

                    if (affectedRows == 1)
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return false;
        }

        public static DataTable AtWork()
        {
            #region Columns
            DataTable dt = new DataTable();

            dt.Columns.Add("User", typeof(string));
            dt.Columns.Add("In", typeof(DateTime));
            #endregion

            DataTable tmp = Report(ALLUSERS, DateTime.Now, DateTime.Now);
            if (tmp.Rows.Count > 0)
            {
                try
                {
                    DateTime t = new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day);
                    string filter = string.Format(CultureInfo.InvariantCulture, "[Out] = #{0}#", t);

                    tmp.DefaultView.RowFilter = filter;

                    foreach (DataRowView row in tmp.DefaultView)
                    {
                        dt.Rows.Add(row[1], row[2]);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }

            return dt;
        }

        public static DataTable Report(int user, DateTime begin, DateTime end)
        {

            #region Columns
            DataTable dt = new DataTable("DataTableReport");

            dt.Columns.Add("Date", typeof(DateTime));
            //dt.Columns.Add("User", typeof(int));
            dt.Columns.Add("User", typeof(string));
            dt.Columns.Add("In", typeof(DateTime));
            dt.Columns.Add("Out", typeof(DateTime));
            dt.Columns.Add("Duration", typeof(TimeSpan));
            #endregion

            List<User> users = GetUsers(user);

            //TimeSpan amount = new TimeSpan();

            for (DateTime date = begin; date <= end; date = date.AddDays(1))
            {
                foreach (User u in users)
                {
                    List<object[]> records = GetRecords(u.Id, date);

                    foreach (object[] r in records)
                    {
                        r[0] = date;
                        r[1] = u.FirstName + " " + u.LastName;

                        if (r[2] == null || r[3] == null)
                        {
                            if (r[2] == null) r[2] = new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day);
                            if (r[3] == null) r[3] = new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day);
                            r[4] = TimeSpan.Zero;
                        }
                        else
                            r[4] = (DateTime)r[3] - (DateTime)r[2];

                        dt.Rows.Add(r);
                        //amount += (TimeSpan)c[4];
                    }
                }

            }

            //DataRow dr = dt.NewRow();
            //dr[0]="Amount";
            //dr[4]=(amount.Days * 24 + amount.Hours).ToString() + ":" + amount.Minutes;

            return dt;
        }

        static List<object[]> GetRecords(int user, DateTime date)
        {
            List<object[]> records = new List<object[]>();

            string command = "SELECT id,[When],[What] FROM log WHERE id=@id AND DATEPART(yy, [When])=@year AND DATEPART(mm, [When])=@month AND DATEPART(dd, [When])=@day ORDER BY [When]";

            using (SqlCeConnection con = new SqlCeConnection(global::Programlancer.Properties.Settings.Default.ShopConnectionString))
            {
                SqlCeCommand com = new SqlCeCommand(command, con);

                com.Parameters.Add("id", user);
                com.Parameters.Add("year", date.Year);
                com.Parameters.Add("month", date.Month);
                com.Parameters.Add("day", date.Day);

                try
                {
                    con.Open();
                    SqlCeDataReader reader = com.ExecuteReader();

                    object[] tmp = new object[5];

                    while (reader.Read())
                    {
                        //string s = reader.GetString(2).Trim().ToUpper();

                        switch (reader.GetString(2).Trim().ToUpper())
                        {
                            case "IN":
                                if (tmp[2] != null)
                                {
                                    records.Add(tmp);
                                    tmp = new object[5];
                                }

                                tmp[2] = reader.GetDateTime(1);
                                break;

                            case "OUT":
                                if (tmp[3] != null)
                                {
                                    records.Add(tmp);
                                    tmp = new object[5];
                                }

                                tmp[3] = reader.GetDateTime(1);
                                break;

                            default:
                                break;
                        }

                    }

                    if (tmp[2] != null || tmp[3] != null) records.Add(tmp);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return records;
        }

        internal static string UpgradeDB()
        {
            string connStringCI = "Data Source= Shop.sdf; LCID= 1049";

            // Set "Case Sensitive" to true to change the collation from CI to CS.
            string connStringCS = "Data Source= Shop.sdf; LCID= 1049; Case Sensitive=true";

            SqlCeEngine engine = new SqlCeEngine(connStringCI);

            // The collation of the database will be case sensitive because of 
            // the new connection string used by the Upgrade method.                
            engine.Upgrade(connStringCS);

            SqlCeConnection conn = null;
            conn = new SqlCeConnection(connStringCI);
            conn.Open();

            //Retrieve the connection string information - notice the 'Case Sensitive' value.
            List<KeyValuePair<string, string>> dbinfo = conn.GetDatabaseInfo();

            Console.WriteLine("\nGetDatabaseInfo() results:");

            foreach (KeyValuePair<string, string> kvp in dbinfo)
            {
                Console.WriteLine(kvp);
            }

            return "Shop.sdf has been upgraded to Ver. 4.0. Please rerun the program.";
        }

        public static List<User> GetUsers(int user)
        {
            List<User> users = new List<User>();

            string command = "select id, lastname, firstname from users where showinlist=1";
            if (user != 0) command += " and id=@id";
            command += " order by lastname";

            using (SqlCeConnection con = new SqlCeConnection(global::Programlancer.Properties.Settings.Default.ShopConnectionString))
            {
                SqlCeCommand com = new SqlCeCommand(command, con);

                if (user != 0) com.Parameters.Add("id", user);

                try
                {
                    con.Open();
                    SqlCeDataReader reader = com.ExecuteReader();

                    while (reader.Read())
                    {
                        string lName = "";
                        string fName = "";

                        if (!reader.IsDBNull(1)) lName = reader.GetString(1);
                        if (!reader.IsDBNull(2)) fName += reader.GetString(2);

                        users.Add(new User((int)reader.GetDecimal(0), "", fName, lName, false));
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            return users;
        }

        public static string BackUp()
        {
            bool fileCopied = Library.CopyFileToBakDir();

            bool mailSent = false;

            if (Properties.Settings.Default.SendBackUpByEMail)
            {
                List<string> files = new List<string>();
                files.Add("Shop.sdf");
                files.Add("TimeClock.txt");

                mailSent = Library.SendEMail(
                    Properties.Settings.Default.SendEMailFrom,
                    Properties.Settings.Default.SendBackUpToEMail,
                    "Backup " + DateTime.Now.ToString("yyyy-MM-dd HH:mm"),
                    "Version " + Library.GetVersionNum(),
                    files);
            }

            string message = "";

            if (!fileCopied && !mailSent) message += "Error";
            if (fileCopied) message += Program.resourceManager.GetString("strBackupCreated");
            if (mailSent) message += " " + Program.resourceManager.GetString("strAndMailSent");
            message += " !";

            return message;
        }

        public static string Restore()
        {
            bool fileRenamed = RenameExistingFile("Shop", ".sdf");
            bool fileCopied = false;


            string message = "";

            if (!fileRenamed && !fileCopied) message += "Error";
            if (fileRenamed) message += " " + Program.resourceManager.GetString("strFileRenamed");
            if (fileCopied) message += Program.resourceManager.GetString("strFileRestored");

            message += " !";

            return message;
        }

        public static bool CopyFileToBakDir()
        {
            bool result = false;

            string name = "Shop";
            string ext = ".sdf";

            string sourceDir = "";
            string sourceFile = System.IO.Path.Combine(sourceDir, name + ext);

            string targetDir = "Bak";
            string destFile = System.IO.Path.Combine(targetDir, name + DateTime.Now.ToString("yyyyMMddHHmm") + ext);

            if (!System.IO.Directory.Exists(targetDir))
            {
                System.IO.Directory.CreateDirectory(targetDir);
            }

            try
            {
                System.IO.File.Copy(sourceFile, destFile, true);

                result = true;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            return result;
        }

        public static bool RenameExistingFile(string name, string ext)
        {
            bool result = false;

            //string sourceFile = System.IO.Path.Combine(name, ext);
            string sourceFile = name + ext;

            if (System.IO.File.Exists(sourceFile))
            {
                //string destFile = System.IO.Path.Combine(name, DateTime.Now.ToString("yyyyMMddHHmm"), ext);
                string destFile = name + DateTime.Now.ToString("yyyyMMddHHmm") + ext;

                if (System.IO.File.Exists(destFile))
                {
                    System.Console.WriteLine("Destination file exists !");
                    result = false;
                }
                else
                    try
                    {
                        System.IO.File.Move(sourceFile, destFile);

                        result = true;
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine(e.Message);
                    }
            }
            else
                result = true;

            return result;
        }

        public static bool CopyFileFromBakDir()
        {
            bool result = false;

            string name = "Shop";
            string ext = ".sdf";

            string sourceDir = "";
            string sourceFile = System.IO.Path.Combine(sourceDir, name + ext);

            string targetDir = "Bak";
            string destFile = System.IO.Path.Combine(targetDir, name + DateTime.Now.ToString("yyyyMMddHHmm") + ext);

            if (!System.IO.Directory.Exists(targetDir))
            {
                System.IO.Directory.CreateDirectory(targetDir);
            }

            try
            {
                System.IO.File.Copy(sourceFile, destFile, true);

                result = true;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.Message);
            }

            return result;
        }

        public static bool SendEMail(string from, string to, string subject, string body, List<string> files)
        {
            bool result = false;
            string errorMessage = null;

            MailMessage msg = new MailMessage(from, to, subject, body);

            try
            {

                foreach (string file in files)
                {
                    Attachment data = new Attachment(file, MediaTypeNames.Application.Octet);
                    msg.Attachments.Add(data);
                }

                SmtpClient client = new SmtpClient(Properties.Settings.Default.SMTPserver);
                client.UseDefaultCredentials = false;

                string user = "", pass = "";

                if (Properties.Settings.Default.SMTPuser.Trim() != "")
                {
                    user = Properties.Settings.Default.SMTPuser;

                    if (Properties.Settings.Default.SMTPpassword.Trim() != "") pass = Properties.Settings.Default.SMTPpassword;
                }
                else
                {
                    user = "v_and_j";
                    pass = "crimea12";
                }

                client.Credentials = new System.Net.NetworkCredential(user, pass);

                client.Send(msg);

                result = true;
            }
            catch (Exception ex)
            {
                errorMessage = "Exception caught in SendEMail(): " + ex.Message;
            }
            finally
            {
                foreach (Attachment item in msg.Attachments)
                {
                    item.Dispose();
                }
            }

            if (errorMessage != null) WriteTextMessage(errorMessage);

            return result;
        }

        public static string GetVersionNum()
        {
            Assembly assembly = System.Reflection.Assembly.GetEntryAssembly();

            if (assembly == null) return null;
            return assembly.GetName().Version.ToString();

            //object[] customAttributes = assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false);
            //if ((customAttributes == null) || (customAttributes.Length == 0)) return null;
            //return ((AssemblyFileVersionAttribute)customAttributes[0]).Version;
        }

        public static string FilesExist()
        {
            string message = "";

            string[] files = { "Shop.sdf" };

            foreach (string file in files)
            {
                if (!System.IO.File.Exists(file))
                {
                    message += "\n" + file;
                }
            }

            return message;
        }

        public static void WriteTextMessage(string msg)
        {
            try
            {
                System.IO.File.AppendAllText(Properties.Settings.Default.TextMessagesFile.Trim(), DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss ") + msg + Environment.NewLine);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
