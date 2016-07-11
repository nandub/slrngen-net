#region License
// Copyright (c) 2016 Fernando Ortiz
//
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion

using System;

namespace Hellosaint.SLRN
{
    public class SLRNGenerator
    {
        private static Random rnd = new Random();
        private static int min    = 10000000;
        private static int max    = 99999999;

        public static String CreateSLRN() 
        {
            int eigth = rnd.Next(min, max); 
            int ninth = CalculateChecksumDigit("" + eigth);
            return Convert.ToString(eigth) + Convert.ToString(ninth);
        }
        
        public static bool VerifySLRN(String code)
        {
            String result      = code.Replace("-", "");
            String eigthString = result.Substring(0,result.Length-1);
            int ninth          = CalculateChecksumDigit(eigthString);
            return (eigthString + ninth).Equals(result);
        }

        public static int CalculateChecksumDigit(String code)
        {
            String prefixAndCode = "2672" + code;
            String codeWithoutVd = prefixAndCode.Substring(0, 12);
            int e = SumEven(codeWithoutVd);
            int o = SumOdd(codeWithoutVd);
            int me = o * 3;
            int s = me + e;
            int dv = GetEanVd(s);
            return dv;
        }

        private static int GetEanVd(int s) 
        {
            return (10 - (s % 10)) % 10;
        }

        private static int SumEven(String code) 
        {
            int sum = 0;
            for (int i = 0; i < code.Length; i++) 
            {
                if (IsEven(i)) 
                {
                    sum += (int)Char.GetNumericValue(code[i]);
                }
            }
            return sum;
        }
        
        private static int SumOdd(String code) 
        {
            int sum = 0;
            for (int i = 0; i < code.Length; i++) {
                if (!IsEven(i)) 
                {
                    sum += (int)Char.GetNumericValue(code[i]);
                }
            }
            return sum;
        }

        private static bool IsEven(int i) 
        {
            return i % 2 == 0;
        }
    }
}
