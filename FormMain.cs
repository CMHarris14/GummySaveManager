namespace GummySaveManager {
    public partial class FormMain : Form {

        private SaveManager SavesManager = LoadManagerFromFile();
        public FormMain() {
            InitializeComponent();
            //List_Games.Items.Add(SaveManager[0].name);
        }

        private void CBox_Groups_SelectedIndexChanged(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void Btn_AddGame_Click(object sender, EventArgs e) {
            GameSave fireE = new("Fire Emblem");
            fireE.AddFolderPath("E:\\Downloads\\assetwork");
            fireE.AddFolderPath("C:\\Users\\Cain\\Desktop\\Data");
            fireE.AddBackup("testback");
            SavesManager.Add(fireE);
            RefreshGameList();
            SaveClass(SavesManager);
        }

        private void RefreshGameList() {
            foreach(GameSave game in SavesManager) {
                List_Games.Items.Add(game.name);
            }
        }
    }
}
