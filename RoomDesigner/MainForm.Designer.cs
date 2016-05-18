namespace RoomDesigner
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ViewSwitcherBtn = new System.Windows.Forms.Button();
            this.openJsonBtn = new System.Windows.Forms.Button();
            this.Scale_lbl = new System.Windows.Forms.Label();
            this.Scale1_lbl = new System.Windows.Forms.Label();
            this.Scale_tb = new System.Windows.Forms.TextBox();
            this.ctrBar = new System.Windows.Forms.Panel();
            this.ctrBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ViewSwitcherBtn
            // 
            this.ViewSwitcherBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ViewSwitcherBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ViewSwitcherBtn.Location = new System.Drawing.Point(17, 18);
            this.ViewSwitcherBtn.Name = "ViewSwitcherBtn";
            this.ViewSwitcherBtn.Size = new System.Drawing.Size(112, 85);
            this.ViewSwitcherBtn.TabIndex = 0;
            this.ViewSwitcherBtn.Text = "to 3D";
            this.ViewSwitcherBtn.UseVisualStyleBackColor = false;
            this.ViewSwitcherBtn.Click += new System.EventHandler(this.ViewSwitcherBtn_Click);
            // 
            // openJsonBtn
            // 
            this.openJsonBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.openJsonBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.openJsonBtn.Location = new System.Drawing.Point(1000, 30);
            this.openJsonBtn.Name = "openJsonBtn";
            this.openJsonBtn.Size = new System.Drawing.Size(112, 44);
            this.openJsonBtn.TabIndex = 1;
            this.openJsonBtn.Text = "Open Json File";
            this.openJsonBtn.UseVisualStyleBackColor = false;
            this.openJsonBtn.Click += new System.EventHandler(this.openJsonBtn_Click);
            // 
            // Scale_lbl
            // 
            this.Scale_lbl.AutoSize = true;
            this.Scale_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Scale_lbl.Location = new System.Drawing.Point(38, 522);
            this.Scale_lbl.Name = "Scale_lbl";
            this.Scale_lbl.Size = new System.Drawing.Size(54, 20);
            this.Scale_lbl.TabIndex = 2;
            this.Scale_lbl.Text = "Scale";
            // 
            // Scale1_lbl
            // 
            this.Scale1_lbl.AutoSize = true;
            this.Scale1_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Scale1_lbl.Location = new System.Drawing.Point(26, 545);
            this.Scale1_lbl.Name = "Scale1_lbl";
            this.Scale1_lbl.Size = new System.Drawing.Size(44, 20);
            this.Scale1_lbl.TabIndex = 3;
            this.Scale1_lbl.Text = "1    :";
            // 
            // Scale_tb
            // 
            this.Scale_tb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Scale_tb.Location = new System.Drawing.Point(77, 545);
            this.Scale_tb.Name = "Scale_tb";
            this.Scale_tb.Size = new System.Drawing.Size(52, 26);
            this.Scale_tb.TabIndex = 4;
            this.Scale_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Scale_tb.TextChanged += new System.EventHandler(this.Scale_tb_TextChanged);
            // 
            // ctrBar
            // 
            this.ctrBar.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ctrBar.Controls.Add(this.ViewSwitcherBtn);
            this.ctrBar.Controls.Add(this.Scale_tb);
            this.ctrBar.Controls.Add(this.Scale_lbl);
            this.ctrBar.Controls.Add(this.Scale1_lbl);
            this.ctrBar.Location = new System.Drawing.Point(982, 110);
            this.ctrBar.Name = "ctrBar";
            this.ctrBar.Size = new System.Drawing.Size(142, 588);
            this.ctrBar.TabIndex = 5;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.ctrBar);
            this.Controls.Add(this.openJsonBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Room Designer v. 1.0";
            this.ctrBar.ResumeLayout(false);
            this.ctrBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ViewSwitcherBtn;
        private System.Windows.Forms.Button openJsonBtn;
        private System.Windows.Forms.Label Scale_lbl;
        private System.Windows.Forms.Label Scale1_lbl;
        private System.Windows.Forms.TextBox Scale_tb;
        private System.Windows.Forms.Panel ctrBar;
    }
}

