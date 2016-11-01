namespace GetAcross {
    partial class Scores {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblPlay = new System.Windows.Forms.Label();
            this.pnlScores = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.BurlyWood;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblTitle.Size = new System.Drawing.Size(123, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Scoreboard";
            // 
            // lblPlay
            // 
            this.lblPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPlay.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.lblPlay.ForeColor = System.Drawing.Color.AntiqueWhite;
            this.lblPlay.Location = new System.Drawing.Point(224, 235);
            this.lblPlay.Name = "lblPlay";
            this.lblPlay.Size = new System.Drawing.Size(35, 18);
            this.lblPlay.TabIndex = 9;
            this.lblPlay.Text = "play";
            this.lblPlay.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblPlay.Click += new System.EventHandler(this.lblGoAgain_Click);
            this.lblPlay.MouseEnter += new System.EventHandler(this.lbl_MouseEnter);
            this.lblPlay.MouseLeave += new System.EventHandler(this.lbl_MouseLeave);
            // 
            // pnlScores
            // 
            this.pnlScores.AutoScroll = true;
            this.pnlScores.Location = new System.Drawing.Point(5, 38);
            this.pnlScores.Name = "pnlScores";
            this.pnlScores.Size = new System.Drawing.Size(279, 215);
            this.pnlScores.TabIndex = 10;
            // 
            // Scores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AntiqueWhite;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.lblPlay);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlScores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Scores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scores";
            this.Load += new System.EventHandler(this.Scores_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblPlay;
        private System.Windows.Forms.Panel pnlScores;
    }
}