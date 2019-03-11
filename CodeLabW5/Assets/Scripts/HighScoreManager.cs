using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class HighScoreManager : MonoBehaviour
{
    public List<string> hsNames;
    public List<int> hsScores;
    
    void Start()
    {
        string filePath = Application.dataPath + "/highScore.txt";
        
        //IF THE FILE DON'T EXIST, WE CREATE IT
        if (!File.Exists(filePath)) //file don't exist yo
        {
            //create file
            string output = "";

            for (int i = 0; i < 10; i++)
            {
                output += "NotMatt:" + (10-i) + '\n';
            }
            Debug.Log("Output: "+ output);
            File.WriteAllText(filePath,output);
        }
        
        // initialize list here
        // not reqd. since the inspector initializes public variables for us
        //hsNames = new List<string>();
        //hsScores = new List<int>();
        
        //if file exists, read it 
        string[] inputLines= File.ReadAllLines(filePath);
        for (int i = 0; i < inputLines.Length; i++)
        {
            string line = inputLines[i]; //ex: "Matt:10"
            string[] splitLine = line.Split(':'); //ex: "Matt" | "10"
            string name = splitLine[0]; //ex: "Matt"
            int score = Int32.Parse(splitLine[1]); //ex: 10
            
            hsNames.Add(name); //put name in my list of names
            hsScores.Add(score); //put score in my list of scores
        }
    }
}
