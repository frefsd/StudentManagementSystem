namespace StudentManagementSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dgvStudents = new DataGridView();
            btnAdd = new Button();
            btnDelete = new Button();
            btnSearch = new Button();
            txtSearch = new TextBox();
            cmbClass = new ComboBox();
            cmbDepartment = new ComboBox();
            lblClass = new Label();
            lblDepartment = new Label();
            btnFirst = new Button();
            btnPrev = new Button();
            btnNext = new Button();
            btnLast = new Button();
            lblPageInfo = new Label();
            cmbPageSize = new ComboBox();
            txtGoToPage = new TextBox();
            btnGoToPage = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            SuspendLayout();
            // 
            // dgvStudents
            // 
            dgvStudents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStudents.BackgroundColor = Color.White;
            dgvStudents.GridColor = Color.Pink;
            dgvStudents.Location = new Point(189, 46);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(810, 595);
            dgvStudents.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(0, 150);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 23);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "新增学生";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(106, 150);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "删除学生";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(106, 0);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "点击搜索";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(0, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(100, 23);
            txtSearch.TabIndex = 4;
            // 
            // cmbClass
            // 
            cmbClass.FormattingEnabled = true;
            cmbClass.Location = new Point(0, 46);
            cmbClass.Name = "cmbClass";
            cmbClass.Size = new Size(121, 25);
            cmbClass.TabIndex = 5;
            // 
            // cmbDepartment
            // 
            cmbDepartment.FormattingEnabled = true;
            cmbDepartment.Location = new Point(0, 94);
            cmbDepartment.Name = "cmbDepartment";
            cmbDepartment.Size = new Size(121, 25);
            cmbDepartment.TabIndex = 6;
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Location = new Point(127, 54);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(56, 17);
            lblClass.TabIndex = 7;
            lblClass.Text = "班级查询";
            // 
            // lblDepartment
            // 
            lblDepartment.AutoSize = true;
            lblDepartment.Location = new Point(127, 102);
            lblDepartment.Name = "lblDepartment";
            lblDepartment.Size = new Size(56, 17);
            lblDepartment.TabIndex = 8;
            lblDepartment.Text = "院系查询";
            // 
            // btnFirst
            // 
            btnFirst.Location = new Point(189, 647);
            btnFirst.Name = "btnFirst";
            btnFirst.Size = new Size(75, 23);
            btnFirst.TabIndex = 9;
            btnFirst.Text = "首页";
            btnFirst.UseVisualStyleBackColor = true;
            btnFirst.Click += btnFirst_Click;
            // 
            // btnPrev
            // 
            btnPrev.Location = new Point(270, 647);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(75, 23);
            btnPrev.TabIndex = 10;
            btnPrev.Text = "上一页";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Location = new Point(351, 647);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(75, 23);
            btnNext.TabIndex = 11;
            btnNext.Text = "下一页";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnLast
            // 
            btnLast.Location = new Point(432, 647);
            btnLast.Name = "btnLast";
            btnLast.Size = new Size(75, 23);
            btnLast.TabIndex = 12;
            btnLast.Text = "末页";
            btnLast.UseVisualStyleBackColor = true;
            btnLast.Click += btnLast_Click;
            // 
            // lblPageInfo
            // 
            lblPageInfo.AutoSize = true;
            lblPageInfo.Location = new Point(525, 650);
            lblPageInfo.Name = "lblPageInfo";
            lblPageInfo.Size = new Size(51, 17);
            lblPageInfo.TabIndex = 13;
            lblPageInfo.Text = "第1/1页";
            // 
            // cmbPageSize
            // 
            cmbPageSize.FormattingEnabled = true;
            cmbPageSize.Location = new Point(598, 647);
            cmbPageSize.Name = "cmbPageSize";
            cmbPageSize.Size = new Size(121, 25);
            cmbPageSize.TabIndex = 14;
            // 
            // txtGoToPage
            // 
            txtGoToPage.Location = new Point(741, 647);
            txtGoToPage.Name = "txtGoToPage";
            txtGoToPage.Size = new Size(100, 23);
            txtGoToPage.TabIndex = 15;
            // 
            // btnGoToPage
            // 
            btnGoToPage.Location = new Point(860, 647);
            btnGoToPage.Name = "btnGoToPage";
            btnGoToPage.Size = new Size(75, 23);
            btnGoToPage.TabIndex = 16;
            btnGoToPage.Text = "跳转";
            btnGoToPage.UseVisualStyleBackColor = true;
            btnGoToPage.Click += btnGoToPage_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(1004, 749);
            Controls.Add(btnGoToPage);
            Controls.Add(txtGoToPage);
            Controls.Add(cmbPageSize);
            Controls.Add(lblPageInfo);
            Controls.Add(btnLast);
            Controls.Add(btnNext);
            Controls.Add(btnPrev);
            Controls.Add(btnFirst);
            Controls.Add(lblDepartment);
            Controls.Add(lblClass);
            Controls.Add(cmbDepartment);
            Controls.Add(cmbClass);
            Controls.Add(txtSearch);
            Controls.Add(btnSearch);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(dgvStudents);
            Location = new Point(500, 50);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvStudents;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnSearch;
        private TextBox txtSearch;
        private ComboBox cmbClass;
        private ComboBox cmbDepartment;
        private Label lblClass;
        private Label lblDepartment;
        private Button btnFirst;
        private Button btnPrev;
        private Button btnNext;
        private Button btnLast;
        private Label lblPageInfo;
        private ComboBox cmbPageSize;
        private TextBox txtGoToPage;
        private Button btnGoToPage;
    }
}
