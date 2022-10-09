using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KocsikApp
{
    /// <summary>
    /// Interaction logic for CarsGUI.xaml
    /// </summary>
    public partial class CarsGUI : Window
    {
        public CarsGUI()
        {
            InitializeComponent();
        }

        Database db;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                db = new Database();
                Feltoltes();
            }
            catch(Exception)
            {
                MessageBox.Show("Nem sikerült csatlakozni az adatbázishoz");
                this.Close();
            }
            
        }
        private void Feltoltes()
        {
            List<Cars> cars = db.ListAllCars();
            CarList.Items.Clear();
            foreach(var car in cars)
            {
                CarList.Items.Add(car);
            }

        }

        private void btn_del_Click(object sender, RoutedEventArgs e)
        {
            if (CarList.SelectedIndex < 0)
            {
                MessageBox.Show("Nincs kijelölt elem");
                return;
            }
            MessageBoxResult result = MessageBox.Show("Biztos Törölni akarod a kocsit?",
                "Megerősítés",MessageBoxButton.YesNo);
            if (result.Equals(MessageBoxResult.Yes))
            {
                Cars torlendo = CarList.SelectedItem as Cars;
                //Cars torlendo2 = (Cars)CarList.SelectedItem;
                try
                {
                    if (db.Torles(torlendo))
                    {
                        MessageBox.Show("Sikeres Törlés");
                    }
                    else
                    {
                        MessageBox.Show("Sikertelen Törlés");
                    }
                    Feltoltes();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
        }
    }
}
