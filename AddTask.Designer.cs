
namespace ManagementApp
{
    partial class AddTask
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
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textboxTaskName = new System.Windows.Forms.TextBox();
            this.comboboxPriority = new System.Windows.Forms.ComboBox();
            this.datetimeDue = new System.Windows.Forms.DateTimePicker();
            this.textboxDesc = new System.Windows.Forms.TextBox();
            this.buttonSubit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(328, 21);
            this.label5.TabIndex = 22;
            this.label5.Text = "Please, specify the task you wish to create";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(24, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "Name of task*:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(59, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Due date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(63, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Priority*:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(43, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Description:";
            // 
            // textboxTaskName
            // 
            this.textboxTaskName.Location = new System.Drawing.Point(140, 46);
            this.textboxTaskName.Name = "textboxTaskName";
            this.textboxTaskName.Size = new System.Drawing.Size(160, 23);
            this.textboxTaskName.TabIndex = 27;
            // 
            // comboboxPriority
            // 
            this.comboboxPriority.AutoCompleteCustomSource.AddRange(new string[] {
            "Low",
            "Medium",
            "High"});
            this.comboboxPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxPriority.FormattingEnabled = true;
            this.comboboxPriority.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.comboboxPriority.Location = new System.Drawing.Point(140, 75);
            this.comboboxPriority.Name = "comboboxPriority";
            this.comboboxPriority.Size = new System.Drawing.Size(160, 23);
            this.comboboxPriority.TabIndex = 28;
            // 
            // datetimeDue
            // 
            this.datetimeDue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datetimeDue.Location = new System.Drawing.Point(140, 104);
            this.datetimeDue.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.datetimeDue.MinDate = new System.DateTime(2021, 2, 26, 0, 0, 0, 0);
            this.datetimeDue.Name = "datetimeDue";
            this.datetimeDue.Size = new System.Drawing.Size(160, 23);
            this.datetimeDue.TabIndex = 29;
            this.datetimeDue.Value = new System.DateTime(2021, 2, 26, 0, 0, 0, 0);
            // 
            // textboxDesc
            // 
            this.textboxDesc.Location = new System.Drawing.Point(140, 162);
            this.textboxDesc.MaxLength = 2000;
            this.textboxDesc.Multiline = true;
            this.textboxDesc.Name = "textboxDesc";
            this.textboxDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textboxDesc.Size = new System.Drawing.Size(160, 156);
            this.textboxDesc.TabIndex = 30;
            // 
            // buttonSubit
            // 
            this.buttonSubit.AutoSize = true;
            this.buttonSubit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSubit.Location = new System.Drawing.Point(12, 343);
            this.buttonSubit.Name = "buttonSubit";
            this.buttonSubit.Size = new System.Drawing.Size(75, 27);
            this.buttonSubit.TabIndex = 31;
            this.buttonSubit.Text = "Submit";
            this.buttonSubit.UseVisualStyleBackColor = true;
            this.buttonSubit.Click += new System.EventHandler(this.buttonSubit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCancel.Location = new System.Drawing.Point(245, 343);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 27);
            this.buttonCancel.TabIndex = 32;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(63, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(203, 15);
            this.label6.TabIndex = 33;
            this.label6.Text = "Boxes marked with \"*\" must be filled.";
            // 
            // comboBoxDepartment
            // 
            this.comboBoxDepartment.AutoCompleteCustomSource.AddRange(new string[] {
            "Low",
            "Medium",
            "High"});
            this.comboBoxDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDepartment.FormattingEnabled = true;
            this.comboBoxDepartment.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.comboBoxDepartment.Location = new System.Drawing.Point(140, 133);
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.Size = new System.Drawing.Size(160, 23);
            this.comboBoxDepartment.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(39, 136);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 20);
            this.label7.TabIndex = 35;
            this.label7.Text = "Department:";
            // 
            // AddTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 382);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxDepartment);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubit);
            this.Controls.Add(this.textboxDesc);
            this.Controls.Add(this.datetimeDue);
            this.Controls.Add(this.comboboxPriority);
            this.Controls.Add(this.textboxTaskName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTask";
            this.Text = "Add Task";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textboxTaskName;
        private System.Windows.Forms.ComboBox comboboxPriority;
        private System.Windows.Forms.DateTimePicker datetimeDue;
        private System.Windows.Forms.TextBox textboxDesc;
        private System.Windows.Forms.Button buttonSubit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
        private System.Windows.Forms.Label label7;
    }
}