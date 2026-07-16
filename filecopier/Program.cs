using System;

namespace FileCopier
{
    internal class Program
    {
        [STAThread]
        static void Main()
        {
            Copier applicativo = new Copier();
            applicativo.Run();
        }
    }
}