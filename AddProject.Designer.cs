
namespace ManagementApp
{
    partial class AddProject
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
            this.components = new System.ComponentModel.Container();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxProjName = new System.Windows.Forms.TextBox();
            this.dateTimeDue = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBoxScrum = new System.Windows.Forms.CheckBox();
            this.checkBoxWaterfall = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxDept = new System.Windows.Forms.ComboBox();
            this.comboBoxPriority = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(179, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(263, 21);
            this.label5.TabIndex = 23;
            this.label5.Text = "Please, specify the project details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(14, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Name of project*:";
            // 
            // textBoxProjName
            // 
            this.textBoxProjName.Location = new System.Drawing.Point(151, 38);
            this.textBoxProjName.MaxLength = 50;
            this.textBoxProjName.Name = "textBoxProjName";
            this.textBoxProjName.Size = new System.Drawing.Size(435, 23);
            this.textBoxProjName.TabIndex = 28;
            // 
            // dateTimeDue
            // 
            this.dateTimeDue.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDue.Location = new System.Drawing.Point(151, 96);
            this.dateTimeDue.MaxDate = new System.DateTime(2100, 12, 31, 0, 0, 0, 0);
            this.dateTimeDue.MinDate = new System.DateTime(2021, 2, 26, 0, 0, 0, 0);
            this.dateTimeDue.Name = "dateTimeDue";
            this.dateTimeDue.Size = new System.Drawing.Size(435, 23);
            this.dateTimeDue.TabIndex = 31;
            this.dateTimeDue.Value = new System.DateTime(2021, 2, 26, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(70, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Due date:";
            // 
            // textBoxDesc
            // 
            this.textBoxDesc.Location = new System.Drawing.Point(151, 150);
            this.textBoxDesc.MaxLength = 255;
            this.textBoxDesc.Multiline = true;
            this.textBoxDesc.Name = "textBoxDesc";
            this.textBoxDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxDesc.Size = new System.Drawing.Size(435, 121);
            this.textBoxDesc.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(54, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Description:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(199, 303);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(203, 15);
            this.label7.TabIndex = 41;
            this.label7.Text = "Boxes marked with \"*\" must be filled.";
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.AutoSize = true;
            this.buttonSubmit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSubmit.Location = new System.Drawing.Point(12, 328);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(172, 27);
            this.buttonSubmit.TabIndex = 42;
            this.buttonSubmit.Text = "Create";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCancel.Location = new System.Drawing.Point(422, 328);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(172, 27);
            this.buttonCancel.TabIndex = 43;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(50, 276);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 20);
            this.label8.TabIndex = 45;
            this.label8.Text = "Department:";
            // 
            // checkBoxScrum
            // 
            this.checkBoxScrum.AutoSize = true;
            this.checkBoxScrum.Location = new System.Drawing.Point(151, 125);
            this.checkBoxScrum.Name = "checkBoxScrum";
            this.checkBoxScrum.Size = new System.Drawing.Size(64, 19);
            this.checkBoxScrum.TabIndex = 46;
            this.checkBoxScrum.Text = "Parallel";
            this.checkBoxScrum.UseVisualStyleBackColor = true;
            this.checkBoxScrum.CheckedChanged += new System.EventHandler(this.checkBoxScrum_CheckedChanged);
            // 
            // checkBoxWaterfall
            // 
            this.checkBoxWaterfall.AutoSize = true;
            this.checkBoxWaterfall.Location = new System.Drawing.Point(273, 125);
            this.checkBoxWaterfall.Name = "checkBoxWaterfall";
            this.checkBoxWaterfall.Size = new System.Drawing.Size(73, 19);
            this.checkBoxWaterfall.TabIndex = 47;
            this.checkBoxWaterfall.Text = "Waterfall";
            this.checkBoxWaterfall.UseVisualStyleBackColor = true;
            this.checkBoxWaterfall.CheckedChanged += new System.EventHandler(this.checkBoxWaterfall_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(48, 122);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 20);
            this.label9.TabIndex = 48;
            this.label9.Text = "Project Type:";
            // 
            // comboBoxDept
            // 
            this.comboBoxDept.FormattingEnabled = true;
            this.comboBoxDept.Location = new System.Drawing.Point(151, 277);
            this.comboBoxDept.Name = "comboBoxDept";
            this.comboBoxDept.Size = new System.Drawing.Size(435, 23);
            this.comboBoxDept.TabIndex = 49;
            // 
            // comboBoxPriority
            // 
            this.comboBoxPriority.FormattingEnabled = true;
            this.comboBoxPriority.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.comboBoxPriority.Location = new System.Drawing.Point(151, 67);
            this.comboBoxPriority.Name = "comboBoxPriority";
            this.comboBoxPriority.Size = new System.Drawing.Size(435, 23);
            this.comboBoxPriority.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(81, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 51;
            this.label3.Text = "Priority:";
            // 
            // AddProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 367);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxPriority);
            this.Controls.Add(this.comboBoxDept);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.checkBoxWaterfall);
            this.Controls.Add(this.checkBoxScrum);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDesc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimeDue);
            this.Controls.Add(this.textBoxProjName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProject";
            this.Text = "Add Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProjName;
        private System.Windows.Forms.DateTimePicker dateTimeDue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBoxScrum;
        private System.Windows.Forms.CheckBox checkBoxWaterfall;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxDept;
        private System.Windows.Forms.ComboBox comboBoxPriority;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerRefresh;
    }
}