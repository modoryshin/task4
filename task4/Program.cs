using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace task4
{
    class Program
    {
        static int Number(string n)
        {
            string n1 = n.Trim();
            return Convert.ToInt32(n1);
        }
        static double[] Array(string n, int num)
        {
            string n1 = n.Trim(' ');
            string[] arr = new string[num];
            int c = 0;
            for (int i = 0; i < num && c < n1.Length; i++)
            {
                try
                {
                    while (n1[c] != ' ')
                    {
                        arr[i] = arr[i] + n1[c];
                        c++;
                    }
                    n1 = n1.Remove(0, c);
                    n1 = n1.Trim();
                    c = 0;
                }
                catch (IndexOutOfRangeException)
                {
                    break;
                }
            }
            double[] mas = new double[num];
            for (int i = 0; i < num; i++)
            {
                mas[i] = Convert.ToDouble(arr[i]);
            }
            return mas;
        }
        static double[] InsertionSort(double[] array)
        {
            double[] result = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && result[j - 1] > array[i])
                {
                    result[j] = result[j - 1];
                    j--;
                }
                result[j] = array[i];
            }
            return result;
        }
        static void Main(string[] args)
        {
            FileStream f = new FileStream("input.txt", FileMode.OpenOrCreate);
            StreamReader r = new StreamReader(f);
            string s1 = r.ReadLine();
            string s2 = r.ReadLine();
            f.Close();
            r.Close();
            int num = Number(s1);
            double[] mas = Array(s2, num);
            double[,] mas1 = new double[2, mas.Length];
            for(int i = 0; i < mas.Length; i++)
            {
                mas1[1, i] = i + 1;
                mas1[0, i] = mas[i];
            }

            double[] res = InsertionSort(mas);
            int[] people = new int[3];
            for(int i = 0; i < mas.Length; i++)
            {
                if (mas1[0, i] == res[0])
                {
                    people[0] = Convert.ToInt32(mas1[1, i]);
                }
                if (mas1[0, i] == res[res.Length / 2])
                {
                    people[1]= Convert.ToInt32(mas1[1, i] );
                }
                if (mas1[0, i] == res[res.Length - 1])
                {
                    people[2]= Convert.ToInt32(mas1[1, i]);
                }
            }
            FileStream f1 = new FileStream("output.txt", FileMode.Create);
            StreamWriter w = new StreamWriter(f1);
            foreach (double x in people)
            {
                w.Write(x + " ");
            }
            w.Close();
            f1.Close();
        }
    }
}
