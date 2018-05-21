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

public class ReadLocationFile : MonoBehaviour
{

    public List<string> allLocations;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // public List<string> ReadLocation()
    // takes input from a file and puts them into a list of strings to be used on splash screen
    public List<string> ReadLocation()
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
        return allLocations;
    }
}
