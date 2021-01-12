using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Indexers
{
    public class IndexerExample
    {
        class StringDataStore
        {
            private string[] strings = new string[10];

            public string this[int index, string prefix]
            {
                get => strings[index];
                set => strings[index] = prefix + value;
            }

            public int this[string data]
            {
                get
                {
                    for (int i = 0; i < strings.Length; i++)
                        if (strings[i] == data)
                            return i;
                    return -1;
                }
            }

            public void SetString(int index, string value)
            {
                strings[index] = value;
            }

            public string GetString(int index)
            {
                return strings[index];
            }
        }

        public void Test()
        {
            var stringDataStore = new StringDataStore();
            stringDataStore.SetString(0, "1");
            stringDataStore.SetString(1, "two");
            stringDataStore.SetString(2, "III");

            stringDataStore[3, "_"] = "4";
            stringDataStore[4, "_"] = "five";
            stringDataStore[5, "_"] = "VI";

            var fiveIndex = stringDataStore["_five"];
            stringDataStore[fiveIndex, "-"] = "FIVE";

            for(int i =0; i < 10; i ++)
                Console.WriteLine(stringDataStore[i, ""]);
        }
    }
}
