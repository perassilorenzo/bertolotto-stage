using System;
using System.IO;
using System.Windows.Forms;
using Dropbox.Api;
using Dropbox.Api.Files;

namespace FileCopier
{
    public class Uploader
    {
        public void Run()
        {
            try
            {
                string token = LoadToken();
                if (string.IsNullOrEmpty(token))
                {
                    Console.Write("Dropbox token: ");
                    token = (Console.ReadLine() ?? "").Trim();
                    File.WriteAllText("token.txt", token);
                }

                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() != DialogResult.OK) return;

                using var dbx = new DropboxClient(token);
                using var stream = File.OpenRead(dialog.FileName);

                var uploaded = dbx.Files.UploadAsync(
                    $"/Prova/{Path.GetFileName(dialog.FileName)}",
                    WriteMode.Overwrite.Instance,
                    body: stream
                ).GetAwaiter().GetResult();

                Console.WriteLine($"Uploaded: {uploaded.PathDisplay}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadKey();
        }

        string LoadToken()
        {
            if (File.Exists("token.txt"))
            {
                string val = File.ReadAllText("token.txt").Trim();
                if (val.Length > 0) return val;
            }
            return "";
        }
    }
}
