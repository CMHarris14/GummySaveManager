namespace GummySaveManager {
    public partial class FormMain : Form {

        private readonly SaveManager SavesManager = [];
        public FormMain() {
            InitializeComponent();
            //Verify settings folders exists and load the settings
            Settings.Load();
            PokeDirectory(Settings.BackupPath);
            SavesManager.LoadFromFile();

            Refresh_CBox_Groups();

            try {
                CBox_Groups.SelectedIndex = 0;
            }
            catch {
                Logger.LogMessage("No games exist so the category box cannot default to any value");
            }
        }

        private void CBox_Groups_SelectedIndexChanged(object sender, EventArgs e) {
            Refresh_GameList();
        }

        private void Refresh_CBox_Groups() {
            CBox_Groups.Items.Clear();
            CBox_Groups.Items.AddRange(SavesManager.GetCategories().ToArray());
        }

        private void Btn_AddGame_Click(object sender, EventArgs e) {
            GameSave fireE = new("Fire Emblem", "Retro");
            fireE.AddFolderPath("E:\\Downloads\\assetwork");
            fireE.AddBackup("testback");
            SavesManager.Add(fireE);
            Refresh_GameList();
            SavesManager.Save();

            Refresh_CBox_Groups();
            CBox_Groups.SelectedIndex = CBox_Groups.Items.IndexOf(fireE.category);
            
        }

        private void Refresh_GameList() {
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
