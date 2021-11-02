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
            List<string> txtm = new List<string>();
            string m = string.Empty;
            for (int x = 0; x < match.Count; x++)
            {
                m.Replace("<Capital>", "");
                m.Replace("</Capital>", "");
                m = match[x].ToString();
                m.ToUpper();
                txtm.Add(m);
            }
            for (int v = 0; v < match.Count; v++)
            {
                input.Replace(m, txtm[v]);
            }
        }
        public static void TagMarker(ref string input)
        {
            Regex rx = new Regex("<Marker>" + ".*" + "</Marker>");
            MatchCollection match = rx.Matches(input);
            List<string> txtm = new List<string>();
            string m = string.Empty;
            for (int x = 0; x < match.Count; x++)
            {
                m.Replace("<Marker>", "");
                m.Replace("</Marker>", "");
                m = "***" + match[x].ToString() + "***";
                m.ToUpper();
                txtm.Add(m);
            }
            for (int v = 0; v < match.Count; v++)
            {
                input.Replace(m, txtm[v]);
            }
        }
        public static void TagHide(ref string input)
        {
            Regex rx = new Regex("<Hide>" + ".*" + "</Hide>");
            MatchCollection match = rx.Matches(input);
            List<string> txtm = new List<string>();
            string m = string.Empty;
            for (int x = 0; x < match.Count; x++)
            {
                m.Replace("<Hide>", "");
                m.Replace("</Hide>", "");
                for (int h = 0; h < match[x].ToString().Length; h++)
                {
                    m += "*";
                }
                txtm.Add(m);
            }
            for (int v = 0; v < match.Count; v++)
            {
                input.Replace(m, txtm[v]);
            }
        }
        public static void TagHash(ref string input)
        {
            Regex rx = new Regex("<Hash>" + ".*" + "</Hash>");
            MatchCollection match = rx.Matches(input);
            List<string> txtm = new List<string>();
            string m = string.Empty;
            for (int x = 0; x < match.Count; x++)
            {
                m.Replace("<Hash>", "");
                m.Replace("</Hash>", "");
                m.GetHashCode();
                txtm.Add(m);
            }
            for (int v = 0; v < match.Count; v++)
            {
                input.Replace(m, txtm[v]);
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
