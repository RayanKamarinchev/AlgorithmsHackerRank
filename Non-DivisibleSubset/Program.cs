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
     * Complete the 'biggerIsGreater' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING w as parameter.
     */

    public static string biggerIsGreater(string w)
    {
        int l = w.Length;
        if (l < 2)
        {
            return "no answer";
        }
        int i = 2;
        string workable = w.Substring(l-i, i);
        try
        {
            while (workable.Max() == workable[0])
            {
                i++;
                workable = w.Substring(l - i, i);
            }
        }
        catch (Exception e)
        {
            return "no answer";
        }
        char replacor = workable.Where(c => c > workable[0]).Min();
        string res = replacor+"";
        workable = workable.Remove(workable.IndexOf(replacor), 1);
        for (int j = 0; j < i-1; j++)
        {
            char add = workable.Min();
            res += add;
            workable = workable.Remove(workable.IndexOf(add), 1);
        }
        return w.Substring(0, l - i) + res;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            string w = Console.ReadLine();

            string result = Result.biggerIsGreater(w);

            Console.WriteLine(result);
        }

        //textWriter.Flush();
        //textWriter.Close();
    }
}