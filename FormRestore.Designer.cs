namespace GummySaveManager {
    partial class FormRestore {
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
            GV_Restore = new DataGridView();
            Btn_Restore = new Button();
            OriginalName = new DataGridViewTextBoxColumn();
            Target = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)GV_Restore).BeginInit();
            SuspendLayout();
            // 
            // GV_Restore
            // 
            GV_Restore.AllowUserToAddRows = false;
            GV_Restore.AllowUserToDeleteRows = false;
            GV_Restore.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            GV_Restore.Columns.AddRange(new DataGridViewColumn[] { OriginalName, Target });
            GV_Restore.Location = new Point(12, 12);
            GV_Restore.Name = "GV_Restore";
            GV_Restore.Size = new Size(574, 226);
            GV_Restore.TabIndex = 0;
            // 
            // Btn_Restore
            // 
            Btn_Restore.Location = new Point(492, 244);
            Btn_Restore.Name = "Btn_Restore";
            Btn_Restore.Size = new Size(93, 31);
            Btn_Restore.TabIndex = 1;
            Btn_Restore.Text = "Confirm";
            Btn_Restore.UseVisualStyleBackColor = true;
            Btn_Restore.Click += Btn_Restore_Click;
            // 
            // OriginalName
            // 
            OriginalName.HeaderText = "Folder Name";
            OriginalName.Name = "OriginalName";
            OriginalName.ReadOnly = true;
            // 
            // Target
            // 
            Target.HeaderText = "Destination";
            Target.Name = "Target";
            Target.ReadOnly = true;
            // 
            // FormRestore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(597, 287);
            Controls.Add(Btn_Restore);
            Controls.Add(GV_Restore);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormRestore";
            Text = "FormRestore";
            ((System.ComponentModel.ISupportInitialize)GV_Restore).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView GV_Restore;
        private Button Btn_Restore;
        private DataGridViewTextBoxColumn OriginalName;
        private DataGridViewTextBoxColumn Target;
    }
}