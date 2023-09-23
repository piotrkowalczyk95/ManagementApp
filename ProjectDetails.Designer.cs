
namespace ManagementApp
{
    partial class ProjectDetails
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelSupervisor = new System.Windows.Forms.Label();
            this.buttonViewComments = new System.Windows.Forms.Button();
            this.buttonAddComment = new System.Windows.Forms.Button();
            this.dataGridViewComments = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonEditEmp = new System.Windows.Forms.Button();
            this.dataEmp = new System.Windows.Forms.DataGridView();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneVisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmailVisible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.labelDesc = new System.Windows.Forms.Label();
            this.labelDue = new System.Windows.Forms.Label();
            this.labelPriority = new System.Windows.Forms.Label();
            this.labelProjectName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTasks = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.datagridTask = new System.Windows.Forms.DataGridView();
            this.SortNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskDetail = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TaskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.labelLeader = new System.Windows.Forms.Label();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.labelProjectType = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridTask)).BeginInit();
            this.SuspendLayout();
            // 
            // labelSupervisor
            // 
            this.labelSupervisor.AutoSize = true;
            this.labelSupervisor.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelSupervisor.Location = new System.Drawing.Point(331, 258);
            this.labelSupervisor.Name = "labelSupervisor";
            this.labelSupervisor.Size = new System.Drawing.Size(0, 20);
            this.labelSupervisor.TabIndex = 75;
            // 
            // buttonViewComments
            // 
            this.buttonViewComments.AutoSize = true;
            this.buttonViewComments.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonViewComments.Location = new System.Drawing.Point(576, 620);
            this.buttonViewComments.Name = "buttonViewComments";
            this.buttonViewComments.Size = new System.Drawing.Size(135, 27);
            this.buttonViewComments.TabIndex = 72;
            this.buttonViewComments.Text = "View All Comments";
            this.buttonViewComments.UseVisualStyleBackColor = true;
            this.buttonViewComments.Click += new System.EventHandler(this.buttonViewComments_Click);
            // 
            // buttonAddComment
            // 
            this.buttonAddComment.AutoSize = true;
            this.buttonAddComment.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAddComment.Location = new System.Drawing.Point(717, 620);
            this.buttonAddComment.Name = "buttonAddComment";
            this.buttonAddComment.Size = new System.Drawing.Size(123, 27);
            this.buttonAddComment.TabIndex = 71;
            this.buttonAddComment.Text = "Add Comment";
            this.buttonAddComment.UseVisualStyleBackColor = true;
            this.buttonAddComment.Click += new System.EventHandler(this.buttonAddComment_Click);
            // 
            // dataGridViewComments
            // 
            this.dataGridViewComments.AllowUserToAddRows = false;
            this.dataGridViewComments.AllowUserToDeleteRows = false;
            this.dataGridViewComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Employee,
            this.Date,
            this.dataGridViewTextBoxColumn3});
            this.dataGridViewComments.Location = new System.Drawing.Point(147, 516);
            this.dataGridViewComments.Name = "dataGridViewComments";
            this.dataGridViewComments.ReadOnly = true;
            this.dataGridViewComments.RowHeadersVisible = false;
            this.dataGridViewComments.RowTemplate.Height = 25;
            this.dataGridViewComments.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridViewComments.Size = new System.Drawing.Size(693, 98);
            this.dataGridViewComments.TabIndex = 70;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ProjectCommentID";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Employee
            // 
            this.Employee.DataPropertyName = "ProjectCommentAuthor";
            this.Employee.DividerWidth = 1;
            this.Employee.HeaderText = "Employee";
            this.Employee.Name = "Employee";
            this.Employee.ReadOnly = true;
            this.Employee.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Date
            // 
            this.Date.DataPropertyName = "ProjectCommentDate";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ProjectComment";
            this.dataGridViewTextBoxColumn3.DividerWidth = 1;
            this.dataGridViewTextBoxColumn3.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(56, 516);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 20);
            this.label8.TabIndex = 69;
            this.label8.Text = "Comments:";
            // 
            // buttonEdit
            // 
            this.buttonEdit.AutoSize = true;
            this.buttonEdit.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEdit.Location = new System.Drawing.Point(582, 5);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(131, 27);
            this.buttonEdit.TabIndex = 66;
            this.buttonEdit.Text = "Edit Project Details";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.AutoSize = true;
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDelete.Location = new System.Drawing.Point(719, 5);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(121, 27);
            this.buttonDelete.TabIndex = 65;
            this.buttonDelete.Text = "Delete Project";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonEditEmp
            // 
            this.buttonEditEmp.AutoSize = true;
            this.buttonEditEmp.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonEditEmp.Location = new System.Drawing.Point(717, 483);
            this.buttonEditEmp.Name = "buttonEditEmp";
            this.buttonEditEmp.Size = new System.Drawing.Size(123, 27);
            this.buttonEditEmp.TabIndex = 64;
            this.buttonEditEmp.Text = "Edit Employee(-s)";
            this.buttonEditEmp.UseVisualStyleBackColor = true;
            this.buttonEditEmp.Click += new System.EventHandler(this.buttonEditEmp_Click);
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
            this.dataEmp.Location = new System.Drawing.Point(147, 289);
            this.dataEmp.Name = "dataEmp";
            this.dataEmp.ReadOnly = true;
            this.dataEmp.RowHeadersVisible = false;
            this.dataEmp.RowTemplate.Height = 25;
            this.dataEmp.Size = new System.Drawing.Size(693, 188);
            this.dataEmp.TabIndex = 63;
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
            this.Phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Phone.DataPropertyName = "PhoneNumber";
            this.Phone.DividerWidth = 1;
            this.Phone.HeaderText = "Phone Number";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            this.Phone.Width = 105;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Email.DataPropertyName = "Email";
            this.Email.DividerWidth = 1;
            this.Email.HeaderText = "E-mail";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 67;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(55, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 20);
            this.label5.TabIndex = 62;
            this.label5.Text = "Employees:";
            // 
            // labelDesc
            // 
            this.labelDesc.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDesc.Location = new System.Drawing.Point(147, 163);
            this.labelDesc.Name = "labelDesc";
            this.labelDesc.Size = new System.Drawing.Size(693, 111);
            this.labelDesc.TabIndex = 61;
            this.labelDesc.Text = "Description:";
            // 
            // labelDue
            // 
            this.labelDue.AutoSize = true;
            this.labelDue.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelDue.Location = new System.Drawing.Point(147, 134);
            this.labelDue.Name = "labelDue";
            this.labelDue.Size = new System.Drawing.Size(75, 20);
            this.labelDue.TabIndex = 60;
            this.labelDue.Text = "Due date:";
            // 
            // labelPriority
            // 
            this.labelPriority.AutoSize = true;
            this.labelPriority.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPriority.Location = new System.Drawing.Point(147, 105);
            this.labelPriority.Name = "labelPriority";
            this.labelPriority.Size = new System.Drawing.Size(64, 20);
            this.labelPriority.TabIndex = 59;
            this.labelPriority.Text = "Priority:";
            // 
            // labelProjectName
            // 
            this.labelProjectName.AutoSize = true;
            this.labelProjectName.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelProjectName.Location = new System.Drawing.Point(147, 47);
            this.labelProjectName.Name = "labelProjectName";
            this.labelProjectName.Size = new System.Drawing.Size(47, 20);
            this.labelProjectName.TabIndex = 58;
            this.labelProjectName.Text = "name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(50, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 57;
            this.label4.Text = "Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(66, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 56;
            this.label2.Text = "Due date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(77, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 55;
            this.label3.Text = "Priority:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(17, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 54;
            this.label1.Text = "Name of project:";
            // 
            // buttonTasks
            // 
            this.buttonTasks.AutoSize = true;
            this.buttonTasks.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonTasks.Location = new System.Drawing.Point(382, 5);
            this.buttonTasks.Name = "buttonTasks";
            this.buttonTasks.Size = new System.Drawing.Size(194, 27);
            this.buttonTasks.TabIndex = 76;
            this.buttonTasks.Text = "Edit Tasks and Project Leader";
            this.buttonTasks.UseVisualStyleBackColor = true;
            this.buttonTasks.Click += new System.EventHandler(this.buttonTasks_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(1183, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 20);
            this.label7.TabIndex = 77;
            this.label7.Text = "List of tasks";
            // 
            // datagridTask
            // 
            this.datagridTask.AllowUserToAddRows = false;
            this.datagridTask.AllowUserToDeleteRows = false;
            this.datagridTask.AllowUserToResizeRows = false;
            this.datagridTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SortNumber,
            this.TaskName,
            this.DueDate,
            this.Priority,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn7,
            this.taskDetail,
            this.TaskID});
            this.datagridTask.Location = new System.Drawing.Point(893, 47);
            this.datagridTask.Name = "datagridTask";
            this.datagridTask.ReadOnly = true;
            this.datagridTask.RowHeadersVisible = false;
            this.datagridTask.RowTemplate.Height = 25;
            this.datagridTask.Size = new System.Drawing.Size(666, 567);
            this.datagridTask.TabIndex = 78;
            this.datagridTask.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridTask_CellContentClick);
            // 
            // SortNumber
            // 
            this.SortNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SortNumber.DataPropertyName = "ProjectSortNumber";
            this.SortNumber.DividerWidth = 1;
            this.SortNumber.HeaderText = "ID";
            this.SortNumber.Name = "SortNumber";
            this.SortNumber.ReadOnly = true;
            this.SortNumber.Width = 44;
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
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TaskStatus";
            this.dataGridViewTextBoxColumn5.DividerWidth = 1;
            this.dataGridViewTextBoxColumn5.HeaderText = "Status";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 65;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Department";
            this.dataGridViewTextBoxColumn7.HeaderText = "Department";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 95;
            // 
            // taskDetail
            // 
            this.taskDetail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.taskDetail.DefaultCellStyle = dataGridViewCellStyle1;
            this.taskDetail.DividerWidth = 1;
            this.taskDetail.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.taskDetail.HeaderText = "Details";
            this.taskDetail.Name = "taskDetail";
            this.taskDetail.ReadOnly = true;
            this.taskDetail.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.taskDetail.Text = "View";
            this.taskDetail.UseColumnTextForButtonValue = true;
            this.taskDetail.Width = 49;
            // 
            // TaskID
            // 
            this.TaskID.DataPropertyName = "TaskID";
            this.TaskID.HeaderText = "TaskID";
            this.TaskID.Name = "TaskID";
            this.TaskID.ReadOnly = true;
            this.TaskID.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(893, 623);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 20);
            this.label6.TabIndex = 79;
            this.label6.Text = "Status:";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelStatus.Location = new System.Drawing.Point(953, 623);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(54, 20);
            this.labelStatus.TabIndex = 80;
            this.labelStatus.Text = "Status:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(29, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 20);
            this.label9.TabIndex = 81;
            this.label9.Text = "Project Leader:";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 60000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // labelLeader
            // 
            this.labelLeader.AutoSize = true;
            this.labelLeader.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLeader.Location = new System.Drawing.Point(147, 76);
            this.labelLeader.Name = "labelLeader";
            this.labelLeader.Size = new System.Drawing.Size(100, 20);
            this.labelLeader.TabIndex = 82;
            this.labelLeader.Text = "No leader set";
            // 
            // buttonAccept
            // 
            this.buttonAccept.AutoSize = true;
            this.buttonAccept.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAccept.Location = new System.Drawing.Point(1364, 620);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(195, 27);
            this.buttonAccept.TabIndex = 83;
            this.buttonAccept.Text = "Change Status to \"Accepted\"";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(893, 24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 20);
            this.label10.TabIndex = 84;
            this.label10.Text = "Type of project:";
            // 
            // labelProjectType
            // 
            this.labelProjectType.AutoSize = true;
            this.labelProjectType.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelProjectType.Location = new System.Drawing.Point(1014, 24);
            this.labelProjectType.Name = "labelProjectType";
            this.labelProjectType.Size = new System.Drawing.Size(115, 20);
            this.labelProjectType.TabIndex = 85;
            this.labelProjectType.Text = "Type of project:";
            // 
            // ProjectDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1571, 654);
            this.Controls.Add(this.labelProjectType);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.labelLeader);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.datagridTask);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonTasks);
            this.Controls.Add(this.labelSupervisor);
            this.Controls.Add(this.buttonViewComments);
            this.Controls.Add(this.buttonAddComment);
            this.Controls.Add(this.dataGridViewComments);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEditEmp);
            this.Controls.Add(this.dataEmp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.labelDesc);
            this.Controls.Add(this.labelDue);
            this.Controls.Add(this.labelPriority);
            this.Controls.Add(this.labelProjectName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectDetails";
            this.Text = "Project Details";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.datagridTask)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelSupervisor;
        private System.Windows.Forms.Button buttonViewComments;
        private System.Windows.Forms.Button buttonAddComment;
        private System.Windows.Forms.DataGridView dataGridViewComments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonEditEmp;
        private System.Windows.Forms.DataGridView dataEmp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelDesc;
        private System.Windows.Forms.Label labelDue;
        private System.Windows.Forms.Label labelPriority;
        private System.Windows.Forms.Label labelProjectName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTasks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneVisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmailVisible;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView datagridTask;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Label labelLeader;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewButtonColumn taskDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskID;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label labelProjectType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}