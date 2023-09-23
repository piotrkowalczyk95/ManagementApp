
namespace ManagementApp
{
    partial class PasswordChange
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxOldPass = new System.Windows.Forms.TextBox();
            this.textBoxNewPass = new System.Windows.Forms.TextBox();
            this.textBoxNewPass2 = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(43, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(65, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "New password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Repeat new password:";
            // 
            // textBoxOldPass
            // 
            this.textBoxOldPass.Location = new System.Drawing.Point(192, 32);
            this.textBoxOldPass.Name = "textBoxOldPass";
            this.textBoxOldPass.PasswordChar = '*';
            this.textBoxOldPass.Size = new System.Drawing.Size(317, 23);
            this.textBoxOldPass.TabIndex = 3;
            this.textBoxOldPass.UseSystemPasswordChar = true;
            this.textBoxOldPass.WordWrap = false;
            // 
            // textBoxNewPass
            // 
            this.textBoxNewPass.AcceptsTab = true;
            this.textBoxNewPass.Location = new System.Drawing.Point(192, 67);
            this.textBoxNewPass.Name = "textBoxNewPass";
            this.textBoxNewPass.PasswordChar = '*';
            this.textBoxNewPass.Size = new System.Drawing.Size(317, 23);
            this.textBoxNewPass.TabIndex = 4;
            this.textBoxNewPass.UseSystemPasswordChar = true;
            // 
            // textBoxNewPass2
            // 
            this.textBoxNewPass2.AcceptsTab = true;
            this.textBoxNewPass2.Location = new System.Drawing.Point(192, 102);
            this.textBoxNewPass2.Name = "textBoxNewPass2";
            this.textBoxNewPass2.PasswordChar = '*';
            this.textBoxNewPass2.Size = new System.Drawing.Size(317, 23);
            this.textBoxNewPass2.TabIndex = 5;
            this.textBoxNewPass2.UseSystemPasswordChar = true;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.AutoSize = true;
            this.buttonSubmit.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonSubmit.Location = new System.Drawing.Point(236, 131);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(75, 31);
            this.buttonSubmit.TabIndex = 6;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(458, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Your password must contain at least 8 characters, 1 small letter, 1 big letter, 1" +
    " number.";
            // 
            // PasswordChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 172);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.textBoxNewPass2);
            this.Controls.Add(this.textBoxNewPass);
            this.Controls.Add(this.textBoxOldPass);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordChange";
            this.Text = "Change your passord";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxOldPass;
        private System.Windows.Forms.TextBox textBoxNewPass;
        private System.Windows.Forms.TextBox textBoxNewPass2;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Label label4;
    }
}