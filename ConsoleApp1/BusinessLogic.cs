using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class BusinessLogic
    {
        public double Szamolas(string input)
        {
            string valid = "0123456789+-/*";
            for (int i = 0; i < input.Length; i++)
            {
                if (!valid.Contains(input[i]))
                {
                    throw new FormatException();
                }
            }
            List<string> list = new List<string>();
            string jelenlegiszam = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] ==  '+' || input[i] == '-' || input[i] == '*' || input[i] == '/')
                {
                    list.Add(jelenlegiszam);
                    jelenlegiszam = "";
                    list.Add(input[i].ToString());
                }
                else
                {
                    jelenlegiszam += input[i];
                }
            }
            list.Add(jelenlegiszam);
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == "/")
                {
                    if (list[i + 1] == "0")
                    {
                        throw new DivideByZeroException();
                    }
                    double eredmeny = double.Parse(list[i - 1]) / double.Parse(list[i + 1]);
                    list.RemoveAt(i + 1);
                    list.RemoveAt(i);
                    list.RemoveAt(i - 1);
                    list.Insert(i - 1, eredmeny.ToString());
                    i--;
                }
                else if (list[i] == "*")
                {
                    double eredmeny = double.Parse(list[i - 1]) * double.Parse(list[i + 1]);
                    list.RemoveAt(i + 1);
                    list.RemoveAt(i);
                    list.RemoveAt(i - 1);
                    list.Insert(i - 1, eredmeny.ToString());
                    i--;
                }
            }
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == "+")
                {
                    double eredmeny = double.Parse(list[i - 1]) + double.Parse(list[i + 1]);
                    list.RemoveAt(i + 1);
                    list.RemoveAt(i);
                    list.RemoveAt(i - 1);
                    list.Insert(i - 1, eredmeny.ToString());
                    i--;
                }
                else if (list[i] == "-")
                {
                    double eredmeny = double.Parse(list[i - 1]) - double.Parse(list[i + 1]);
                    list.RemoveAt(i + 1);
                    list.RemoveAt(i);
                    list.RemoveAt(i - 1);
                    list.Insert(i - 1, eredmeny.ToString());
                    i--;
                }
            }
            return double.Parse(list[0]);
        }
    }
}
