using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using System.Resources;

namespace Programlancer
{
    static class Program
    {
        internal static ResourceManager resourceManager;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            Library.WriteTextMessage("Application started");

            string message = Library.FilesExist();
            if (message.Length > 0)
            {
                MessageBox.Show("File does not exist:" + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(1);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            resourceManager = new ResourceManager("Programlancer.Timeclock", typeof(Program).Assembly);

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(Properties.Settings.Default.CultureInfo, false);

            if (args.Length == 0)
            {
                Application.Run(new FormMain());
            }
            else
            {
                #region Args
                string name = "", pass = "";

                for (int i = 0; i < args.Length; i++)
                {
                    switch (i)
                    {
                        case 1://User Name
                            name = args[1];
                            break;

                        case 2://Password
                            pass = args[2];
                            break;

                        default:
                            break;
                    }
                }
                #endregion

                #region User
                User user = null;

                if (!String.IsNullOrWhiteSpace(name))
                {

                    if (name.Equals("admin") && String.IsNullOrWhiteSpace(pass))
                    {
                        // Try get a password again
                        using (FormPassword formPassword = new FormPassword())
                        {
                            DialogResult dr = formPassword.ShowDialog();

                            if (dr == DialogResult.OK) pass = formPassword.Pass;
                        }
                    }

                    user = User.Create(name, pass, true);
                }
                #endregion

                #region Action

                switch (args[0].ToUpper())
                {
                    case "ENTER":
                        Application.Run(new FormEnterExit { Direction = "ENTER" });
                        break;

                    case "EXIT":
                        Application.Run(new FormEnterExit { Direction = "EXIT" });
                        break;

                    case "REPORT":
                        if (user == null)
                            using (FormLogin formLogin = new FormLogin())
                            {
                                DialogResult dr = formLogin.ShowDialog();

                                if (dr == DialogResult.OK) user = formLogin.User;
                            }

                        if (user != null) Application.Run(new FormReport(user));
                        break;

                    case "BACKUP":
                        message = Library.BackUp();
                        MessageBox.Show(message, Program.resourceManager.GetString("strBackUp"));
                        break;

                    case "RESTORE":
                        if (user == null)
                            using (FormLogin formLogin = new FormLogin())
                            {
                                DialogResult dr = formLogin.ShowDialog();

                                if (dr == DialogResult.OK) user = formLogin.User;
                            }

                        if (user != null)
                            if (user.IsAdmin)
                            {
                                message = Library.Restore();
                                MessageBox.Show(message, Program.resourceManager.GetString("strRestore"));
                            }
                            else
                                MessageBox.Show(
                                    Program.resourceManager.GetString("strOnlyAdminCanViewForm") + " !"
                                    , Program.resourceManager.GetString("strError")
                                    , MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        break;

                    case "ADMIN":
                        if (user == null)
                            using (FormLogin formLogin = new FormLogin())
                            {
                                DialogResult dr = formLogin.ShowDialog();

                                if (dr == DialogResult.OK) user = formLogin.User;
                            }

                        if (user != null)
                            if (user.IsAdmin)
                            {
                                Application.Run(new FormAdministrator(user));
                            }
                            else
                                MessageBox.Show(
                                    Program.resourceManager.GetString("strOnlyAdminCanViewForm") + " !"
                                    , Program.resourceManager.GetString("strError")
                                    , MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
                        break;

                    case "?":
                        string msg = "timeclock [Action[ User[ Password]]]" +
                            "\nActions:" +
                            "\n\t?\tthis help" +
                            "\n\tENTER\tרישום כניסה למערכת" +
                            "\n\tEXIT\tרישום יציאה ממערכת" +
                            "\n\tREPORT" +
                            "\n\tBACKUP" +
                            "\n\tRESTORE\tin development" +
                            "\n\tADMIN" +
                            "\n\tPlease do not send an administrator password in command line!";

                        Console.Write(msg);
                        MessageBox.Show(msg, "Using TimeClock");
                        break;

                    case "TEST":
                        Application.Run(new Test());
                        break;

                    default:
                        Application.Run(new FormMain());
                        break;
                }
                #endregion
            }

            Library.WriteTextMessage("Application exited");
        }
    }
}