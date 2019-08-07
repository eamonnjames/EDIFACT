using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ABM
{
    class Program
    {
        static void Main(string[] args)
        {
            var stringToParse = "UNA:+.? 'UNB + UNOC:3 + 2021000969 + 4441963198 + 180525:1225 + 3VAL2MJV6EH9IX + KMSV7HMD + CUSDECU - IE++1++1'UNH + EDIFACT + CUSDEC:D: 96B: UN: 145050' BGM + ZEM:::EX + 09SEE7JPUV5HC06IC6 + Z'LOC + 17 + IT044100'LOC + 18 + SOL'LOC + 35 + SE'LOC + 36 + TZ'LOC + 116 + SE003033'DTM + 9:20090527:102'DTM + 268:20090626:102'DTM + 182:20090527:102'";
            var data = ParseStringWithRegularExpression(stringToParse, @"LOC\s*\+\d*\s*\d*\s*\+\s*[^']*");
            var SecondAndThirdElement = LocData(data);
        }


        private static List<string> ParseStringWithRegularExpression(string text, string expr)
        {
            var matchesList = (from Match m in Regex.Matches(text, expr) select m.Value).ToList();
            return matchesList;
        }

        private static Dictionary<string, string> LocData(List<string> data)
        {
            var SecondAndThirdElement = new Dictionary<string, string>();
            var TrimData = new List<string>();
            data.ForEach(x =>  {TrimData.Add(x.Replace(" ","")); });

            TrimData.ForEach(y =>
            {
                string[] elements = y.Split('+');
                SecondAndThirdElement.Add(elements[1], elements[2]);
            });

            return SecondAndThirdElement;
        }
    }
}
