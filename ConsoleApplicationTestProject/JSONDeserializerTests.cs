using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApplication1;

namespace ConsoleApplicationTestProject
{
    [TestClass]
    public class JSONDeserializerTests
    {
        [TestMethod]
        public void DeserializePersonAndGroupByGender_StaticJson_GroupedCats()
        {
            string json = "[{\"name\":\"Bob\",\"gender\":\"Male\",\"age\":23,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"},{\"name\":\"Fido\",\"type\":\"Dog\"}]},{\"name\":\"Jennifer\",\"gender\":\"Female\",\"age\":18,\"pets\":[{\"name\":\"Garfield\",\"type\":\"Cat\"}]},{\"name\":\"Steve\",\"gender\":\"Male\",\"age\":45,\"pets\":null},{\"name\":\"Fred\",\"gender\":\"Male\",\"age\":40,\"pets\":[{\"name\":\"Tom\",\"type\":\"Cat\"},{\"name\":\"Max\",\"type\":\"Cat\"},{\"name\":\"Sam\",\"type\":\"Dog\"},{\"name\":\"Jim\",\"type\":\"Cat\"}]},{\"name\":\"Samantha\",\"gender\":\"Female\",\"age\":40,\"pets\":[{\"name\":\"Tabby\",\"type\":\"Cat\"}]},{\"name\":\"Alice\",\"gender\":\"Female\",\"age\":64,\"pets\":[{\"name\":\"Simba\",\"type\":\"Cat\"},{\"name\":\"Nemo\",\"type\":\"Fish\"}]}]";

            var grouped = JSONDeserializer.DeserializePersonAndGroupByGender(json);

            int i = 0;
            foreach (var group in grouped)
            {
                if(i==0) Assert.AreEqual("MALE", group.Key.ToUpper());
                if (i == 1) Assert.AreEqual("FEMALE", group.Key.ToUpper());

                foreach(var pet in group)
                {
                    // ToDo Assert check pet names are corret
                }

                i++;
            }


        }
    }
}
