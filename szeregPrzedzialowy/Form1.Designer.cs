namespace szeregPrzedzialowy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnSelectFile = new Button();
            tBFilePath = new TextBox();
            SuspendLayout();
            // 
            // btnSelectFile
            // 
            btnSelectFile.AutoSize = true;
            btnSelectFile.BackColor = Color.WhiteSmoke;
            btnSelectFile.ForeColor = Color.FromArgb(24, 24, 24);
            btnSelectFile.Location = new Point(12, 50);
            btnSelectFile.Name = "btnSelectFile";
            btnSelectFile.Size = new Size(189, 28);
            btnSelectFile.TabIndex = 0;
            btnSelectFile.Text = "Wczytaj plik danych";
            btnSelectFile.UseVisualStyleBackColor = false;
            btnSelectFile.Click += FileLoad;
            // 
            // tBFilePath
            // 
            tBFilePath.AllowDrop = true;
            tBFilePath.AutoCompleteMode = AutoCompleteMode.Suggest;
            tBFilePath.AutoCompleteSource = AutoCompleteSource.FileSystem;
            tBFilePath.BackColor = Color.WhiteSmoke;
            tBFilePath.Font = new Font("Hack Nerd Font", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            tBFilePath.ForeColor = Color.FromArgb(24, 24, 24);
            tBFilePath.Location = new Point(12, 12);
            tBFilePath.Name = "tBFilePath";
            tBFilePath.Size = new Size(298, 20);
            tBFilePath.TabIndex = 1;
            // 
            // Form1
            // 
            AcceptButton = btnSelectFile;
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            ClientSize = new Size(586, 122);
            Controls.Add(tBFilePath);
            Controls.Add(btnSelectFile);
            Font = new Font("Hack Nerd Font", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.WhiteSmoke;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Wybierz plik danych (.txt)";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSelectFile;
        private TextBox tBFilePath;
    }
}