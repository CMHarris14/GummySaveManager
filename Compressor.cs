using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GummySaveManager.Utility;

namespace GummySaveManager {
    internal class Compressor {
        static public void CompressDirectory(string directory, string destination) {
            if (Directory.Exists(directory)) {
                Logger.LogMessage($"Compressing {directory} to {destination}");
                RunProcess("7za.exe", "a -r \"" + destination + "\" \"" + directory + "\"");
            }
        }

        static public void Decompress(string target) {
            if (File.Exists(target)) {
                Logger.LogMessage($"Extracting {target}");
                RunProcess("7za.exe", "x \"" + target + "\"");
            }
        }

        static public void Decompress(string target, string destination) {
            PokeDirectory(destination);
            if (File.Exists(target)) {
                Logger.LogMessage($"Extracting {target} to {destination}");
                RunProcess("7za.exe", "x \"" + target + "\"" + " -o \"" + destination + "\"");
            }
        }

        static private void RunProcess(string fileName, string args) {
            ProcessStartInfo startInfo = new() { FileName = fileName, Arguments = args };
            Process process = new() { StartInfo = startInfo };

            try {
                process.Start();
            }
            catch (Exception ex) {
                Logger.LogMessage(ex.Message, Logger.Severity.ERROR);
            }

            process.WaitForExit();
        }
    }
}
