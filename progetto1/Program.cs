using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace progetto1
{
    class Program
    {
        struct Magazzino
        {
            public string product;
            public double quantity;
            public double price;
            public double totalPrice;
            public bool modify;
        }
        static List<Magazzino> list = new List<Magazzino>();

        [STAThread]
        static void Main()
        {
            try
            {
                ReadFile();

                int totalPrice = 0;
                foreach (Magazzino m in list)
                {
                    totalPrice += Convert.ToInt32(m.totalPrice); 
                    if (m.modify)
                    {
                        Console.WriteLine($"- {m.product}");
                    }
                }
                Console.WriteLine($"\nPREZZO TOTALE DI TUTTO IL MAGAZZINO: {totalPrice}€\n");
            
            }
            catch (IOException)
            {
                MessageBox.Show("Errore nella lettura del file");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Errore nel passaggio di valore nullo");
            }
            catch (Exception)
            {
                MessageBox.Show("ERRORE: controllare il codice");
            }
        }

        static void ReadFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            string fileName = "";

            if (fileDialog.ShowDialog() == DialogResult.OK) 
            {
                fileName = fileDialog.FileName; 
            }

            using (StreamReader sr = new StreamReader(fileName))
            {
                string intestation = sr.ReadLine();
                Console.WriteLine($"\n===== Intestazione: {intestation} =====\n");

                string line;
                
                while((line = sr.ReadLine()) != null)
                {
                    string[] dat = line.Split(';');
                    Magazzino magazzino = new Magazzino();
                    
                    magazzino.product = dat[0];
                    magazzino.quantity = double.Parse(dat[1]);
                    magazzino.price = double.Parse(dat[2]);

                    if (magazzino.quantity > 50)
                    {
                        magazzino.totalPrice = magazzino.quantity * magazzino.price * 0.10;
                        magazzino.modify = true;
                    }
                    else magazzino.modify = false;

                    list.Add(magazzino);
                }
            }
        }
    }
}