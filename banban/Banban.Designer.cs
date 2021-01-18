
namespace banban
{
    partial class Banban
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Banban));
            this.label1 = new System.Windows.Forms.Label();
            this.picbox_backGroundPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_backGroundPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // picbox_backGroundPictureBox
            // 
            this.picbox_backGroundPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.picbox_backGroundPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picbox_backGroundPictureBox.BackgroundImage")));
            this.picbox_backGroundPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picbox_backGroundPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picbox_backGroundPictureBox.Location = new System.Drawing.Point(0, 0);
            this.picbox_backGroundPictureBox.Name = "picbox_backGroundPictureBox";
            this.picbox_backGroundPictureBox.Padding = new System.Windows.Forms.Padding(100, 200, 0, 0);
            this.picbox_backGroundPictureBox.Size = new System.Drawing.Size(800, 450);
            this.picbox_backGroundPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picbox_backGroundPictureBox.TabIndex = 2;
            this.picbox_backGroundPictureBox.TabStop = false;
            // 
            // Banban
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.picbox_backGroundPictureBox);
            this.Controls.Add(this.label1);
            this.Name = "Banban";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Banban_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Banban_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picbox_backGroundPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picbox_backGroundPictureBox;
    }
}

