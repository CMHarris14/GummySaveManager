namespace GummySaveManager {
    public partial class FormMain : Form {

        private readonly SaveManager SavesManager = [];
        public FormMain() {
            InitializeComponent();
            SavesManager.LoadFromFile();
            RefreshGameList();
            //List_Games.Items.Add(SaveManager[0].name);
        }

        private void CBox_Groups_SelectedIndexChanged(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        private void Btn_AddGame_Click(object sender, EventArgs e) {
            //GameSave fireE = new("Fire Emblem", "Default");
            //fireE.AddFolderPath("E:\\Downloads\\assetwork");
            //fireE.AddFolderPath("C:\\Users\\Cain\\Desktop\\Data");
            //fireE.AddBackup("testback");
            //SavesManager.Add(fireE);
            //RefreshGameList();
            //SaveManager(SavesManager);
        }

        private void RefreshGameList() {
            foreach (GameSave game in SavesManager) {
                List_Games.Items.Add(game.name);
            }
        }
    }
}
