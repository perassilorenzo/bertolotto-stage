using System;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms.VisualStyles;

namespace progetto2
{
    class Program
    {
        struct Magazzino
        {
            public string client;
            public int quantity;
            public double price;
            public double totalPrice;
        }

        static List<string> salesClient = new List<string>();
        static List<Magazzino> magazzinos = new List<Magazzino>();

        [STAThread]
        static void Main()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            string fileName = "";
            
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
            }

            using (StreamReader sr = new StreamReader(fileName))
            {
                string intestation = sr.ReadLine();
                Console.WriteLine($"\n===== Intestazione: {intestation} =====\n");

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dat = line.Split(';');
                    Magazzino m = new Magazzino();

                    m.client = dat[0];
                    m.quantity = int.Parse(dat[1]);
                    m.price = double.Parse(dat[2]);

                    if ((m.totalPrice = m.quantity * m.price) > 500)
                    {
                        m.totalPrice = m.totalPrice * 0.75; 
                        salesClient.Add(m.client);
                    }

                    magazzinos.Add(m);
                }
            }

            Console.WriteLine("\nI clienti che hanno ricevuto lo sconto sono:");
            foreach(string c in salesClient) Console.WriteLine($"- {c}");
            
            double totalPrice = 0;
            foreach(Magazzino m in magazzinos) totalPrice += m.totalPrice;
            Console.WriteLine($"\nIl valore totale degli ordini è: {totalPrice}");
        }
    }
}