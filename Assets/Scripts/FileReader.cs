using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class FileReader
{
    /// <summary>
    /// read text from file in streaming assets
    /// </summary>
    /// <param name="path"></param>
    /// path inside streaming assets
    /// <returns></returns>
    public static string ReadTextFile(string path)
    {
        StreamReader reader = new StreamReader(Application.streamingAssetsPath + "/" + path);
        return reader.ReadToEnd();
    }
}
