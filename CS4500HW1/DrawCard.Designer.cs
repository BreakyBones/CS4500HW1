// This is DrawCard.Designer.cs
// This file declares all of the properties for the Card selection page, which includes the pictures for the cards,
// the pictures for all four suites for each card, the drop-down for selecting the value of the cards, and the buttons
// Before that happens, any resources that need to be disposed to set up the design will be disposed if needed.
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

        // List the design properties
        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawCard));
            DealBtn = new Button();
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
            textBoxLog = new TextBox();
            card1Confirm = new Button();
            card2Confirm = new Button();
            card3Confirm = new Button();
            card4Confirm = new Button();
            NextRoundBtn = new Button();
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
            // DealBtn
            // 
            DealBtn.AccessibleDescription = "Button to Draw Cards";
            DealBtn.AccessibleName = "DealBtn";
            DealBtn.BackColor = Color.DarkGreen;
            DealBtn.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 0);
            DealBtn.FlatAppearance.BorderSize = 2;
            DealBtn.FlatStyle = FlatStyle.Flat;
            DealBtn.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point);
            DealBtn.ForeColor = Color.White;
            DealBtn.Location = new Point(324, 582);
            DealBtn.Name = "DealBtn";
            DealBtn.Size = new Size(200, 40);
            DealBtn.TabIndex = 0;
            DealBtn.Text = "Deal";
            DealBtn.UseVisualStyleBackColor = false;
            DealBtn.Click += draw_Click;
            // 
            // Quit
            // 
            Quit.BackColor = Color.Red;
            Quit.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 0);
            Quit.FlatAppearance.BorderSize = 2;
            Quit.FlatStyle = FlatStyle.Flat;
            Quit.Font = new Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point);
            Quit.ForeColor = Color.White;
            Quit.Location = new Point(578, 581);
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
            pictureBox4.Location = new Point(843, 127);
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
            label1.Location = new Point(232, 15);
            label1.Name = "label1";
            label1.Size = new Size(532, 97);
            label1.TabIndex = 6;
            label1.Text = "ART DEALER";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.Khaki;
            comboBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Please select value" });
            comboBox1.Location = new Point(60, 456);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(193, 23);
            comboBox1.TabIndex = 7;
            // 
            // comboBox2
            // 
            comboBox2.BackColor = Color.Khaki;
            comboBox2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Please select value" });
            comboBox2.Location = new Point(322, 456);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(194, 23);
            comboBox2.TabIndex = 8;
            // 
            // comboBox3
            // 
            comboBox3.BackColor = Color.Khaki;
            comboBox3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Please select value" });
            comboBox3.Location = new Point(578, 456);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(191, 23);
            comboBox3.TabIndex = 9;
            // 
            // comboBox4
            // 
            comboBox4.BackColor = Color.Khaki;
            comboBox4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "Please select value" });
            comboBox4.Location = new Point(843, 456);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(193, 23);
            comboBox4.TabIndex = 10;
            // 
            // pictureBoxC1
            // 
            pictureBoxC1.Image = (Image)resources.GetObject("pictureBoxC1.Image");
            pictureBoxC1.Location = new Point(160, 397);
            pictureBoxC1.Name = "pictureBoxC1";
            pictureBoxC1.Padding = new Padding(3, 2, 3, 2);
            pictureBoxC1.Size = new Size(42, 39);
            pictureBoxC1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxC1.TabIndex = 25;
            pictureBoxC1.TabStop = false;
            pictureBoxC1.Click += PictureBoxSuit_Click;
            // 
            // pictureBoxD1
            // 
            pictureBoxD1.Image = (Image)resources.GetObject("pictureBoxD1.Image");
            pictureBoxD1.Location = new Point(109, 397);
            pictureBoxD1.Name = "pictureBoxD1";
            pictureBoxD1.Padding = new Padding(3, 2, 3, 2);
            pictureBoxD1.Size = new Size(42, 39);
            pictureBoxD1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxD1.TabIndex = 24;
            pictureBoxD1.TabStop = false;
            pictureBoxD1.Click += PictureBoxSuit_Click;
            // 
            // pictureBoxH1
            // 
            pictureBoxH1.Image = (Image)resources.GetObject("pictureBoxH1.Image");
            pictureBoxH1.Location = new Point(59, 397);
            pictureBoxH1.Name = "pictureBoxH1";
            pictureBoxH1.Padding = new Padding(3, 2, 3, 2);
            pictureBoxH1.Size = new Size(42, 39);
            pictureBoxH1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxH1.TabIndex = 23;
            pictureBoxH1.TabStop = false;
            pictureBoxH1.Click += PictureBoxSuit_Click;
            // 
            // pictureBoxS1
            // 
            pictureBoxS1.Image = (Image)resources.GetObject("pictureBoxS1.Image");
            pictureBoxS1.Location = new Point(211, 397);
            pictureBoxS1.Name = "pictureBoxS1";
            pictureBoxS1.Padding = new Padding(3, 2, 3, 2);
            pictureBoxS1.Size = new Size(42, 39);
            pictureBoxS1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxS1.TabIndex = 26;
            pictureBoxS1.TabStop = false;
            pictureBoxS1.Click += PictureBoxSuit_Click;
            // 
            // pictureBoxS2
            // 
            pictureBoxS2.Image = (Image)resources.GetObject("pictureBoxS2.Image");
            pictureBoxS2.Location = new Point(474, 397);
            pictureBoxS2.Name = "pictureBoxS2";
            pictureBoxS2.Padding = new Padding(3, 2, 3, 2);
            pictureBoxS2.Size = new Size(42, 39);
            pictureBoxS2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxS2.TabIndex = 30;
            pictureBoxS2.TabStop = false;
            // 
            // pictureBoxC2
            // 
            pictureBoxC2.Image = (Image)resources.GetObject("pictureBoxC2.Image");
            pictureBoxC2.Location = new Point(423, 397);
            pictureBoxC2.Name = "pictureBoxC2";
            pictureBoxC2.Padding = new Padding(3, 2, 3, 2);
            pictureBoxC2.Size = new Size(42, 39);
            pictureBoxC2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxC2.TabIndex = 29;
            pictureBoxC2.TabStop = false;
            // 
            // pictureBoxD2
            // 
            pictureBoxD2.Image = (Image)resources.GetObject("pictureBoxD2.Image");
            pictureBoxD2.Location = new Point(372, 397);
            pictureBoxD2.Name = "pictureBoxD2";
            pictureBoxD2.Padding = new Padding(3, 2, 3, 2);
            pictureBoxD2.Size = new Size(42, 39);
            pictureBoxD2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxD2.TabIndex = 28;
            pictureBoxD2.TabStop = false;
            // 
            // pictureBoxH2
            // 
            pictureBoxH2.Image = (Image)resources.GetObject("pictureBoxH2.Image");
            pictureBoxH2.Location = new Point(322, 397);
            pictureBoxH2.Name = "pictureBoxH2";
            pictureBoxH2.Padding = new Padding(3, 2, 3, 2);
            pictureBoxH2.Size = new Size(42, 39);
            pictureBoxH2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxH2.TabIndex = 27;
            pictureBoxH2.TabStop = false;
            // 
            // pictureBoxS3
            // 
            pictureBoxS3.Image = (Image)resources.GetObject("pictureBoxS3.Image");
            pictureBoxS3.Location = new Point(726, 397);
            pictureBoxS3.Name = "pictureBoxS3";
            pictureBoxS3.Padding = new Padding(3, 2, 3, 2);
            pictureBoxS3.Size = new Size(42, 39);
            pictureBoxS3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxS3.TabIndex = 34;
            pictureBoxS3.TabStop = false;
            // 
            // pictureBoxC3
            // 
            pictureBoxC3.Image = (Image)resources.GetObject("pictureBoxC3.Image");
            pictureBoxC3.Location = new Point(675, 397);
            pictureBoxC3.Name = "pictureBoxC3";
            pictureBoxC3.Padding = new Padding(3, 2, 3, 2);
            pictureBoxC3.Size = new Size(42, 39);
            pictureBoxC3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxC3.TabIndex = 33;
            pictureBoxC3.TabStop = false;
            // 
            // pictureBoxD3
            // 
            pictureBoxD3.Image = (Image)resources.GetObject("pictureBoxD3.Image");
            pictureBoxD3.Location = new Point(624, 397);
            pictureBoxD3.Name = "pictureBoxD3";
            pictureBoxD3.Padding = new Padding(3, 2, 3, 2);
            pictureBoxD3.Size = new Size(42, 39);
            pictureBoxD3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxD3.TabIndex = 32;
            pictureBoxD3.TabStop = false;
            // 
            // pictureBoxH3
            // 
            pictureBoxH3.Image = (Image)resources.GetObject("pictureBoxH3.Image");
            pictureBoxH3.Location = new Point(574, 397);
            pictureBoxH3.Name = "pictureBoxH3";
            pictureBoxH3.Padding = new Padding(3, 2, 3, 2);
            pictureBoxH3.Size = new Size(42, 39);
            pictureBoxH3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxH3.TabIndex = 31;
            pictureBoxH3.TabStop = false;
            // 
            // pictureBoxS4
            // 
            pictureBoxS4.Image = (Image)resources.GetObject("pictureBoxS4.Image");
            pictureBoxS4.Location = new Point(993, 397);
            pictureBoxS4.Name = "pictureBoxS4";
            pictureBoxS4.Padding = new Padding(3, 2, 3, 2);
            pictureBoxS4.Size = new Size(42, 39);
            pictureBoxS4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxS4.TabIndex = 38;
            pictureBoxS4.TabStop = false;
            // 
            // pictureBoxC4
            // 
            pictureBoxC4.Image = (Image)resources.GetObject("pictureBoxC4.Image");
            pictureBoxC4.Location = new Point(942, 397);
            pictureBoxC4.Name = "pictureBoxC4";
            pictureBoxC4.Padding = new Padding(3, 2, 3, 2);
            pictureBoxC4.Size = new Size(42, 39);
            pictureBoxC4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxC4.TabIndex = 37;
            pictureBoxC4.TabStop = false;
            // 
            // pictureBoxD4
            // 
            pictureBoxD4.Image = (Image)resources.GetObject("pictureBoxD4.Image");
            pictureBoxD4.Location = new Point(891, 397);
            pictureBoxD4.Name = "pictureBoxD4";
            pictureBoxD4.Padding = new Padding(3, 2, 3, 2);
            pictureBoxD4.Size = new Size(42, 39);
            pictureBoxD4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxD4.TabIndex = 36;
            pictureBoxD4.TabStop = false;
            // 
            // pictureBoxH4
            // 
            pictureBoxH4.Image = (Image)resources.GetObject("pictureBoxH4.Image");
            pictureBoxH4.Location = new Point(841, 397);
            pictureBoxH4.Name = "pictureBoxH4";
            pictureBoxH4.Padding = new Padding(3, 2, 3, 2);
            pictureBoxH4.Size = new Size(42, 39);
            pictureBoxH4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxH4.TabIndex = 35;
            pictureBoxH4.TabStop = false;
            // 
            // textBoxLog
            // 
            textBoxLog.Location = new Point(891, 5);
            textBoxLog.Multiline = true;
            textBoxLog.Name = "textBoxLog";
            textBoxLog.ScrollBars = ScrollBars.Vertical;
            textBoxLog.Size = new Size(196, 107);
            textBoxLog.TabIndex = 39;
            // 
            // card1Confirm
            // 
            card1Confirm.BackColor = Color.ForestGreen;
            card1Confirm.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            card1Confirm.ForeColor = Color.Gold;
            card1Confirm.Location = new Point(59, 502);
            card1Confirm.Name = "card1Confirm";
            card1Confirm.Size = new Size(194, 39);
            card1Confirm.TabIndex = 40;
            card1Confirm.Text = "Confirm Card";
            card1Confirm.UseVisualStyleBackColor = false;
            card1Confirm.Click += card1Confirm_Click;
            // 
            // card2Confirm
            // 
            card2Confirm.BackColor = Color.ForestGreen;
            card2Confirm.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            card2Confirm.ForeColor = Color.Gold;
            card2Confirm.Location = new Point(322, 502);
            card2Confirm.Name = "card2Confirm";
            card2Confirm.Size = new Size(194, 39);
            card2Confirm.TabIndex = 41;
            card2Confirm.Text = "Confirm Card";
            card2Confirm.UseVisualStyleBackColor = false;
            card2Confirm.Click += card2Confirm_Click;
            // 
            // card3Confirm
            // 
            card3Confirm.BackColor = Color.ForestGreen;
            card3Confirm.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            card3Confirm.ForeColor = Color.Gold;
            card3Confirm.Location = new Point(578, 502);
            card3Confirm.Name = "card3Confirm";
            card3Confirm.Size = new Size(194, 39);
            card3Confirm.TabIndex = 42;
            card3Confirm.Text = "Confirm Card";
            card3Confirm.UseVisualStyleBackColor = false;
            card3Confirm.Click += card3Confirm_Click;
            // 
            // card4Confirm
            // 
            card4Confirm.BackColor = Color.ForestGreen;
            card4Confirm.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            card4Confirm.ForeColor = Color.Gold;
            card4Confirm.Location = new Point(841, 502);
            card4Confirm.Name = "card4Confirm";
            card4Confirm.Size = new Size(194, 39);
            card4Confirm.TabIndex = 43;
            card4Confirm.Text = "Confirm Card";
            card4Confirm.UseVisualStyleBackColor = false;
            card4Confirm.Click += card4Confirm_Click;
            // 
            // NextRoundBtn
            // 
            NextRoundBtn.AccessibleDescription = "Button to Draw Cards";
            NextRoundBtn.AccessibleName = "Draw";
            NextRoundBtn.BackColor = Color.DarkGreen;
            NextRoundBtn.FlatAppearance.BorderColor = Color.FromArgb(192, 192, 0);
            NextRoundBtn.FlatAppearance.BorderSize = 2;
            NextRoundBtn.FlatStyle = FlatStyle.Flat;
            NextRoundBtn.Font = new Font("Impact", 16F, FontStyle.Regular, GraphicsUnit.Point);
            NextRoundBtn.ForeColor = Color.White;
            NextRoundBtn.Location = new Point(60, 581);
            NextRoundBtn.Name = "NextRoundBtn";
            NextRoundBtn.Size = new Size(200, 40);
            NextRoundBtn.TabIndex = 44;
            NextRoundBtn.Text = "Next Round";
            NextRoundBtn.UseVisualStyleBackColor = false;
            NextRoundBtn.Click += NextRoundBtn_Click;
            // 
            // DrawCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(1093, 657);
            Controls.Add(NextRoundBtn);
            Controls.Add(card4Confirm);
            Controls.Add(card3Confirm);
            Controls.Add(card2Confirm);
            Controls.Add(card1Confirm);
            Controls.Add(textBoxLog);
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
            Controls.Add(DealBtn);
            Name = "DrawCard";
            Padding = new Padding(3, 2, 3, 2);
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

        private System.Windows.Forms.Button DealBtn;
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
        private TextBox textBoxLog;
        private Button card1Confirm;
        private Button card2Confirm;
        private Button card3Confirm;
        private Button card4Confirm;
        private Button NextRoundBtn;
    }
}
// End of file