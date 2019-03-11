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
                // create an empty tile GameObject
                GameObject tile = null;
                switch (line[x])
                {
                    case 'X':
                        //make a wall
                        tile = Instantiate(Resources.Load("Prefabs/Wall")) as GameObject;
                        break;
                    case '*':
                         tile = Instantiate(Resources.Load("Prefabs/Berry")) as GameObject;
                        break;
                    case 'P':
                       tile = Instantiate(Resources.Load("Prefabs/Player")) as GameObject;
                        break;
                    case 'T':
                        tile = Instantiate(Resources.Load("Prefabs/Goal")) as GameObject;
                        break;
                    default:
                        tile = null;
                        break;
                }
                // position the tile
                if (tile != null)
                        {
                            tile.transform.position = new Vector3(x - line.Length / 2f, inputLines.Length / 2f - y);
                        }
            }
        }
    }
}
