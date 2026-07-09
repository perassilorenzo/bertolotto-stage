using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace progetto7
{
    class Program
    {
        struct Fattura
        {
            public string numero_fattura;
            public string cliente;
            public double importo;
            public bool pagata;
        }
        static List<Fattura> fatturas = new List<Fattura>();

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
                    string[] intestazione = sr.ReadLine().Split(';');
                    Console.WriteLine();
                    foreach(string i in intestazione) Console.Write($"{i}   ");

                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        string[] dat = line.Split(';');
                        Fattura f = new Fattura();

                        f.numero_fattura = dat[0];
                        f.cliente = dat[1];
                        f.importo = double.Parse(dat[2]);
                        
                        f.pagata = false;
                        if (dat[3].ToLower() == "pagata") f.pagata = true;

                        fatturas.Add(f);
                    }
                }

                double totale_pagate = 0;
                double totale_non_pagate = 0;
                int count_non_pagate = 0;
                List<string> clienti_non_pagate = new List<string>();

                foreach(Fattura f in fatturas)
                {
                    if (f.pagata) totale_pagate += f.importo;
                    else
                    {
                        totale_non_pagate += f.importo;
                        count_non_pagate++;
                        clienti_non_pagate.Add(f.cliente);
                    }
                }

                Console.WriteLine($"\n- Totale fatture pagate: {totale_pagate}€");
                Console.WriteLine($"- Totale fatture non pagate: {totale_non_pagate}€");
                Console.WriteLine($"- Fatture non pagate: {count_non_pagate}");
                Console.WriteLine($"\nClienti con fatture non pagate:");
                foreach(string c in clienti_non_pagate) Console.WriteLine($"- {c}");
                Console.WriteLine();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}