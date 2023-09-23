
namespace ManagementApp
{
    partial class AddEmployee
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
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textboxName = new System.Windows.Forms.TextBox();
            this.textboxSurname = new System.Windows.Forms.TextBox();
            this.datetimeBirth = new System.Windows.Forms.DateTimePicker();
            this.textboxPesel = new System.Windows.Forms.TextBox();
            this.textboxStreet = new System.Windows.Forms.TextBox();
            this.textboxApt = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textboxPost = new System.Windows.Forms.TextBox();
            this.textboxCity = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxPermission = new System.Windows.Forms.ComboBox();
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.checkBoxPhone = new System.Windows.Forms.CheckBox();
            this.checkBoxEmail = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.AutoSize = true;
            this.buttonSubmit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSubmit.Location = new System.Drawing.Point(28, 425);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 27);
            this.buttonSubmit.TabIndex = 24;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(74, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name*:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(54, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Surname*:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(75, 159);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Street*:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(28, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Date of birth*:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(77, 130);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "PESEL*:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(40, 334);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 20);
            this.label8.TabIndex = 8;
            this.label8.Text = "Department:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(54, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "Postcode*:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(89, 247);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 20);
            this.label10.TabIndex = 10;
            this.label10.Text = "City*:";
            // 
            // textboxName
            // 
            this.textboxName.Location = new System.Drawing.Point(141, 40);
            this.textboxName.Name = "textboxName";
            this.textboxName.Size = new System.Drawing.Size(234, 23);
            this.textboxName.TabIndex = 11;
            // 
            // textboxSurname
            // 
            this.textboxSurname.Location = new System.Drawing.Point(141, 69);
            this.textboxSurname.Name = "textboxSurname";
            this.textboxSurname.Size = new System.Drawing.Size(234, 23);
            this.textboxSurname.TabIndex = 12;
            // 
            // datetimeBirth
            // 
            this.datetimeBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimeBirth.Location = new System.Drawing.Point(141, 98);
            this.datetimeBirth.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.datetimeBirth.MinDate = new System.DateTime(1940, 1, 1, 0, 0, 0, 0);
            this.datetimeBirth.Name = "datetimeBirth";
            this.datetimeBirth.Size = new System.Drawing.Size(234, 23);
            this.datetimeBirth.TabIndex = 13;
            this.datetimeBirth.Value = new System.DateTime(2021, 8, 13, 0, 0, 0, 0);
            // 
            // textboxPesel
            // 
            this.textboxPesel.Location = new System.Drawing.Point(141, 127);
            this.textboxPesel.Name = "textboxPesel";
            this.textboxPesel.Size = new System.Drawing.Size(234, 23);
            this.textboxPesel.TabIndex = 14;
            // 
            // textboxStreet
            // 
            this.textboxStreet.Location = new System.Drawing.Point(141, 156);
            this.textboxStreet.Name = "textboxStreet";
            this.textboxStreet.Size = new System.Drawing.Size(234, 23);
            this.textboxStreet.TabIndex = 15;
            // 
            // textboxApt
            // 
            this.textboxApt.Location = new System.Drawing.Point(141, 186);
            this.textboxApt.Name = "textboxApt";
            this.textboxApt.Size = new System.Drawing.Size(234, 23);
            this.textboxApt.TabIndex = 16;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(49, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 20);
            this.label11.TabIndex = 17;
            this.label11.Text = "Apartment:";
            // 
            // textboxPost
            // 
            this.textboxPost.Location = new System.Drawing.Point(141, 215);
            this.textboxPost.Name = "textboxPost";
            this.textboxPost.Size = new System.Drawing.Size(234, 23);
            this.textboxPost.TabIndex = 18;
            // 
            // textboxCity
            // 
            this.textboxCity.Location = new System.Drawing.Point(141, 244);
            this.textboxCity.Name = "textboxCity";
            this.textboxCity.Size = new System.Drawing.Size(234, 23);
            this.textboxCity.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(75, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(306, 21);
            this.label5.TabIndex = 21;
            this.label5.Text = "Please, input employee\'s personal data";
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCancel.Location = new System.Drawing.Point(352, 425);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 27);
            this.buttonCancel.TabIndex = 25;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(132, 398);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 15);
            this.label4.TabIndex = 23;
            this.label4.Text = "Boxes marked with \"*\" must be filled.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(49, 363);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 20);
            this.label12.TabIndex = 25;
            this.label12.Text = "Permission:";
            // 
            // comboBoxPermission
            // 
            this.comboBoxPermission.FormattingEnabled = true;
            this.comboBoxPermission.Items.AddRange(new object[] {
            "Employee",
            "Manager",
            "Administration"});
            this.comboBoxPermission.Location = new System.Drawing.Point(141, 360);
            this.comboBoxPermission.Name = "comboBoxPermission";
            this.comboBoxPermission.Size = new System.Drawing.Size(234, 23);
            this.comboBoxPermission.TabIndex = 23;
            // 
            // comboBoxDepartment
            // 
            this.comboBoxDepartment.FormattingEnabled = true;
            this.comboBoxDepartment.Items.AddRange(new object[] {
            "Employee",
            "Manager",
            "Administration"});
            this.comboBoxDepartment.Location = new System.Drawing.Point(141, 331);
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.Size = new System.Drawing.Size(234, 23);
            this.comboBoxDepartment.TabIndex = 22;
            this.comboBoxDepartment.SelectedIndexChanged += new System.EventHandler(this.comboBoxDepartment_SelectedIndexChanged);
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Location = new System.Drawing.Point(141, 273);
            this.textBoxPhone.MaxLength = 9;
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(234, 23);
            this.textBoxPhone.TabIndex = 20;
            this.textBoxPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPhone_KeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(19, 276);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "Phone number:";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(141, 302);
            this.textBoxEmail.MaxLength = 30;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(234, 23);
            this.textBoxEmail.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(79, 305);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 20);
            this.label14.TabIndex = 29;
            this.label14.Text = "E-mail:";
            // 
            // checkBoxPhone
            // 
            this.checkBoxPhone.AutoSize = true;
            this.checkBoxPhone.Location = new System.Drawing.Point(381, 275);
            this.checkBoxPhone.Name = "checkBoxPhone";
            this.checkBoxPhone.Size = new System.Drawing.Size(65, 19);
            this.checkBoxPhone.TabIndex = 30;
            this.checkBoxPhone.TabStop = false;
            this.checkBoxPhone.Text = "Visible?";
            this.checkBoxPhone.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmail
            // 
            this.checkBoxEmail.AutoSize = true;
            this.checkBoxEmail.Location = new System.Drawing.Point(381, 308);
            this.checkBoxEmail.Name = "checkBoxEmail";
            this.checkBoxEmail.Size = new System.Drawing.Size(65, 19);
            this.checkBoxEmail.TabIndex = 31;
            this.checkBoxEmail.Text = "Visible?";
            this.checkBoxEmail.UseVisualStyleBackColor = true;
            // 
            // AddEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 464);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxEmail);
            this.Controls.Add(this.checkBoxPhone);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.comboBoxDepartment);
            this.Controls.Add(this.comboBoxPermission);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textboxCity);
            this.Controls.Add(this.textboxPost);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textboxApt);
            this.Controls.Add(this.textboxStreet);
            this.Controls.Add(this.textboxPesel);
            this.Controls.Add(this.datetimeBirth);
            this.Controls.Add(this.textboxSurname);
            this.Controls.Add(this.textboxName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSubmit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEmployee";
            this.Text = "Add Employee";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textboxName;
        private System.Windows.Forms.TextBox textboxSurname;
        private System.Windows.Forms.DateTimePicker datetimeBirth;
        private System.Windows.Forms.TextBox textboxPesel;
        private System.Windows.Forms.TextBox textboxStreet;
        private System.Windows.Forms.TextBox textboxApt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textboxPost;
        private System.Windows.Forms.TextBox textboxCity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxPermission;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox checkBoxPhone;
        private System.Windows.Forms.CheckBox checkBoxEmail;
    }
}