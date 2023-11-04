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
            nUDIntervalCount = new NumericUpDown();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)nUDIntervalCount).BeginInit();
            SuspendLayout();
            // 
            // lBData
            // 
            lBData.BackColor = Color.WhiteSmoke;
            lBData.FormattingEnabled = true;
            lBData.ItemHeight = 18;
            lBData.Location = new Point(12, 110);
            lBData.Name = "lBData";
            lBData.Size = new Size(560, 436);
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
            btnSubmitData.Location = new Point(473, 14);
            btnSubmitData.Name = "btnSubmitData";
            btnSubmitData.Size = new Size(99, 28);
            btnSubmitData.TabIndex = 2;
            btnSubmitData.Text = "Zatwierdź";
            btnSubmitData.UseVisualStyleBackColor = true;
            btnSubmitData.Click += SubmitData;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Hack Nerd Font", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(88, 92);
            label2.Name = "label2";
            label2.Size = new Size(383, 15);
            label2.TabIndex = 3;
            label2.Text = "Szereg szczegółowy nieposortowany | posortowany";
            label2.Click += label2_Click;
            // 
            // nUDIntervalCount
            // 
            nUDIntervalCount.Location = new Point(179, 51);
            nUDIntervalCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nUDIntervalCount.Name = "nUDIntervalCount";
            nUDIntervalCount.Size = new Size(80, 25);
            nUDIntervalCount.TabIndex = 5;
            nUDIntervalCount.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 53);
            label3.Name = "label3";
            label3.Size = new Size(161, 18);
            label3.TabIndex = 6;
            label3.Text = "ilość przedziałów";
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(584, 561);
            Controls.Add(label3);
            Controls.Add(nUDIntervalCount);
            Controls.Add(label2);
            Controls.Add(btnSubmitData);
            Controls.Add(label1);
            Controls.Add(lBData);
            Font = new Font("Hack Nerd Font", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.WhiteSmoke;
            Margin = new Padding(4);
            MaximumSize = new Size(600, 600);
            MinimumSize = new Size(600, 600);
            Name = "Form2";
            Text = "Zatwierdzanie danych";
            ((System.ComponentModel.ISupportInitialize)nUDIntervalCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox lBData;
        private Button btnSubmitData;
        private Label label2;
        private NumericUpDown nUDIntervalCount;
        private Label label3;
    }
}