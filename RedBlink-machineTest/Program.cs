using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedBlink_machineTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter which function you want to test (GroupBy / Sorting): ");
            string Methodtype = Console.ReadLine();
            List<string> lst = new List<string>();
            switch (Methodtype)
            {
                case "GroupBy":

                    lst = AskForInput().OrderBy(s=>s).ToList();
                    lst.GroupBy(s => s).Select(s => new { Name = s.Key, Count = s.Count() }).ToList().ForEach(s=> {
                       Console.WriteLine(s.Name + " - " + s.Count.ToString());
                    });
                    
                    break;
                case "Sorting":

                    lst = AskForInput();
                    lst = lst.OrderBy(s => s.Substring(s.IndexOf(" ") + 1)).ThenBy(s => s.Substring(0, s.IndexOf(" "))).ToList();
                    Console.WriteLine("Sorted Array is: ");
                    Console.WriteLine(JsonConvert.SerializeObject(lst));

                    break;
                default:
                    Console.WriteLine("Given method type not found");
                    break;
            }
        }

        static List<string> AskForInput()
        {
            List<string> lst = new List<string>();
            Console.WriteLine("Please enter input JSON: ");
            string JSON= Console.ReadLine();
            if (!string.IsNullOrEmpty(JSON))
            {
                try
                {
                    lst = JsonConvert.DeserializeObject<List<string>>(JSON);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error in parsing the JSON");
                }
            }
            else
            {
                Console.WriteLine("Please enter the JSON");
            }
            return lst;
        }
    }
}
