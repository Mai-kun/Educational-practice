using System.Drawing;

namespace Exercise_16
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
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            btnSettings = new System.Windows.Forms.Button();
            btnONOFF = new System.Windows.Forms.Button();
            Settings = new System.Windows.Forms.Panel();
            btnFix = new System.Windows.Forms.Button();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            lengthBetweenNUD = new System.Windows.Forms.NumericUpDown();
            dotsCountNUD = new System.Windows.Forms.NumericUpDown();
            Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lengthBetweenNUD).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dotsCountNUD).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Interval = 5;
            timer1.Tick += timer1_Tick;
            // 
            // btnSettings
            // 
            btnSettings.Location = new Point(550, 12);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(85, 30);
            btnSettings.TabIndex = 11;
            btnSettings.Text = "Настройки";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnONOFF
            // 
            btnONOFF.Location = new Point(459, 12);
            btnONOFF.Name = "btnONOFF";
            btnONOFF.Size = new Size(85, 30);
            btnONOFF.TabIndex = 12;
            btnONOFF.Text = "Вкл/выкл";
            btnONOFF.UseVisualStyleBackColor = true;
            btnONOFF.Click += btnONOFF_Click;
            // 
            // Settings
            // 
            Settings.Controls.Add(btnFix);
            Settings.Controls.Add(label4);
            Settings.Controls.Add(label3);
            Settings.Controls.Add(lengthBetweenNUD);
            Settings.Controls.Add(dotsCountNUD);
            Settings.Location = new Point(362, 48);
            Settings.Name = "Settings";
            Settings.Size = new Size(273, 100);
            Settings.TabIndex = 13;
            // 
            // btnFix
            // 
            btnFix.Location = new Point(97, 61);
            btnFix.Name = "btnFix";
            btnFix.Size = new Size(168, 30);
            btnFix.TabIndex = 14;
            btnFix.Text = "Применить изменения";
            btnFix.UseVisualStyleBackColor = true;
            btnFix.Click += btnFix_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(3, 40);
            label4.Name = "label4";
            label4.Size = new Size(117, 15);
            label4.TabIndex = 17;
            label4.Text = "Макс длинна линии";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 11);
            label3.Name = "label3";
            label3.Size = new Size(65, 15);
            label3.TabIndex = 16;
            label3.Text = "Кол. точек";
            // 
            // lengthBetweenNUD
            // 
            lengthBetweenNUD.Location = new Point(145, 32);
            lengthBetweenNUD.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            lengthBetweenNUD.Name = "lengthBetweenNUD";
            lengthBetweenNUD.Size = new Size(120, 23);
            lengthBetweenNUD.TabIndex = 15;
            // 
            // dotsCountNUD
            // 
            dotsCountNUD.Location = new Point(145, 3);
            dotsCountNUD.Maximum = new decimal(new int[] { 150, 0, 0, 0 });
            dotsCountNUD.Name = "dotsCountNUD";
            dotsCountNUD.Size = new Size(120, 23);
            dotsCountNUD.TabIndex = 14;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new Size(657, 390);
            Controls.Add(Settings);
            Controls.Add(btnONOFF);
            Controls.Add(btnSettings);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            Resize += Form1_Resize;
            Settings.ResumeLayout(false);
            Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lengthBetweenNUD).EndInit();
            ((System.ComponentModel.ISupportInitialize)dotsCountNUD).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Button btnONOFF;
        private System.Windows.Forms.Panel Settings;
        private System.Windows.Forms.Button btnFix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown lengthBetweenNUD;
        private System.Windows.Forms.NumericUpDown dotsCountNUD;
    }
}
