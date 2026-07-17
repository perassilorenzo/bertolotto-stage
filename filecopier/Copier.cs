using System;
using System.IO;
using System.Windows.Forms;

namespace FileCopier
{
    public class Copier
    {
        public void Run()
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                FolderBrowserDialog folderDialog = new FolderBrowserDialog();

                if (fileDialog.ShowDialog() != DialogResult.OK || folderDialog.ShowDialog() != DialogResult.OK) return;

                string src = fileDialog.FileName;
                string dstFolder = folderDialog.SelectedPath;
                string dst = Path.Combine(dstFolder, Path.GetFileName(src));

                File.Copy(src, dst, true);

                Console.WriteLine($"File copied: {dst}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied: cannot write to that folder.");
            }
            catch (IOException ex) when ((ex.HResult & 0xFFFF) == 32)
            {
                Console.WriteLine("File is open by another program. Close it and try again.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"I/O error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}
