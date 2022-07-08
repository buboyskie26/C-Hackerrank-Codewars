using System;
using System.Collections.Generic;
using System.Text;

namespace BuildPrac
{
    public static class Algorithm
    {

        /*   public static int[] BubbleSort(int[] array)
           {
               for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
               {
                   for (int i = 0; i < partIndex; i++)
                   {
                       if (array[i] > array[i + 1])
                       {
                           Swap(array, i, i + 1);
                       }
                   }
               }
               Console.WriteLine(array);
               return array;
           }*/

        public static int[] BubbleSort(int[] array)
        {
            int temp = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if(array[j] > array[j + 1])
                    {
                        Swap(array, i, i);
                    }
                }
            }
            return array;
        }
   
        private static void Swap(int[] array, int n1, int n2)
        {
            if (n1 == n2) return;

            int temp = array[n1 + 1];
            array[n1+1] = array[n2];
            array[n2] = temp;
        }
    }
}
