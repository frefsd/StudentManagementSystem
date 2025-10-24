namespace StudentManagementSystem.Forms
{
    partial class EditStudentForm
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
            label3 = new Label();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            btnSave = new Button();
            btnShut = new Button();
            txtStudentId = new TextBox();
            txtName = new TextBox();
            cmbGender = new ComboBox();
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
            label1.Location = new Point(212, 29);
            label1.Name = "label1";
            label1.Size = new Size(44, 17);
            label1.TabIndex = 1;
            label1.Text = "学号：";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(212, 109);
            label3.Name = "label3";
            label3.Size = new Size(44, 17);
            label3.TabIndex = 7;
            label3.Text = "性别：";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(212, 71);
            label2.Name = "label2";
            label2.Size = new Size(44, 17);
            label2.TabIndex = 6;
            label2.Text = "姓名：";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(212, 164);
            label4.Name = "label4";
            label4.Size = new Size(44, 17);
            label4.TabIndex = 8;
            label4.Text = "年龄：";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(212, 200);
            label5.Name = "label5";
            label5.Size = new Size(44, 17);
            label5.TabIndex = 9;
            label5.Text = "班级：";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(212, 239);
            label6.Name = "label6";
            label6.Size = new Size(44, 17);
            label6.TabIndex = 10;
            label6.Text = "院系：";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(212, 274);
            label7.Name = "label7";
            label7.Size = new Size(44, 17);
            label7.TabIndex = 11;
            label7.Text = "专业：";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(239, 360);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 12;
            btnSave.Text = "保存";
            btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnShut
            // 
            btnShut.Location = new Point(364, 360);
            btnShut.Name = "btnShut";
            btnShut.Size = new Size(75, 23);
            btnShut.TabIndex = 13;
            btnShut.Text = "取消";
            btnShut.UseVisualStyleBackColor = true;
            this.btnShut.Click += new System.EventHandler(this.btnShut_Click);
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(297, 26);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(100, 23);
            txtStudentId.TabIndex = 14;
            // 
            // txtName
            // 
            txtName.Location = new Point(297, 65);
            txtName.Name = "txtName";
            txtName.Size = new Size(100, 23);
            txtName.TabIndex = 15;
            // 
            // cmbGender
            // 
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(297, 106);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(121, 25);
            cmbGender.TabIndex = 16;
            // 
            // numAge
            // 
            numAge.Location = new Point(297, 162);
            numAge.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            numAge.Name = "numAge";
            numAge.Size = new Size(120, 23);
            numAge.TabIndex = 17;
            numAge.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // txtClass
            // 
            txtClass.Location = new Point(297, 197);
            txtClass.Name = "txtClass";
            txtClass.Size = new Size(100, 23);
            txtClass.TabIndex = 18;
            // 
            // txtDepartment
            // 
            txtDepartment.Location = new Point(297, 236);
            txtDepartment.Name = "txtDepartment";
            txtDepartment.Size = new Size(100, 23);
            txtDepartment.TabIndex = 19;
            // 
            // txtMajor
            // 
            txtMajor.Location = new Point(297, 271);
            txtMajor.Name = "txtMajor";
            txtMajor.Size = new Size(100, 23);
            txtMajor.TabIndex = 20;
            // 
            // EditStudentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtMajor);
            Controls.Add(txtDepartment);
            Controls.Add(txtClass);
            Controls.Add(numAge);
            Controls.Add(cmbGender);
            Controls.Add(txtName);
            Controls.Add(txtStudentId);
            Controls.Add(btnShut);
            Controls.Add(btnSave);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EditStudentForm";
            Text = "EditStudentForm";
            Load += EditStudentForm_Load;
            ((System.ComponentModel.ISupportInitialize)numAge).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label2;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Button btnSave;
        private Button btnShut;
        private TextBox txtStudentId;
        private TextBox txtName;
        private ComboBox cmbGender;
        private NumericUpDown numAge;
        private TextBox txtClass;
        private TextBox txtDepartment;
        private TextBox txtMajor;
    }
}