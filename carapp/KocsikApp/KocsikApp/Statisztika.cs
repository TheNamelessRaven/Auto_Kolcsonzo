using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace KocsikApp
{
    
    class Statisztika
    {
        static List<Cars> cars;
        public static void Start()
        {
            try
            {
                Beolvas();
                if (cars.Count == 0)
                {
                    throw new Exception("Nincs kocsi az adatbázisban");
                }
                First();
                Second();
                Third();
                Fourth();
                Fifth();
            }
            catch (MySqlException)
            {
                Console.WriteLine("Sikertelen csatlakozás");
            }
            catch (Exception z)
            {
                Console.WriteLine(z.Message);
            }
            
        }
        private static void Beolvas()
        {
            Database db = new Database();
            cars = db.ListAllCars();
        }
        private static void First() //20000-ft nál olcsóbb
        {
            int db = 0;
            foreach(var car in cars)
            {
                if (car.Daily_costs < 20000)
                {
                    db++;
                }
               
            }
            Console.WriteLine($"20000ft nál olcsóbb napidíjú kocsik száma:{db} ");
        }
        private static void Second()
        {
            bool state = false;
            foreach (var car in cars)
            {
                if (car.Daily_costs > 26000)
                {
                    state = true;
                }

            }
            if (state)
            {
                Console.WriteLine("Van drágább kocsi mint 26000ft!");
            }
            else
            {
                Console.WriteLine("Nincs drágább kocsi mint 26000ft");

            }
        }
        private static void Third()
        {
            Cars expensive = cars[0];
            for(int i = 1; i < cars.Count; i++)
            {
                if (expensive.Daily_costs < cars[i].Daily_costs)
                {
                    expensive = cars[i];
                }
            }
            Console.WriteLine($"Legdrágább napidíjú autó: {expensive.Lincense} {expensive.Brand} {expensive.Model} {expensive.Daily_costs}");
        }
        private static void Fourth()
        {
            int renault=0;
            int Ford=0;
            int Peugot=0;
            foreach (var car in cars)
            {
                switch (car.Brand)
                {
                    case "Renault":
                        renault++;
                        break;
                    case "Ford":
                        Ford++;
                        break;
                    case "Peugeot":
                        Peugot++;
                        break;
                    default:
                        // code block
                        break;
                }
            }
            Console.WriteLine($"Autok száma\nRenault: {renault}\nFord: {Ford}\nPeugot: {Peugot}");
        }
        private static void Fifth()
        {
            string license;
            do
            {
                Console.Write("Kérem adjon meg egy rendszámot: ");
                license = Console.ReadLine();
            } while (license == "");
            bool valid=false;
            bool gr = false;
            foreach(var car in cars)
            {
                if (license == car.Lincense)
                {
                    valid = true;
                    if (car.Daily_costs >= 250000)
                    {
                        gr = true;
                    }
                }
            }
            if (valid)
            {
                if (gr)
                {
                    Console.WriteLine("A megadott kocsinak nagyobb a napi költsége mint 25000Ft");
                }
                else
                {
                    Console.WriteLine("A megadott kocsinak kissebb a költsége mint 25000Ft");
                }
            }
            else
            {
                Console.WriteLine("Nincs ilyen rendszámú kocsi");
            }
        }
    }
}
