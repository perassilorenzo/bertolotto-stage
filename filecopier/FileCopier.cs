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

                string fileOrigine = fileDialog.FileName;
                string cartellaDestinazione = folderDialog.SelectedPath;

                string destinazione = Path.Combine(cartellaDestinazione, Path.GetFileName(fileOrigine));

                File.Copy(fileOrigine, destinazione, true);

                Console.WriteLine($"File copiato correttamente: {destinazione}");
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Permesso negato: non puoi scrivere in quella cartella.");
            }
            catch (IOException ex) when ((ex.HResult & 0xFFFF) == 32)
            {
                Console.WriteLine("Il file è aperto da un altro programma. Chiudilo e riprova.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Errore di I/O: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Errore imprevisto: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}