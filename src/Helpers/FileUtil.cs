using System.IO;
using System.Windows.Forms;

namespace Helpers {
    public class FileUtil {
        public static string CurrentDirectory => Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        public static string FindDestinationFile(string filter, string msg) {
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog()) {
                saveFileDialog1.InitialDirectory = ".";
                saveFileDialog1.Filter = filter;
                saveFileDialog1.Title = msg;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                    return saveFileDialog1.FileName;
                }
            }
            return "";
        }

        public static string FindSourceFile(string filter, string msg) {
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog()) {
                openFileDialog1.InitialDirectory = ".";
                openFileDialog1.Filter = filter;
                openFileDialog1.FilterIndex = 0;
                openFileDialog1.RestoreDirectory = true;
                openFileDialog1.Title = msg;

                if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                    return openFileDialog1.FileName;
                }
            }
            return "";
        }


        public static string FindFolder(string defaultPath) {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog()) {
                fbd.SelectedPath = defaultPath;
                DialogResult result = fbd.ShowDialog();

                return fbd.SelectedPath;
            }
        }

        public static void CreateFolder(string fullPath) {
            Directory.CreateDirectory(fullPath);
        }

        public void ExportTextToFile(RichTextBox text) {
            using (SaveFileDialog saveFileDialog1 = new SaveFileDialog()) {
                saveFileDialog1.InitialDirectory = ".";
                saveFileDialog1.Filter = "Text File | *.txt";
                saveFileDialog1.Title = "Export to a text File";

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
