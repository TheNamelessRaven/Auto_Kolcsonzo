using System;
using System.Collections.Generic;
using System.Text;

namespace KocsikApp
{
    class Cars
    {
        int id;
        string lincense;
        string brand;
        string model;
        int daily_costs;

        public Cars(int id, string lincense, string brand, string model, int daily_costs)
        {
            this.Id = id;
            this.Lincense = lincense;
            this.Brand = brand;
            this.Model = model;
            this.Daily_costs = daily_costs;
        }

        public int Id { get => id; set => id = value; }
        public string Lincense { get => lincense; set => lincense = value; }
        public string Brand { get => brand; set => brand = value; }
        public string Model { get => model; set => model = value; }
        public int Daily_costs { get => daily_costs; set => daily_costs = value; }
        public override string ToString()
        {
            return $"{lincense,-50} {brand,-30} {model,-30} {daily_costs}";
        }
    }
    

}
