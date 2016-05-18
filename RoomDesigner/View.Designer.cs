namespace RoomDesigner
{
    partial class View
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.DrawingPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // DrawingPanel
            // 
            this.DrawingPanel.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.DrawingPanel.Location = new System.Drawing.Point(10, 10);
            this.DrawingPanel.Name = "DrawingPanel";
            this.DrawingPanel.Size = new System.Drawing.Size(560, 461);
            this.DrawingPanel.TabIndex = 0;
            this.DrawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingPanel_Paint);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.DrawingPanel);
            this.Name = "View";
            this.Size = new System.Drawing.Size(948, 750);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.View_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel DrawingPanel;
    }
}
