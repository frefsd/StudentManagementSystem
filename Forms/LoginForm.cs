using StudentManagementSystem.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        private const string DefaultUsername = "admin";
        private const string DefaultPasswordHash = "100000sROQTORj105ExK+tr2EJNfA==$uRgPjASrOjx/6vUwKkcQxvsS4gnYLAGFnYjmQDKhDy0=";

        private int failedAttempts = 0;
        private readonly int maxFailedAttempts = 5;

        public LoginForm()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Font = new Font("微软雅黑", 9);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.Size = new Size(600, 550);
            this.Text = "登录 - 学生管理系统";

            // 启用双缓冲防止闪烁
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.ResizeRedraw,
                true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            Rectangle rect = ClientRectangle;

            // 1. 渐变背景：从左上蓝绿到右下奶黄
            using (LinearGradientBrush bgBrush = new LinearGradientBrush(
                rect, Color.FromArgb(224, 247, 250), Color.FromArgb(255, 243, 224), 45F))
            {
                g.FillRectangle(bgBrush, rect);
            }

            // 2. 左侧漂浮半透明圆圈（气泡感）
            using (Brush bubble1 = new SolidBrush(Color.FromArgb(180, 255, 255, 255)))
            using (Brush bubble2 = new SolidBrush(Color.FromArgb(150, 255, 250, 240)))
            using (Brush bubble3 = new SolidBrush(Color.FromArgb(130, 240, 248, 255)))
            {
                g.FillEllipse(bubble1, -50, -50, 150, 150);
                g.FillEllipse(bubble2, -30, 400, 120, 120);
                g.FillEllipse(bubble3, Width - 80, -30, 100, 100);
                g.FillEllipse(bubble2, Width - 100, Height - 100, 140, 140);
            }

            // 3. 底部波浪线（模拟水面）
            using (Pen wavePen = new Pen(Color.FromArgb(200, 200, 240), 3))
            {
                Point[] wavePoints = new Point[10];
                for (int i = 0; i < 10; i++)
                {
                    int x = i * (Width / 9);
                    int y = Height - 60 + (int)(Math.Sin(i * 0.5) * 15);
                    wavePoints[i] = new Point(x, y);
                }
                g.DrawLines(wavePen, wavePoints);
            }

            // 4. 中央内容遮罩层（白色面板，提高可读性）
            using (Brush panelBrush = new SolidBrush(Color.FromArgb(245, 255, 255)))
            using (Pen border = new Pen(Color.FromArgb(200, 220, 240), 1))
            {
                Rectangle panelRect = new Rectangle(50, 80, Width - 100, Height - 200);
                g.FillRectangle(panelBrush, panelRect);
                g.DrawRectangle(border, panelRect);
            }

            // 可选：绘制系统标题
            using (Font titleFont = new Font("微软雅黑", 12, FontStyle.Bold))
            using (Brush titleBrush = new SolidBrush(Color.FromArgb(0, 102, 204)))
            {
                string title = "学生管理系统";
                SizeF titleSize = g.MeasureString(title, titleFont);
                float titleX = (Width - titleSize.Width) / 2;
                g.DrawString(title, titleFont, titleBrush, titleX, 40);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // 自动填充用户名
            if (Properties.Settings.Default.RememberUser && !string.IsNullOrEmpty(Properties.Settings.Default.LastUser))
            {
                txtUsername.Text = Properties.Settings.Default.LastUser;
                chkRemember.Checked = true;
                txtPassword.Focus();
            }
            else
            {
                txtUsername.Focus();
            }

            // 确保控件在最上层显示
            BringControlsToFront();
        }

        private void BringControlsToFront()
        {
            // 将所有控件置于顶层
            foreach (Control ctrl in this.Controls)
            {
                ctrl.BringToFront();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("请输入用户名和密码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (failedAttempts >= maxFailedAttempts)
            {
                MessageBox.Show("登录失败次数过多，请稍后再试！", "安全提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (username == DefaultUsername && PasswordHasher.VerifyPassword(password, DefaultPasswordHash))
            {
                SaveLoginPreference(username);
                failedAttempts = 0;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                failedAttempts++;
                MessageBox.Show($"用户名或密码错误！剩余尝试次数：{maxFailedAttempts - failedAttempts}",
                                "登录失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtUsername.Focus();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SaveLoginPreference(string username)
        {
            Properties.Settings.Default.RememberUser = chkRemember.Checked;
            Properties.Settings.Default.LastUser = chkRemember.Checked ? username : "";
            Properties.Settings.Default.Save();
        }
    }
}