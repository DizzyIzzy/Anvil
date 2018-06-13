using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEngine;

public class SimpleTextFileManager : MonoBehaviour {

    private GameObject blackBoard;
   

    private void Start()
    {
        blackBoard = GameObject.Find("Blackboard");
    }
    public void SaveWayPointFile()
    {
        List<AnvilWayPoint> allWayPoints =  MasterBlackBoard.allGameWayPoints;
        string timeString = DateTime.Now.ToString("yyMMddHHMMss");
        string path = "Assets/Resources/Saves/" + timeString + ".txt";
        StreamWriter writer = new StreamWriter(path);

        foreach (AnvilWayPoint thisPoint in allWayPoints)
        {
            string output = thisPoint.ToString();
            writer.WriteLine(output);
        }
        writer.Close();
    }
}
