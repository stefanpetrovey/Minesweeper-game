namespace Minesweeper
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panelShow = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tbFlag = new System.Windows.Forms.TextBox();
            this.tbScore = new System.Windows.Forms.TextBox();
            this.btnHard = new System.Windows.Forms.Button();
            this.btnEasy = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelShow.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelShow
            // 
            this.panelShow.Controls.Add(this.progressBar);
            this.panelShow.Controls.Add(this.tbFlag);
            this.panelShow.Controls.Add(this.tbScore);
            this.panelShow.Controls.Add(this.btnHard);
            this.panelShow.Controls.Add(this.btnEasy);
            this.panelShow.Location = new System.Drawing.Point(13, 13);
            this.panelShow.Name = "panelShow";
            this.panelShow.Size = new System.Drawing.Size(412, 60);
            this.panelShow.TabIndex = 0;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(227, 33);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(182, 23);
            this.progressBar.TabIndex = 4;
            // 
            // tbFlag
            // 
            this.tbFlag.Location = new System.Drawing.Point(227, 5);
            this.tbFlag.Name = "tbFlag";
            this.tbFlag.ReadOnly = true;
            this.tbFlag.Size = new System.Drawing.Size(76, 22);
            this.tbFlag.TabIndex = 3;
            // 
            // tbScore
            // 
            this.tbScore.Location = new System.Drawing.Point(309, 4);
            this.tbScore.Name = "tbScore";
            this.tbScore.ReadOnly = true;
            this.tbScore.Size = new System.Drawing.Size(100, 22);
            this.tbScore.TabIndex = 2;
            // 
            // btnHard
            // 
            this.btnHard.Location = new System.Drawing.Point(4, 33);
            this.btnHard.Name = "btnHard";
            this.btnHard.Size = new System.Drawing.Size(107, 23);
            this.btnHard.TabIndex = 1;
            this.btnHard.Text = "Hard";
            this.btnHard.UseVisualStyleBackColor = true;
            this.btnHard.Click += new System.EventHandler(this.btnHard_Click);
            // 
            // btnEasy
            // 
            this.btnEasy.Location = new System.Drawing.Point(4, 4);
            this.btnEasy.Name = "btnEasy";
            this.btnEasy.Size = new System.Drawing.Size(107, 23);
            this.btnEasy.TabIndex = 0;
            this.btnEasy.Text = "Easy";
            this.btnEasy.UseVisualStyleBackColor = true;
            this.btnEasy.Click += new System.EventHandler(this.btnEasy_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.Location = new System.Drawing.Point(13, 80);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(411, 347);
            this.panelButtons.TabIndex = 1;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(437, 439);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelShow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Minesweeper";
            this.panelShow.ResumeLayout(false);
            this.panelShow.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelShow;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox tbFlag;
        private System.Windows.Forms.TextBox tbScore;
        private System.Windows.Forms.Button btnHard;
        private System.Windows.Forms.Button btnEasy;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Timer timer1;
    }
}

