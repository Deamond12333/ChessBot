namespace ChessBotOnline
{
    partial class StartSettings
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
            this.gameStart = new System.Windows.Forms.Button();
            this.isWhite = new System.Windows.Forms.CheckBox();
            this.pawnWeight = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.bishopWeight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rookWeight = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.knightWeight = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.queenWeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.kingWeight = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameStart
            // 
            this.gameStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.gameStart.Location = new System.Drawing.Point(46, 196);
            this.gameStart.Name = "gameStart";
            this.gameStart.Size = new System.Drawing.Size(94, 35);
            this.gameStart.TabIndex = 0;
            this.gameStart.Text = "Начать игру";
            this.gameStart.UseVisualStyleBackColor = false;
            // 
            // isWhite
            // 
            this.isWhite.AutoSize = true;
            this.isWhite.Checked = true;
            this.isWhite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isWhite.Location = new System.Drawing.Point(46, 173);
            this.isWhite.Name = "isWhite";
            this.isWhite.Size = new System.Drawing.Size(105, 17);
            this.isWhite.TabIndex = 1;
            this.isWhite.Text = "Играть белыми";
            this.isWhite.UseVisualStyleBackColor = true;
            // 
            // pawnWeight
            // 
            this.pawnWeight.Location = new System.Drawing.Point(15, 59);
            this.pawnWeight.Name = "pawnWeight";
            this.pawnWeight.Size = new System.Drawing.Size(44, 20);
            this.pawnWeight.TabIndex = 2;
            this.pawnWeight.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Пешка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Офицер";
            // 
            // bishopWeight
            // 
            this.bishopWeight.Location = new System.Drawing.Point(15, 102);
            this.bishopWeight.Name = "bishopWeight";
            this.bishopWeight.Size = new System.Drawing.Size(44, 20);
            this.bishopWeight.TabIndex = 4;
            this.bishopWeight.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ладья";
            // 
            // rookWeight
            // 
            this.rookWeight.Location = new System.Drawing.Point(15, 146);
            this.rookWeight.Name = "rookWeight";
            this.rookWeight.Size = new System.Drawing.Size(44, 20);
            this.rookWeight.TabIndex = 6;
            this.rookWeight.Text = "5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Конь";
            // 
            // knightWeight
            // 
            this.knightWeight.Location = new System.Drawing.Point(128, 59);
            this.knightWeight.Name = "knightWeight";
            this.knightWeight.Size = new System.Drawing.Size(44, 20);
            this.knightWeight.TabIndex = 8;
            this.knightWeight.Text = "2,5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(125, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Ферзь";
            // 
            // queenWeight
            // 
            this.queenWeight.Location = new System.Drawing.Point(128, 102);
            this.queenWeight.Name = "queenWeight";
            this.queenWeight.Size = new System.Drawing.Size(44, 20);
            this.queenWeight.TabIndex = 10;
            this.queenWeight.Text = "8";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(125, 130);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Король";
            // 
            // kingWeight
            // 
            this.kingWeight.Location = new System.Drawing.Point(128, 146);
            this.kingWeight.Name = "kingWeight";
            this.kingWeight.Size = new System.Drawing.Size(44, 20);
            this.kingWeight.TabIndex = 12;
            this.kingWeight.Text = "25";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(55, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Вес фигур";
            // 
            // StartSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 243);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.kingWeight);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.queenWeight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.knightWeight);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rookWeight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bishopWeight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pawnWeight);
            this.Controls.Add(this.isWhite);
            this.Controls.Add(this.gameStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "StartSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Стартовые настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gameStart;
        private System.Windows.Forms.CheckBox isWhite;
        private System.Windows.Forms.TextBox pawnWeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox bishopWeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox rookWeight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox knightWeight;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox queenWeight;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox kingWeight;
        private System.Windows.Forms.Label label7;
    }
}