
namespace ManagementApp
{
    partial class AssignProject
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
            this.comboBoxStatus = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonSubmitClose = new System.Windows.Forms.Button();
            this.buttonAssign = new System.Windows.Forms.Button();
            this.buttonNotAssigned = new System.Windows.Forms.Button();
            this.buttonAssigned = new System.Windows.Forms.Button();
            this.buttonAll = new System.Windows.Forms.Button();
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.dataTask = new System.Windows.Forms.DataGridView();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectDue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectProject = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.textboxSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataTask)).BeginInit();
            this.SuspendLayout();
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
            this.comboBoxStatus.TabIndex = 68;
            this.comboBoxStatus.SelectionChangeCommitted += new System.EventHandler(this.timerRefresh_Tick);
            this.comboBoxStatus.TextChanged += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(53, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 21);
            this.label3.TabIndex = 67;
            this.label3.Text = "Status:";
            // 
            // buttonSubmitClose
            // 
            this.buttonSubmitClose.AutoSize = true;
            this.buttonSubmitClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSubmitClose.Location = new System.Drawing.Point(139, 516);
            this.buttonSubmitClose.Name = "buttonSubmitClose";
            this.buttonSubmitClose.Size = new System.Drawing.Size(124, 27);
            this.buttonSubmitClose.TabIndex = 66;
            this.buttonSubmitClose.Text = "Submit and Close";
            this.buttonSubmitClose.UseVisualStyleBackColor = true;
            this.buttonSubmitClose.Click += new System.EventHandler(this.buttonSubmitClose_Click);
            // 
            // buttonAssign
            // 
            this.buttonAssign.AutoSize = true;
            this.buttonAssign.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAssign.Location = new System.Drawing.Point(10, 515);
            this.buttonAssign.Name = "buttonAssign";
            this.buttonAssign.Size = new System.Drawing.Size(121, 27);
            this.buttonAssign.TabIndex = 65;
            this.buttonAssign.Text = "Submit";
            this.buttonAssign.UseVisualStyleBackColor = true;
            this.buttonAssign.Click += new System.EventHandler(this.buttonAssign_Click);
            // 
            // buttonNotAssigned
            // 
            this.buttonNotAssigned.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonNotAssigned.Location = new System.Drawing.Point(450, 90);
            this.buttonNotAssigned.Name = "buttonNotAssigned";
            this.buttonNotAssigned.Size = new System.Drawing.Size(214, 27);
            this.buttonNotAssigned.TabIndex = 64;
            this.buttonNotAssigned.Text = "Show Not Assigned";
            this.buttonNotAssigned.UseVisualStyleBackColor = true;
            this.buttonNotAssigned.Click += new System.EventHandler(this.buttonNotAssigned_Click);
            // 
            // buttonAssigned
            // 
            this.buttonAssigned.AutoSize = true;
            this.buttonAssigned.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAssigned.Location = new System.Drawing.Point(230, 90);
            this.buttonAssigned.Name = "buttonAssigned";
            this.buttonAssigned.Size = new System.Drawing.Size(214, 27);
            this.buttonAssigned.TabIndex = 63;
            this.buttonAssigned.Text = "Show Assigned";
            this.buttonAssigned.UseVisualStyleBackColor = true;
            this.buttonAssigned.Click += new System.EventHandler(this.buttonAssigned_Click);
            // 
            // buttonAll
            // 
            this.buttonAll.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAll.Location = new System.Drawing.Point(10, 90);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(214, 27);
            this.buttonAll.TabIndex = 62;
            this.buttonAll.Text = "Show All";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.buttonAll_Click);
            // 
            // comboBoxDepartment
            // 
            this.comboBoxDepartment.FormattingEnabled = true;
            this.comboBoxDepartment.Location = new System.Drawing.Point(118, 3);
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.Size = new System.Drawing.Size(546, 23);
            this.comboBoxDepartment.TabIndex = 61;
            this.comboBoxDepartment.SelectionChangeCommitted += new System.EventHandler(this.timerRefresh_Tick);
            this.comboBoxDepartment.TextChanged += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(10, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 21);
            this.label2.TabIndex = 60;
            this.label2.Text = "Department:";
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCancel.Location = new System.Drawing.Point(543, 516);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(121, 27);
            this.buttonCancel.TabIndex = 59;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // dataTask
            // 
            this.dataTask.AllowUserToAddRows = false;
            this.dataTask.AllowUserToDeleteRows = false;
            this.dataTask.AllowUserToResizeRows = false;
            this.dataTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EmployeeID,
            this.ProjectID,
            this.ProjectName,
            this.ProjectDue,
            this.ProjectStatus,
            this.ProjectPriority,
            this.Department,
            this.SelectProject});
            this.dataTask.Location = new System.Drawing.Point(10, 123);
            this.dataTask.Name = "dataTask";
            this.dataTask.ReadOnly = true;
            this.dataTask.RowHeadersVisible = false;
            this.dataTask.RowTemplate.Height = 25;
            this.dataTask.Size = new System.Drawing.Size(653, 387);
            this.dataTask.TabIndex = 58;
            this.dataTask.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataTask_CellContentClick);
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
            // ProjectID
            // 
            this.ProjectID.DataPropertyName = "ProjectID";
            this.ProjectID.HeaderText = "ProjectID";
            this.ProjectID.Name = "ProjectID";
            this.ProjectID.ReadOnly = true;
            this.ProjectID.Visible = false;
            // 
            // ProjectName
            // 
            this.ProjectName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ProjectName.DataPropertyName = "ProjectName";
            this.ProjectName.DividerWidth = 1;
            this.ProjectName.HeaderText = "Project Name";
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.ReadOnly = true;
            // 
            // ProjectDue
            // 
            this.ProjectDue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProjectDue.DataPropertyName = "ProjectDue";
            this.ProjectDue.DividerWidth = 1;
            this.ProjectDue.HeaderText = "Due Date";
            this.ProjectDue.Name = "ProjectDue";
            this.ProjectDue.ReadOnly = true;
            this.ProjectDue.Width = 81;
            // 
            // ProjectStatus
            // 
            this.ProjectStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProjectStatus.DataPropertyName = "ProjectStatus";
            this.ProjectStatus.DividerWidth = 1;
            this.ProjectStatus.HeaderText = "Status";
            this.ProjectStatus.Name = "ProjectStatus";
            this.ProjectStatus.ReadOnly = true;
            this.ProjectStatus.Width = 65;
            // 
            // ProjectPriority
            // 
            this.ProjectPriority.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ProjectPriority.DataPropertyName = "ProjectPriority";
            this.ProjectPriority.DividerWidth = 1;
            this.ProjectPriority.HeaderText = "Priority";
            this.ProjectPriority.Name = "ProjectPriority";
            this.ProjectPriority.ReadOnly = true;
            this.ProjectPriority.Width = 71;
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
            // SelectProject
            // 
            this.SelectProject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SelectProject.DividerWidth = 1;
            this.SelectProject.FalseValue = "false";
            this.SelectProject.HeaderText = "Select?";
            this.SelectProject.Name = "SelectProject";
            this.SelectProject.ReadOnly = true;
            this.SelectProject.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SelectProject.TrueValue = "true";
            this.SelectProject.Width = 50;
            // 
            // textboxSearch
            // 
            this.textboxSearch.Location = new System.Drawing.Point(119, 61);
            this.textboxSearch.Name = "textboxSearch";
            this.textboxSearch.Size = new System.Drawing.Size(545, 23);
            this.textboxSearch.TabIndex = 57;
            this.textboxSearch.TextChanged += new System.EventHandler(this.textboxSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(50, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 21);
            this.label1.TabIndex = 56;
            this.label1.Text = "Search:";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 60000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // AssignProject
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssignProject";
            this.Text = "Assign project(-s) to employee";
            ((System.ComponentModel.ISupportInitialize)(this.dataTask)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonSubmitClose;
        private System.Windows.Forms.Button buttonAssign;
        private System.Windows.Forms.Button buttonNotAssigned;
        private System.Windows.Forms.Button buttonAssigned;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridView dataTask;
        private System.Windows.Forms.TextBox textboxSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectTask;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectDue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectProject;
        private System.Windows.Forms.Timer timerRefresh;
    }
}