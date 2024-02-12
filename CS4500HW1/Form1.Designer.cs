
namespace CS4500HW1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            Draw = new System.Windows.Forms.Button();
            Quit = new System.Windows.Forms.Button();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            TitleBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // Draw
            // 
            Draw.AccessibleDescription = "Button to Draw Cards";
            Draw.AccessibleName = "Draw";
            Draw.BackColor = System.Drawing.Color.DarkGreen;
            Draw.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(192, 192, 0);
            Draw.FlatAppearance.BorderSize = 2;
            Draw.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Draw.Font = new System.Drawing.Font("Impact", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Draw.ForeColor = System.Drawing.Color.White;
            Draw.Location = new System.Drawing.Point(324, 420);
            Draw.Name = "Draw";
            Draw.Size = new System.Drawing.Size(200, 40);
            Draw.TabIndex = 0;
            Draw.Text = "Draw Cards";
            Draw.UseVisualStyleBackColor = false;
            Draw.Click += draw_Click;
            // 
            // Quit
            // 
            Quit.BackColor = System.Drawing.Color.Red;
            Quit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(192, 192, 0);
            Quit.FlatAppearance.BorderSize = 2;
            Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            Quit.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Quit.ForeColor = System.Drawing.Color.White;
            Quit.Location = new System.Drawing.Point(578, 420);
            Quit.Name = "Quit";
            Quit.Size = new System.Drawing.Size(200, 40);
            Quit.TabIndex = 1;
            Quit.Text = "Quit";
            Quit.UseVisualStyleBackColor = false;
            Quit.Click += quit_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox1.Location = new System.Drawing.Point(60, 127);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(193, 255);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox2.Location = new System.Drawing.Point(323, 127);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(193, 255);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox3.Location = new System.Drawing.Point(576, 127);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(193, 255);
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (System.Drawing.Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox4.Location = new System.Drawing.Point(857, 127);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(193, 255);
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            // 
            // TitleBox
            // 
            TitleBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TitleBox.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            TitleBox.Location = new System.Drawing.Point(283, 27);
            TitleBox.Name = "TitleBox";
            TitleBox.Size = new System.Drawing.Size(536, 50);
            TitleBox.TabIndex = 6;
            TitleBox.Text = "CARD GAME";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new System.Drawing.Size(1093, 490);
            Controls.Add(TitleBox);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(Quit);
            Controls.Add(Draw);
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button Draw;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox TitleBox;
    }
}

