
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
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            pictureBoxC1 = new PictureBox();
            pictureBoxD1 = new PictureBox();
            pictureBoxH1 = new PictureBox();
            pictureBoxS1 = new PictureBox();
            pictureBoxS2 = new PictureBox();
            pictureBoxC2 = new PictureBox();
            pictureBoxD2 = new PictureBox();
            pictureBoxH2 = new PictureBox();
            pictureBoxS3 = new PictureBox();
            pictureBoxC3 = new PictureBox();
            pictureBoxD3 = new PictureBox();
            pictureBoxH3 = new PictureBox();
            pictureBoxS4 = new PictureBox();
            pictureBoxC4 = new PictureBox();
            pictureBoxD4 = new PictureBox();
            pictureBoxH4 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxC1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxD1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxH1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxS1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxS2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxC2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxD2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxH2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxS3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxC3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxD3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxH3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxS4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxC4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxD4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxH4).BeginInit();
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
            Draw.Location = new Point(370, 720);
            Draw.Margin = new Padding(3, 4, 3, 4);
            Draw.Name = "Draw";
            Draw.Size = new Size(229, 53);
            Draw.TabIndex = 0;
            Draw.Text = "Confirm 4 cards";
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
            Quit.Location = new Point(661, 720);
            Quit.Margin = new Padding(3, 4, 3, 4);
            Quit.Name = "Quit";
            Quit.Size = new Size(229, 53);
            Quit.TabIndex = 1;
            Quit.Text = "Quit";
            Quit.UseVisualStyleBackColor = false;
            Quit.Click += quit_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(69, 169);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(221, 340);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(369, 169);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(221, 340);
            pictureBox2.TabIndex = 3;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(658, 169);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(221, 340);
            pictureBox3.TabIndex = 4;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = (Image)resources.GetObject("pictureBox4.BackgroundImage");
            pictureBox4.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox4.Location = new Point(963, 169);
            pictureBox4.Margin = new Padding(3, 4, 3, 4);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(221, 340);
            pictureBox4.TabIndex = 5;
            pictureBox4.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("MS Gothic", 72F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point);
            label1.ForeColor = Color.Gold;
            label1.Location = new Point(262, 17);
            label1.Name = "label1";
            label1.Size = new Size(782, 120);
            label1.TabIndex = 6;
            label1.Text = "CARD SHUFFLE";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.Khaki;
            comboBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Please select value" });
            comboBox1.Location = new Point(69, 608);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(220, 28);
            comboBox1.TabIndex = 7;
            // 
            // comboBox2
            // 
            comboBox2.BackColor = Color.Khaki;
            comboBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Please select value" });
            comboBox2.Location = new Point(368, 608);
            comboBox2.Margin = new Padding(3, 4, 3, 4);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(221, 28);
            comboBox2.TabIndex = 8;
            // 
            // comboBox3
            // 
            comboBox3.BackColor = Color.Khaki;
            comboBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Please select value" });
            comboBox3.Location = new Point(661, 608);
            comboBox3.Margin = new Padding(3, 4, 3, 4);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(218, 28);
            comboBox3.TabIndex = 9;
            // 
            // comboBox4
            // 
            comboBox4.BackColor = Color.Khaki;
            comboBox4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "Please select value" });
            comboBox4.Location = new Point(963, 608);
            comboBox4.Margin = new Padding(3, 4, 3, 4);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(220, 28);
            comboBox4.TabIndex = 10;
            // 
            // pictureBoxC1
            // 
            pictureBoxC1.Image = (Image)resources.GetObject("pictureBoxC1.Image");
            pictureBoxC1.Location = new Point(183, 529);
            pictureBoxC1.Margin = new Padding(3, 4, 3, 4);
            pictureBoxC1.Name = "pictureBoxC1";
            pictureBoxC1.Padding = new Padding(5);
            pictureBoxC1.Size = new Size(48, 52);
            pictureBoxC1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxC1.TabIndex = 25;
            pictureBoxC1.TabStop = false;
            pictureBoxC1.Click += PictureBoxSuit_Click;
            // 
            // pictureBoxD1
            // 
            pictureBoxD1.Image = (Image)resources.GetObject("pictureBoxD1.Image");
            pictureBoxD1.Location = new Point(125, 529);
            pictureBoxD1.Margin = new Padding(3, 4, 3, 4);
            pictureBoxD1.Name = "pictureBoxD1";
            pictureBoxD1.Padding = new Padding(5);
            pictureBoxD1.Size = new Size(48, 52);
            pictureBoxD1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxD1.TabIndex = 24;
            pictureBoxD1.TabStop = false;
            pictureBoxD1.Click += PictureBoxSuit_Click;
            // 
            // pictureBoxH1
            // 
            pictureBoxH1.Image = (Image)resources.GetObject("pictureBoxH1.Image");
            pictureBoxH1.Location = new Point(67, 529);
            pictureBoxH1.Margin = new Padding(3, 4, 3, 4);
            pictureBoxH1.Name = "pictureBoxH1";
            pictureBoxH1.Padding = new Padding(5);
            pictureBoxH1.Size = new Size(48, 52);
            pictureBoxH1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxH1.TabIndex = 23;
            pictureBoxH1.TabStop = false;
            pictureBoxH1.Click += PictureBoxSuit_Click;
            // 
            // pictureBoxS1
            // 
            pictureBoxS1.Image = (Image)resources.GetObject("pictureBoxS1.Image");
            pictureBoxS1.Location = new Point(241, 529);
            pictureBoxS1.Margin = new Padding(3, 4, 3, 4);
            pictureBoxS1.Name = "pictureBoxS1";
            pictureBoxS1.Padding = new Padding(5);
            pictureBoxS1.Size = new Size(48, 52);
            pictureBoxS1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxS1.TabIndex = 26;
            pictureBoxS1.TabStop = false;
            pictureBoxS1.Click += PictureBoxSuit_Click;
            // 
            // pictureBoxS2
            // 
            pictureBoxS2.Image = (Image)resources.GetObject("pictureBoxS2.Image");
            pictureBoxS2.Location = new Point(542, 529);
            pictureBoxS2.Margin = new Padding(3, 4, 3, 4);
            pictureBoxS2.Name = "pictureBoxS2";
            pictureBoxS2.Padding = new Padding(5);
            pictureBoxS2.Size = new Size(48, 52);
            pictureBoxS2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxS2.TabIndex = 30;
            pictureBoxS2.TabStop = false;
            // 
            // pictureBoxC2
            // 
            pictureBoxC2.Image = (Image)resources.GetObject("pictureBoxC2.Image");
            pictureBoxC2.Location = new Point(483, 529);
            pictureBoxC2.Margin = new Padding(3, 4, 3, 4);
            pictureBoxC2.Name = "pictureBoxC2";
            pictureBoxC2.Padding = new Padding(5);
            pictureBoxC2.Size = new Size(48, 52);
            pictureBoxC2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxC2.TabIndex = 29;
            pictureBoxC2.TabStop = false;
            // 
            // pictureBoxD2
            // 
            pictureBoxD2.Image = (Image)resources.GetObject("pictureBoxD2.Image");
            pictureBoxD2.Location = new Point(425, 529);
            pictureBoxD2.Margin = new Padding(3, 4, 3, 4);
            pictureBoxD2.Name = "pictureBoxD2";
            pictureBoxD2.Padding = new Padding(5);
            pictureBoxD2.Size = new Size(48, 52);
            pictureBoxD2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxD2.TabIndex = 28;
            pictureBoxD2.TabStop = false;
            // 
            // pictureBoxH2
            // 
            pictureBoxH2.Image = (Image)resources.GetObject("pictureBoxH2.Image");
            pictureBoxH2.Location = new Point(368, 529);
            pictureBoxH2.Margin = new Padding(3, 4, 3, 4);
            pictureBoxH2.Name = "pictureBoxH2";
            pictureBoxH2.Padding = new Padding(5);
            pictureBoxH2.Size = new Size(48, 52);
            pictureBoxH2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxH2.TabIndex = 27;
            pictureBoxH2.TabStop = false;
            // 
            // pictureBoxS3
            // 
            pictureBoxS3.Image = (Image)resources.GetObject("pictureBoxS3.Image");
            pictureBoxS3.Location = new Point(830, 529);
            pictureBoxS3.Margin = new Padding(3, 4, 3, 4);
            pictureBoxS3.Name = "pictureBoxS3";
            pictureBoxS3.Padding = new Padding(5);
            pictureBoxS3.Size = new Size(48, 52);
            pictureBoxS3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxS3.TabIndex = 34;
            pictureBoxS3.TabStop = false;
            // 
            // pictureBoxC3
            // 
            pictureBoxC3.Image = (Image)resources.GetObject("pictureBoxC3.Image");
            pictureBoxC3.Location = new Point(771, 529);
            pictureBoxC3.Margin = new Padding(3, 4, 3, 4);
            pictureBoxC3.Name = "pictureBoxC3";
            pictureBoxC3.Padding = new Padding(5);
            pictureBoxC3.Size = new Size(48, 52);
            pictureBoxC3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxC3.TabIndex = 33;
            pictureBoxC3.TabStop = false;
            // 
            // pictureBoxD3
            // 
            pictureBoxD3.Image = (Image)resources.GetObject("pictureBoxD3.Image");
            pictureBoxD3.Location = new Point(713, 529);
            pictureBoxD3.Margin = new Padding(3, 4, 3, 4);
            pictureBoxD3.Name = "pictureBoxD3";
            pictureBoxD3.Padding = new Padding(5);
            pictureBoxD3.Size = new Size(48, 52);
            pictureBoxD3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxD3.TabIndex = 32;
            pictureBoxD3.TabStop = false;
            // 
            // pictureBoxH3
            // 
            pictureBoxH3.Image = (Image)resources.GetObject("pictureBoxH3.Image");
            pictureBoxH3.Location = new Point(656, 529);
            pictureBoxH3.Margin = new Padding(3, 4, 3, 4);
            pictureBoxH3.Name = "pictureBoxH3";
            pictureBoxH3.Padding = new Padding(5);
            pictureBoxH3.Size = new Size(48, 52);
            pictureBoxH3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxH3.TabIndex = 31;
            pictureBoxH3.TabStop = false;
            // 
            // pictureBoxS4
            // 
            pictureBoxS4.Image = (Image)resources.GetObject("pictureBoxS4.Image");
            pictureBoxS4.Location = new Point(1135, 529);
            pictureBoxS4.Margin = new Padding(3, 4, 3, 4);
            pictureBoxS4.Name = "pictureBoxS4";
            pictureBoxS4.Padding = new Padding(5);
            pictureBoxS4.Size = new Size(48, 52);
            pictureBoxS4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxS4.TabIndex = 38;
            pictureBoxS4.TabStop = false;
            // 
            // pictureBoxC4
            // 
            pictureBoxC4.Image = (Image)resources.GetObject("pictureBoxC4.Image");
            pictureBoxC4.Location = new Point(1077, 529);
            pictureBoxC4.Margin = new Padding(3, 4, 3, 4);
            pictureBoxC4.Name = "pictureBoxC4";
            pictureBoxC4.Padding = new Padding(5);
            pictureBoxC4.Size = new Size(48, 52);
            pictureBoxC4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxC4.TabIndex = 37;
            pictureBoxC4.TabStop = false;
            // 
            // pictureBoxD4
            // 
            pictureBoxD4.Image = (Image)resources.GetObject("pictureBoxD4.Image");
            pictureBoxD4.Location = new Point(1018, 529);
            pictureBoxD4.Margin = new Padding(3, 4, 3, 4);
            pictureBoxD4.Name = "pictureBoxD4";
            pictureBoxD4.Padding = new Padding(5);
            pictureBoxD4.Size = new Size(48, 52);
            pictureBoxD4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxD4.TabIndex = 36;
            pictureBoxD4.TabStop = false;
            // 
            // pictureBoxH4
            // 
            pictureBoxH4.Image = (Image)resources.GetObject("pictureBoxH4.Image");
            pictureBoxH4.Location = new Point(961, 529);
            pictureBoxH4.Margin = new Padding(3, 4, 3, 4);
            pictureBoxH4.Name = "pictureBoxH4";
            pictureBoxH4.Padding = new Padding(5);
            pictureBoxH4.Size = new Size(48, 52);
            pictureBoxH4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxH4.TabIndex = 35;
            pictureBoxH4.TabStop = false;
            // 
            // DrawCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1249, 823);
            Controls.Add(pictureBoxS4);
            Controls.Add(pictureBoxC4);
            Controls.Add(pictureBoxD4);
            Controls.Add(pictureBoxH4);
            Controls.Add(pictureBoxS3);
            Controls.Add(pictureBoxC3);
            Controls.Add(pictureBoxD3);
            Controls.Add(pictureBoxH3);
            Controls.Add(pictureBoxS2);
            Controls.Add(pictureBoxC2);
            Controls.Add(pictureBoxD2);
            Controls.Add(pictureBoxH2);
            Controls.Add(pictureBoxS1);
            Controls.Add(pictureBoxC1);
            Controls.Add(pictureBoxD1);
            Controls.Add(pictureBoxH1);
            Controls.Add(comboBox4);
            Controls.Add(comboBox3);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(label1);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(Quit);
            Controls.Add(Draw);
            Margin = new Padding(3, 4, 3, 4);
            Name = "DrawCard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CARD GAME";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxC1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxD1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxH1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxS1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxS2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxC2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxD2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxH2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxS3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxC3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxD3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxH3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxS4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxC4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxD4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxH4).EndInit();
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
        private ComboBox comboBox1;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private PictureBox pictureBoxC1;
        private PictureBox pictureBoxD1;
        private PictureBox pictureBox17;
        private PictureBox pictureBox18;
        private PictureBox pictureBox19;
        private PictureBox pictureBoxH1;
        private PictureBox pictureBoxS1;
        private PictureBox pictureBoxS2;
        private PictureBox pictureBoxC2;
        private PictureBox pictureBoxD2;
        private PictureBox pictureBoxH2;
        private PictureBox pictureBoxS3;
        private PictureBox pictureBoxC3;
        private PictureBox pictureBoxD3;
        private PictureBox pictureBoxH3;
        private PictureBox pictureBoxS4;
        private PictureBox pictureBoxC4;
        private PictureBox pictureBoxD4;
        private PictureBox pictureBoxH4;
    }
}

