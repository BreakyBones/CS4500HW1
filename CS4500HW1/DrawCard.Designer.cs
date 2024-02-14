
using System.Drawing;
using System.Windows.Forms;

namespace CS4500HW1
{
    partial class DrawCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawCard));
            Draw = new Button();
            Quit = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            label1 = new Label();
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
            Draw.BackColor = Color.DarkGreen;
            Draw.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 0);
            Draw.FlatAppearance.BorderSize = 2;
            Draw.FlatStyle = FlatStyle.Flat;
            Draw.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point);
            Draw.ForeColor = Color.White;
            Draw.Location = new Point(324, 420);
            Draw.Name = "Draw";
            Draw.Size = new Size(200, 40);
            Draw.TabIndex = 0;
            Draw.Text = "Draw Cards";
            Draw.UseVisualStyleBackColor = false;
            Draw.Click += draw_Click;
            // 
            // Quit
            // 
            Quit.BackColor = Color.Red;
            Quit.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 0);
            Quit.FlatAppearance.BorderSize = 2;
            Quit.FlatStyle = FlatStyle.Flat;
            Quit.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            Quit.ForeColor = Color.White;
            Quit.Location = new Point(578, 420);
            Quit.Name = "Quit";
            Quit.Size = new Size(200, 40);
            Quit.TabIndex = 1;
            Quit.Text = "Quit";
            Quit.UseVisualStyleBackColor = false;
            Quit.Click += quit_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(60, 127);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(193, 255);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(323, 127);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(193, 255);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(576, 127);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(193, 255);
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(857, 127);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(193, 255);
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("MS Gothic", 72F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(229, 13);
            label1.Name = "label1";
            label1.Size = new Size(630, 97);
            label1.TabIndex = 6;
            label1.Text = "CARD SHUFFLE";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1093, 490);
            Controls.Add(label1);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(Quit);
            Controls.Add(Draw);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CARD GAME";
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
        private Label label1;
    }
}

