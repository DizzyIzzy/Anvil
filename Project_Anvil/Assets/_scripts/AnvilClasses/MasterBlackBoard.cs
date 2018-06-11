using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class MasterBlackBoard : MonoBehaviour {
    public List<AnvilRoute> allGameRoutes;
    public List<AnvilWayPoint> allGameWayPoints;
    public List<AnvilAgent> allGameAgents;
    private AnvilAgent activeAgent;
    private int wayPointSerial;
    
    public GameObject faction;


	public GameObject controlScript;



    // Use this for initialization

    void Awake()
    {
        allGameAgents = new List<AnvilAgent>(GameObject.Find("Faction1").GetComponentsInChildren<AnvilAgent>());
    }
    void Start () {
        
        allGameWayPoints = new List<AnvilWayPoint>();
        allGameRoutes = new List<AnvilRoute>();

     
        wayPointSerial = GetWayPointSerial();

		controlScript = GameObject.Find("UIController");

		ReadWayPointFile ();
    }
    
    public int GetWayPointSerial()
    {
        return allGameWayPoints.Count;
    }
    public void createAWayPoint()
    {
        Debug.Log("this is waypoint" + wayPointSerial);
        string wayPointName = "WPT" + wayPointSerial;
        AnvilWayPoint newWayPoint = new AnvilWayPoint(wayPointSerial, wayPointSerial, wayPointSerial, wayPointName);
        allGameWayPoints.Add(newWayPoint);
        Debug.Log(newWayPoint.ToString());
        wayPointSerial++;
    }
    public void ListPointsToConsole()
    {
        Debug.Log("BlackBoard WayPoints:");
        foreach (AnvilWayPoint thisPoint in allGameWayPoints)
        {
            Debug.Log(thisPoint.ToString());
        }
    }

    public void SaveWayPointFile()
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

    public void ReadWayPointFile()
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

		controlScript.GetComponent<UIControlScript> ().nextRoute();


    }   

    //for debug purposes
    public void ListAllAgentsToConsole()
    {
        foreach (AnvilAgent thisAgent in allGameAgents)
        {
            Debug.Log(thisAgent.agentName + " in blackboard");
        }
    }

    public void setActiveAgent (AnvilAgent newActiveAgent)
    {
        activeAgent = newActiveAgent;
    }

    public AnvilAgent getActiveAgent()
    {
        return activeAgent;
    }

}
