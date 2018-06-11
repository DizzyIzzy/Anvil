using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DotNetCoords;

public class AnvilAgent : MonoBehaviour {
    //name,id,location, orientation, faction
    public int agentID;
    private int health;
    
    public Quaternion interestOrientation;
    public bool isSelected;
    public bool isImmortal;
    public string agentName;      //[NAME]
    public string agentSerial;
	public LatLng locationLatLng;		//[Location]
    public string Faction;
    public string locString;
    
    private Transform myTransform;

    public string transformString;

    public AnvilWayPoint navTarget;		//[Nav Target]
    public AnvilWayPoint sensorTarget;  //[Sensor Tgt]
	public string task; 			//[Task]

	public Movement moveScript;

	public List<AnvilWayPoint> agentWayPoints;

	public string activeWaypointName;

	private bool moving;

    //Gear - links to equipments by Arrays and List of owned or accessible objects
    //Goals -links to drives and traits classes
    //working memory - unit level blackboard: navTarget, navSequence, schedule, goals, sensorTarget, sensorList
    //Senses - links to perception and awareness

    public AnvilAgent()
    {
        
        
    }

    public AnvilAgent(string agentName, string agentSerial, LatLng location, string faction)
    {
        this.agentName = agentName;
        this.agentSerial = agentSerial;
        locationLatLng = ConversionTool.LatLongFromUnityVector3D(transform.position);
        Faction = faction;
        locString = locationLatLng.ToString();
    }
    private void Start()
    {
		if (this.agentName == "")
        {
            this.agentName = randomNameGenerator.generateName();
        }
        if (this.agentSerial == "")
        {
            this.agentSerial = randomNameGenerator.generateLetter() + randomNameGenerator.generateLetter() + ((int)Random.Range(0, 10000)).ToString();
        }
            myTransform = myTransform = gameObject.GetComponent<Transform>();
		agentWayPoints = new List<AnvilWayPoint> ();
		moveScript = gameObject.GetComponent<Movement> ();



		Invoke("addPoints", 1);


    }
    void Update()
    {
        transformString = myTransform.position.x.ToString() + "," + myTransform.position.y.ToString();
        locationLatLng = ConversionTool.LatLongFromUnityVector3D(myTransform.position);
        locString = locationLatLng.ToString();


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
             agentName + "," +
             agentSerial + "," +
             locationLatLng+ ","+
             Faction;
        return saveString;
    }
    public LatLng getLatLong()
    {

        return locationLatLng = ConversionTool.LatLongFromUnityVector3D(transform.position);
    }
    public string getMGRSString()
    {
        return getLatLong().ToMGRSRef().ToString();
    }

    public void setNavTarget (AnvilWayPoint setNavPoint)
    {
        navTarget = setNavPoint;
    }

	public void setTask(string newTask)
	{
		task = newTask;
	}

    void addPoints()
	{
		agentWayPoints.Add (new AnvilWayPoint (33.951948, -118.402236, 10, "NorthWestAir"));
		agentWayPoints.Add (new AnvilWayPoint (33.949028, -118.431064, 10, "SouthWestAir"));
		agentWayPoints.Add (new AnvilWayPoint (33.936320, -118.426153, 10, "SouthEastAir"));
		agentWayPoints.Add (new AnvilWayPoint (33.940991, -118.383353, 10, "SouthHighway"));
		agentWayPoints.Add (new AnvilWayPoint (33.931410, -118.422255, 10, "NorthEastAir"));
    }
    public void setHealth(int healthAmount)
    {
        this.health = healthAmount;
    }

    public void takeDamage(int damageAmount)
    {
        this.health = this.health - damageAmount;
    }



}
