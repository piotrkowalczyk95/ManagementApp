
namespace ManagementApp
{
    partial class DepartmentEditEmp
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
            this.dataGridViewEmp = new System.Windows.Forms.DataGridView();
            this.Surname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Position = new System.Windows.Forms.DataGridViewButtonColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxView = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.buttonSubmitClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmp)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewEmp
            // 
            this.dataGridViewEmp.AllowUserToAddRows = false;
            this.dataGridViewEmp.AllowUserToDeleteRows = false;
            this.dataGridViewEmp.AllowUserToResizeRows = false;
            this.dataGridViewEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEmp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Surname,
            this.FirstName,
            this.Position,
            this.EmployeeID});
            this.dataGridViewEmp.Location = new System.Drawing.Point(1, 67);
            this.dataGridViewEmp.Name = "dataGridViewEmp";
            this.dataGridViewEmp.ReadOnly = true;
            this.dataGridViewEmp.RowHeadersVisible = false;
            this.dataGridViewEmp.RowTemplate.Height = 25;
            this.dataGridViewEmp.Size = new System.Drawing.Size(642, 369);
            this.dataGridViewEmp.TabIndex = 0;
            this.dataGridViewEmp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewEmp_CellContentClick);
            // 
            // Surname
            // 
            this.Surname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Surname.DataPropertyName = "Surname";
            this.Surname.HeaderText = "Surname";
            this.Surname.Name = "Surname";
            this.Surname.ReadOnly = true;
            // 
            // FirstName
            // 
            this.FirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // Position
            // 
            this.Position.DataPropertyName = "Permission";
            this.Position.HeaderText = "Position";
            this.Position.Name = "Position";
            this.Position.ReadOnly = true;
            this.Position.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Position.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // EmployeeID
            // 
            this.EmployeeID.DataPropertyName = "EmployeeID";
            this.EmployeeID.HeaderText = "EmployeeID";
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.ReadOnly = true;
            this.EmployeeID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(10, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Show:";
            // 
            // comboBoxView
            // 
            this.comboBoxView.FormattingEnabled = true;
            this.comboBoxView.Items.AddRange(new object[] {
            "All",
            "Not assigned",
            "Employee",
            "Manager",
            "Employed in the department"});
            this.comboBoxView.Location = new System.Drawing.Point(70, 3);
            this.comboBoxView.Name = "comboBoxView";
            this.comboBoxView.Size = new System.Drawing.Size(570, 23);
            this.comboBoxView.TabIndex = 2;
            this.comboBoxView.SelectionChangeCommitted += new System.EventHandler(this.comboBoxView_SelectedIndexChanged);
            this.comboBoxView.TextChanged += new System.EventHandler(this.comboBoxView_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(12, 442);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 3;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.AutoSize = true;
            this.buttonClose.DialogResult = System.Windows.Forms.DialogResult.No;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonClose.Location = new System.Drawing.Point(550, 442);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(82, 27);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(70, 32);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(570, 23);
            this.textBoxSearch.TabIndex = 5;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(1, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "Search:";
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 60000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // buttonSubmitClose
            // 
            this.buttonSubmitClose.AutoSize = true;
            this.buttonSubmitClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSubmitClose.Location = new System.Drawing.Point(93, 442);
            this.buttonSubmitClose.Name = "buttonSubmitClose";
            this.buttonSubmitClose.Size = new System.Drawing.Size(124, 27);
            this.buttonSubmitClose.TabIndex = 7;
            this.buttonSubmitClose.Text = "Submit and Close";
            this.buttonSubmitClose.UseVisualStyleBackColor = true;
            this.buttonSubmitClose.Click += new System.EventHandler(this.buttonSubmitClose_Click);
            // 
            // DepartmentEditEmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 475);
            this.ControlBox = false;
            this.Controls.Add(this.buttonSubmitClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewEmp);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DepartmentEditEmp";
            this.Text = "Edit Employees";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEmp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewEmp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn Surname;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewButtonColumn Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Button buttonSubmitClose;
    }
}