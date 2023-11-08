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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            lBEndPointData = new ListBox();
            btnSaveToExcel = new Button();
            label1 = new Label();
            tBFilePath = new TextBox();
            SuspendLayout();
            // 
            // lBEndPointData
            // 
            resources.ApplyResources(lBEndPointData, "lBEndPointData");
            lBEndPointData.BackColor = Color.WhiteSmoke;
            lBEndPointData.ForeColor = Color.FromArgb(24, 24, 24);
            lBEndPointData.FormattingEnabled = true;
            lBEndPointData.Name = "lBEndPointData";
            // 
            // btnSaveToExcel
            // 
            resources.ApplyResources(btnSaveToExcel, "btnSaveToExcel");
            btnSaveToExcel.BackColor = Color.WhiteSmoke;
            btnSaveToExcel.ForeColor = Color.FromArgb(24, 24, 24);
            btnSaveToExcel.Name = "btnSaveToExcel";
            btnSaveToExcel.UseVisualStyleBackColor = false;
            btnSaveToExcel.Click += FileLoad;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // tBFilePath
            // 
            resources.ApplyResources(tBFilePath, "tBFilePath");
            tBFilePath.Name = "tBFilePath";
            // 
            // Form3
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(24, 24, 24);
            Controls.Add(tBFilePath);
            Controls.Add(label1);
            Controls.Add(btnSaveToExcel);
            Controls.Add(lBEndPointData);
            ForeColor = Color.WhiteSmoke;
            Name = "Form3";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListBox lBEndPointData;
        private Button btnSaveToExcel;
        private Label label1;
        private TextBox tBFilePath;
    }
}