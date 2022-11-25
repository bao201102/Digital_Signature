using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digital_Signature.PL
{
    internal class DigSig
    {
        private int q;

        public int Q
        {
            get { return q; }
            set { q = value; }
        }

        private int p;

        public int P
        {
            get { return p; }
            set { p = value; }
        }

        private int n;

        public int N
        {
            get { return n; }
            set { n = value; }
        }

        private int phiN;

        public int PhiN
        {
            get { return phiN; }
            set { phiN = value; }
        }

        private int eKey;

        public int EKey
        {
            get { return eKey; }
            set { eKey = value; }
        }

        private int dKey;

        public int DKey
        {
            get { return dKey; }
            set { dKey = value; }
        }

        //A^-1 mod B
        //Ax = 1(mod B)
        //Ax + By = 1
        private int ExecuteEuclidean(int a, int b)
        {
            List<int> ri = new List<int>();
            List<int> qi = new List<int>();
            List<int> yi = new List<int>();
            List<int> xi = new List<int>();

            ri.Add(b);
            ri.Add(a);
            qi.Add(0);
            qi.Add(0);
            yi.Add(1);
            yi.Add(0);
            xi.Add(0);
            xi.Add(1);

            int i = 2;
            int tempR = 0;
            do
            {
                tempR = ri[i - 2] % ri[i - 1];

                if (tempR == 0)
                {
                    break;
                }

                int tempQ = ri[i - 2] / ri[i - 1];
                ri.Add(tempR);
                qi.Add(tempQ);

                int tempX = xi[i - 2] - qi[i] * xi[i - 1];
                int tempY = yi[i - 2] - qi[i] * yi[i - 1];
                xi.Add(tempX);
                yi.Add(tempY);

                i++;
            } while (tempR != 0);

            int result = xi[xi.Count - 1];

            if (result < 0)
            {
                result += b;
            }

            return result;
        }

        private int GCD(int num1, int num2)
        {
            int Remainder;

            while (num2 != 0)
            {
                Remainder = num1 % num2;
                num1 = num2;
                num2 = Remainder;
            }

            return num1;
        }

        private bool CheckPrimeNum(int num)
        {
            int i;
            for (i = 2; i <= num - 1; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            if (i == num)
            {
                return true;
            }
            return false;
        }

        private double power(int a, int b, int mod)
        {
            int result = 1;
            while (b > 0)
            {
                if ((b & 1) != 0)
                {
                    a = a % mod;
                    result = (result * a) % mod;
                    result = result % mod;
                }
                b = b >> 1;
                a = a % mod;
                a = (a * a) % mod;
                a = a % mod;
            }
            return result;
        }

        private void RandomPQ()
        {
            Random rd = new Random();

            do
            {
                p = rd.Next(0, 99);
            } while (!CheckPrimeNum(p));

            do
            {
                q = rd.Next(0, 99);
            } while (!CheckPrimeNum(q) || q == p);
        }

        public void GenerateKey()
        {
            RandomPQ();

            n = p * q;
            phiN = (p - 1) * (q - 1);

            Random rd = new Random();

            do
            {
                eKey = rd.Next(2, phiN - 1);
            } while (GCD(eKey, phiN) != 1);

            do
            {
                dKey = ExecuteEuclidean(eKey, phiN);
            } while (dKey == eKey);
        }

        public string Sign(string[] s, int eKey, int n)
        {
            string result = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 1)
                {
                    result += power(int.Parse(s[i]), eKey, n).ToString() + " ";
                }
                else if (i == s.Length - 1)
                {
                    result += power(int.Parse(s[i]), eKey, n).ToString();
                }
            }

            return result;
        }

        public string Verify(string[] s, int dKey, int n)
        {
            string result = "";

            for (int i = 0; i < s.Length; i++)
            {
                if (i < s.Length - 1)
                {
                    result += power(int.Parse(s[i]), dKey, n) + " ";
                }
                else if (i == s.Length - 1)
                {
                    result += power(int.Parse(s[i]), dKey, n);
                }
            }

            return result;
        }
    }
}
