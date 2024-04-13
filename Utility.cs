using System.Diagnostics;
using Newtonsoft.Json;

namespace GummySaveManager {
    internal class Utility {
        public static string BackupPath = ".\\Backups\\";
        public static string DataPath = ".\\Data\\";

        static Utility() {
            PokeDirectory(BackupPath);
            PokeDirectory(DataPath);
        }

        public static void PokeDirectory(string directory) {
            if (!Directory.Exists(directory)) {
                Directory.CreateDirectory(directory);
            }
        }

        public static void GMove(string source, string destination) {
            //Error if the source doesn't exist. Can't move nothing
            if (!Directory.Exists(source)) {
                throw new FileNotFoundException($"Source file does not exist: {source}");
            }
            try {
                Logger.LogMessage($"Attempting to move {source} to {destination}");
                if (File.Exists(source)) {
                    File.Copy(source, destination, true);
                    File.Delete(source);
                }
                else if (Directory.Exists(destination)) {
                    CopyDirectory(destination, source);
                }
                Logger.LogMessage("Success");
            }
            catch (Exception ex) {
                Logger.LogMessage($"Failed to move \"{source}\": {ex.Message}", Logger.Severity.ERROR);
            }
        }

        public static void CopyFilesAndFolders(List<string> paths, string destinationFolder) {
            PokeDirectory(destinationFolder);
            foreach (string path in paths) {
                try {
                    if (File.Exists(path)) {
                        string fileName = Path.GetFileName(path);
                        string destinationPath = Path.Combine(destinationFolder, fileName);
                        File.Copy(path, destinationPath, true);
                        Logger.LogMessage($"Copied file: {path} to {destinationPath}");
                    }
                    else if (Directory.Exists(path)) {
                        string folderName = new DirectoryInfo(path).Name;
                        string destinationFolderPath = Path.Combine(destinationFolder, folderName);
                        Directory.CreateDirectory(destinationFolderPath);
                        CopyDirectory(path, destinationFolderPath);
                        Logger.LogMessage($"Copied folder: {path} to {destinationFolderPath}");
                    }
                    else {
                        Logger.LogMessage($"Tried to copy path that does not exist: {path}", Logger.Severity.WARN);
                    }
                }
                catch (Exception ex) {
                    Logger.LogMessage($"Failed copying {path}: {ex.Message}", Logger.Severity.ERROR);
                }
            }
        }

        public static void CopyDirectory(string sourceDir, string targetDir) {
            Directory.CreateDirectory(targetDir);

            foreach (string file in Directory.GetFiles(sourceDir)) {
                string fileName = Path.GetFileName(file);
                string destFile = Path.Combine(targetDir, fileName);
                File.Copy(file, destFile, true);
            }

            foreach (string subDir in Directory.GetDirectories(sourceDir)) {
                string folderName = new DirectoryInfo(subDir).Name;
                string destDir = Path.Combine(targetDir, folderName);
                CopyDirectory(subDir, destDir);
            }
        }

        public static void SaveClass(object toSave) {
            string json = JsonConvert.SerializeObject(toSave, Formatting.Indented);
            try {
                File.WriteAllText(".\\Data\\saves.json", json);
                Logger.LogMessage("Saved game data successfully");
            }
            catch (Exception ex) {
                Logger.LogMessage($"Failed to save game data - {ex.Message}", Logger.Severity.ERROR);
            }
        }

        public static SaveManager LoadManagerFromFile() {
            if (File.Exists(DataPath + ".\\saves.json")) {
                string loadedJson = File.ReadAllText(DataPath + ".\\saves.json");
                return JsonConvert.DeserializeObject<SaveManager>(loadedJson) ?? new();
            }
            return new();
        }
    }


    internal class Logger {
        private static readonly string logDirectory = "Logs";
        private static readonly string logFilePath = Path.Combine(logDirectory, "output-" + DateTime.Now.ToString("dd-MM-yyyy")) + ".log";

        public enum Severity { INFO, WARN, ERROR }

        private static readonly int daysToKeepLogs = 10;

        static Logger() {
            PokeDirectory(logDirectory);

            foreach (string filePath in Directory.GetFiles(logDirectory)) {
                FileInfo fileInfo = new(filePath);
                TimeSpan age = DateTime.Now - fileInfo.CreationTime;
                if (age.Days > daysToKeepLogs) {
                    try {
                        File.Delete(filePath);
                    }
                    catch (Exception ex) {
                        LogMessage($"Failed to delete old log \"{filePath}\" - {ex.Message}", Severity.ERROR);
                    }
                }
            }
        }

        public static void LogMessage(string message, Severity severity = Severity.INFO) {
            Console.WriteLine(message);
            switch (severity) {
                case Severity.WARN:
                    message = "[WARN] " + message; break;
                case Severity.ERROR:
                    message = "[ERROR] " + message; break;
            }
            AppendToFile(logFilePath, message);
        }

        private static void AppendToFile(string filePath, string toAdd) {
            try {
                using StreamWriter writer = File.AppendText(filePath);
                writer.WriteLine($"[{DateTime.Now}] {toAdd}");
            }
            catch (Exception ex) {
                Debug.WriteLine($"Error writing to log file: {ex.Message}");
            }
        }
    }
}
