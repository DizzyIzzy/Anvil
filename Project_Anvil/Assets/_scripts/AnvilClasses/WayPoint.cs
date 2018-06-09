using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DotNetCoords;
using System;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;

public class WayPoint{
	AbstractMap _map;

    public LatLng latLong;
    string wayPointSerialID;
    public string mWayPointName;
    string wayPointShortTitle;
    string group;
    public double mLatitude;
    public  double mLongitude;
    public double mElevation;
    public static int lastUnassignedSerial=0;

    private GameObject blackBoard;
    private int blackBoardWayPointSerial;
    private List<WayPoint> blackBoardWayPointList;

    public Vector3 position;

    void Start()
    {
		_map = GameObject.Find ("Map").GetComponent<AbstractMap> ();
        blackBoard = GameObject.Find("BlackBoard");
        // blackBoardWayPointSerial = blackBoard.GetComponent<BlackBoardScript>().GetWayPointSerial();
        blackBoardWayPointSerial = 5;
        blackBoardWayPointList = blackBoard.GetComponent<BlackBoardScript>().allGameWayPoints;

		position = new Vector3 ();
    }
    public WayPoint (double latitude, double longitude, double height, string newWayPointName)
    {
        string serialString = DateTime.Now.ToShortDateString();
        string wayPointSerialID = serialString + lastUnassignedSerial.ToString();
        mLatitude = latitude;
        mLongitude = longitude;
        mElevation = height;
        mWayPointName = newWayPointName;
        lastUnassignedSerial ++;
        latLong = new LatLng(latitude, longitude, height);


	//	Vector2d vectorLatLong = new Vector2d(latitude, longitude);

//		position = Conversions.GeoToWorldPosition(vectorLatLong, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();

        wayPointShortTitle = newWayPointName;
        PostToBlackboard();
    }

    override public string ToString()
    {
        string wptString = mWayPointName + "/" + mLatitude + "/" + mLongitude;
        return wptString;
    }

    public string LatLonString()
    {
        string wptString = "Lat: " + mLatitude+ "\nLong: " +  mLongitude + "\nElev: " + mElevation;
        return wptString;
    }
    //TODO method return WayPoint as KML string (https://developers.google.com/kml/documentation/kmlreference#point)

    public void SetLatLongFromXYZ(Vector3 unityCoords)
    {
        
    }

    private void PostToBlackboard()
    {
        //blackBoardWayPointList.Add(this.);
    }

    public string ToSaveString()
    {
        string saveString =
              mLatitude + "," +
        mLongitude + "," +
        mElevation + "," +
        mWayPointName ;
        return saveString;

    }

    //public Vector3 ToUnityVector3()
    //{
    //    return Conversions.GeoToWorldGlobePosition(mLatitude, mLongitude, 6378137 + (float)mElevation);
    //}
}
