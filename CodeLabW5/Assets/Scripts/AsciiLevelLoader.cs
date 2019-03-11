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
                switch (line[x])
                {
                    case 'X':
                        //make a wall
                        GameObject newWall = Instantiate(Resources.Load("Prefabs/Wall")) as GameObject;
                        //change wall position
                        newWall.transform.position = new Vector3(x - line.Length / 2f, -y + inputLines.Length/2f);
                        break;
                    case '*':
                        GameObject newBerry = Instantiate(Resources.Load("Prefabs/Berry")) as GameObject;
                        //change wall position
                        newBerry.transform.position = new Vector3(x - line.Length / 2f,inputLines.Length/2f - y);
                        break;
                    case 'P':
                        GameObject newPlayer = Instantiate(Resources.Load("Prefabs/Player")) as GameObject;
                        //change wall position
                        newPlayer.transform.position = new Vector3(x - line.Length / 2f,inputLines.Length/2f - y);
                        break;
                    case 'T':
                        GameObject newGoal = Instantiate(Resources.Load("Prefabs/Goal")) as GameObject;
                        //change wall position
                        newGoal.transform.position = new Vector3(x - line.Length / 2f,inputLines.Length/2f - y);
                        break;
                }
            }
        }
    }
}
