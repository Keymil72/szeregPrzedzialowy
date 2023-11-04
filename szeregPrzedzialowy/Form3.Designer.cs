namespace szeregPrzedzialowy
{
    partial class Form3
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
            button1 = new Button();
            lBEndPointData = new ListBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.BackColor = Color.WhiteSmoke;
            button1.ForeColor = Color.FromArgb(24, 24, 24);
            button1.Location = new Point(833, 24);
            button1.Name = "button1";
            button1.Size = new Size(81, 28);
            button1.TabIndex = 0;
            button1.Text = "Zamknij";
            button1.UseVisualStyleBackColor = false;
            button1.Click += CloseApp;
            // 
            // lBEndPointData
            // 
            lBEndPointData.BackColor = Color.WhiteSmoke;
            lBEndPointData.ForeColor = Color.FromArgb(24, 24, 24);
            lBEndPointData.FormattingEnabled = true;
            lBEndPointData.ItemHeight = 18;
            lBEndPointData.Location = new Point(12, 23);
            lBEndPointData.Name = "lBEndPointData";
            lBEndPointData.Size = new Size(560, 526);
            lBEndPointData.TabIndex = 1;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(584, 561);
            Controls.Add(lBEndPointData);
            Controls.Add(button1);
            Font = new Font("Hack Nerd Font", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.WhiteSmoke;
            Margin = new Padding(4);
            MaximumSize = new Size(600, 600);
            MinimumSize = new Size(600, 600);
            Name = "Form3";
            Text = "Twoje wyniki";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListBox lBEndPointData;
    }
}