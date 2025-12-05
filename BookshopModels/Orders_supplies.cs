using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace databases_CW.Instances
{
    public class Customer
    {
        public int id {  get; set; }
        public string first_name { get; set; }
        public string middle_name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public List<Order> orders { get; set; } = new List<Order>();
    }

    public class Individual : Customer
    {
        public int individual_id { get; set; }
        public int passport_series {  get; set; }
        public int passport_number { get; set; }
        public string passport_given { get; set; }
        public DateOnly passport_given_date { get; set; }

        public Customer customer { get; set; } = new Customer();
    }

    public class LegalEntity : Customer
    {
        public int entity_id { get; set; }
        public string name { get; set; }
        public int OK_code { get; set; }
        public string abbreviation { get; set; }
        public string current_account_number { get; set; }
        public string correspondent_account_number { get; set; }
        public string bik { get; set; }
        public string inn { get; set; }
        public Bank bank {get; set;} = new Bank();
        public City city {get; set;} = new City();
        public Street street {get; set;} = new Street();
        public string house_namber { get; set; }
    }

    public class Order
    {
        public int id { get; set; }
        public DateOnly date {  get; set; }
        public Customer customer { get; set; }
    }

    public class Suppliers
    {
        public int id { get; set; }
        public string name { get; set; }
        public int OK_code { get; set; }
        public string abbreviation { get; set; }
        public string current_account_number { get; set; }
        public string correspondent_account_number { get; set; }
        public string bik { get; set; }
        public string inn { get; set; }

        public Bank bank {get; set;} = new Bank();
        public City city {get; set;} = new City();
        public Street street {get; set;} = new Street();
        public string house_namber { get; set; }

        public List<Supply> supplies { get; set; } = new List<Supply>();
    }

    public class Supply
    {
        public int id { get; set; }
        public DateOnly date { get; set; }
        public Suppliers supplier { get; set; }
        public List<Item> items { get; set; } = new List<Item>();
    }
}
