using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ReadText {

    public static List<string> wordPool = new List<string>();
    
    public static void ReadWordPool() {
        string path = "Assets/Resources/WordPoolLow.txt";
        string currLine;
        
        StreamReader reader = new StreamReader(path);
        while((currLine=reader.ReadLine()) != null)
            {
                wordPool.Add(currLine);
            }
    }
}
