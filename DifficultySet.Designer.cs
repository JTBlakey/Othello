namespace Othello
{
    partial class DifficultySet
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
            this.Easy = new System.Windows.Forms.Button();
            this.Medium = new System.Windows.Forms.Button();
            this.Hard = new System.Windows.Forms.Button();
            this.Quit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(103)))), ((int)(((byte)(54)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 55F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(71, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(670, 104);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select Difficulty";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Easy
            // 
            this.Easy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Easy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(103)))), ((int)(((byte)(54)))));
            this.Easy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Easy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Easy.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Easy.Location = new System.Drawing.Point(297, 299);
            this.Easy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Easy.Name = "Easy";
            this.Easy.Size = new System.Drawing.Size(229, 133);
            this.Easy.TabIndex = 6;
            this.Easy.Text = "Easy";
            this.Easy.UseVisualStyleBackColor = false;
            this.Easy.Click += new System.EventHandler(this.Easy_Click);
            // 
            // Medium
            // 
            this.Medium.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Medium.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(103)))), ((int)(((byte)(54)))));
            this.Medium.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Medium.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Medium.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Medium.Location = new System.Drawing.Point(297, 440);
            this.Medium.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Medium.Name = "Medium";
            this.Medium.Size = new System.Drawing.Size(229, 133);
            this.Medium.TabIndex = 7;
            this.Medium.Text = "Medium";
            this.Medium.UseVisualStyleBackColor = false;
            this.Medium.Click += new System.EventHandler(this.Medium_Click);
            // 
            // Hard
            // 
            this.Hard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Hard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(103)))), ((int)(((byte)(54)))));
            this.Hard.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Hard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Hard.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Hard.Location = new System.Drawing.Point(297, 581);
            this.Hard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Hard.Name = "Hard";
            this.Hard.Size = new System.Drawing.Size(229, 133);
            this.Hard.TabIndex = 8;
            this.Hard.Text = "Hard";
            this.Hard.UseVisualStyleBackColor = false;
            this.Hard.Click += new System.EventHandler(this.Hard_Click);
            // 
            // Quit
            // 
            this.Quit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(103)))), ((int)(((byte)(54)))));
            this.Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quit.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Quit.Location = new System.Drawing.Point(297, 722);
            this.Quit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(229, 133);
            this.Quit.TabIndex = 9;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = false;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(45)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(805, 908);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.Hard);
            this.Controls.Add(this.Medium);
            this.Controls.Add(this.Easy);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainGame";
            this.Text = "MainGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Button Easy;
        private Button Medium;
        private Button Hard;
        private Button Quit;
    }
}