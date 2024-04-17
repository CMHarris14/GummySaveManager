namespace GummySaveManager {
    partial class FormSettings {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            TB_DataFolder = new TextBox();
            label1 = new Label();
            TB_BackupsFolder = new TextBox();
            label2 = new Label();
            Btn_DataFolder = new Button();
            Btn_BackupsFolder = new Button();
            Btn_Save = new Button();
            SuspendLayout();
            // 
            // TB_DataFolder
            // 
            TB_DataFolder.Font = new Font("Microsoft Sans Serif", 14.25F);
            TB_DataFolder.Location = new Point(184, 15);
            TB_DataFolder.Name = "TB_DataFolder";
            TB_DataFolder.ReadOnly = true;
            TB_DataFolder.Size = new Size(477, 29);
            TB_DataFolder.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 14.25F);
            label1.Location = new Point(56, 15);
            label1.Name = "label1";
            label1.Size = new Size(122, 24);
            label1.TabIndex = 1;
            label1.Text = "Data Folder : ";
            // 
            // TB_BackupsFolder
            // 
            TB_BackupsFolder.Font = new Font("Microsoft Sans Serif", 14.25F);
            TB_BackupsFolder.Location = new Point(184, 57);
            TB_BackupsFolder.Name = "TB_BackupsFolder";
            TB_BackupsFolder.ReadOnly = true;
            TB_BackupsFolder.Size = new Size(477, 29);
            TB_BackupsFolder.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 14.25F);
            label2.Location = new Point(21, 57);
            label2.Name = "label2";
            label2.Size = new Size(157, 24);
            label2.TabIndex = 1;
            label2.Text = "Backups Folder : ";
            // 
            // Btn_DataFolder
            // 
            Btn_DataFolder.Location = new Point(667, 15);
            Btn_DataFolder.Name = "Btn_DataFolder";
            Btn_DataFolder.Size = new Size(61, 29);
            Btn_DataFolder.TabIndex = 2;
            Btn_DataFolder.Text = "Browse";
            Btn_DataFolder.UseVisualStyleBackColor = true;
            Btn_DataFolder.Click += Btn_DataFolder_Click;
            // 
            // Btn_BackupsFolder
            // 
            Btn_BackupsFolder.Location = new Point(667, 57);
            Btn_BackupsFolder.Name = "Btn_BackupsFolder";
            Btn_BackupsFolder.Size = new Size(61, 29);
            Btn_BackupsFolder.TabIndex = 2;
            Btn_BackupsFolder.Text = "Browse";
            Btn_BackupsFolder.UseVisualStyleBackColor = true;
            Btn_BackupsFolder.Click += Btn_BackupsFolder_Click;
            // 
            // Btn_Save
            // 
            Btn_Save.Location = new Point(633, 97);
            Btn_Save.Name = "Btn_Save";
            Btn_Save.Size = new Size(91, 29);
            Btn_Save.TabIndex = 2;
            Btn_Save.Text = "Save";
            Btn_Save.UseVisualStyleBackColor = true;
            Btn_Save.Click += Btn_Save_Click;
            // 
            // FormSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(736, 138);
            Controls.Add(Btn_Save);
            Controls.Add(Btn_BackupsFolder);
            Controls.Add(Btn_DataFolder);
            Controls.Add(label2);
            Controls.Add(TB_BackupsFolder);
            Controls.Add(label1);
            Controls.Add(TB_DataFolder);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FormSettings";
            Text = "FormSettings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox TB_DataFolder;
        private Label label1;
        private TextBox TB_BackupsFolder;
        private Label label2;
        private Button Btn_DataFolder;
        private Button Btn_BackupsFolder;
        private Button Btn_Save;
    }
}