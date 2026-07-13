using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace progetto10
{
    class Program
    {
        struct Work
        {
            public int numero_lavoro;
            public string nome_cliente;
            public string tipo_servizio;
            public double ore_lavorate;
            public double prezzo;
            public bool stato;
        }

        static List<Work> list = new List<Work>();

        [STAThread]
        static void Main()
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                string fileName = "";
                if (dialog.ShowDialog() == DialogResult.OK) fileName = dialog.FileName;

                using (StreamReader sr = new StreamReader(fileName))
                {
                    double fatturato_totale = 0;
                    int lavori_incorso = 0;
                    double valore_incorso = 0;
                    double max_prezzo = -1;
                    double sum = 0;
                    int count = 0;
                    double ore_totali = 0;

                    Console.WriteLine($"\n===== Clienti con lavori ancora in corso =====");
                    sr.ReadLine();
                    Work w = new Work();
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] dat = line.Split(';');
                        
                        w.numero_lavoro = int.Parse(dat[0]);
                        w.nome_cliente = dat[1];
                        w.tipo_servizio = dat[2];
                        w.ore_lavorate = double.Parse(dat[3]);
                        w.prezzo = double.Parse(dat[4]);
                        
                        if (dat[5].ToLower() == "completato") w.stato = true;
                        else
                        {
                            w.stato = false;
                            valore_incorso += w.prezzo;
                            lavori_incorso++;

                            Console.WriteLine($"- {w.nome_cliente}");
                        }

                        fatturato_totale += w.prezzo;
                        sum += w.prezzo;
                        count++;
                        ore_totali += w.ore_lavorate;

                        if (max_prezzo < w.prezzo) max_prezzo = w.prezzo;

                        list.Add(w);
                    }
                    
                    foreach(Work i in list) if (max_prezzo == i.prezzo) Console.WriteLine($"\nCliente con prezzo maggiore: {i.numero_lavoro} - {i.nome_cliente} - {i.tipo_servizio} - {i.prezzo} - {i.ore_lavorate}");

                    Console.WriteLine($"\nFatturato totale dei lavori completati: {fatturato_totale}");
                    Console.WriteLine($"Fatturato totale dei lavori aperti: {valore_incorso}");
                    Console.WriteLine($"Lavori ancora in corso: {lavori_incorso}");
                    Console.WriteLine($"Prezzo medio di tutti i lavori: {(sum/count):F2}");
                    Console.WriteLine($"Ore totali lavorate: {ore_totali}\n");
                }   
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}