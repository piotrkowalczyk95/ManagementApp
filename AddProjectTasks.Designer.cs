
namespace ManagementApp
{
    partial class AddProjectTasks
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
            this.dataGridViewTask = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DueDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Up = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Down = new System.Windows.Forms.DataGridViewButtonColumn();
            this.TaskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditTask = new System.Windows.Forms.DataGridViewButtonColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonTask = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labelLeader = new System.Windows.Forms.Label();
            this.buttonProjectLeader = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTask)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewTask
            // 
            this.dataGridViewTask.AllowUserToAddRows = false;
            this.dataGridViewTask.AllowUserToDeleteRows = false;
            this.dataGridViewTask.AllowUserToResizeColumns = false;
            this.dataGridViewTask.AllowUserToResizeRows = false;
            this.dataGridViewTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.TaskName,
            this.DueDate,
            this.Status,
            this.Up,
            this.Down,
            this.TaskID,
            this.EditTask});
            this.dataGridViewTask.Location = new System.Drawing.Point(12, 70);
            this.dataGridViewTask.Name = "dataGridViewTask";
            this.dataGridViewTask.ReadOnly = true;
            this.dataGridViewTask.RowHeadersVisible = false;
            this.dataGridViewTask.RowTemplate.Height = 25;
            this.dataGridViewTask.Size = new System.Drawing.Size(617, 273);
            this.dataGridViewTask.TabIndex = 38;
            this.dataGridViewTask.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewTask_CellContentClick);
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ID.DataPropertyName = "ProjectSortNumber";
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ID.Width = 43;
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
            this.DueDate.DataPropertyName = "DueDate";
            this.DueDate.DividerWidth = 1;
            this.DueDate.HeaderText = "Due Date";
            this.DueDate.Name = "DueDate";
            this.DueDate.ReadOnly = true;
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
            // Up
            // 
            this.Up.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Up.DividerWidth = 1;
            this.Up.HeaderText = "Up";
            this.Up.MinimumWidth = 50;
            this.Up.Name = "Up";
            this.Up.ReadOnly = true;
            this.Up.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Up.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Up.Text = "Up";
            this.Up.UseColumnTextForButtonValue = true;
            this.Up.Width = 50;
            // 
            // Down
            // 
            this.Down.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Down.DividerWidth = 1;
            this.Down.HeaderText = "Down";
            this.Down.MinimumWidth = 50;
            this.Down.Name = "Down";
            this.Down.ReadOnly = true;
            this.Down.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Down.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Down.Text = "Down";
            this.Down.UseColumnTextForButtonValue = true;
            this.Down.Width = 50;
            // 
            // TaskID
            // 
            this.TaskID.DataPropertyName = "TaskID";
            this.TaskID.HeaderText = "TaskID";
            this.TaskID.Name = "TaskID";
            this.TaskID.ReadOnly = true;
            this.TaskID.Visible = false;
            // 
            // EditTask
            // 
            this.EditTask.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.EditTask.DividerWidth = 1;
            this.EditTask.HeaderText = "Edit";
            this.EditTask.MinimumWidth = 60;
            this.EditTask.Name = "EditTask";
            this.EditTask.ReadOnly = true;
            this.EditTask.Text = "Edit";
            this.EditTask.UseColumnTextForButtonValue = true;
            this.EditTask.Width = 60;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(143, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(285, 21);
            this.label5.TabIndex = 39;
            this.label5.Text = "Add tasks and leader to your project";
            // 
            // buttonTask
            // 
            this.buttonTask.Location = new System.Drawing.Point(549, 349);
            this.buttonTask.Name = "buttonTask";
            this.buttonTask.Size = new System.Drawing.Size(80, 30);
            this.buttonTask.TabIndex = 41;
            this.buttonTask.Text = "Add Task";
            this.buttonTask.UseVisualStyleBackColor = true;
            this.buttonTask.Click += new System.EventHandler(this.buttonTask_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.AutoSize = true;
            this.buttonClose.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonClose.Location = new System.Drawing.Point(494, 385);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(135, 27);
            this.buttonClose.TabIndex = 44;
            this.buttonClose.Text = "Finish";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(12, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 20);
            this.label6.TabIndex = 45;
            this.label6.Text = "Project Leader:";
            // 
            // labelLeader
            // 
            this.labelLeader.AutoSize = true;
            this.labelLeader.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLeader.Location = new System.Drawing.Point(130, 40);
            this.labelLeader.Name = "labelLeader";
            this.labelLeader.Size = new System.Drawing.Size(100, 20);
            this.labelLeader.TabIndex = 51;
            this.labelLeader.Text = "No leader set";
            // 
            // buttonProjectLeader
            // 
            this.buttonProjectLeader.AutoSize = true;
            this.buttonProjectLeader.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonProjectLeader.Location = new System.Drawing.Point(445, 37);
            this.buttonProjectLeader.Name = "buttonProjectLeader";
            this.buttonProjectLeader.Size = new System.Drawing.Size(184, 27);
            this.buttonProjectLeader.TabIndex = 52;
            this.buttonProjectLeader.Text = "Add/Change Project Leader";
            this.buttonProjectLeader.UseVisualStyleBackColor = true;
            this.buttonProjectLeader.Click += new System.EventHandler(this.buttonProjectLeader_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 346);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(457, 44);
            this.label1.TabIndex = 53;
            this.label1.Text = "Please note, that when changing order in waterfall project, tasks\' dates will als" +
    "o be swapped for consistency in system. If you wish to change them you have to d" +
    "o so manually.";
            // 
            // AddProjectTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 423);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonProjectLeader);
            this.Controls.Add(this.labelLeader);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonTask);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGridViewTask);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddProjectTasks";
            this.Text = "Tasks and Project Leader";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewTask)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewTask;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonTask;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelLeader;
        private System.Windows.Forms.Button buttonProjectLeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DueDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewButtonColumn Up;
        private System.Windows.Forms.DataGridViewButtonColumn Down;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskID;
        private System.Windows.Forms.DataGridViewButtonColumn EditTask;
    }
}