
namespace ManagementApp
{
    partial class TaskDetails
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelTaskname = new System.Windows.Forms.Label();
            this.labelPriority = new System.Windows.Forms.Label();
            this.labelDue = new System.Windows.Forms.Label();
            this.labelDesc = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataEmp = new System.Windows.Forms.DataGridView();
            this.buttonEditEmp = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.buttonEdit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dataGridViewComments = new System.Windows.Forms.DataGridView();
            this.Employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskCommentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAddComment = new System.Windows.Forms.Button();
            this.buttonViewComments = new System.Windows.Forms.Button();
            this.buttonStatus = new System.Windows.Forms.Button();
            this.buttonReturn = new System.Windows.Forms.Button();
            this.labelSupervisor = new System.Windows.Forms.Label();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneVisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailVisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComments)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(51, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 20);
            this.label1.TabIndex = 24;
            this.label1.Text = "Name of task:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(91, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 26;
            this.label3.Text = "Priority:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(80, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 32;
            this.label2.Text = "Due date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(64, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "Description:";
            // 
            // labelTaskname
            // 
            this.labelTaskname.AutoSize = true;
            this.labelTaskname.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelTaskname.Location = new System.Drawing.Point(161, 44);
            this.labelTaskname.Name = "labelTaskname";
            this.labelTaskname.Size = new System.Drawing.Size(47, 20);
            this.labelTaskname.TabIndex = 34;
            this.labelTaskname.Text = "name";
            // 
            // labelPriority
            // 
            this.labelPriority.AutoSize = true;
            this.labelPriority.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPriority.Location = new System.Drawing.Point(161, 73);
            this.labelPriority.Name = "labelPriority";
            this.labelPriority.Size = new System.Drawing.Size(64, 20);
            this.labelPriority.TabIndex = 35;
            this.labelPriority.Text = "Priority:";
            // 
            // labelDue
            // 
            this.labelDue.AutoSize = true;
            this.labelDue.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDue.Location = new System.Drawing.Point(161, 102);
            this.labelDue.Name = "labelDue";
            this.labelDue.Size = new System.Drawing.Size(75, 20);
            this.labelDue.TabIndex = 36;
            this.labelDue.Text = "Due date:";
            // 
            // labelDesc
            // 
            this.labelDesc.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDesc.Location = new System.Drawing.Point(161, 131);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(679, 121);
            this.labelDesc.TabIndex = 37;
            this.labelDesc.Text = "Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(69, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 39;
            this.label5.Text = "Employees:";
            // 
            // dataEmp
            // 
            this.dataEmp.AllowUserToAddRows = false;
            this.dataEmp.AllowUserToDeleteRows = false;
            this.dataEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEmp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Surname,
            this.PhoneVisible,
            this.EmailVisible,
            this.FirstName,
            this.Department,
            this.Phone,
            this.Email});
            this.dataEmp.Location = new System.Drawing.Point(161, 286);
            this.dataEmp.Name = "dataEmp";
            this.dataEmp.ReadOnly = true;
            this.dataEmp.RowHeadersVisible = false;
            this.dataEmp.RowTemplate.Height = 25;
            this.dataEmp.Size = new System.Drawing.Size(679, 188);
            this.dataEmp.TabIndex = 40;
            // 
            // buttonEditEmp
            // 
            this.buttonEditEmp.AutoSize = true;
            this.buttonEditEmp.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEditEmp.Location = new System.Drawing.Point(717, 480);
            this.buttonEditEmp.Name = "buttonEditEmp";
            this.buttonEditEmp.Size = new System.Drawing.Size(123, 27);
            this.buttonEditEmp.TabIndex = 41;
            this.buttonEditEmp.Text = "Edit Employee(-s)";
            this.buttonEditEmp.UseVisualStyleBackColor = true;
            this.buttonEditEmp.Click += new System.EventHandler(this.buttonAssign_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.AutoSize = true;
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDelete.Location = new System.Drawing.Point(719, 2);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(121, 27);
            this.buttonDelete.TabIndex = 43;
            this.buttonDelete.Text = "Delete Task";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDeleteTask_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 60000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // buttonEdit
            // 
            this.buttonEdit.AutoSize = true;
            this.buttonEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEdit.Location = new System.Drawing.Point(592, 2);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(121, 27);
            this.buttonEdit.TabIndex = 44;
            this.buttonEdit.Text = "Edit Task";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(101, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 45;
            this.label6.Text = "Status:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelStatus.Location = new System.Drawing.Point(161, 255);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(54, 20);
            this.labelStatus.TabIndex = 46;
            this.labelStatus.Text = "Status:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(70, 513);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 20);
            this.label8.TabIndex = 47;
            this.label8.Text = "Comments:";
            // 
            // dataGridViewComments
            // 
            this.dataGridViewComments.AllowUserToAddRows = false;
            this.dataGridViewComments.AllowUserToDeleteRows = false;
            this.dataGridViewComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Employee,
            this.TaskCommentID,
            this.Date,
            this.dataGridViewTextBoxColumn3});
            this.dataGridViewComments.Location = new System.Drawing.Point(161, 513);
            this.dataGridViewComments.Name = "dataGridViewComments";
            this.dataGridViewComments.ReadOnly = true;
            this.dataGridViewComments.RowHeadersVisible = false;
            this.dataGridViewComments.RowTemplate.Height = 25;
            this.dataGridViewComments.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewComments.Size = new System.Drawing.Size(679, 98);
            this.dataGridViewComments.TabIndex = 48;
            // 
            // Employee
            // 
            this.Employee.DataPropertyName = "TaskCommentAuthor";
            this.Employee.DividerWidth = 1;
            this.Employee.HeaderText = "Employee";
            this.Employee.Name = "Employee";
            this.Employee.ReadOnly = true;
            this.Employee.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // TaskCommentID
            // 
            this.TaskCommentID.DataPropertyName = "TaskCommentID";
            this.TaskCommentID.HeaderText = "TaskCommentID";
            this.TaskCommentID.Name = "TaskCommentID";
            this.TaskCommentID.ReadOnly = true;
            this.TaskCommentID.Visible = false;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "TaskCommentDate";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TaskComment";
            this.dataGridViewTextBoxColumn3.DividerWidth = 1;
            this.dataGridViewTextBoxColumn3.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // buttonAddComment
            // 
            this.buttonAddComment.AutoSize = true;
            this.buttonAddComment.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAddComment.Location = new System.Drawing.Point(717, 617);
            this.buttonAddComment.Name = "buttonAddComment";
            this.buttonAddComment.Size = new System.Drawing.Size(123, 27);
            this.buttonAddComment.TabIndex = 49;
            this.buttonAddComment.Text = "Add Comment";
            this.buttonAddComment.UseVisualStyleBackColor = true;
            this.buttonAddComment.Click += new System.EventHandler(this.buttonAddComment_Click);
            // 
            // buttonViewComments
            // 
            this.buttonViewComments.AutoSize = true;
            this.buttonViewComments.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonViewComments.Location = new System.Drawing.Point(576, 617);
            this.buttonViewComments.Name = "buttonViewComments";
            this.buttonViewComments.Size = new System.Drawing.Size(135, 27);
            this.buttonViewComments.TabIndex = 50;
            this.buttonViewComments.Text = "View All Comments";
            this.buttonViewComments.UseVisualStyleBackColor = true;
            this.buttonViewComments.Click += new System.EventHandler(this.buttonViewComments_Click);
            // 
            // buttonStatus
            // 
            this.buttonStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonStatus.Location = new System.Drawing.Point(649, 255);
            this.buttonStatus.Name = "buttonStatus";
            this.buttonStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonStatus.Size = new System.Drawing.Size(191, 27);
            this.buttonStatus.TabIndex = 51;
            this.buttonStatus.Text = "Change Status to \"Verifying\"";
            this.buttonStatus.UseVisualStyleBackColor = true;
            this.buttonStatus.Click += new System.EventHandler(this.buttonStatus_Click);
            // 
            // buttonReturn
            // 
            this.buttonReturn.AutoSize = true;
            this.buttonReturn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonReturn.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonReturn.Location = new System.Drawing.Point(526, 255);
            this.buttonReturn.Name = "buttonReturn";
            this.buttonReturn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonReturn.Size = new System.Drawing.Size(117, 27);
            this.buttonReturn.TabIndex = 52;
            this.buttonReturn.Text = "Return to Active";
            this.buttonReturn.UseVisualStyleBackColor = true;
            this.buttonReturn.Click += new System.EventHandler(this.buttonReturn_Click);
            // 
            // labelSupervisor
            // 
            this.labelSupervisor.AutoSize = true;
            this.labelSupervisor.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSupervisor.Location = new System.Drawing.Point(345, 255);
            this.labelSupervisor.Name = "labelSupervisor";
            this.labelSupervisor.Size = new System.Drawing.Size(0, 20);
            this.labelSupervisor.TabIndex = 53;
            // 
            // Surname
            // 
            this.Surname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Surname.DataPropertyName = "Surname";
            this.Surname.HeaderText = "Surname";
            this.Surname.Name = "Surname";
            this.Surname.ReadOnly = true;
            // 
            // PhoneVisible
            // 
            this.PhoneVisible.DataPropertyName = "PhoneVisible";
            this.PhoneVisible.HeaderText = "PhoneVisible";
            this.PhoneVisible.Name = "PhoneVisible";
            this.PhoneVisible.ReadOnly = true;
            this.PhoneVisible.Visible = false;
            // 
            // EmailVisible
            // 
            this.EmailVisible.DataPropertyName = "EmailVisible";
            this.EmailVisible.HeaderText = "EmailVisible";
            this.EmailVisible.Name = "EmailVisible";
            this.EmailVisible.ReadOnly = true;
            this.EmailVisible.Visible = false;
            // 
            // FirstName
            // 
            this.FirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // Department
            // 
            this.Department.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Department.DataPropertyName = "Department";
            this.Department.HeaderText = "Department";
            this.Department.Name = "Department";
            this.Department.ReadOnly = true;
            this.Department.Width = 95;
            // 
            // Phone
            // 
            this.Phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Phone.DataPropertyName = "PhoneNumber";
            this.Phone.HeaderText = "Phone Number";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            this.Phone.Width = 113;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "E-mail";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 66;
            // 
            // TaskDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 654);
            this.Controls.Add(this.labelSupervisor);
            this.Controls.Add(this.buttonReturn);
            this.Controls.Add(this.buttonStatus);
            this.Controls.Add(this.buttonViewComments);
            this.Controls.Add(this.buttonAddComment);
            this.Controls.Add(this.dataGridViewComments);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEditEmp);
            this.Controls.Add(this.dataEmp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.labelDue);
            this.Controls.Add(this.labelPriority);
            this.Controls.Add(this.labelTaskname);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskDetails";
            this.Text = "Task Details";
            ((System.ComponentModel.ISupportInitialize)(this.dataEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelTaskname;
        private System.Windows.Forms.Label labelPriority;
        private System.Windows.Forms.Label labelDue;
        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataEmp;
        private System.Windows.Forms.Button buttonEditEmp;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridViewComments;
        private System.Windows.Forms.Button buttonAddComment;
        private System.Windows.Forms.Button buttonViewComments;
        private System.Windows.Forms.Button buttonStatus;
        private System.Windows.Forms.Button buttonReturn;
        private System.Windows.Forms.Label labelSupervisor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskCommentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneVisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailVisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    }
}