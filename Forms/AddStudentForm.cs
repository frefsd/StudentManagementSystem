using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementSystem.Forms
{
    public partial class AddStudentForm : Form
    {
        List<Student> students = new List<Student>();
        public AddStudentForm()
        {
            InitializeComponent();
            //设置标题
            this.Text = "新增学生";
            //设置性别选项
            cmbGender.Items.AddRange(new string[] { "男", "女" });
        }

        public Student Student { get; private set; } = null!;

        private void AddStudentForm_Load(object sender, EventArgs e)
        {
            // 设置全局字体（比 Designer 更优先）
            this.Font = new Font("微软雅黑", 9F);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // 固定边框，防止拉伸变形

            // 背景色柔和化
            this.BackColor = Color.FromArgb(248, 249, 250);

            // 给所有 TextBox 添加鼠标进入高亮效果
            foreach (var control in this.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.GotFocus += (s, _) => textBox.BackColor = Color.White;
                    textBox.LostFocus += (s, _) => textBox.BackColor = SystemColors.Window;
                }
            }

            // === 按钮美化 ===
            btnSave.Text = "保 存";
            btnShut.Text = "取 消"; // 注意：你原名是 btnShut → 应改为 btnCancel 更语义化

            // 如果你的按钮叫 btnShut，请改成 btnCancel 并更新设计器
            // 否则下面这行会报错
            btnSave.BackColor = Color.FromArgb(0, 102, 204);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Size = new Size(90, 30);
            btnSave.Font = new Font("微软雅黑", 9F, FontStyle.Bold);

            btnShut.BackColor = Color.Silver;
            btnShut.ForeColor = Color.Black;
            btnShut.FlatStyle = FlatStyle.Flat;
            btnShut.Size = new Size(90, 30);
            btnShut.Font = new Font("微软雅黑", 9F, FontStyle.Regular);

            // 居中按钮组
            int buttonTop = txtMajor.Bottom + 25;
            int buttonStartX = (this.ClientSize.Width - (btnSave.Width + 10 + btnShut.Width)) / 2;

            btnSave.Location = new Point(buttonStartX, buttonTop);
            btnShut.Location = new Point(buttonStartX + btnSave.Width + 10, buttonTop);

            // 锚定关键控件（可选：让窗口可拉伸时保持对齐）
            txtMajor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnShut.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            SetPlaceholder(txtStudentId, "请输入学号");
            SetPlaceholder(txtName, "请输入学生姓名");
            SetPlaceholder(txtClass, "请输入班级名称");
            SetPlaceholder(txtDepartment, "请输入所属院系");
            SetPlaceholder(txtMajor, "请输入专业名称");

            // 默认焦点
            txtStudentId.Focus();

            // 支持快捷键
            this.AcceptButton = btnSave;  // 回车触发保存
            this.CancelButton = btnShut;  // ESC 触发取消
        }

        private Dictionary<TextBox, string> placeholders = new Dictionary<TextBox, string>();

        private void SetPlaceholder(TextBox textBox, string text)
        {
            placeholders[textBox] = text;
            textBox.ForeColor = Color.Gray;
            textBox.Text = text;

            textBox.Enter += (s, e) =>
            {
                if (textBox.Text == placeholders[textBox])
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholders[textBox];
                    textBox.ForeColor = Color.Gray;
                }
            };
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            //获取输入的值
            string studentId = txtStudentId.Text.Trim();
            string name = txtName.Text.Trim();
            string gender = cmbGender.Text.Trim();
            int age = (int)numAge.Value;
            string className = txtClass.Text.Trim();
            string department = txtDepartment.Text.Trim();
            string major = txtMajor.Text.Trim();

            // 过滤占位符文本
            if (placeholders.ContainsKey(txtStudentId) && studentId == placeholders[txtStudentId])
                studentId = "";
            if (placeholders.ContainsKey(txtName) && name == placeholders[txtName])
                name = "";

            // 类似处理其他字段...
            if (placeholders.ContainsKey(txtClass) && className == placeholders[txtClass])
                className = "";
            if (placeholders.ContainsKey(txtDepartment) && department == placeholders[txtDepartment])
                department = "";
            if (placeholders.ContainsKey(txtMajor) && major == placeholders[txtMajor])
                major = "";

            //验证输入
            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("请输入学号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(studentId, out _))
            {
                MessageBox.Show("学号必须为数字！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("请输入姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbGender.SelectedItem == null)
            {
                MessageBox.Show("请输入性别！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(numAge.Text))
            {
                MessageBox.Show("请输入年龄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtClass.Text))
            {
                MessageBox.Show("请输入班级！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtDepartment.Text))
            {
                MessageBox.Show("请输入院系！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(txtMajor.Text))
            {
                MessageBox.Show("请输入专业！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //检查数据库中是否已存在该学号
            using var context = new SchoolContext();
            bool exists = await context.Students
                .AnyAsync(s => s.StudentId == studentId);
            //判断
            if (exists)
            {
                MessageBox.Show($"学号[{studentId}]已存在，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentId.Focus();
                txtStudentId.SelectAll();
                return;
            }

            //创建学生对象
            Student = new Student
            {
                StudentId = studentId,
                Name = name,
                Gender = gender,
                Age = age,
                Class = className,
                Department = department,
                Major = major
            };

            //设置DialogResult自动关闭窗口
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnShut_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
