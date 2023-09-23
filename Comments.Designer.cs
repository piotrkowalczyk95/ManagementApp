
namespace ManagementApp
{
    partial class Comments
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
            this.dataGridViewComments = new System.Windows.Forms.DataGridView();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TaskCommentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.buttonAddComment = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComments)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewComments
            // 
            this.dataGridViewComments.AllowUserToAddRows = false;
            this.dataGridViewComments.AllowUserToDeleteRows = false;
            this.dataGridViewComments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dataGridViewComments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewComments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Author,
            this.TaskCommentID,
            this.Date,
            this.Comment});
            this.dataGridViewComments.Location = new System.Drawing.Point(3, 12);
            this.dataGridViewComments.Name = "dataGridViewComments";
            this.dataGridViewComments.RowHeadersVisible = false;
            this.dataGridViewComments.RowTemplate.Height = 25;
            this.dataGridViewComments.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewComments.Size = new System.Drawing.Size(785, 426);
            this.dataGridViewComments.TabIndex = 0;
            // 
            // Author
            // 
            this.Author.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Author.DataPropertyName = "TaskCommentAuthor";
            this.Author.HeaderText = "Author";
            this.Author.Name = "Author";
            this.Author.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Author.Width = 50;
            // 
            // TaskCommentID
            // 
            this.TaskCommentID.DataPropertyName = "TaskCommentID";
            this.TaskCommentID.HeaderText = "TaskCommentID";
            this.TaskCommentID.Name = "TaskCommentID";
            this.TaskCommentID.Visible = false;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Date.DataPropertyName = "TaskCommentDate";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Date.Width = 37;
            // 
            // Comment
            // 
            this.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Comment.DataPropertyName = "TaskComment";
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            this.Comment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // timerRefresh
            // 
            this.timerRefresh.Enabled = true;
            this.timerRefresh.Interval = 10000;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // buttonAddComment
            // 
            this.buttonAddComment.AutoSize = true;
            this.buttonAddComment.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAddComment.Location = new System.Drawing.Point(665, 444);
            this.buttonAddComment.Name = "buttonAddComment";
            this.buttonAddComment.Size = new System.Drawing.Size(123, 27);
            this.buttonAddComment.TabIndex = 50;
            this.buttonAddComment.Text = "Add Comment";
            this.buttonAddComment.UseVisualStyleBackColor = true;
            this.buttonAddComment.Click += new System.EventHandler(this.buttonAddComment_Click);
            // 
            // Comments
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 479);
            this.Controls.Add(this.buttonAddComment);
            this.Controls.Add(this.dataGridViewComments);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Comments";
            this.Text = "Comments";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewComments)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewComments;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Button buttonAddComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn TaskCommentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
    }
}