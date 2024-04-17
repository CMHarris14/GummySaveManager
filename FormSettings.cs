using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GummySaveManager {
    public partial class FormSettings : Form {
        public FormSettings() {
            InitializeComponent();
            TB_DataFolder.Text = Settings.DataPath;
            TB_BackupsFolder.Text = Settings.BackupPath;
        }

        private void Btn_DataFolder_Click(object sender, EventArgs e) {
            string newPath = AskForPath();
            if (newPath != string.Empty) {
                TB_DataFolder.Text = newPath;
            }
        }

        private void Btn_BackupsFolder_Click(object sender, EventArgs e) {
            string newPath = AskForPath();
            if (newPath != string.Empty) {
                TB_BackupsFolder.Text = newPath;
            }
        }

        private void Btn_Save_Click(object sender, EventArgs e) {
            if (TB_BackupsFolder.Text != Settings.BackupPath) {
                DialogResult result = MessageBox.Show("Backups will be moved to the new location", "Confirmation", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK) {
                    string oldPath = Settings.BackupPath;
                    Settings.BackupPath = TB_BackupsFolder.Text;
                    GMove(oldPath, Settings.BackupPath);
                }else {
                    this.Close();
                }
            }
            Settings.DataPath = TB_DataFolder.Text;
            Settings.Save();
            this.Close();
        }

        private static string AskForPath() {
            using FolderBrowserDialog folderBrowser = new();
            DialogResult result = folderBrowser.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowser.SelectedPath)) {
                return folderBrowser.SelectedPath;
            }
            else {
                return string.Empty;
            }
        }
    }
}
