using StudentManagementSystem.Forms;

namespace StudentManagementSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {
                //显示登录窗体
                using var loginForm = new LoginForm();
                var result = loginForm.ShowDialog(); 
                if (result == DialogResult.OK)
                {
                    //登录成功，打开主窗体
                    using var mainForm = new Form1();
                    //显示主窗体
                    mainForm.ShowDialog();
                }
                else
                {
                    //用户取消登录或关闭登录界面，彻底退出程序
                    break;
                }              
            }

            //所有窗体都关闭后，安全退出
            Application.Exit();
        }
    }
}