﻿namespace Othello
{
    partial class MainGame
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
            this.Quit = new System.Windows.Forms.Button();
            this.board = new System.Windows.Forms.TableLayoutPanel();
            this.Back = new System.Windows.Forms.Button();
            this.ScoreBoard = new System.Windows.Forms.TextBox();
            this.Timer = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Quit
            // 
            this.Quit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Quit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(103)))), ((int)(((byte)(54)))));
            this.Quit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Quit.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Quit.Location = new System.Drawing.Point(657, 821);
            this.Quit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(136, 75);
            this.Quit.TabIndex = 10;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = false;
            this.Quit.Click += new System.EventHandler(this.Quit_Click_1);
            // 
            // board
            // 
            this.board.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(103)))), ((int)(((byte)(54)))));
            this.board.ColumnCount = 8;
            this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.Location = new System.Drawing.Point(94, 128);
            this.board.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.board.Name = "board";
            this.board.RowCount = 8;
            this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.board.Size = new System.Drawing.Size(605, 685);
            this.board.TabIndex = 11;
            // 
            // Back
            // 
            this.Back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Back.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(103)))), ((int)(((byte)(54)))));
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Back.Location = new System.Drawing.Point(514, 821);
            this.Back.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(136, 75);
            this.Back.TabIndex = 12;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // ScoreBoard
            // 
            this.ScoreBoard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(103)))), ((int)(((byte)(54)))));
            this.ScoreBoard.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ScoreBoard.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ScoreBoard.Location = new System.Drawing.Point(94, 12);
            this.ScoreBoard.Multiline = true;
            this.ScoreBoard.Name = "ScoreBoard";
            this.ScoreBoard.ReadOnly = true;
            this.ScoreBoard.Size = new System.Drawing.Size(389, 109);
            this.ScoreBoard.TabIndex = 13;
            this.ScoreBoard.TextChanged += new System.EventHandler(this.ScoreBoard_TextChanged);
            // 
            // Timer
            // 
            this.Timer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(103)))), ((int)(((byte)(54)))));
            this.Timer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Timer.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Timer.Location = new System.Drawing.Point(489, 12);
            this.Timer.Multiline = true;
            this.Timer.Name = "Timer";
            this.Timer.ReadOnly = true;
            this.Timer.Size = new System.Drawing.Size(210, 109);
            this.Timer.TabIndex = 14;
            // 
            // MainGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(45)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(805, 908);
            this.Controls.Add(this.Timer);
            this.Controls.Add(this.ScoreBoard);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.board);
            this.Controls.Add(this.Quit);
            this.Name = "MainGame";
            this.Text = "MainGame";
            this.Load += new System.EventHandler(this.MainGame_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Quit;
        private TableLayoutPanel board;
        private Button Back;
        private TextBox ScoreBoard;
        private TextBox Timer;
    }
}