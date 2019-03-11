using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AsciiLevelLoader : MonoBehaviour
{
   
    void Start()
    {
        string filePath = Application.dataPath + "/level0.txt";

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath,"X");
        }

        string[] inputLines = File.ReadAllLines(filePath);
        for (int y = 0; y < inputLines.Length; y++)
        {
            string line = inputLines[y];
            for (int x = 0; x < line.Length; x++)
            {
                if (line[x] == 'X')
                {
                    //make a wall
                    GameObject newWall = Instantiate(Resources.Load("Prefabs/Wall")) as GameObject;
                    //change wall position
                    newWall.transform.position = new Vector3(x,y);
                }
            }
        }
    }

    
    void Update()
    {
        
    }
}
