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
            this.ViewSwitcher = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ViewSwitcher
            // 
            this.ViewSwitcher.Location = new System.Drawing.Point(1037, 479);
            this.ViewSwitcher.Name = "ViewSwitcher";
            this.ViewSwitcher.Size = new System.Drawing.Size(75, 23);
            this.ViewSwitcher.TabIndex = 0;
            this.ViewSwitcher.Text = "to 3D";
            this.ViewSwitcher.UseVisualStyleBackColor = true;
            this.ViewSwitcher.Click += new System.EventHandler(this.ViewSwitcher_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.ViewSwitcher);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ViewSwitcher;
    }
}

