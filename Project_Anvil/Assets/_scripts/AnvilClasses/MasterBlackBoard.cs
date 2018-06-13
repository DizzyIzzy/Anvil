using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public static class MasterBlackBoard  {
    static public List<AnvilRoute> allGameRoutes;
    static public List<AnvilWayPoint> allGameWayPoints;
    static public List<AnvilAgent> allGameAgents;
    static public List<FactionController> allFactions;
    static private AnvilAgent activeAgent;
    static private int wayPointSerial;

    static public GameObject controlScript;

    // Use this for initialization

    public static void InitializeMasterBlackBoard()
    {
        controlScript = GameObject.Find("UIController");
        ReadWayPointsFromFile ();
        RefreshAllNavigationInfo();
        RefreshAllAgentsList();
    }

    static public void RefreshAllAgentsList()
    {
        allGameAgents = new List<AnvilAgent>();
        allFactions = new List<FactionController>(GameObject.Find("GameController").GetComponentsInChildren<FactionController>());
        foreach(FactionController faction in allFactions)
        {
            allGameAgents.AddRange(faction.factionAgentList);
        }
     }

    static public void RefreshAllNavigationInfo()
    {
        allGameWayPoints = new List<AnvilWayPoint>();
        allGameRoutes = new List<AnvilRoute>();
        wayPointSerial = GetWayPointSerial();
    }

    // void Start () {

    //    allGameWayPoints = new List<AnvilWayPoint>();
    //    allGameRoutes = new List<AnvilRoute>();
    //      wayPointSerial = GetWayPointSerial();
    //  controlScript = GameObject.Find("UIController");

    //	ReadWayPointsFromFile ();


    static public int GetWayPointSerial()
    {
        return allGameWayPoints.Count;
    }

    static public void createAWayPoint()
    {
        Debug.Log("this is waypoint" + wayPointSerial);
        string wayPointName = "WPT" + wayPointSerial;
        AnvilWayPoint newWayPoint = new AnvilWayPoint(wayPointSerial, wayPointSerial, wayPointSerial, wayPointName);
        allGameWayPoints.Add(newWayPoint);
        Debug.Log(newWayPoint.ToString());
        wayPointSerial++;
    }
    static public void ListPointsToConsole()
    {
        Debug.Log("BlackBoard WayPoints:");
        foreach (AnvilWayPoint thisPoint in allGameWayPoints)
        {
            Debug.Log(thisPoint.ToString());
        }
    }

    static public void SaveWayPointsToFile()
    {
 
        string timeString = DateTime.Now.ToString("yyMMddHHMMss");//would be used if wanted multiple states of saves by inserting the timestring into the filename
                                                                  //  string path = "Assets/Resources/Saves/WPT" +timeString+ ".txt";
        string path = "Assets/Resources/Saves/Waypoints.txt";
        StreamWriter writer = new StreamWriter(path);
    //    Debug.Log("trying saving to: " + path);
        foreach (AnvilWayPoint thisPoint in allGameWayPoints)
        {
            string output = thisPoint.ToSaveString();
          //  Debug.Log("putting out:" +thisPoint.ToSaveString());
            writer.WriteLine(output);
        }
      //  Debug.Log("Closing Writer");
        writer.Close();
    }

    static public void ReadWayPointsFromFile()
    {
        allGameWayPoints = new List<AnvilWayPoint>();
        string fileName = "Waypoints";
        string path = "Assets/Resources/Saves/" + fileName +".txt";
        StreamReader reader = new StreamReader(path);
        string readString = reader.ReadLine();
        //    Debug.Log("trying saving to: " + path);
        while(readString != null)
        {
            char[] delimiter = {','};
            string[] fields = readString.Split(delimiter);

		//	Debug.Log ("Fields 0: " + fields[0]);
			//Debug.Log ("Fields 1: " + fields[1]);
			//Debug.Log ("Fields 2: " + fields[2]);
           
            allGameWayPoints.Add(new AnvilWayPoint(Convert.ToDouble(fields[0]), Convert.ToDouble(fields[1]), Convert.ToDouble(fields[2]), fields[3]));
           
		


			readString = reader.ReadLine();
        }


        AnvilRoute loadedRoute = new AnvilRoute(fileName, allGameWayPoints);
        allGameRoutes.Add(loadedRoute);


      //  GameObject.Find("UIController").GetComponent<UserControlScript>().UpdateRouteUIInfo();

	//	controlScript.GetComponent<UIControlScript> ().nextRoute();


    }   

    //for debug purposes
    static public void ListAllAgentsToConsole()
    {
        foreach (AnvilAgent thisAgent in allGameAgents)
        {
            Debug.Log(thisAgent.agentName + " in blackboard");
        }
    }

    static public void setActiveAgent (AnvilAgent newActiveAgent)
    {
        activeAgent = newActiveAgent;
    }

    static public AnvilAgent getActiveAgent()
    {
        return activeAgent;
    }





}
