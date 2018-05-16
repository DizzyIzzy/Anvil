using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using Mapbox.Geocoding;
using System.Text;
using Mapbox.Json;
using Mapbox.Platform;
using Mapbox.Utils.JsonConverters;
using Mapbox.Utils;
using Mapbox.Unity;

public class ReadLocationFile : MonoBehaviour {

    public List<string> allLocations;

    // Use this for initialization
    void Start () {
        ReadLocation();
}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReadLocation()
    {
        allLocations = new List<string>();
        string fileName = "Locations";
        string path = "Assets/Resources/" + fileName + ".txt";
        StreamReader reader = new StreamReader(path);
        string readString = reader.ReadLine();
        //    Debug.Log("trying saving to: " + path);
        while (readString != null)
        {
            char[] delimiter = { ',' };
            string[] fields = readString.Split(delimiter);

            allLocations.Add(fields[0]);
            readString = reader.ReadLine();
        }
        Debug.Log(allLocations[0] + " : " + allLocations[1]);
        // load the locations
        //HandleLocationInput("lyman wy"); // change the location here if you want to test out finding coords
    }

    public void SaveLocation()
    {

        string path = "Assets/Resources/Locations.txt";
        StreamWriter writer = new StreamWriter(path);
        foreach (string thisPoint in allLocations)
        {
            writer.WriteLine(thisPoint);
        }
        writer.Close();
    }
}
