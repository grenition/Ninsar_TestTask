using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringHelper 
{
    //извлечение чисел из текста  
    public static int[][] GetMatrixFromText(string text)
    {
        List<int[]> matrix = new List<int[]>();
        foreach (var line in text.Split('\n'))
        {
            List<int> row = new List<int>();

            for(int i = 0; i < line.Length; i++)
            { 
                if (int.TryParse(line[i].ToString(), out int res))
                    row.Add(res);
            }

            if(row.Count != 0)
                matrix.Add(row.ToArray());
        }
        return matrix.ToArray();
    }
}
