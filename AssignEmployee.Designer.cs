
namespace ManagementApp
{
    partial class AssignEmployee
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
            this.dataEmp = new System.Windows.Forms.DataGridView();
            this.buttonAssign = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.comboBoxDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxPermission = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonAll = new System.Windows.Forms.Button();
            this.buttonAssigned = new System.Windows.Forms.Button();
            this.buttonNotAssigned = new System.Windows.Forms.Button();
            this.buttonSubmitClose = new System.Windows.Forms.Button();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectEmp = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataEmp)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(49, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search:";
            // 
            // textboxSearch
            // 
            this.textboxSearch.Location = new System.Drawing.Point(118, 61);
            this.textboxSearch.Name = "textboxSearch";
            this.textboxSearch.Size = new System.Drawing.Size(546, 23);
            this.textboxSearch.TabIndex = 3;
            this.textboxSearch.TextChanged += new System.EventHandler(this.textboxSearch_TextChanged);
            // 
            // dataEmp
            // 
            this.dataEmp.AllowUserToAddRows = false;
            this.dataEmp.AllowUserToDeleteRows = false;
            this.dataEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataEmp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Surname,
            this.FirstName,
            this.Department,
            this.Position,
            this.SelectEmp,
            this.EmployeeID});
            this.dataEmp.Location = new System.Drawing.Point(10, 123);
            this.dataEmp.Name = "dataEmp";
            this.dataEmp.RowHeadersVisible = false;
            this.dataEmp.RowTemplate.Height = 25;
            this.dataEmp.Size = new System.Drawing.Size(653, 387);
            this.dataEmp.TabIndex = 4;
            this.dataEmp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataEmp_CellContentClick);
            this.dataEmp.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataEmp_CellFormatting);
            // 
            // buttonAssign
            // 
            this.buttonAssign.AutoSize = true;
            this.buttonAssign.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAssign.Location = new System.Drawing.Point(10, 516);
            this.buttonAssign.Name = "buttonAssign";
            this.buttonAssign.Size = new System.Drawing.Size(121, 27);
            this.buttonAssign.TabIndex = 42;
            this.buttonAssign.Text = "Submit";
            this.buttonAssign.UseVisualStyleBackColor = true;
            this.buttonAssign.Click += new System.EventHandler(this.buttonAssign_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.AutoSize = true;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCancel.Location = new System.Drawing.Point(542, 516);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(121, 27);
            this.buttonCancel.TabIndex = 43;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // comboBoxDepartment
            // 
            this.comboBoxDepartment.FormattingEnabled = true;
            this.comboBoxDepartment.Location = new System.Drawing.Point(118, 3);
            this.comboBoxDepartment.Name = "comboBoxDepartment";
            this.comboBoxDepartment.Size = new System.Drawing.Size(546, 23);
            this.comboBoxDepartment.TabIndex = 44;
            this.comboBoxDepartment.SelectionChangeCommitted += new System.EventHandler(this.comboBoxDepartment_SelectionChangeCommitted);
            this.comboBoxDepartment.TextChanged += new System.EventHandler(this.comboBoxDepartment_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(10, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 21);
            this.label2.TabIndex = 45;
            this.label2.Text = "Department:";
            // 
            // comboBoxPermission
            // 
            this.comboBoxPermission.FormattingEnabled = true;
            this.comboBoxPermission.Items.AddRange(new object[] {
            "All",
            "Employee",
            "Manager",
            "Administrator"});
            this.comboBoxPermission.Location = new System.Drawing.Point(118, 32);
            this.comboBoxPermission.Name = "comboBoxPermission";
            this.comboBoxPermission.Size = new System.Drawing.Size(546, 23);
            this.comboBoxPermission.TabIndex = 46;
            this.comboBoxPermission.SelectionChangeCommitted += new System.EventHandler(this.timerRefresh_Tick);
            this.comboBoxPermission.TextChanged += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(40, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 21);
            this.label3.TabIndex = 47;
            this.label3.Text = "Position:";
            // 
            // buttonAll
            // 
            this.buttonAll.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAll.Location = new System.Drawing.Point(10, 90);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(214, 27);
            this.buttonAll.TabIndex = 48;
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
            this.buttonAssigned.TabIndex = 49;
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
            this.buttonNotAssigned.TabIndex = 50;
            this.buttonNotAssigned.Text = "Show Not Assigned";
            this.buttonNotAssigned.UseVisualStyleBackColor = true;
            this.buttonNotAssigned.Click += new System.EventHandler(this.buttonNotAssigned_Click);
            // 
            // buttonSubmitClose
            // 
            this.buttonSubmitClose.AutoSize = true;
            this.buttonSubmitClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSubmitClose.Location = new System.Drawing.Point(137, 516);
            this.buttonSubmitClose.Name = "buttonSubmitClose";
            this.buttonSubmitClose.Size = new System.Drawing.Size(124, 27);
            this.buttonSubmitClose.TabIndex = 51;
            this.buttonSubmitClose.Text = "Submit and Close";
            this.buttonSubmitClose.UseVisualStyleBackColor = true;
            this.buttonSubmitClose.Click += new System.EventHandler(this.buttonSubmitClose_Click);
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 60000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // Surname
            // 
            this.Surname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Surname.DataPropertyName = "Surname";
            this.Surname.DividerWidth = 1;
            this.Surname.HeaderText = "Surname";
            this.Surname.Name = "Surname";
            // 
            // FirstName
            // 
            this.FirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.DividerWidth = 1;
            this.FirstName.HeaderText = "Name";
            this.FirstName.Name = "FirstName";
            // 
            // Department
            // 
            this.Department.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Department.DataPropertyName = "Department";
            this.Department.DividerWidth = 1;
            this.Department.HeaderText = "Department";
            this.Department.Name = "Department";
            // 
            // Position
            // 
            this.Position.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Position.DataPropertyName = "Permission";
            this.Position.HeaderText = "Position";
            this.Position.Name = "Position";
            // 
            // SelectEmp
            // 
            this.SelectEmp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SelectEmp.DividerWidth = 1;
            this.SelectEmp.FalseValue = "false";
            this.SelectEmp.HeaderText = "Select?";
            this.SelectEmp.IndeterminateValue = "";
            this.SelectEmp.Name = "SelectEmp";
            this.SelectEmp.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.SelectEmp.TrueValue = "true";
            this.SelectEmp.Width = 50;
            // 
            // EmployeeID
            // 
            this.EmployeeID.DataPropertyName = "EmployeeID";
            this.EmployeeID.HeaderText = "EmployeeID";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.Visible = false;
            // 
            // AssignEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 548);
            this.ControlBox = false;
            this.Controls.Add(this.buttonSubmitClose);
            this.Controls.Add(this.buttonNotAssigned);
            this.Controls.Add(this.buttonAssigned);
            this.Controls.Add(this.buttonAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxPermission);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxDepartment);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAssign);
            this.Controls.Add(this.dataEmp);
            this.Controls.Add(this.textboxSearch);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AssignEmployee";
            this.Text = "Assign employee(-s) to task";
            ((System.ComponentModel.ISupportInitialize)(this.dataEmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textboxSearch;
        private System.Windows.Forms.DataGridView dataEmp;
        private System.Windows.Forms.Button buttonAssign;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.ComboBox comboBoxDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxPermission;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.Button buttonAssigned;
        private System.Windows.Forms.Button buttonNotAssigned;
        private System.Windows.Forms.Button buttonSubmitClose;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Position;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectEmp;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
    }
}