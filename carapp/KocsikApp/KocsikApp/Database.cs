using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace KocsikApp
{
    class Database
    {
        MySqlConnection conn;

        public Database()
        {
            MySqlConnectionStringBuilder connString = new MySqlConnectionStringBuilder();
            connString.Server = "localhost";
            connString.Database = "kocsi-2022";
            connString.UserID = "root";
            connString.Password = "";
            conn = new MySqlConnection(connString.ConnectionString);
            conn.Open();
        }
        public List<Cars> ListAllCars()
        {
            List<Cars> cars = new List<Cars>();
            MySqlCommand command = conn.CreateCommand();
            string sql = "Select * from cars";
            command.CommandText =sql;
            using(MySqlDataReader reader = command.ExecuteReader())
            {
                int db = 0;
                while (reader.Read())
                {
                    //db++;
                    int id = reader.GetInt32("id");
                    string lincense = reader.GetString("license_plate_number"); 
                    string brand = reader.GetString("brand"); 
                    string model = reader.GetString("model"); 
                    int daily_costs = reader.GetInt32("daily_cost");
                    Cars car = new Cars(id,lincense, brand, model, daily_costs);
                    cars.Add(car);
                    //Console.WriteLine(db);
                }
            }
            return cars;
           
    }

        internal bool Torles(Cars torlendo)
        {
            MySqlCommand command = conn.CreateCommand();
            string sql = "Delete from cars Where id=@id";
            command.CommandText = sql;
            command.Parameters.AddWithValue("@id", torlendo.Id);
            return command.ExecuteNonQuery()>0;
        }
    }
}
