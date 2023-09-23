
namespace ManagementApp
{
    partial class AssignTask
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
            this.textboxSearch = new System.Windows.Forms.TextBox();
            this.dataTask = new System.Windows.Forms.DataGridView();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Priority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectTask = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            this.buttonAll = new System.Windows.Forms.Button();
            this.buttonAssigned = new System.Windows.Forms.Button();
            this.buttonNotAssigned = new System.Windows.Forms.Button();
            this.buttonAssign = new System.Windows.Forms.Button();
            this.buttonSubmitClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataTask)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(50, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search:";
            // 
            // textboxSearch
            // 
            this.textboxSearch.Location = new System.Drawing.Point(119, 61);
            this.textboxSearch.Name = "textboxSearch";
            this.textboxSearch.Size = new System.Drawing.Size(545, 23);
            this.textboxSearch.TabIndex = 3;
            this.textboxSearch.TextChanged += new System.EventHandler(this.textboxSearch_TextChanged);
            // 
            // dataTask
            // 
            this.dataTask.AllowUserToAddRows = false;
            this.dataTask.AllowUserToDeleteRows = false;
            this.dataTask.AllowUserToResizeRows = false;
            this.dataTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeID,
            this.TaskID,
            this.TaskName,
            this.DueDate,
            this.Status,
            this.Priority,
            this.Department,
            this.SelectTask});
            this.dataTask.Location = new System.Drawing.Point(10, 123);
            this.dataTask.Name = "dataTask";
            this.dataTask.ReadOnly = true;
            this.dataTask.RowHeadersVisible = false;
            this.dataTask.RowTemplate.Height = 25;
            this.dataTask.Size = new System.Drawing.Size(653, 387);
            this.dataTask.TabIndex = 4;
            this.dataTask.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTask_CellContentClick);
            this.dataTask.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTask_CellContentClick);
            this.dataTask.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataTask_CellFormatting);
            // 
            // EmployeeID
            // 
            this.EmployeeID.DataPropertyName = "ASSIGNED_TASK.EmployeeID";
            this.EmployeeID.DividerWidth = 1;
            this.EmployeeID.HeaderText = "EmployeeID";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.ReadOnly = true;
            this.EmployeeID.Visible = false;
            // 
            // TaskID
            // 
            this.TaskID.DataPropertyName = "TaskID";
            this.TaskID.HeaderText = "TaskID";
            this.TaskID.Name = "TaskID";
            this.TaskID.ReadOnly = true;
            this.TaskID.Visible = false;
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
            // Status
            // 
            this.Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Status.DataPropertyName = "TaskStatus";
            this.Status.DividerWidth = 1;
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Width = 65;
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
            // Department
            // 
            this.Department.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Department.DataPropertyName = "Department";
            this.Department.DividerWidth = 1;
            this.Department.HeaderText = "Department";
            this.Department.Name = "Department";
            this.Department.ReadOnly = true;
            this.Department.Width = 96;
            // 
            // SelectTask
            // 
            this.SelectTask.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SelectTask.DividerWidth = 1;
            this.SelectTask.FalseValue = "false";
            this.SelectTask.HeaderText = "Select?";
            this.SelectTask.Name = "SelectTask";
            this.SelectTask.ReadOnly = true;
            this.SelectTask.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SelectTask.TrueValue = "true";
            this.SelectTask.Width = 50;
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCancel.Location = new System.Drawing.Point(543, 516);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(121, 27);
            this.buttonCancel.TabIndex = 43;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(10, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 21);
            this.label2.TabIndex = 46;
            this.label2.Text = "Department:";
            // 
            // comboBoxDepartment
            // 
            this.comboBoxDepartment.FormattingEnabled = true;
            this.comboBoxDepartment.Location = new System.Drawing.Point(118, 3);
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.Size = new System.Drawing.Size(546, 23);
            this.comboBoxDepartment.TabIndex = 47;
            this.comboBoxDepartment.SelectionChangeCommitted += new System.EventHandler(this.timerRefresh_Tick);
            this.comboBoxDepartment.TextChanged += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // buttonAll
            // 
            this.buttonAll.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAll.Location = new System.Drawing.Point(10, 90);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(214, 27);
            this.buttonAll.TabIndex = 49;
            this.buttonAll.Text = "Show All";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.buttonAll_Click);
            // 
            // buttonAssigned
            // 
            this.buttonAssigned.AutoSize = true;
            this.buttonAssigned.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAssigned.Location = new System.Drawing.Point(230, 90);
            this.buttonAssigned.Name = "buttonAssigned";
            this.buttonAssigned.Size = new System.Drawing.Size(214, 27);
            this.buttonAssigned.TabIndex = 50;
            this.buttonAssigned.Text = "Show Assigned";
            this.buttonAssigned.UseVisualStyleBackColor = true;
            this.buttonAssigned.Click += new System.EventHandler(this.buttonAssigned_Click);
            // 
            // buttonNotAssigned
            // 
            this.buttonNotAssigned.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonNotAssigned.Location = new System.Drawing.Point(450, 90);
            this.buttonNotAssigned.Name = "buttonNotAssigned";
            this.buttonNotAssigned.Size = new System.Drawing.Size(214, 27);
            this.buttonNotAssigned.TabIndex = 51;
            this.buttonNotAssigned.Text = "Show Not Assigned";
            this.buttonNotAssigned.UseVisualStyleBackColor = true;
            this.buttonNotAssigned.Click += new System.EventHandler(this.buttonNotAssigned_Click);
            // 
            // buttonAssign
            // 
            this.buttonAssign.AutoSize = true;
            this.buttonAssign.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAssign.Location = new System.Drawing.Point(10, 515);
            this.buttonAssign.Name = "buttonAssign";
            this.buttonAssign.Size = new System.Drawing.Size(121, 27);
            this.buttonAssign.TabIndex = 52;
            this.buttonAssign.Text = "Submit";
            this.buttonAssign.UseVisualStyleBackColor = true;
            // 
            // buttonSubmitClose
            // 
            this.buttonSubmitClose.AutoSize = true;
            this.buttonSubmitClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSubmitClose.Location = new System.Drawing.Point(139, 516);
            this.buttonSubmitClose.Name = "buttonSubmitClose";
            this.buttonSubmitClose.Size = new System.Drawing.Size(124, 27);
            this.buttonSubmitClose.TabIndex = 53;
            this.buttonSubmitClose.Text = "Submit and Close";
            this.buttonSubmitClose.UseVisualStyleBackColor = true;
            this.buttonSubmitClose.Click += new System.EventHandler(this.buttonSubmitClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(53, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 21);
            this.label3.TabIndex = 54;
            this.label3.Text = "Status:";
            // 
            // comboBoxStatus
            // 
            this.comboBoxStatus.FormattingEnabled = true;
            this.comboBoxStatus.Items.AddRange(new object[] {
            "All",
            "Pending",
            "Active",
            "Verifying",
            "To be fixed",
            "Done"});
            this.comboBoxStatus.Location = new System.Drawing.Point(118, 32);
            this.comboBoxStatus.Name = "comboBoxStatus";
            this.comboBoxStatus.Size = new System.Drawing.Size(546, 23);
            this.comboBoxStatus.TabIndex = 55;
            this.comboBoxStatus.SelectionChangeCommitted += new System.EventHandler(this.timerRefresh_Tick);
            this.comboBoxStatus.TextChanged += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 60000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // AssignTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 554);
            this.ControlBox = false;
            this.Controls.Add(this.comboBoxStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSubmitClose);
            this.Controls.Add(this.buttonAssign);
            this.Controls.Add(this.buttonNotAssigned);
            this.Controls.Add(this.buttonAssigned);
            this.Controls.Add(this.buttonAll);
            this.Controls.Add(this.comboBoxDepartment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.dataTask);
            this.Controls.Add(this.textboxSearch);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssignTask";
            this.Text = "Assign task(-s) to employee";
            ((System.ComponentModel.ISupportInitialize)(this.dataTask)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textboxSearch;
        private System.Windows.Forms.DataGridView dataTask;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.Button buttonAssigned;
        private System.Windows.Forms.Button buttonNotAssigned;
        private System.Windows.Forms.Button buttonAssign;
        private System.Windows.Forms.Button buttonSubmitClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectTask;
    }
}