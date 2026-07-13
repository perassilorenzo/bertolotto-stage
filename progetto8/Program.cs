using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace progetto8
{
    class Program
    {
        struct Product
        {
            public string code;
            public string name;
            public int quantity;
            public bool available;
        }

        static List<Product> list = new List<Product>();

        [STAThread]
        static void Main()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                string fileName = "";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = dialog.FileName;
                }

                using (StreamReader sr = new StreamReader(fileName))
                {
                    sr.ReadLine();
                    string line = "";
                    while((line = sr.ReadLine()) != null)
                    {
                        string[] dat = line.Split(';');
                        Product p = new Product();

                        p.code = dat[0];
                        p.name = dat[1];
                        p.quantity = int.Parse(dat[2]);
                        p.available = false;
                        if (dat[3].ToLower() == "disponibile") p.available = true;

                        list.Add(p);
                    }
                }

                Console.WriteLine("\n===== Not available products =====");
                int available_quantity = 0;
                int not_available_quantity = 0;
                int not_available_product = 0;

                foreach(Product p in list)
                {
                    if (p.available) available_quantity += p.quantity;
                    else
                    {
                        not_available_quantity += p.quantity;
                        not_available_product++;
                        Console.WriteLine($"- {p.name}");
                    }
                }
                Console.WriteLine($"\nQuantity total of products available: {available_quantity}");
                Console.WriteLine($"Quantity total of products unavailable: {not_available_quantity}");
                Console.WriteLine($"Quantity of products unavailable: {not_available_product}\n");
            }
            catch(Exception)
            {
                return;
            }
        }
    }
}