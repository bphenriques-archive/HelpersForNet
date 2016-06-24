using System.Diagnostics;
using System.IO;

namespace HelpersForNet {
    /// <summary>
    /// Wraps common operations with processes
    /// </summary>
    public class ProcessUtil {
        /// <summary>
        /// Execute a new process with the executable on the given filepath with the arguments given
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="arguments"></param>
        public static void ExecuteNewProcess(string filePath, string arguments) {
            string fileName = Path.GetFileName(filePath);
            string workingDirectory = Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar;

            ProcessStartInfo startInfo = new ProcessStartInfo(filePath);
            startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            startInfo.Arguments = arguments;
            startInfo.WorkingDirectory = workingDirectory;

            Process.Start(startInfo);
        }

        /// <summary>
        /// Opens the explorer in the given folder
        /// </summary>
        /// <param name="folderPath"></param>
        public static void OpenFolder(string folderPath) {
            ExecuteNewProcess("explorer.exe", folderPath);
        }
    }
}
