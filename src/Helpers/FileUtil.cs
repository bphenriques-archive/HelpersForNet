using System.IO;
using System.Windows.Forms;

namespace HelpersForNet {
    /// <summary>
    /// Contains some wrappers to common operations
    /// </summary>
    public class FileUtil {
        
        /// <summary>
        /// Returns the current assembly location
        /// </summary>
        public static string CurrentDirectory => Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        
        /// <summary>
        /// Opens a SaveFileDialog with the given title and filter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="title"></param>
        /// <returns>The path if the user selected a file or empty string if not</returns>
        public static string FindDestinationFile(string filter, string title) {
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog()) {
                saveFileDialog1.InitialDirectory = ".";
                saveFileDialog1.Filter = filter;
                saveFileDialog1.Title = title;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    return saveFileDialog1.FileName;
                }
            }
            return "";
        }

        /// <summary>
        /// Opens a OpenFileDialog with the given title and filter
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="title"></param>
        /// <returns>The path if user selected a file and </returns>
        public static string FindSourceFile(string filter, string title) {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog()) {
                openFileDialog1.InitialDirectory = ".";
                openFileDialog1.Filter = filter;
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.Title = title;

                if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                    return openFileDialog1.FileName;
                }
            }
            return "";
        }

        /// <summary>
        /// Opens a FolderBrowserDialog with the defaultPath open
        /// </summary>
        /// <param name="defaultPath"></param>
        /// <returns></returns>
        public static string FindFolder(string defaultPath) {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
                fbd.SelectedPath = defaultPath;
                DialogResult result = fbd.ShowDialog();

                return fbd.SelectedPath;
            }
        }

        /// <summary>
        /// Creates the directory as needed given the fullPath
        /// </summary>
        /// <param name="fullPath"></param>
        public static void CreateFolder(string fullPath) {
            Directory.CreateDirectory(fullPath);
        }

        /// <summary>
        /// Exports the given text to a external file by opening a SaveFileDialog
        /// </summary>
        /// <param name="text"></param>
        /// <param name="currentDirectory"></param>
        /// <param name="filter"></param>
        /// <param name="title"></param>
        public void ExportTextToFile(RichTextBox text, string currentDirectory, string filter, string title) {
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog()) {
                saveFileDialog1.InitialDirectory = currentDirectory;
                saveFileDialog1.Filter = filter;
                saveFileDialog1.Title = title;

                // create a writer and open the file
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    string fileName = saveFileDialog1.FileName;
                    using (TextWriter tw = new StreamWriter(fileName)) {
                        tw.WriteLine(text);
                    }
                }
            }
        }
    }
}
