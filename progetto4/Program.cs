using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace progetto4
{
    class Program
    {
        struct Client
        {
            public string name;
            public double used;
            public double cost;
            public double bill;
            public bool penal;
        }
        static List<Client> clients = new List<Client>();

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
                Console.WriteLine($"\n===== Intestazione: {sr.ReadLine()} =====");

                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dat = line.Split(';');
                    Client client = new Client();

                    client.name = dat[0];
                    client.used = double.Parse(dat[1]);
                    client.cost = double.Parse(dat[2]);
                    client.penal = false;
                        
                    client.bill = client.used * client.cost;
                    if (client.bill > 500)
                    {
                        client.bill += 25;
                        client.penal = true;
                    }

                    clients.Add(client);
                }
            }

            Console.WriteLine($"\nClienti che hanno ricevuto una penale:");
            double totalBill = 0;

            foreach(Client c in clients)
            {
                if (c.penal) Console.WriteLine($"- {c.name}");
                totalBill += c.bill;
            }

            Console.WriteLine($"Costo totale delle bollette: {totalBill}€\n");

        }
    }
}