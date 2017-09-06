using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    public static class JSONDeserializer
    {

        public static IEnumerable<Person> DeserializePerson(string json)
        {
            return JsonConvert.DeserializeObject<IEnumerable<Person>>(json);
        }

        public static IEnumerable<IGrouping<string, Person>> DeserializePersonAndGroupByGender(string json)
        {
            var persons = DeserializePerson(json);
            return persons.GroupBy(x => x.gender); // Ideally this function would be adapted to group by any field
        }

   
    }
}
