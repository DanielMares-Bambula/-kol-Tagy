using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace Úkol_Tagy
{  
    class Program
    {
        public delegate void Tag(ref string input);
        public static void TagCapital(ref string input)
        {
            Regex rx = new Regex("<Capital>" + ".*" + "</Capital>");
            MatchCollection match = rx.Matches(input);
            string m = string.Empty;
            for (int x = 0; x < match.Count; x++)
            {
                m = match[x].ToString();
                m = m.Replace("<Capital>", "");
                m = m.Replace("</Capital>", "");
                m = m.ToUpper();
                input =  input.Replace(match[x].ToString(), m);
            }
        }
        public static void TagMarker(ref string input)
        {
            Regex rx = new Regex("<Marker>" + ".*" + "</Marker>");
            MatchCollection match = rx.Matches(input);
            string m = string.Empty;
            for (int x = 0; x < match.Count; x++)
            {
                m = "***" + match[x].ToString() + "***";
                m = m.Replace("<Marker>", "");
                m = m.Replace("</Marker>", "");              
                m = m.ToUpper();
                input = input.Replace(match[x].ToString(), m);
            }
        }
        public static void TagHide(ref string input)
        {
            Regex rx = new Regex("<Hide>" + ".*" + "</Hide>");
            MatchCollection match = rx.Matches(input);
            string m = string.Empty;
            string t = string.Empty;
            for (int x = 0; x < match.Count; x++)
            {
                t = match[x].ToString();
                t = t.Replace("<Hide>", "");
                t = t.Replace("</Hide>", "");
                foreach (char c in t) 
                {
                    m += "*";
                }
                input = input.Replace(match[x].ToString(), m);
            }
        }
        public static void TagHash(ref string input)
        {
            Regex rx = new Regex("<Hash>" + ".*" + "</Hash>");
            MatchCollection match = rx.Matches(input);
            string m = string.Empty;
            for (int x = 0; x < match.Count; x++)
            {
                m = match[x].ToString();
                m = m.Replace("<Hash>", "");
                m = m.Replace("</Hash>", "");
                m = m.GetHashCode().ToString();
                input = input.Replace(match[x].ToString(), m);
            }
        }

        static void Main(string[] args)
        {
            string input = args.ToString();
            TagCapital(ref input);
            TagHash(ref input);
            TagHide(ref input);
            TagMarker(ref input);
            Console.WriteLine(input);
        }
    }
}
