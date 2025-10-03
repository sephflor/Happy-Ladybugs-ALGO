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
     * Complete the 'happyLadybugs' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING b as parameter.
     */

    public static string happyLadybugs(string b)
    {
         Dictionary<char, int> counts = new Dictionary<char, int>();
        bool hasEmpty = false;

        foreach (char c in b)
        {
            if (c == '_')
            {
                hasEmpty = true;
                continue;
            }

            if (!counts.ContainsKey(c))
                counts[c] = 0;
            counts[c]++;
        }

       
        foreach (var kvp in counts)
        {
            if (kvp.Value == 1)
                return "NO";
        }

        
        if (hasEmpty)
            return "YES";

        
        for (int i = 0; i < b.Length; i++)
        {
            if ((i > 0 && b[i] == b[i - 1]) || (i < b.Length - 1 && b[i] == b[i + 1]))
                continue;
            else
                return "NO";
        }

        return "YES";
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int g = Convert.ToInt32(Console.ReadLine().Trim());

        for (int gItr = 0; gItr < g; gItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            string b = Console.ReadLine();

            string result = Result.happyLadybugs(b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
