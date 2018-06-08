using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DotNetCoords;

public class AnvilAgent : MonoBehaviour {
    //name,id,location, orientation, faction
	public string mAgentName;      //[NAME]
    public string mAgentSerial;
	public LatLng mLocation;		//[Location]
    public string mFaction;
    public string locString;
    public bool isSelected;
    private Transform myTransform;

    public string transformString;

    public WayPoint mNavTarget;		//[Nav Target]
    public WayPoint mSensorTarget;  //[Sensor Tgt]
	public string task; 			//[Task]

	public Movement moveScript;

	public List<WayPoint> agentWayPoints;


	public string activeWaypointName;

	private bool moving;

    //Gear - links to equipments by Arrays and List of owned or accessible objects
    //Goals -links to drives and traits classes
    //working memory - unit level blackboard: navTarget, navSequence, schedule, goals, sensorTarget, sensorList
    //Senses - links to perception and awareness

    public AnvilAgent(string agentName, string agentSerial, LatLng location, string faction)
    {
        mAgentName = agentName;
        mAgentSerial = agentSerial;
        mLocation = ConversionTool.LatLongFromUnityVector3D(transform.position);
        mFaction = faction;
        locString = mLocation.ToString();
    }
    private void Start()
    {
		
        myTransform = myTransform = gameObject.GetComponent<Transform>();
		agentWayPoints = new List<WayPoint> ();
		moveScript = gameObject.GetComponent<Movement> ();



		Invoke("addPoints", 1);


    }
    void Update()
    {
        transformString = myTransform.position.x.ToString() + "," + myTransform.position.y.ToString();
        mLocation = ConversionTool.LatLongFromUnityVector3D(myTransform.position);
        locString = mLocation.ToString();


		if(Input.GetKey(KeyCode.Y))
			{
			moving = true;
			}

		if (moving)
		{
			moveScript.moveToWaypoint (agentWayPoints [0]);
		}

		//activeWaypointName = mNavTarget.mWayPointName;
    }

    public string ToSaveString()
    {
        string saveString =
             mAgentName + "," +
             mAgentSerial + "," +
             mLocation+ ","+
             mFaction;
        return saveString;
    }
    public LatLng getLatLong()
    {

        return mLocation = ConversionTool.LatLongFromUnityVector3D(transform.position);
    }
    public string getMGRSString()
    {
        return getLatLong().ToMGRSRef().ToString();
    }

    public void setNavTarget (WayPoint setNavPoint)
    {
        mNavTarget = setNavPoint;
    }

	public void setTask(string newTask)
	{
		task = newTask;
	}



	void addPoints()
	{
		agentWayPoints.Add (new WayPoint (33.951948, -118.402236, 10, "NorthWestAir"));
		agentWayPoints.Add (new WayPoint (33.949028, -118.431064, 10, "SouthWestAir"));
		agentWayPoints.Add (new WayPoint (33.936320, -118.426153, 10, "SouthEastAir"));
		agentWayPoints.Add (new WayPoint (33.940991, -118.383353, 10, "SouthHighway"));
		agentWayPoints.Add (new WayPoint (33.931410, -118.422255, 10, "NorthEastAir"));





	}




}
