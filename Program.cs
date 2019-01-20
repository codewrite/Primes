using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace primes
{
    internal class Program
    {
        private readonly List<int> primes = new List<int>(); 

        public static void Main(string[] args)
        {
            Program prog = new Program();
            var t1 = DateTime.Now;
            for (int i=2; i<1e6; i++)
            {
                if (prog.IsPrime(i))
                    prog.primes.Add(i);
            }
            var t2 = (DateTime.Now - t1).TotalMilliseconds;
            var primeList = String.Join(", ", prog.primes);
            Console.WriteLine(primeList);
            Console.WriteLine($"{prog.primes.Count:N0} primes calculated in {t2:N0} milliseconds");
        }

        private bool IsPrime(int n)
        {
            int divStop = (int)Math.Sqrt(n);
            bool isPrime = true;
            for (int i=0; i<primes.Count; i++)
            {
                if (n % primes[i] == 0)
                {
                    isPrime = false;
                    break;
                }
                if (primes[i] > divStop)
                    break;
            }
            return isPrime;
        }

        private bool IsPrime2(int n)
        {
            int divStop = (int)Math.Sqrt(n);
            bool isPrime = (from p in primes where p <= divStop select p).All(p => n % p != 0);
            return isPrime;
        }

    }
}
