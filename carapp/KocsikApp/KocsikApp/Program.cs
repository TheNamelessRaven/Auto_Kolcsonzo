using System;
using System.Linq;
using System.Windows;
namespace KocsikApp
{
    
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Contains("--stat"))
            {
                Statisztika.Start();
            }
            else
            {
                Application app = new Application();
                app.Run(new CarsGUI());
            }
        }
    }
}
