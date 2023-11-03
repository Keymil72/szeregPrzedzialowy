namespace szeregPrzedzialowy
{
    partial class Form2
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
            lBData = new ListBox();
            label1 = new Label();
            btnSubmitData = new Button();
            label2 = new Label();
            SuspendLayout();
            // 
            // lBData
            // 
            lBData.BackColor = Color.WhiteSmoke;
            lBData.FormattingEnabled = true;
            lBData.ItemHeight = 18;
            lBData.Location = new Point(12, 74);
            lBData.Name = "lBData";
            lBData.Size = new Size(380, 454);
            lBData.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(233, 18);
            label1.TabIndex = 1;
            label1.Text = "Sprawdź poprawność danych";
            // 
            // btnSubmitData
            // 
            btnSubmitData.AutoSize = true;
            btnSubmitData.ForeColor = Color.FromArgb(24, 24, 24);
            btnSubmitData.Location = new Point(293, 14);
            btnSubmitData.Name = "btnSubmitData";
            btnSubmitData.Size = new Size(99, 28);
            btnSubmitData.TabIndex = 2;
            btnSubmitData.Text = "Zatwierdź";
            btnSubmitData.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Hack Nerd Font", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(9, 56);
            label2.Name = "label2";
            label2.Size = new Size(383, 15);
            label2.TabIndex = 3;
            label2.Text = "Szereg szczegółowy nieposortowany | posortowany";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(404, 541);
            Controls.Add(label2);
            Controls.Add(btnSubmitData);
            Controls.Add(label1);
            Controls.Add(lBData);
            Font = new Font("Hack Nerd Font", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.WhiteSmoke;
            Margin = new Padding(4);
            MaximumSize = new Size(420, 580);
            MinimumSize = new Size(420, 580);
            Name = "Form2";
            Text = "Zatwierdzanie danych";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBox1;
        private Label label1;
        private Button button1;
        private ListBox lBData;
        private Button btnSubmitData;
        private Label label2;
    }
}