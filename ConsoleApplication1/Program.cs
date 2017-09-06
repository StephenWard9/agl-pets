using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        private const string CAT_STRING = "CAT";

        static void Main(string[] args)
        {

            GetJsonAndDisplay();

            Console.WriteLine("Downloading ...");
            Console.ReadLine();
           
        }

        static async void GetJsonAndDisplay()
        {
            // ToDo Move to config
            string url = "http://agl-developer-test.azurewebsites.net/people.json";

            var json = await JSONClient.DownloadUrlAsync(url);

            var grouped = JSONDeserializer.DeserializePersonAndGroupByGender(json);

            foreach(var group in grouped)
            {
                Console.WriteLine(group.Key);

                foreach(Person person in group)
                {
                    if (person.pets != null)
                    {
                        foreach (Pet pet in person.pets)
                        {
                            if (pet.type.ToUpper() == CAT_STRING)
                            {
                                Console.WriteLine(" - " + pet.name);
                            }
                        }
                    }
                }
       
            }
        }
    
    }
}
