namespace GummySaveManager {
    public partial class FormMain : Form {

        private readonly SaveManager SavesManager = [];
        public FormMain() {
            InitializeComponent();
            //Verify settings folders exists and load the settings
            PokeDirectory(Settings.BackupPath);
            Settings.Load();
            SavesManager.LoadFromFile();

            CBox_Groups.Items.AddRange(SavesManager.GetCategories().ToArray());
        }

        private void CBox_Groups_SelectedIndexChanged(object sender, EventArgs e) {
            RefreshGameList();
        }

        private void Btn_AddGame_Click(object sender, EventArgs e) {
            GameSave fireE = new("Fire Emblem", "Buttstuff");
            fireE.AddFolderPath("E:\\Downloads\\assetwork");
            fireE.AddFolderPath("C:\\Users\\Cain\\Desktop\\Data");
            fireE.AddBackup("testback");
            SavesManager.Add(fireE);
            RefreshGameList();
            SavesManager.Save();
        }

        private void RefreshGameList() {
            List_Games.Items.Clear();
            foreach (GameSave game in SavesManager) {
                if (game.category == CBox_Groups.Text) {
                    List_Games.Items.Add(game.name);
                }
            }
        }

        private void Btn_Settings_Click(object sender, EventArgs e) {
            FormSettings settings = new();
            settings.ShowDialog();
        }
    }
}
