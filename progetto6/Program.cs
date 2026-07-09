using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Text;
using System.IO;
using System.Security.Cryptography.Xml;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace progetto6
{
    class Program
    {
        struct Week
        {
            public string city;
            public double mon;
            public double tue;
            public double wen;
            public double thu;
            public double fri;
            public double sat;
            public double sun;
            public double average;
            public double max;
            public bool signal;
        }
        static List<Week> list = new List<Week>();

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
                    string[] elements = sr.ReadLine().Split(';');
                    Console.Write($"\n===== Intestation:");
                    foreach(string e in elements) Console.Write($" {e}");
                    Console.Write(" =====\n");

                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] dat = line.Split(';');
                        Week w = new Week();

                        w.city = dat[0];
                        w.mon = double.Parse(dat[1]);
                        w.tue = double.Parse(dat[2]);
                        w.wen = double.Parse(dat[3]);
                        w.thu = double.Parse(dat[4]);
                        w.fri = double.Parse(dat[5]);
                        w.sat = double.Parse(dat[6]);
                        w.sun = double.Parse(dat[7]);

                        w.average = (w.mon + w.tue + w.wen + w.thu + w.fri + w.sat + w.sun) / 7;
                        w.max = double.MinValue;
                        w.signal = false;
                        for (int i = 1; i < 8; i++)
                        {
                            if (w.max < double.Parse(dat[i])) w.max = double.Parse(dat[i]);
                        }
                        if (w.max > 35) w.signal = true;

                        list.Add(w);
                    }
                }

                Console.WriteLine($"City    Average     Max     Signal");

                double max = double.MinValue;
                double sum = 0;
                int count = 0;

                foreach(Week w in list){
                    Console.WriteLine($"{w.city}    {w.average:F1}     {w.max}     {Signal(w.signal)}");
                    if (max < w.max) max = w.max;
                    sum += w.average;
                    count++;
                }
                Console.WriteLine($"\nCity max temperature: {max}");
                Console.WriteLine($"City average tempature: {sum/count:F1}°\n");

            }
            catch (Exception)
            {
                Console.WriteLine("ERRORE NEL CODICE!!");
            }
            
        }

        static string Signal(bool signal)
        {
            if (signal) return "ALLARM";
            return "Ok";
        }
    }
}