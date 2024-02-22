namespace Exercise_11
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
            BtnShowExample = new System.Windows.Forms.Button();
            BtnCellsUnlock = new System.Windows.Forms.Button();
            BtnSave = new System.Windows.Forms.Button();
            BtnFixCondition = new System.Windows.Forms.Button();
            BtnLoadSave = new System.Windows.Forms.Button();
            BtnNewGame = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // BtnShowExample
            // 
            BtnShowExample.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BtnShowExample.Location = new System.Drawing.Point(582, 105);
            BtnShowExample.Name = "BtnShowExample";
            BtnShowExample.Size = new System.Drawing.Size(183, 74);
            BtnShowExample.TabIndex = 0;
            BtnShowExample.Text = "Показать пример судоку";
            BtnShowExample.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            BtnShowExample.UseVisualStyleBackColor = true;
            BtnShowExample.Click += BtnShowExample_Click;
            // 
            // BtnCellsUnlock
            // 
            BtnCellsUnlock.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BtnCellsUnlock.Location = new System.Drawing.Point(582, 199);
            BtnCellsUnlock.Name = "BtnCellsUnlock";
            BtnCellsUnlock.Size = new System.Drawing.Size(183, 74);
            BtnCellsUnlock.TabIndex = 1;
            BtnCellsUnlock.Text = "Разблокировать ячейки";
            BtnCellsUnlock.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            BtnCellsUnlock.UseVisualStyleBackColor = true;
            BtnCellsUnlock.Click += BtnCellsUnlock_Click;
            // 
            // BtnSave
            // 
            BtnSave.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BtnSave.Location = new System.Drawing.Point(582, 478);
            BtnSave.Name = "BtnSave";
            BtnSave.Size = new System.Drawing.Size(183, 47);
            BtnSave.TabIndex = 2;
            BtnSave.Text = "Сохранить";
            BtnSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            BtnSave.UseVisualStyleBackColor = true;
            BtnSave.Click += BtnSave_Click;
            // 
            // BtnFixCondition
            // 
            BtnFixCondition.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BtnFixCondition.Location = new System.Drawing.Point(582, 293);
            BtnFixCondition.Name = "BtnFixCondition";
            BtnFixCondition.Size = new System.Drawing.Size(183, 74);
            BtnFixCondition.TabIndex = 3;
            BtnFixCondition.Text = "Условие введено";
            BtnFixCondition.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            BtnFixCondition.UseVisualStyleBackColor = true;
            BtnFixCondition.Click += BtnFixCondition_Click;
            // 
            // BtnLoadSave
            // 
            BtnLoadSave.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BtnLoadSave.Location = new System.Drawing.Point(582, 385);
            BtnLoadSave.Name = "BtnLoadSave";
            BtnLoadSave.Size = new System.Drawing.Size(183, 74);
            BtnLoadSave.TabIndex = 4;
            BtnLoadSave.Text = "Загрузить сохранение";
            BtnLoadSave.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            BtnLoadSave.UseVisualStyleBackColor = true;
            BtnLoadSave.Click += BtnLoadSave_Click;
            // 
            // BtnNewGame
            // 
            BtnNewGame.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            BtnNewGame.Location = new System.Drawing.Point(582, 37);
            BtnNewGame.Name = "BtnNewGame";
            BtnNewGame.Size = new System.Drawing.Size(183, 46);
            BtnNewGame.TabIndex = 5;
            BtnNewGame.Text = "Новая игра";
            BtnNewGame.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            BtnNewGame.UseVisualStyleBackColor = true;
            BtnNewGame.Click += BtnNewGame_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(790, 589);
            Controls.Add(BtnNewGame);
            Controls.Add(BtnLoadSave);
            Controls.Add(BtnFixCondition);
            Controls.Add(BtnSave);
            Controls.Add(BtnCellsUnlock);
            Controls.Add(BtnShowExample);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Name = "Form1";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Судоку";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button BtnShowExample;
        private System.Windows.Forms.Button BtnCellsUnlock;
        private System.Windows.Forms.Button BtnSave;
        private System.Windows.Forms.Button BtnFixCondition;
        private System.Windows.Forms.Button BtnLoadSave;
        private System.Windows.Forms.Button BtnNewGame;
    }
}
