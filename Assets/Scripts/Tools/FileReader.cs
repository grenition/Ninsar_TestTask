using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class FileReader
{
    //чтение файла с папки streamingAssets
    public static string ReadTextFile(string streamingAssetsPath)
    {
        string directory = Application.streamingAssetsPath + "/" + streamingAssetsPath;
        if(!File.Exists(Application.streamingAssetsPath + "/" + streamingAssetsPath))
        {
            Debug.LogWarning(directory + " file is not exists");
            return ""; 
        }
        StreamReader reader = new StreamReader(directory);
        return reader.ReadToEnd();
    }
}
