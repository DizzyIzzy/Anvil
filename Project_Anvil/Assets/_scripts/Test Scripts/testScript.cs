using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void callAletter()
    {
        string output = randomValuesGenerator.generateNameInitialFromNameDistribution() + ", ";
        output += randomValuesGenerator.generateNameInitialFromNameDistribution() + ", ";
        output += randomValuesGenerator.generateNameInitialFromNameDistribution() + ", ";
         output += randomValuesGenerator.generateNameInitialFromNameDistribution() + ", ";
        output += randomValuesGenerator.generateNameInitialFromNameDistribution() + ", ";
        output += randomValuesGenerator.generateNameInitialFromNameDistribution() + ", ";
         output += randomValuesGenerator.generateNameInitialFromNameDistribution() + ", ";
        output += randomValuesGenerator.generateNameInitialFromNameDistribution() + ", ";
        output += randomValuesGenerator.generateNameInitialFromNameDistribution() + ", ";
        output += randomValuesGenerator.generateNameInitialFromNameDistribution();
        Debug.Log(output);
    }


    public void randomFloatTester()
    {
        Debug.Log(Random.Range(0, 1f));
        Debug.Log("op");
    }
}
