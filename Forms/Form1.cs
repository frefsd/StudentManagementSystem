using Microsoft.EntityFrameworkCore;    //EF Core 核心功能
using StudentManagementSystem.Data;     //自定义数据上下文   
using StudentManagementSystem.Forms;   //数据模型
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

namespace StudentManagementSystem
{
    public partial class Form1 : Form
    {
        //保存所有学生数据
        List<Student> allStudent = new List<Student>();

        //分页相关
        private int currentPage = 1;
        private int pageSize = 20;
        private int totalPages = 1;

        //筛选后的数据不分页
        private List<Student> filteredStudents = new List<Student>();
        private Button btnExit; //声明一个按钮

        public Form1()
        {

            //初始化窗体组件
            InitializeComponent();

            this.Text = "学生管理系统——主界面";  //设置标题
            this.Size = new Size(1300, 750); //设置宽1300，高750
            //窗体初始位置居中
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White; //设置背景颜色

            // 添加退出按钮
            btnExit = new Button();
            btnExit.Text = "退出";
            btnExit.Width = 80;
            btnExit.Height = 32;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.ForeColor = Color.White;
            btnExit.BackColor = Color.FromArgb(220, 50, 50); // 红色
            btnExit.Font = new Font("微软雅黑", 9F, FontStyle.Bold);
            btnExit.Click += BtnExit_Click;

            //绑定回车搜索
            txtSearch.KeyDown += txtSearch_KeyDown;

            //初始化筛选下拉框
            InitializeFilterControls();

            //初始化每页下拉框大小
            cmbPageSize.Items.AddRange(new object[] { 10, 20, 50, 100 });
            cmbPageSize.SelectedIndex = 1; //默认选择20

            //绑定事件
            cmbPageSize.SelectedIndexChanged += (sender, e) =>
            {
                if (cmbPageSize.SelectedItem is int newSize)
                {
                    pageSize = newSize;
                    currentPage = 1; //重置为第一页
                    UpdatePaginationInfo();
                    ShowCurrentPage();
                }
            };

            //设置窗体加载完成后的布局和样式
            this.Load += Form1_Load1_EnhanceUI;
        }

        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object? sender, EventArgs e)
        {
            //弹出确认对话框，询问用户是否退出
            var result = MessageBox.Show("您确定要退出吗？", 
                                         "退出确认", 
                                          MessageBoxButtons.YesNo, 
                                          MessageBoxIcon.Question, 
                                          MessageBoxDefaultButton.Button2 //默认选择“否”
                                          );

            //如果用户点击“是”，则关闭窗体
            if (result == DialogResult.Yes)
            {
                //退出主窗体
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void Form1_Load1_EnhanceUI(object? sender, EventArgs e)
        {
            //1. 设置 DataGridView 美观样式
            SetupDataGridViewStyle();

            //2. 设置按钮扁平化 + 颜色
            SetupButtonStyles();

            //3. 设置字体统一
            SetFontForAllControls(this, new Font("微软雅黑", 9F));

            //4. 使用 TableLayoutPanel 优化布局
            SetupLayout();
        }

        private void SetupLayout()
        {
            // 创建主布局容器
            var mainLayout = new TableLayoutPanel();
            mainLayout.Dock = DockStyle.Fill;
            mainLayout.RowCount = 4;
            mainLayout.ColumnCount = 1;
            mainLayout.Padding = new Padding(10);
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 50)); // 搜索行
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 40)); // 筛选行
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));  // 表格主体
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));  // 分页行

            // 清除原有控件（保留 dgvStudents）
            this.Controls.Clear();

            // 1️⃣ 搜索区域
            // 1️⃣ 搜索区域（使用 TableLayoutPanel 实现右对齐）
            var searchTable = new TableLayoutPanel();
            searchTable.Dock = DockStyle.Fill;
            searchTable.Height = 50;
            searchTable.ColumnCount = 6;
            searchTable.RowCount = 1;

            txtSearch.Width = 180;
            btnSearch.Width = 80;
            btnAdd.Width = 100;
            btnDelete.Width = 100;
            btnExit.Width = 80; // 设置宽度

            // 列设置
            searchTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 180)); // txtSearch
            searchTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));  // btnSearch
            searchTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100)); // btnAdd
            searchTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100)); // btnDelete
            searchTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));  // 弹簧
            searchTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));  // btnExit

            // 添加控件
            searchTable.Controls.Add(txtSearch, 0, 0);
            searchTable.Controls.Add(btnSearch, 1, 0);
            searchTable.Controls.Add(btnAdd, 2, 0);
            searchTable.Controls.Add(btnDelete, 3, 0);
            searchTable.Controls.Add(new Panel(), 4, 0); // 占位，用于拉伸
            searchTable.Controls.Add(btnExit, 5, 0);

            txtSearch.Location = new Point(0, 10);
            btnSearch.Location = new Point(190, 10);
            btnAdd.Location = new Point(280, 10);
            btnDelete.Location = new Point(390, 10);
            btnExit.Location = new Point(490, 10); // 靠右对齐

            // 行样式
            searchTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            mainLayout.Controls.Add(searchTable, 0, 0);

            // 2️⃣ 筛选区域
            var filterPanel = new Panel();
            filterPanel.Dock = DockStyle.Fill;

            cmbClass.Width = 120;
            cmbDepartment.Width = 120;

            filterPanel.Controls.Add(new Label { Text = "班级:", Location = new Point(0, 12), AutoSize = true });
            filterPanel.Controls.Add(cmbClass);
            filterPanel.Controls.Add(new Label { Text = "院系:", Location = new Point(160, 12), AutoSize = true });
            filterPanel.Controls.Add(cmbDepartment);
            filterPanel.Controls.Add(new Label { Text = "每页:", Location = new Point(320, 12), AutoSize = true });
            filterPanel.Controls.Add(cmbPageSize);

            cmbClass.Location = new Point(40, 10);
            cmbDepartment.Location = new Point(200, 10);
            cmbPageSize.Location = new Point(360, 10);

            mainLayout.Controls.Add(filterPanel, 0, 1);

            // 3️⃣ 表格区域
            dgvStudents.Dock = DockStyle.Fill;
            mainLayout.Controls.Add(dgvStudents, 0, 2);

            // 4️⃣ 分页区域
            var paginationPanel = new Panel();
            paginationPanel.Dock = DockStyle.Fill;
            paginationPanel.Height = 60;

            // 分页按钮布局
            btnFirst.Width = 70;
            btnPrev.Width = 70;
            btnNext.Width = 70;
            btnLast.Width = 70;
            btnGoToPage.Width = 60;
            txtGoToPage.Width = 50;
            lblPageInfo.Width = 180;

            paginationPanel.Controls.Add(btnFirst);
            paginationPanel.Controls.Add(btnPrev);
            paginationPanel.Controls.Add(btnNext);
            paginationPanel.Controls.Add(btnLast);
            paginationPanel.Controls.Add(lblPageInfo);
            paginationPanel.Controls.Add(txtGoToPage);
            paginationPanel.Controls.Add(btnGoToPage);

            btnFirst.Location = new Point(0, 10);
            btnPrev.Location = new Point(80, 10);
            btnNext.Location = new Point(160, 10);
            btnLast.Location = new Point(240, 10);
            lblPageInfo.Location = new Point(330, 15);
            txtGoToPage.Location = new Point(500, 12);
            btnGoToPage.Location = new Point(560, 10);

            mainLayout.Controls.Add(paginationPanel, 0, 3);

            // 添加主布局到窗体
            this.Controls.Add(mainLayout);
        }

        private void SetFontForAllControls(Control parent, Font font)
        {
            foreach (Control ctrl in parent.Controls)
            {
                ctrl.Font = font;
                if (ctrl.Controls.Count > 0)
                {
                    SetFontForAllControls(ctrl, font);
                }
            }
        }

        private void SetupButtonStyles()
        {
            // 统一设置按钮样式
            var buttons = new[] { btnAdd, btnDelete, btnSearch, btnFirst, btnPrev, btnNext, btnLast, btnGoToPage };

            foreach (var btn in buttons)
            {
                if (btn == null) continue;

                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.Font = new Font("微软雅黑", 9F, FontStyle.Bold);
                btn.Height = 32;

                // 不同按钮不同颜色
                if (btn == btnAdd)
                    btn.BackColor = Color.FromArgb(0, 176, 80); // 绿色
                else if (btn == btnDelete)
                    btn.BackColor = Color.FromArgb(255, 192, 0); // 橙色
                else if (btn == btnSearch)
                    btn.BackColor = Color.FromArgb(100, 180, 255); // 蓝色
                else
                    btn.BackColor = Color.FromArgb(100, 149, 237); // 浅蓝
            }

            // 特殊：删除按钮为红色
            btnDelete.BackColor = Color.FromArgb(220, 50, 50);
        }

        private void SetupDataGridViewStyle()
        {
            dgvStudents.DefaultCellStyle.Font = new Font("微软雅黑", 9);
            dgvStudents.ColumnHeadersDefaultCellStyle.Font = new Font("微软雅黑", 9, FontStyle.Bold);
            dgvStudents.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 144, 255); // 道奇蓝
            dgvStudents.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.MultiSelect = false;
            dgvStudents.ReadOnly = true;
            dgvStudents.GridColor = Color.Gainsboro;
            dgvStudents.BorderStyle = BorderStyle.None;
            dgvStudents.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 255);
            dgvStudents.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // 列自动填充
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// async: 声明异步方法
        /// Task：表示异步操作
        /// await：等待异步操作完成，不阻塞UI线程
        /// </summary>
        /// <returns></returns>
        //声明异步方法
        private async Task LoadDataAsync()
        {
            try
            {
                //创建数据库上下文实例
                using var context = new SchoolContext();

                //保存到allStudent中并绑定
                allStudent = await context.Students.ToListAsync();

                //填充院系到下拉框（去重）
                var departments = allStudent
                    .Select(s => s.Department)
                    .Where(d => !string.IsNullOrEmpty(d)) //过滤null和空格
                    .Distinct()
                    .OrderBy(d => d)
                    .ToList();
                cmbDepartment.Items.Clear();
                cmbDepartment.Items.Add("全部");

                foreach (var dept in departments)
                {
                    if (!string.IsNullOrEmpty(dept))
                    {
                        cmbDepartment.Items.Add(dept);
                    }

                }
                //默认选 全部
                cmbDepartment.SelectedIndex = 0;

                //填充班级到下拉框（去重）
                var classes = allStudent
                    .Select(s => s.Class?.Trim()) //提取并空格
                    .Where(c => !string.IsNullOrEmpty(c)) //过滤null和空格
                    .Distinct()
                    .OrderBy(c => c)
                    .ToList();
                cmbClass.Items.Clear();
                cmbClass.Items.Add("全部");

                foreach (var cls in classes)
                {
                    if (!string.IsNullOrEmpty(cls.Trim()))
                    {
                        cmbClass.Items.Add(cls);
                    }
                }
                //默认选中全部
                cmbClass.SelectedIndex = 0;

                //初始化分页
                filteredStudents = allStudent.ToList(); //刚开始显示全部学生信息
                UpdatePaginationInfo();
                ShowCurrentPage(); //显示当前页的学生信息

         
                SetGridViewColumns(); //调用setGridViewColumns()方法设置列标题             

                // 设置列标题
                dgvStudents.Columns["StudentId"].HeaderText = "学号";
                dgvStudents.Columns["Name"].HeaderText = "姓名";
                dgvStudents.Columns["Gender"].HeaderText = "性别";
                dgvStudents.Columns["Age"].HeaderText = "年龄";
                dgvStudents.Columns["Class"].HeaderText = "班级";
                dgvStudents.Columns["Department"].HeaderText = "院系";
                dgvStudents.Columns["Major"].HeaderText = "专业";
            }
            catch (Exception ex)
            {
                MessageBox.Show("加载失败：" + ex.Message, "错误",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //抽取设置列标题的方法，避免重复
        private void SetGridViewColumns()
        {
           
            var columns = new Dictionary<string, string>
            {
                {"StudentId", "学号" },
                { "Name", "姓名" },
                { "Gender", "性别" },
                { "Age", "年龄" },
                { "Class", "班级" },
                { "Department", "院系" },
                { "Major", "专业" }
            };

            foreach (var column in columns)
            {
                if (dgvStudents.Columns[column.Key] != null)
                {
                    dgvStudents.Columns[column.Key].HeaderText = column.Value;
                }
            }
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //设置选择模式
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.MultiSelect = false;
            dgvStudents.DoubleClick += DgvStudents_DoubleClick;

            await LoadDataAsync();
        }

        private async void DgvStudents_DoubleClick(object? sender, EventArgs e)
        {
            try
            {
                await DgvStudents_DoubleClickAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"修改学生时出错：{ex.Message}\n{ex.StackTrace}", "错误",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 新增学生信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAdd_Click(object sender, EventArgs e)
        {
            //显示新增窗体
            using var addStudentForm = new AddStudentForm();
            //查看对话框
            var result = addStudentForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    //保存到数据库
                    using var context = new SchoolContext();
                    context.Students.Add(addStudentForm.Student);
                    await context.SaveChangesAsync();

                    //刷新主界面
                    await LoadDataAsync();
                    MessageBox.Show("添加成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败!" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
        }

        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnDelete_Click(object sender, EventArgs e)
        {
            //1.检查是否有选中的行
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择要删除的学生！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //2.获取选中行对应的学生对象
            var selectedRow = dgvStudents.SelectedRows[0];
            var student = selectedRow.DataBoundItem as Student;

            if (student == null)
            {
                MessageBox.Show("无法获取学生信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //3.弹出对话框
            var result = MessageBox.Show($"确认要删除[{student.Name}]学生信息吗？", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            try
            {
                //4.从数据库中删除
                using var context = new SchoolContext();
                context.Students.Remove(student);
                await context.SaveChangesAsync();

                //刷新表格
                await LoadDataAsync();
                MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除失败！", "错误" + ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <returns></returns>
        private async Task DgvStudents_DoubleClickAsync()
        {
            //1.检查是否有选中的行
            if (dgvStudents.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先点击选中一行！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //2.获取选中的学生对象
            var selectedRow = dgvStudents.SelectedRows[0];
            var student = selectedRow.DataBoundItem as Student;

            if (student == null)
            {
                MessageBox.Show("无法获取到学生信息！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //3.显示编辑窗体
            using var editForm = new EditStudentForm();
            editForm.Student = student;

            var result = editForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    //4.保存数据到数据库
                    using var context = new SchoolContext();
                    var studentInDb = await context.Students.FindAsync(student.Id);

                    if (studentInDb == null)
                    {
                        MessageBox.Show("该学生不存在，无法更新！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //更新所有字段
                    studentInDb.Name = editForm.Student.Name;
                    studentInDb.Gender = editForm.Student.Gender;
                    studentInDb.Age = editForm.Student.Age;
                    studentInDb.Class = editForm.Student.Class;
                    studentInDb.Department = editForm.Student.Department;
                    studentInDb.Major = editForm.Student.Major;

                    //保存更改后的信息
                    await context.SaveChangesAsync();

                    //刷新窗体
                    await LoadDataAsync();
                    MessageBox.Show("学生信息更新成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("保存失败！" + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 搜索框查询学生信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {

            //复用筛选逻辑
            FilterStudents();

            //防止输入的信息空格
            string keyword = txtSearch.Text.Trim();

            //如果搜索框为空
            if (string.IsNullOrEmpty(keyword))
            {
                //显示全部数据
                dgvStudents.DataSource = allStudent.ToList();
                return;
            }


            //模糊搜索 “姓名”或 “学号”
            var filtered = allStudent
                .Where(s => s.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                            s.StudentId.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();

            //提示用户
            if (filtered.Count == 0)
            {
                MessageBox.Show("未找到匹配的学生。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //按回车键搜索
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //触发按钮点击
                btnSearch.PerformClick();
                // 防止“叮”声
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// 初始化筛选下拉框并绑定事件
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void InitializeFilterControls()
        {
            //院系下拉框事件
            cmbDepartment.SelectedIndexChanged += FilterStudents;
            //班级下拉框事件
            cmbClass.SelectedIndexChanged += FilterStudents;
        }

        private void FilterStudents(object? sender = null, EventArgs? e = null)
        {
            //重置第一页
            currentPage = 1;

            //搜索框关键词
            string keyword = txtSearch.Text.Trim();
            string selectDept = cmbDepartment.SelectedItem?.ToString() ?? "全部";
            string selectClass = cmbClass.SelectedItem?.ToString() ?? "全部";

            //从原始数据allStudent中过滤，使用AsQueryable（）可以链式调用Where
            var filtered = allStudent.AsQueryable();

            //1.搜索框：姓名或者学号包含关键字
            if (!string.IsNullOrEmpty(keyword))
            {
                filtered = filtered.Where(s =>
                s.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                s.StudentId.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                );
            }

            //2.院系筛选
            if (selectDept != "全部")
            {
                filtered = filtered.Where(s => s.Department == selectDept);
            }

            //3.班级筛选
            if (selectClass != "全部")
            {
                filtered = filtered.Where(s => s.Class == selectClass);
            }

            //执行查询，保存到filteredStudents中
            filteredStudents = filtered.ToList();

            //更新分页信息
            UpdatePaginationInfo();

            //显示当前页数
            ShowCurrentPage();

        }

        //更新总页数信息
        private void UpdatePaginationInfo()
        {
            totalPages = (int)Math.Ceiling((double)filteredStudents.Count / pageSize);

            lblPageInfo.Text = $"第{currentPage} / {totalPages}页（共{filteredStudents.Count}）条";
            UpdatePaginationButtons();
        }

        //更新按钮状态
        private void UpdatePaginationButtons()
        {
            //首页
            btnFirst.Enabled = currentPage > 1;
            //上一页
            btnPrev.Enabled = currentPage > 1;
            //下一页
            btnNext.Enabled = currentPage < totalPages;
            //末页
            btnLast.Enabled = currentPage < totalPages;
        }

        //显示当前页的数据
        private void ShowCurrentPage()
        {
            var pageDate = filteredStudents
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            //绑定数据到DatAGridView视图当中
            dgvStudents.DataSource = pageDate;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            currentPage = 1;
            ShowCurrentPage();
            lblPageInfo.Text = $"第{currentPage} / {totalPages}页";
            UpdatePaginationButtons(); //更新按钮状态信息
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                ShowCurrentPage(); //查看当前页的数据
                lblPageInfo.Text = $"第{currentPage} / {totalPages}页";
                UpdatePaginationButtons();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                ShowCurrentPage();
                lblPageInfo.Text = $"第{currentPage} / {totalPages}页";
                UpdatePaginationButtons();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            currentPage = totalPages;
            ShowCurrentPage();
            lblPageInfo.Text = $"第{currentPage} / {totalPages}页";
            UpdatePaginationButtons();
        }

        //跳转到指定页面
        private void btnGoToPage_Click(object sender, EventArgs e)
        {
            //获取用户输入的页码
            if (int.TryParse(txtGoToPage.Text.Trim(), out int targetPage))
            {
                //检查是否在有效范围内
                if (targetPage >= 1 && targetPage <= totalPages)
                {
                    currentPage = targetPage;
                    ShowCurrentPage(); //查看当前页面内容
                    lblPageInfo.Text = $"第{currentPage} / {totalPages}页";
                    UpdatePaginationButtons();
                }
                else
                {
                    MessageBox.Show($"请输入1到{totalPages}之间的页码", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("请输入有效的数字", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            //清空输入框
            txtGoToPage.Text = "";
        }

        //回车跳转指定页面
        private void btnGoToPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGoToPage.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}
