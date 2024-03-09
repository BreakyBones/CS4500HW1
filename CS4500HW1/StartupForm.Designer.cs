// This file primarily is for disposing resources and cleaning up resources to be able to set up the Welcome page
namespace CS4500HW1
{
    partial class StartupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupForm));
            NextBtn = new System.Windows.Forms.Button();
            purposeTitle = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // NextBtn
            // 
            NextBtn.AccessibleDescription = "Next button";
            NextBtn.AccessibleName = "NextBtn";
            NextBtn.BackColor = System.Drawing.Color.DarkGreen;
            NextBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(192, 192, 0);
            NextBtn.FlatAppearance.BorderSize = 2;
            NextBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            NextBtn.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            NextBtn.ForeColor = System.Drawing.Color.White;
            NextBtn.Location = new System.Drawing.Point(487, 369);
            NextBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            NextBtn.Name = "NextBtn";
            NextBtn.Size = new System.Drawing.Size(229, 53);
            NextBtn.TabIndex = 1;
            NextBtn.Text = "Next";
            NextBtn.UseVisualStyleBackColor = false;
            NextBtn.Click += NextBtn_Click;
            // 
            // purposeTitle
            // 
            purposeTitle.AutoSize = true;
            purposeTitle.BackColor = System.Drawing.Color.Transparent;
            purposeTitle.Font = new System.Drawing.Font("MS Gothic", 72F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            purposeTitle.ForeColor = System.Drawing.Color.Gold;
            purposeTitle.Location = new System.Drawing.Point(355, 24);
            purposeTitle.Name = "purposeTitle";
            purposeTitle.Size = new System.Drawing.Size(538, 120);
            purposeTitle.TabIndex = 7;
            purposeTitle.Text = "Welcome!";
            purposeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Font = new System.Drawing.Font("Constantia", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.Gold;
            label1.Location = new System.Drawing.Point(12, 144);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(1150, 164);
            label1.TabIndex = 8;
            label1.Text = resources.GetString("label1.Text");
            label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // StartupForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new System.Drawing.Size(1185, 624);
            Controls.Add(label1);
            Controls.Add(purposeTitle);
            Controls.Add(NextBtn);
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "StartupForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "StartupForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button NextBtn;
        private System.Windows.Forms.Label purposeTitle;
        private System.Windows.Forms.Label label1;
    }
}