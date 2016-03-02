namespace ZombieEditor
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
            this.txtBoxHP = new System.Windows.Forms.TextBox();
            this.txtBoxAtt = new System.Windows.Forms.TextBox();
            this.txtBoxSpeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.resetBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBoxHP
            // 
            this.txtBoxHP.Location = new System.Drawing.Point(104, 78);
            this.txtBoxHP.Name = "txtBoxHP";
            this.txtBoxHP.Size = new System.Drawing.Size(100, 20);
            this.txtBoxHP.TabIndex = 0;
            this.txtBoxHP.Text = "100";
            // 
            // txtBoxAtt
            // 
            this.txtBoxAtt.Location = new System.Drawing.Point(104, 147);
            this.txtBoxAtt.Name = "txtBoxAtt";
            this.txtBoxAtt.Size = new System.Drawing.Size(100, 20);
            this.txtBoxAtt.TabIndex = 1;
            this.txtBoxAtt.Text = "1";
            // 
            // txtBoxSpeed
            // 
            this.txtBoxSpeed.Location = new System.Drawing.Point(104, 214);
            this.txtBoxSpeed.Name = "txtBoxSpeed";
            this.txtBoxSpeed.Size = new System.Drawing.Size(100, 20);
            this.txtBoxSpeed.TabIndex = 2;
            this.txtBoxSpeed.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Zombie\'s Health:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Zombie\'s Attack:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Zombie\'s Speed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(101, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Zombie Attribute Editor";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(235, 110);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(75, 23);
            this.SaveBtn.TabIndex = 7;
            this.SaveBtn.Text = "Save";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // resetBtn
            // 
            this.resetBtn.Location = new System.Drawing.Point(235, 187);
            this.resetBtn.Name = "resetBtn";
            this.resetBtn.Size = new System.Drawing.Size(75, 23);
            this.resetBtn.TabIndex = 8;
            this.resetBtn.Text = "Reset";
            this.resetBtn.UseVisualStyleBackColor = true;
            this.resetBtn.Click += new System.EventHandler(this.resetBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 263);
            this.Controls.Add(this.resetBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBoxSpeed);
            this.Controls.Add(this.txtBoxAtt);
            this.Controls.Add(this.txtBoxHP);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBoxHP;
        private System.Windows.Forms.TextBox txtBoxAtt;
        private System.Windows.Forms.TextBox txtBoxSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SaveBtn;
        private System.Windows.Forms.Button resetBtn;
    }
}

