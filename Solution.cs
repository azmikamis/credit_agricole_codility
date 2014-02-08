using System;
using System.Collections.Generic;
// you can also use other imports, for example:
// using System.Collections.Generic;
class Solution
{
    public static int solution1(int[] A)
    {
        Dictionary<int, int> d = new Dictionary<int, int>();
        foreach (int i in A)
        {
            if (!d.ContainsKey(i))
                d.Add(i, 1);
            else
                d[i] += 1;
        }
        foreach (var pair in d)
        {
            if (pair.Value == 1)
                return pair.Key;
        }
        return 0;
    }

    public static int solution2(int[] A)
    {
        if(A.Length < 2)
            return 0;

        Array.Sort(A);

        int d = A[1] - A[0];
        for (int i = 2; i < A.Length - 1; i++)
        {
            d = Math.Min(d, A[i] - A[i - 1]);
        }

        return d;
    }

    public static string solution3(string S)
    {
        Queue<char> q = new Queue<char>();
        foreach (char c in S)
        {
            q.Enqueue(c);
        }
        string s = "";
        while (q.Count > 0)
        {
            if (s.Length >= 1)
            {
                string last = s.Substring(s.Length - 1, 1);
                if (last + q.Peek() == "AB" || last + q.Peek() == "BA" || last + q.Peek() == "AA")
                {
                    s += q.Dequeue();
                    s = s.Replace(s.Substring(s.Length - 2, 2), "A");
                }
                else if (last + q.Peek() == "CB" || last + q.Peek() == "BC" || last + q.Peek() == "CC")
                {
                    q.Dequeue();
                    s = s.Replace(s.Substring(s.Length - 2, 2), "C");
                }
                else
                {
                    s += q.Dequeue();
                }
            }
            else
            {
                s += q.Dequeue();
            }
        }

        return s;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(solution1(new int[] {2, 2, 3, 3, 4, 4}));
        Console.WriteLine(solution3("ABABABC"));
    }
}
