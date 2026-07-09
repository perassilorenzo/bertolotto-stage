using System;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace progetto3
{
    class Program
    {
        struct Student
        {
            public string name;
            public double mark1;
            public double mark2;
            public double mark3;
            public double average;
            public bool promotion;
        }

        static List<Student> students = new List<Student>();

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
                Console.WriteLine($"\n===== Intestazione: {intestation} =====");

                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] dat = line.Split(';');
                    Student student = new Student();

                    student.name = dat[0];
                    student.mark1 = double.Parse(dat[1]);
                    student.mark2 = double.Parse(dat[2]);
                    student.mark3 = double.Parse(dat[3]);

                    student.average = (student.mark1 + student.mark2 + student.mark3) / 3;
                    
                    if (student.average >= 6) student.promotion = true;
                    else student.promotion = false;

                    students.Add(student);
                }
            }

            double sum = 0;
            int count = 0;

            Console.WriteLine("\nStudenti promossi:");
            foreach(Student s in students)
            {
                if (s.promotion) Console.WriteLine($"- {s.name}");
                sum += s.average;
                count++;
            }

            Console.WriteLine($"\nMedia totale della classe: {sum/count}");
        }
    }
}