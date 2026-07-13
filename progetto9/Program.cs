using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace progetto9
{
    class Program
    {
        struct Order
        {
            public int n_order;
            public string name_client;
            public string category;
            public double amount;
            public bool submitted;
        }

        static List<Order> list = new List<Order>();

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
                    Order o = new Order();
                    sr.ReadLine();
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] dat = line.Split(';');

                        o.n_order = int.Parse(dat[0]);
                        o.name_client = dat[1];
                        o.category = dat[2];
                        o.amount = double.Parse(dat[3]);
                        
                        o.submitted = false;
                        if (dat[4].ToLower() == "consegnato") o.submitted = true;
                        
                        list.Add(o);
                    }

                }

                double amount_submitted = 0;
                double amount_not_submitted = 0;
                int not_submitted = 0;
                double max_amount = -1;
                double sum = 0;
                int count = 0;
                int elettronica = 0;
                int casa = 0;
                int sport = 0;

                Console.WriteLine($"\n===== Waiting clients =====\n");
                foreach(Order o in list)
                {
                    if (o.submitted) amount_submitted += o.amount;
                    else
                    {
                        amount_not_submitted += o.amount;
                        not_submitted++;
                        Console.WriteLine($"- {o.name_client}");
                    }
                    if (max_amount < o.amount) max_amount = o.amount;
                    sum += o.amount;
                    count++;

                    if (o.category.ToLower() == "elettronica") elettronica++;
                    else if (o.category.ToLower() == "casa") casa++;
                    else if (o.category.ToLower() == "sport") sport++;  
                }

                Console.WriteLine($"\nTotal amount of submitted orders: {amount_submitted:F2}");
                Console.WriteLine($"Total amount of unsubmitted orders: {amount_not_submitted:F2}");
                Console.WriteLine($"Orders unsubmitted: {not_submitted}");

                foreach(Order o in list) if(o.amount == max_amount) Console.WriteLine($"Client with max amount: {o.name_client} - {o.amount:F2}");

                Console.WriteLine($"Average amount: {(sum / count):F2}");
                Console.WriteLine($"Elettronica orders: {elettronica}");
                Console.WriteLine($"Casa orders: {casa}");
                Console.WriteLine($"Sport orders: {sport}\n");

            }
            catch (Exception)
            {
                return;
            }
        }
    }
}