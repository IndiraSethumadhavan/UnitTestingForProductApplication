using System;

namespace Inlämning4
{
    public static class Dumper
    {
        public static void Dump<T>(this T v, string s)
        {
            Console.WriteLine(s + " : " + v);
        }

        public static void Dump<T>(this T v)
        {
            Console.WriteLine(v);
        }
    }
}
