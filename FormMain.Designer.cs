
namespace GummySaveManager {
    partial class FormMain {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            CBox_Groups = new ComboBox();
            List_Games = new ListBox();
            Btn_AddGame = new Button();
            SuspendLayout();
            // 
            // CBox_Groups
            // 
            CBox_Groups.FormattingEnabled = true;
            CBox_Groups.Items.AddRange(new object[] { "Default" });
            CBox_Groups.Location = new Point(12, 12);
            CBox_Groups.Name = "CBox_Groups";
            CBox_Groups.Size = new Size(209, 23);
            CBox_Groups.TabIndex = 0;
            CBox_Groups.SelectedIndexChanged += CBox_Groups_SelectedIndexChanged;
            // 
            // List_Games
            // 
            List_Games.FormattingEnabled = true;
            List_Games.ItemHeight = 15;
            List_Games.Location = new Point(12, 41);
            List_Games.Name = "List_Games";
            List_Games.Size = new Size(209, 379);
            List_Games.TabIndex = 1;
            // 
            // Btn_AddGame
            // 
            Btn_AddGame.Location = new Point(29, 426);
            Btn_AddGame.Name = "Btn_AddGame";
            Btn_AddGame.Size = new Size(168, 23);
            Btn_AddGame.TabIndex = 2;
            Btn_AddGame.Text = "Add Game";
            Btn_AddGame.UseVisualStyleBackColor = true;
            Btn_AddGame.Click += Btn_AddGame_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 457);
            Controls.Add(Btn_AddGame);
            Controls.Add(List_Games);
            Controls.Add(CBox_Groups);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormMain";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private ComboBox CBox_Groups;
        private ListBox List_Games;
        private Button Btn_AddGame;
    }
}
