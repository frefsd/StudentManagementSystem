using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Windows.Forms;

namespace StudentManagementSystem.Forms
{
    public partial class EditStudentForm : Form
    {
        public EditStudentForm()
        {
            InitializeComponent();

            //设置性别选项
            cmbGender.Items.AddRange(new string[] { "男", "女" });
        }

        public Student Student { get; set; } = null!;
        private void EditStudentForm_Load(object sender, EventArgs e)
        {
            // === 全局样式设置 ===
            this.Font = new Font("微软雅黑", 9F);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.BackColor = Color.FromArgb(248, 249, 250);

            // === 设置标题（已存在）===
            if (Student != null)
            {
                txtStudentId.Text = Student.StudentId;
                txtName.Text = Student.Name;
                cmbGender.Text = Student.Gender;
                numAge.Value = Student.Age;
                txtClass.Text = Student.Class;
                txtDepartment.Text = Student.Department;
                txtMajor.Text = Student.Major;

                this.Text = $"编辑学生信息 - {Student.Name} ({Student.StudentId})";
            }
            else
            {
                this.Text = "编辑学生信息 - 数据错误";
                MessageBox.Show("未传入学生数据，无法编辑。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            // === 填充表单数据 ===
            txtStudentId.Text = Student.StudentId;
            txtName.Text = Student.Name ?? "";
            cmbGender.Text = Student.Gender;
            numAge.Value = Student.Age;
            txtClass.Text = Student.Class ?? "";
            txtDepartment.Text = Student.Department ?? "";
            txtMajor.Text = Student.Major ?? "";

            // === 设置水印（仅当文本为空时显示）===
            SetPlaceholder(txtName, "请输入学生姓名");
            SetPlaceholder(txtClass, "请输入班级名称");
            SetPlaceholder(txtDepartment, "请输入所属院系");
            SetPlaceholder(txtMajor, "请输入专业名称");

            // 将学号设为只读
            txtStudentId.ReadOnly = true;
            txtStudentId.BackColor = Color.Gainsboro;

            // === 按钮美化 ===
            btnSave.Text = "保 存";
            btnShut.Text = "取 消";

            btnSave.BackColor = Color.FromArgb(0, 102, 204);
            btnSave.ForeColor = Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Size = new Size(90, 30);
            btnSave.Font = new Font("微软雅黑", 9F, FontStyle.Bold);

            btnShut.BackColor = Color.Silver;
            btnShut.ForeColor = Color.Black;
            btnShut.FlatStyle = FlatStyle.Flat;
            btnShut.Size = new Size(90, 30);

            // 居中按钮
            int buttonTop = txtMajor.Bottom + 25;
            int buttonStartX = (this.ClientSize.Width - (btnSave.Width + 10 + btnShut.Width)) / 2;

            btnSave.Location = new Point(buttonStartX, buttonTop);
            btnShut.Location = new Point(buttonStartX + btnSave.Width + 10, buttonTop);

            // === 高亮效果 ===
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox textBox && !textBox.ReadOnly)
                {
                    textBox.GotFocus += (s, _) => textBox.BackColor = Color.White;
                    textBox.LostFocus += (s, _) => textBox.BackColor = SystemColors.Window;
                }
            }

            // === 快捷键支持 ===
            this.AcceptButton = btnSave;  // 回车 → 保存
            this.CancelButton = btnShut;  // ESC → 取消
        }

        private Dictionary<TextBox, string> placeholders = new Dictionary<TextBox, string>();

        private void SetPlaceholder(TextBox textBox, string text)
        {
            placeholders[textBox] = text;

            //如果文本框为空时，显示placeholder
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.ForeColor = Color.Gray;
                textBox.Text = text;
            }
            else
            {
                textBox.ForeColor = Color.Black;
            }

                textBox.Enter += (s, e) =>
                {
                    if (placeholders.ContainsKey(textBox) && textBox.Text == placeholders[textBox])
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string className = txtClass.Text.Trim();
            string department = txtDepartment.Text.Trim();
            string major = txtMajor.Text.Trim();

            // 直接判断是否为空或占位符
            if (string.IsNullOrWhiteSpace(name) ||
                (placeholders.ContainsKey(txtName) && name == placeholders[txtName]))
            {
                MessageBox.Show("请输入姓名！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbGender.SelectedItem == null)
            {
                MessageBox.Show("请选择性别！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //if (numAge.Value <= 0)
            //{
            //    MessageBox.Show("请输入有效的年龄！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //// 对其他字段同样处理
            //if (string.IsNullOrWhiteSpace(className) ||
            //    (placeholders.ContainsKey(txtClass) && className == placeholders[txtClass]))
            //{
            //    MessageBox.Show("请输入班级！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(department) ||
            //    (placeholders.ContainsKey(txtDepartment) && department == placeholders[txtDepartment]))
            //{
            //    MessageBox.Show("请输入院系！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(major) ||
            //    (placeholders.ContainsKey(txtMajor) && major == placeholders[txtMajor]))
            //{
            //    MessageBox.Show("请输入专业！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            Student = new Student
            {
                StudentId = txtStudentId.Text.Trim(),
                Name = name,
                Gender = cmbGender.Text.Trim(),
                Age = (int)numAge.Value,
                Class = className,
                Department = department,
                Major = major
            };

            DialogResult = DialogResult.OK;
        }

        private void btnShut_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
