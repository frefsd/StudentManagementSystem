namespace StudentManagementSystem.Forms
{
    partial class AddStudentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtStudentId = new TextBox();
            txtName = new TextBox();
            cmbGender = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnSave = new Button();
            btnShut = new Button();
            numAge = new NumericUpDown();
            txtClass = new TextBox();
            txtDepartment = new TextBox();
            txtMajor = new TextBox();
            ((System.ComponentModel.ISupportInitialize)numAge).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(210, 6);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 0;
            label1.Text = "学号：";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(265, 3);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(100, 23);
            txtStudentId.TabIndex = 1;
            // 
            // txtName
            // 
            txtName.Location = new Point(265, 53);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 2;
            // 
            // cmbGender
            // 
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(265, 113);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(121, 25);
            cmbGender.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(210, 59);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 4;
            label2.Text = "姓名：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(210, 116);
            label3.Name = "label3";
            label3.Size = new Size(44, 17);
            label3.TabIndex = 5;
            label3.Text = "性别：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(210, 162);
            label4.Name = "label4";
            label4.Size = new Size(44, 17);
            label4.TabIndex = 6;
            label4.Text = "年龄：";
            
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(210, 217);
            label5.Name = "label5";
            label5.Size = new Size(44, 17);
            label5.TabIndex = 7;
            label5.Text = "班级：";
           
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(210, 263);
            label6.Name = "label6";
            label6.Size = new Size(44, 17);
            label6.TabIndex = 8;
            label6.Text = "院系：";
           
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(210, 309);
            label7.Name = "label7";
            label7.Size = new Size(44, 17);
            label7.TabIndex = 9;
            label7.Text = "专业：";
            label7.Click += label7_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(210, 359);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnShut
            // 
            btnShut.Location = new Point(359, 359);
            btnShut.Name = "btnShut";
            btnShut.Size = new Size(75, 23);
            btnShut.TabIndex = 11;
            btnShut.Text = "取消";
            btnShut.UseVisualStyleBackColor = true;
            btnShut.Click += btnShut_Click;
            // 
            // numAge
            // 
            numAge.Location = new Point(266, 156);
            numAge.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numAge.Name = "numAge";
            numAge.Size = new Size(120, 23);
            numAge.TabIndex = 12;
            numAge.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // txtClass
            // 
            txtClass.Location = new Point(266, 211);
            txtClass.Name = "txtClass";
            txtClass.Size = new Size(100, 23);
            txtClass.TabIndex = 13;
            // 
            // txtDepartment
            // 
            txtDepartment.Location = new Point(266, 257);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(100, 23);
            txtDepartment.TabIndex = 14;
            // 
            // txtMajor
            // 
            txtMajor.Location = new Point(266, 303);
            txtMajor.Name = "txtMajor";
            txtMajor.Size = new Size(100, 23);
            txtMajor.TabIndex = 15;
            // 
            // AddStudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtMajor);
            Controls.Add(txtDepartment);
            Controls.Add(txtClass);
            Controls.Add(numAge);
            Controls.Add(btnShut);
            Controls.Add(btnSave);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cmbGender);
            Controls.Add(txtName);
            Controls.Add(txtStudentId);
            Controls.Add(label1);
            Name = "AddStudentForm";
            Text = "AddStudentForm";
            Load += AddStudentForm_Load;
            ((System.ComponentModel.ISupportInitialize)numAge).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtStudentId;
        private TextBox txtName;
        private ComboBox cmbGender;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnSave;
        private Button btnShut;
        private NumericUpDown numAge;
        private TextBox txtClass;
        private TextBox txtDepartment;
        private TextBox txtMajor;
    }
}