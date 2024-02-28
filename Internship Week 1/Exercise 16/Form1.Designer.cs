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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSettings = new System.Windows.Forms.Button();
            this.btnONOFF = new System.Windows.Forms.Button();
            this.Settings = new System.Windows.Forms.Panel();
            this.btnFix = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lengthBetweenNUD = new System.Windows.Forms.NumericUpDown();
            this.dotsCountNUD = new System.Windows.Forms.NumericUpDown();
            this.Settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthBetweenNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dotsCountNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 5;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(550, 12);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(85, 30);
            this.btnSettings.TabIndex = 11;
            this.btnSettings.Text = "Настройки";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnONOFF
            // 
            this.btnONOFF.Location = new System.Drawing.Point(459, 12);
            this.btnONOFF.Name = "btnONOFF";
            this.btnONOFF.Size = new System.Drawing.Size(85, 30);
            this.btnONOFF.TabIndex = 12;
            this.btnONOFF.Text = "Вкл/пауза";
            this.btnONOFF.UseVisualStyleBackColor = true;
            this.btnONOFF.Click += new System.EventHandler(this.btnONOFF_Click);
            // 
            // Settings
            // 
            this.Settings.Controls.Add(this.btnFix);
            this.Settings.Controls.Add(this.label4);
            this.Settings.Controls.Add(this.label3);
            this.Settings.Controls.Add(this.lengthBetweenNUD);
            this.Settings.Controls.Add(this.dotsCountNUD);
            this.Settings.Location = new System.Drawing.Point(362, 48);
            this.Settings.Name = "Settings";
            this.Settings.Size = new System.Drawing.Size(273, 100);
            this.Settings.TabIndex = 13;
            // 
            // btnFix
            // 
            this.btnFix.Location = new System.Drawing.Point(97, 61);
            this.btnFix.Name = "btnFix";
            this.btnFix.Size = new System.Drawing.Size(168, 30);
            this.btnFix.TabIndex = 14;
            this.btnFix.Text = "Применить изменения";
            this.btnFix.UseVisualStyleBackColor = true;
            this.btnFix.Click += new System.EventHandler(this.btnFix_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Макс длинна линии";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(55, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Кол. точек";
            // 
            // lengthBetweenNUD
            // 
            this.lengthBetweenNUD.Location = new System.Drawing.Point(145, 32);
            this.lengthBetweenNUD.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.lengthBetweenNUD.Name = "lengthBetweenNUD";
            this.lengthBetweenNUD.Size = new System.Drawing.Size(120, 23);
            this.lengthBetweenNUD.TabIndex = 15;
            // 
            // dotsCountNUD
            // 
            this.dotsCountNUD.Location = new System.Drawing.Point(145, 3);
            this.dotsCountNUD.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.dotsCountNUD.Name = "dotsCountNUD";
            this.dotsCountNUD.Size = new System.Drawing.Size(120, 23);
            this.dotsCountNUD.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 390);
            this.Controls.Add(this.Settings);
            this.Controls.Add(this.btnONOFF);
            this.Controls.Add(this.btnSettings);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Settings.ResumeLayout(false);
            this.Settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lengthBetweenNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dotsCountNUD)).EndInit();
            this.ResumeLayout(false);

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
