
namespace Conway_s_Game_Of_Life
{
    partial class SettingsForm
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
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TimerIntervalText = new System.Windows.Forms.Label();
            this.intervalSlider = new System.Windows.Forms.NumericUpDown();
            this.xCellsCount = new System.Windows.Forms.Label();
            this.YCellsCount = new System.Windows.Forms.Label();
            this.xCellSlider = new System.Windows.Forms.NumericUpDown();
            this.yCellsSlider = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xCellSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yCellsSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(248, 151);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(167, 151);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Controls.Add(this.yCellsSlider);
            this.panel1.Controls.Add(this.CancelButton);
            this.panel1.Controls.Add(this.xCellSlider);
            this.panel1.Controls.Add(this.YCellsCount);
            this.panel1.Controls.Add(this.xCellsCount);
            this.panel1.Controls.Add(this.intervalSlider);
            this.panel1.Controls.Add(this.TimerIntervalText);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 189);
            this.panel1.TabIndex = 2;
            // 
            // TimerIntervalText
            // 
            this.TimerIntervalText.AutoSize = true;
            this.TimerIntervalText.Location = new System.Drawing.Point(30, 32);
            this.TimerIntervalText.Name = "TimerIntervalText";
            this.TimerIntervalText.Size = new System.Drawing.Size(93, 13);
            this.TimerIntervalText.TabIndex = 0;
            this.TimerIntervalText.Text = "Timer Interval (ms)";
            // 
            // intervalSlider
            // 
            this.intervalSlider.Location = new System.Drawing.Point(139, 30);
            this.intervalSlider.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.intervalSlider.Name = "intervalSlider";
            this.intervalSlider.Size = new System.Drawing.Size(120, 20);
            this.intervalSlider.TabIndex = 1;
            // 
            // xCellsCount
            // 
            this.xCellsCount.AutoSize = true;
            this.xCellsCount.Location = new System.Drawing.Point(30, 69);
            this.xCellsCount.Name = "xCellsCount";
            this.xCellsCount.Size = new System.Drawing.Size(65, 13);
            this.xCellsCount.TabIndex = 2;
            this.xCellsCount.Text = "X Cell Count";
            // 
            // YCellsCount
            // 
            this.YCellsCount.AutoSize = true;
            this.YCellsCount.Location = new System.Drawing.Point(30, 108);
            this.YCellsCount.Name = "YCellsCount";
            this.YCellsCount.Size = new System.Drawing.Size(65, 13);
            this.YCellsCount.TabIndex = 3;
            this.YCellsCount.Text = "Y Cell Count";
            // 
            // xCellSlider
            // 
            this.xCellSlider.Location = new System.Drawing.Point(139, 67);
            this.xCellSlider.Name = "xCellSlider";
            this.xCellSlider.Size = new System.Drawing.Size(120, 20);
            this.xCellSlider.TabIndex = 4;
            // 
            // yCellsSlider
            // 
            this.yCellsSlider.Location = new System.Drawing.Point(139, 106);
            this.yCellsSlider.Name = "yCellsSlider";
            this.yCellsSlider.Size = new System.Drawing.Size(120, 20);
            this.yCellsSlider.TabIndex = 5;
            // 
            // SettingsForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(335, 189);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.intervalSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xCellSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yCellsSlider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown yCellsSlider;
        private System.Windows.Forms.NumericUpDown xCellSlider;
        private System.Windows.Forms.Label YCellsCount;
        private System.Windows.Forms.Label xCellsCount;
        private System.Windows.Forms.NumericUpDown intervalSlider;
        private System.Windows.Forms.Label TimerIntervalText;
    }
}