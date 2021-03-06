﻿using CustomerManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerManager.Repository
{
    internal static class DataInitializer
    {
        internal static void Initialize(CustomerManagerContext context)
        {
            var random = new Random();

            var sortedStates = states.OrderBy(s => s.Name);
            foreach (var state in sortedStates)
            {
                context.States.Add(state);
            }

            //Generate customers and orders
            for (int i = 0; i < customerNames.Length; i++)
            {
                var nameGenderHost = SplitValue(customerNames[i]);
                var cityState = SplitValue(citiesStates[i]);
                var cust = new Customer 
                {
                    Id = i + 1,
                    FirstName = nameGenderHost[0],
                    LastName = nameGenderHost[1],
                    Email= String.Format("{0}.{1}@{2}", nameGenderHost[0], nameGenderHost[1], nameGenderHost[3]),
                    Address = addresses[i],
                    City = cityState[0],
                    State = sortedStates.Where(state => state.Abbreviation == cityState[1]).SingleOrDefault(),
                    Zip = zip + i,
                    Gender = (Gender)Enum.Parse(typeof(Gender), nameGenderHost[2])
                };
                context.Customers.Add(cust);

                //Generate customer orders
                var skip = random.Next(orders.Count - 1);
                var take = orders.Count - skip;
                var custOrders = orders.Skip(skip).Take(take);
                foreach (var order in custOrders)
                {
                    var custOrder = order.Clone();
                    custOrder.CustomerId = cust.Id;
                    context.Orders.Add(custOrder);
                }
            }
             
        }

        private static string[] SplitValue(string val)
        {
            return val.Split(',');
        }

        static string[] customerNames = 
        { 
            "Marcus,HighTower,Male,acmecorp.com", 
            "Jesse,Smith,Female,gmail.com", 
            "Albert,Einstein,Male,outlook.com", 
            "Dan,Wahlin,Male,yahoo.com", 
            "Ward,Bell,Male,gmail.com", 
            "Brad,Green,Male,gmail.com", 
            "Igor,Minar,Male,gmail.com", 
            "Miško,Hevery,Male,gmail.com", 
            "Michelle,Avery,Female,acmecorp.com", 
            "Heedy,Wahlin,Female,hotmail.com" 
        };
        static string[] addresses = 
        { 
            "1234 Anywhere St.", 
            "435 Main St.", 
            "1 Atomic St.", 
            "85 Cedar Dr.", 
            "12 Ocean View St.", 
            "1600 Amphitheatre Parkway", 
            "1600 Amphitheatre Parkway", 
            "1600 Amphitheatre Parkway", 
            "1578 Main St.", "85 Cedar Dr." 
        };

        static string[] citiesStates = 
        { 
            "Phoenix,AZ", 
            "Encinitas,CA", 
            "Seattle,WA", 
            "Chandler,AZ", 
            "Dallas,TX", 
            "Orlando,FL", 
            "Carey,NC", 
            "Anaheim,CA", 
            "Dallas,TX", 
            "Chandler,AZ" 
        };

        static List<State> states = new List<State> {
            new State { Name="Alabama", Abbreviation="AL"},
            new State { Name=" Montana", Abbreviation="MT"},
            new State { Name=" Alaska", Abbreviation="AK"},
            new State { Name=" Nebraska", Abbreviation="NE"},
            new State { Name=" Arizona", Abbreviation="AZ"},
            new State { Name=" Nevada", Abbreviation="NV"},
            new State { Name="Arkansas", Abbreviation="AR"},
            new State { Name=" New Hampshire", Abbreviation="NH"},
            new State { Name="California", Abbreviation="CA"},
            new State { Name="New Jersey", Abbreviation="NJ"},
            new State { Name="Colorado", Abbreviation="CO"}, 
            new State { Name="New Mexico", Abbreviation="NM"},
            new State { Name="Connecticut", Abbreviation="CT"}, 
            new State { Name="New York", Abbreviation="NY"},
            new State { Name="Delaware", Abbreviation="DE"},
            new State { Name="North Carolina", Abbreviation="NC"},
            new State { Name="Florida", Abbreviation="FL"},
            new State { Name="North Dakota", Abbreviation="ND"},
            new State { Name="Georgia", Abbreviation="GA"}, 
            new State { Name="Ohio", Abbreviation="OH"},
            new State { Name="Hawaii", Abbreviation="HI"},
            new State { Name="Oklahoma", Abbreviation="OK"},
            new State { Name="Idaho", Abbreviation="ID"}, 
            new State { Name="Oregon", Abbreviation="OR"},
            new State { Name="Illinois", Abbreviation="IL"}, 
            new State { Name="Pennsylvania", Abbreviation="PA"},
            new State { Name="Indiana", Abbreviation="IN"}, 
            new State { Name=" Rhode Island", Abbreviation="RI"},
            new State { Name="Iowa", Abbreviation="IA"}, 
            new State { Name="South Carolina", Abbreviation="SC"},
            new State { Name="Kansas", Abbreviation="KS"}, 
            new State { Name="South Dakota", Abbreviation="SD"},
            new State { Name="Kentucky", Abbreviation="KY"}, 
            new State { Name="Tennessee", Abbreviation="TN"},
            new State { Name="Louisiana", Abbreviation="LA"}, 
            new State { Name="Texas", Abbreviation="TX"},
            new State { Name="Maine", Abbreviation="ME"}, 
            new State { Name="Utah", Abbreviation="UT"},
            new State { Name="Maryland", Abbreviation="MD"}, 
            new State { Name="Vermont", Abbreviation="VT"},
            new State { Name="Massachusetts", Abbreviation="MA"}, 
            new State { Name="Virginia", Abbreviation="VA"},
            new State { Name="Michigan", Abbreviation="MI"}, 
            new State { Name="Washington", Abbreviation="WA"},
            new State { Name="Minnesota", Abbreviation="MN"}, 
            new State { Name="West Virginia", Abbreviation="WV"},
            new State { Name="Mississippi", Abbreviation="MS"}, 
            new State { Name="Wisconsin", Abbreviation="WI"},
            new State { Name="Missouri", Abbreviation="MO"}, 
            new State { Name="Wyoming", Abbreviation="WY"}
        };

        static int zip = 85229;

        static List<Order> orders = new List<Order> 
        {
            new Order { Product = "Basket", Price =  29.99M , Quantity=  1},
            new Order { Product = "Yarn", Price =  9.99M, Quantity=  1  },
            new Order { Product = "Needes", Price =  5.99M, Quantity=  1 },
            new Order { Product = "Speakers", Price = 499.99M, Quantity =  1 },
            new Order { Product = "iPod", Price =  399.99M, Quantity=  1 },
            new Order { Product = "Table", Price =  329.99M, Quantity=  1 },
            new Order { Product = "Chair", Price =  129.99M, Quantity=  4 },
            new Order { Product = "Lamp", Price =  89.99M, Quantity=  5 },
            new Order { Product = "Call of Duty", Price =  59.99M, Quantity=  1},
            new Order { Product = "Controller", Price =  49.99M, Quantity=  1},
            new Order { Product = "Gears of War", Price =  49.99M, Quantity=  1 },
            new Order { Product = "Lego City", Price =  49.99M, Quantity=  1 },
            new Order { Product = "Baseball", Price =  9.99M, Quantity=  5 },
            new Order { Product = "Bat", Price =  19.99M, Quantity=  1 }
        };    
    }
}
