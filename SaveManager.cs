using static GummySaveManager.Compressor;
using Newtonsoft.Json;
using System.Collections;
using System.Diagnostics;

namespace GummySaveManager {
    //Holds the relations between folders in the archive and their original position 
    //Needed to suggest restore locations later
    internal struct BackupInfo {
        public string BackupName;
        //Relations are <folder name, original path>
        public List<Tuple<string, string>> FileRelations;

        public BackupInfo() {
            this.BackupName = "";
            this.FileRelations = [];
        }
    }
    internal class GameSave {
        public string name;
        [JsonProperty("folderPaths")]
        private readonly List<string> folderPaths = [];
        [JsonProperty("backups")]
        private readonly List<BackupInfo> backups = [];
        [JsonProperty("category")]
        public string category = "";

        public GameSave(string name, string category) {
            this.name = name;
            this.category = category;
        }

        public void AddFolderPath(string path) { folderPaths.Add(path); }

        public void RemoveFolderPath(string path) { folderPaths.Remove(path); }

        public List<string> GetFolderPaths() { return folderPaths; }

        public void AddBackup(string backupName) {
            //Check to make sure the name is unique in the backup list
            foreach (BackupInfo backup in this.backups) {
                Debug.WriteLine($"Backup name {backup.BackupName}");
                if (backup.BackupName == backupName) {
                    throw new Exception("Error: A backup with that name already exists");
                }
            }

            //Make sure the backup directory exists
            PokeDirectory(Settings.BackupPath + this.name);

            CopyFilesAndFolders(this.folderPaths, ".\\tmp\\");
            CompressDirectory(".\\tmp", Settings.BackupPath + this.name + "\\" + backupName + ".zip");
            Directory.Delete(".\\tmp", true);

            //Get the original locations and file names to the backup
            List<string> fileNames = [];
            foreach (string path in folderPaths) {
                string directoryName = Path.GetFileName(path) ?? "";
                if (directoryName.Length > 0) {
                    fileNames.Add(directoryName);
                }
            }
            BackupInfo newBackup = new() { BackupName = backupName };
            newBackup.FileRelations = fileNames.Zip(this.folderPaths, (first, second) => Tuple.Create(first, second)).ToList();
            this.backups.Add(newBackup);
        }

        public void RestoreBackup(int backupId) {
            BackupInfo toRestore = this.backups[backupId];
            FormRestore formRestore = new(name, toRestore);
            formRestore.ShowDialog();
        }

        public void RemoveBackup(string backupName) {
            backups.RemoveAll(backup => backup.BackupName == backupName);
        }

        public List<BackupInfo> GetBackups() {
            return backups;
        }

    }
    internal class SaveManager : IEnumerable<GameSave> {
        private List<GameSave> saves = [];

        public SaveManager() {

        }

        public void Add(GameSave save) {
            saves.Add(save);
        }

        public List<string> GetCategories() {
            HashSet<string> categories = [];
            foreach(GameSave save in saves) {
                categories.Add(save.category);
            }
            return [.. categories];
        }

        public void Save() {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            try {
                File.WriteAllText(Settings.DataFilePath(), json);
                Logger.LogMessage("Saved game data successfully");
            }
            catch (Exception ex) {
                Logger.LogMessage($"Failed to save game data - {ex.Message}", Logger.Severity.ERROR);
            }
        }

        public void LoadFromFile() {
            if (File.Exists(Settings.DataFilePath())) {
                Logger.LogMessage(Settings.DataFilePath());
                string loadedJson = File.ReadAllText(Settings.DataFilePath());
                saves = JsonConvert.DeserializeObject<List<GameSave>>(loadedJson) ?? [];
            }else {
                Logger.LogMessage("Save file does not exist. It will be generated when any saves are created.");
            }
        }

        public GameSave this[int index] {
            get {
                if (index < 0 || index >= saves.Count) {
                    throw new IndexOutOfRangeException($"Index {index} is out of range");
                }
                return saves[index];
            }
            set {
                if (index < 0 || index >= saves.Count) {
                    throw new IndexOutOfRangeException($"Index {index} is out of range");
                }
                saves[index] = value;
            }
        }

        public IEnumerator<GameSave> GetEnumerator() {
            return saves.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}