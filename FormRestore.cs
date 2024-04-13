using static GummySaveManager.SaveManager;
using static GummySaveManager.Compressor;

namespace GummySaveManager {
    public partial class FormRestore : Form {
        private readonly BackupInfo backup;
        private readonly string gameName;
        public FormRestore(string gameName, BackupInfo backup) {
            InitializeComponent();
            GV_Restore.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            this.gameName = gameName;
            this.backup = backup;

            foreach (Tuple<string, string> pair in this.backup.FileRelations) {
                int rowIndex = GV_Restore.Rows.Add();
                GV_Restore.Rows[rowIndex].Cells[0].Value = pair.Item1;
                GV_Restore.Rows[rowIndex].Cells[1].Value = pair.Item2;
            }
        }

        private void Btn_Restore_Click(object sender, EventArgs e) {
            DialogResult result = MessageBox.Show("Are you sure? Existing files may be overwritten.", "Confirmation", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) {
                Decompress(BackupPath + gameName + "\\" + backup.BackupName + ".zip");
                foreach (Tuple<string, string> pair in backup.FileRelations) {
                    try {
                        GMove(".\\tmp\\" + pair.Item1, pair.Item2);
                    }
                    catch (Exception ex) {
                        Logger.LogMessage(ex.Message, Logger.Severity.ERROR);
                    }
                }
                try {
                    Directory.Delete(".\\tmp", true);
                }
                catch (Exception ex) {
                    Logger.LogMessage(ex.Message, Logger.Severity.ERROR);
                }

                this.Close();
            }
        }
    }
}
