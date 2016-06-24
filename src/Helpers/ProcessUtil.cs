using System.Diagnostics;
using System.IO;

namespace Helpers {
    public class ProcessUtil {
        public static void ExecuteNewProcess(string filePath, string arguments) {
            string fileName = Path.GetFileName(filePath);
            string workingDirectory = Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar;

            ProcessStartInfo startInfo = new ProcessStartInfo(filePath);
            startInfo.WindowStyle = ProcessWindowStyle.Minimized;
            startInfo.Arguments = arguments;
            startInfo.WorkingDirectory = workingDirectory;

            Process.Start(startInfo);
        }

        public static void OpenFolder(string folderPath) {
            ExecuteNewProcess("explorer.exe", folderPath);
        }

        public static void CloseProcess(string process) {
            string arguments = "/F /IM " + process;
            ExecuteNewProcess("CMD.EXE", "/C " + arguments);
        }
    }
}
