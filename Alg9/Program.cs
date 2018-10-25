using System;
using System.Collections.Generic;
using System.Linq;

namespace Alg9
{
    class Program
    {
        static void Main(string[] args)
        {
            var perms = Permutation(4, 4);
            PrintPermutations(perms);
            Console.ReadKey();

        }

        static void PrintPermutations(IEnumerable<int[]> permutations)
        {
            foreach (var permutation in permutations)
            {
                foreach (var element in permutation)
                {
                    Console.Write(element);
                }
                Console.WriteLine();
            }
        }

        static IEnumerable<int[]> Permutation(int length, int level)
        {
            if (level == 1)
            {
                return new List<int[]>
                {
                    new int[] { length }
                };
            }

            //permutations.Trans()
            var permutations = Permutation(length, level - 1);
            var newPermutations = new List<int[]>();
            foreach (var permutation in permutations)
            {
                var tempPerm = new int[level];
                tempPerm[0] = length - level + 1;
                for (int i = 0; i < permutation.Length; i++)
                {
                    tempPerm[i + 1] = permutation[i];
                }
                
                newPermutations.Add(tempPerm.Clone() as int[]);
                for (int i = 0; i < tempPerm.Length - 1; i++)
                {
                    tempPerm.Trans(i, i + 1);
                    newPermutations.Add(tempPerm.Clone() as int[]);
                }

                //foreach (var element in permutation)
                //{
                //    newPermutations.Add(element);
                //}
                
            }
            return newPermutations;
        }

    }

    public static class Extension
    {
        public static T[] Trans<T>(this T[] array, int firstIndex, int secondIndex)
        {
            var firstElement = array[firstIndex];
            array[firstIndex] = array[secondIndex];
            array[secondIndex] = firstElement;
            return array;
        }

    }
}
