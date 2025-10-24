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
                //��ʾ��¼����
                using var loginForm = new LoginForm();
                var result = loginForm.ShowDialog(); 
                if (result == DialogResult.OK)
                {
                    //��¼�ɹ�����������
                    using var mainForm = new Form1();
                    //��ʾ������
                    mainForm.ShowDialog();
                }
                else
                {
                    //�û�ȡ����¼��رյ�¼���棬�����˳�����
                    break;
                }              
            }

            //���д��嶼�رպ󣬰�ȫ�˳�
            Application.Exit();
        }
    }
}