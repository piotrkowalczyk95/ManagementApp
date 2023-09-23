
namespace ManagementApp
{
    partial class EmployeeDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelSurname = new System.Windows.Forms.Label();
            this.labelDept = new System.Windows.Forms.Label();
            this.labelPesel = new System.Windows.Forms.Label();
            this.labelRes = new System.Windows.Forms.Label();
            this.labelBirth = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataTasks = new System.Windows.Forms.DataGridView();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAssign = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.dataProj = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonProjects = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.labelPos = new System.Windows.Forms.Label();
            this.buttonPassReset = new System.Windows.Forms.Button();
            this.buttonBlock = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataProj)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(85, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(65, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Surname:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(39, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Date of birth:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(86, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 20);
            this.label7.TabIndex = 8;
            this.label7.Text = "PESEL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(3, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Place of residence:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(44, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 17;
            this.label4.Text = "Department:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelName.Location = new System.Drawing.Point(152, 31);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(47, 20);
            this.labelName.TabIndex = 19;
            this.labelName.Text = "name";
            // 
            // labelSurname
            // 
            this.labelSurname.AutoSize = true;
            this.labelSurname.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSurname.Location = new System.Drawing.Point(152, 60);
            this.labelSurname.Name = "labelSurname";
            this.labelSurname.Size = new System.Drawing.Size(68, 20);
            this.labelSurname.TabIndex = 20;
            this.labelSurname.Text = "surname";
            // 
            // labelDept
            // 
            this.labelDept.AutoSize = true;
            this.labelDept.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDept.Location = new System.Drawing.Point(152, 89);
            this.labelDept.Name = "labelDept";
            this.labelDept.Size = new System.Drawing.Size(40, 20);
            this.labelDept.TabIndex = 21;
            this.labelDept.Text = "dept";
            // 
            // labelPesel
            // 
            this.labelPesel.AutoSize = true;
            this.labelPesel.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPesel.Location = new System.Drawing.Point(152, 176);
            this.labelPesel.Name = "labelPesel";
            this.labelPesel.Size = new System.Drawing.Size(44, 20);
            this.labelPesel.TabIndex = 23;
            this.labelPesel.Text = "pesel";
            // 
            // labelRes
            // 
            this.labelRes.AutoSize = true;
            this.labelRes.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelRes.Location = new System.Drawing.Point(152, 205);
            this.labelRes.Name = "labelRes";
            this.labelRes.Size = new System.Drawing.Size(29, 20);
            this.labelRes.TabIndex = 24;
            this.labelRes.Text = "res";
            // 
            // labelBirth
            // 
            this.labelBirth.AutoSize = true;
            this.labelBirth.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelBirth.Location = new System.Drawing.Point(152, 147);
            this.labelBirth.Name = "labelBirth";
            this.labelBirth.Size = new System.Drawing.Size(27, 20);
            this.labelBirth.TabIndex = 22;
            this.labelBirth.Text = "bd";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(47, 292);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 20);
            this.label5.TabIndex = 26;
            this.label5.Text = "Active tasks:";
            // 
            // dataTasks
            // 
            this.dataTasks.AllowUserToAddRows = false;
            this.dataTasks.AllowUserToDeleteRows = false;
            this.dataTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TaskName,
            this.DueDate,
            this.Priority,
            this.TaskStatus});
            this.dataTasks.Location = new System.Drawing.Point(152, 292);
            this.dataTasks.Name = "dataTasks";
            this.dataTasks.RowHeadersVisible = false;
            this.dataTasks.RowTemplate.Height = 25;
            this.dataTasks.Size = new System.Drawing.Size(508, 120);
            this.dataTasks.TabIndex = 29;
            this.dataTasks.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataTasks_CellFormatting);
            // 
            // TaskName
            // 
            this.TaskName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TaskName.DataPropertyName = "TaskName";
            this.TaskName.DividerWidth = 1;
            this.TaskName.HeaderText = "Task Name";
            this.TaskName.Name = "TaskName";
            this.TaskName.ReadOnly = true;
            // 
            // DueDate
            // 
            this.DueDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DueDate.DataPropertyName = "DueDate";
            this.DueDate.DividerWidth = 1;
            this.DueDate.HeaderText = "Due Date";
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
            this.DueDate.Width = 81;
            // 
            // Priority
            // 
            this.Priority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Priority.DataPropertyName = "Priority";
            this.Priority.DividerWidth = 1;
            this.Priority.HeaderText = "Priority";
            this.Priority.Name = "Priority";
            this.Priority.ReadOnly = true;
            this.Priority.Width = 71;
            // 
            // TaskStatus
            // 
            this.TaskStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TaskStatus.DataPropertyName = "TaskStatus";
            this.TaskStatus.DividerWidth = 1;
            this.TaskStatus.HeaderText = "TaskStatus";
            this.TaskStatus.Name = "TaskStatus";
            this.TaskStatus.Width = 87;
            // 
            // buttonAssign
            // 
            this.buttonAssign.AutoSize = true;
            this.buttonAssign.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAssign.Location = new System.Drawing.Point(561, 418);
            this.buttonAssign.Name = "buttonAssign";
            this.buttonAssign.Size = new System.Drawing.Size(90, 27);
            this.buttonAssign.TabIndex = 32;
            this.buttonAssign.Text = "Edit Task(-s)";
            this.buttonAssign.UseVisualStyleBackColor = true;
            this.buttonAssign.Click += new System.EventHandler(this.buttonAssign_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.AutoSize = true;
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDelete.Location = new System.Drawing.Point(536, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(124, 27);
            this.buttonDelete.TabIndex = 33;
            this.buttonDelete.Text = "Delete Employee";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 60000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // dataProj
            // 
            this.dataProj.AllowUserToAddRows = false;
            this.dataProj.AllowUserToDeleteRows = false;
            this.dataProj.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProj.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.ProjectPriority,
            this.ProjectStatus});
            this.dataProj.Location = new System.Drawing.Point(152, 451);
            this.dataProj.Name = "dataProj";
            this.dataProj.RowHeadersVisible = false;
            this.dataProj.RowTemplate.Height = 25;
            this.dataProj.Size = new System.Drawing.Size(508, 120);
            this.dataProj.TabIndex = 35;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ProjectName";
            this.dataGridViewTextBoxColumn1.DividerWidth = 1;
            this.dataGridViewTextBoxColumn1.HeaderText = "Project Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ProjectDue";
            this.dataGridViewTextBoxColumn2.DividerWidth = 1;
            this.dataGridViewTextBoxColumn2.HeaderText = "Due Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 81;
            // 
            // ProjectPriority
            // 
            this.ProjectPriority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProjectPriority.DataPropertyName = "ProjectPriority";
            this.ProjectPriority.DividerWidth = 1;
            this.ProjectPriority.HeaderText = "Priority";
            this.ProjectPriority.Name = "ProjectPriority";
            this.ProjectPriority.Width = 71;
            // 
            // ProjectStatus
            // 
            this.ProjectStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProjectStatus.DataPropertyName = "ProjectStatus";
            this.ProjectStatus.DividerWidth = 1;
            this.ProjectStatus.HeaderText = "ProjectStatus";
            this.ProjectStatus.Name = "ProjectStatus";
            this.ProjectStatus.Width = 102;
            // 
            // buttonProjects
            // 
            this.buttonProjects.AutoSize = true;
            this.buttonProjects.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonProjects.Location = new System.Drawing.Point(545, 577);
            this.buttonProjects.Name = "buttonProjects";
            this.buttonProjects.Size = new System.Drawing.Size(106, 27);
            this.buttonProjects.TabIndex = 37;
            this.buttonProjects.Text = "Edit Project(-s)";
            this.buttonProjects.UseVisualStyleBackColor = true;
            this.buttonProjects.Click += new System.EventHandler(this.buttonProjects_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(33, 451);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(113, 20);
            this.label8.TabIndex = 38;
            this.label8.Text = "Active Projects:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(72, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 20);
            this.label9.TabIndex = 39;
            this.label9.Text = "Position:";
            // 
            // buttonEdit
            // 
            this.buttonEdit.AutoSize = true;
            this.buttonEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEdit.Location = new System.Drawing.Point(406, 2);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(124, 27);
            this.buttonEdit.TabIndex = 40;
            this.buttonEdit.Text = "Edit Employee";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // labelPos
            // 
            this.labelPos.AutoSize = true;
            this.labelPos.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPos.Location = new System.Drawing.Point(152, 118);
            this.labelPos.Name = "labelPos";
            this.labelPos.Size = new System.Drawing.Size(60, 20);
            this.labelPos.TabIndex = 41;
            this.labelPos.Text = "positon";
            this.labelPos.UseWaitCursor = true;
            // 
            // buttonPassReset
            // 
            this.buttonPassReset.AutoSize = true;
            this.buttonPassReset.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonPassReset.Location = new System.Drawing.Point(146, 2);
            this.buttonPassReset.Name = "buttonPassReset";
            this.buttonPassReset.Size = new System.Drawing.Size(124, 27);
            this.buttonPassReset.TabIndex = 42;
            this.buttonPassReset.Text = "Reset Password";
            this.buttonPassReset.UseVisualStyleBackColor = true;
            this.buttonPassReset.Click += new System.EventHandler(this.buttonPassReset_Click);
            // 
            // buttonBlock
            // 
            this.buttonBlock.AutoSize = true;
            this.buttonBlock.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonBlock.Location = new System.Drawing.Point(276, 2);
            this.buttonBlock.Name = "buttonBlock";
            this.buttonBlock.Size = new System.Drawing.Size(124, 27);
            this.buttonBlock.TabIndex = 43;
            this.buttonBlock.Text = "Block Account";
            this.buttonBlock.UseVisualStyleBackColor = true;
            this.buttonBlock.Click += new System.EventHandler(this.buttonBlock_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(32, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 20);
            this.label10.TabIndex = 44;
            this.label10.Text = "Phone numer:";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPhone.Location = new System.Drawing.Point(152, 234);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(53, 20);
            this.labelPhone.TabIndex = 45;
            this.labelPhone.Text = "phone";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(83, 263);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 20);
            this.label12.TabIndex = 46;
            this.label12.Text = "E-mail:";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEmail.Location = new System.Drawing.Point(152, 263);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(46, 20);
            this.labelEmail.TabIndex = 47;
            this.labelEmail.Text = "email";
            // 
            // EmployeeDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 611);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.buttonBlock);
            this.Controls.Add(this.buttonPassReset);
            this.Controls.Add(this.labelPos);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonProjects);
            this.Controls.Add(this.dataProj);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAssign);
            this.Controls.Add(this.dataTasks);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelRes);
            this.Controls.Add(this.labelPesel);
            this.Controls.Add(this.labelBirth);
            this.Controls.Add(this.labelDept);
            this.Controls.Add(this.labelSurname);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmployeeDetails";
            this.Text = "Employee Details";
            ((System.ComponentModel.ISupportInitialize)(this.dataTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataProj)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelSurname;
        private System.Windows.Forms.Label labelDept;
        private System.Windows.Forms.Label labelPesel;
        private System.Windows.Forms.Label labelRes;
        private System.Windows.Forms.Label labelBirth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataTasks;
        private System.Windows.Forms.Button buttonAssign;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Button buttonProjects;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Label labelPos;
        private System.Windows.Forms.Button buttonPassReset;
        private System.Windows.Forms.Button buttonBlock;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.DataGridView dataProj;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectStatus;
    }
}