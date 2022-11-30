using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'queensAttack' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER r_q
     *  4. INTEGER c_q
     *  5. 2D_INTEGER_ARRAY obstacles
     */

    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        int sum = 0;
        if (obstacles.Where(o => o[1] == c_q && o[0] > r_q).Count() != 0)
        {
            sum += obstacles.Where(o => o[1] == c_q && o[0] > r_q).Select(o => o[0]).Min() - r_q;
        }
        else
        {
            sum += n - r_q;
        }

        if (obstacles.Where(o => o[1] == c_q && o[0] < r_q).Count() != 0)
        {
            sum += r_q - obstacles.Where(o => o[1] == c_q && o[0] < r_q).Select(o => o[0]).Max();
        }
        else
        {
            sum += r_q - n;
        }
        if (obstacles.Where(o => o[0] == r_q && o[1] > c_q).Count() != 0)
        {
            sum += obstacles.Where(o => o[0] == r_q && o[1] > c_q).Select(o => o[1]).Min() - c_q;
        }
        else
        {
            sum += c_q-1;
        }
        if (obstacles.Where(o => o[0] == r_q && o[1] < c_q).Count() != 0)
        {
            sum += c_q - obstacles.Where(o => o[0] == r_q && o[1] < c_q).Select(o => o[1]).Max();
        }
        else
        {
            sum += r_q-1;
        }
        if (obstacles.Where(o => o[0] - r_q == o[1] - c_q).Select(o => o[1]).Count() != 0)
        {
            sum += obstacles.Where(o => o[0] - r_q == o[1] - c_q).Select(o => o[1]).Min() - c_q;
        }
        else
        {
            sum += c_q - n - 1;
        }
        if (obstacles.Where(o => o[0] - r_q == c_q - o[1]).Count() != 0)
        {
            sum += obstacles.Where(o => o[0] - r_q == c_q - o[1]).Select(o => o[1]).Min() - c_q;
        }
        else
        {
            sum += n - 1;
        }
        if (obstacles.Where(o => r_q - o[0] == o[1] - c_q).Count() != 0)
        {
            sum += c_q - obstacles.Where(o => r_q - o[0] == o[1] - c_q).Select(o => o[1]).Max();
        }
        else
        {
            sum += c_q-n;
        }
        if (obstacles.Where(o => r_q - o[0] == c_q - o[1]).Count() != 0)
        {
            sum += c_q - obstacles.Where(o => r_q - o[0] == c_q - o[1]).Select(o => o[1]).Max();
        }
        else
        {
            sum += c_q-n;
        }
        return sum;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r_q = Convert.ToInt32(secondMultipleInput[0]);

        int c_q = Convert.ToInt32(secondMultipleInput[1]);

        List<List<int>> obstacles = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            obstacles.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(obstaclesTemp => Convert.ToInt32(obstaclesTemp)).ToList());
        }

        int result = Result.queensAttack(n, k, r_q, c_q, obstacles);
        Console.WriteLine(result);
        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}