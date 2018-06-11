using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// This will be used to generate names for NPC's. In the NPC's start() function, we can simply call: 'string myName = randomNameGenerator.generate();'
public static class randomValuesGenerator: object {

	// Creates array of all last names in the lastName.txt file
	static string[] lines = System.IO.File.ReadAllLines(@"Assets\Resources\lastNamesCleaned.txt");
	// String of all chars that will be used for the First Name Initial and Middle Name Initial
	static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    static float[] alphabetDistribution = new float[26] {0.038f,0.127f,0.191f,0.247f,0.268f,0.304f,0.357f,0.413f,0.421f,0.435f,
0.492f,0.544f,0.627f,0.648f,0.664f,0.717f,0.720f,0.768f,0.877f,0.916f,
0.920f,0.946f,0.981f,0.981f,0.987f,1.000f};
   
  
    static int serialNumberIndexer = 0; //used to provide sequential serials to avoid number conflicts

    // Generates the randomized name
    public static string generateName(){

		int numLast = Random.Range (0, lines.Length - 1);
		int numFirst = Random.Range (0, 26);
        
        float middleInitialSelector = Random.Range (0, 1f); // about 80% of people have a middle initial
      
        string returnString = lines[numLast] + ", " + alphabet[numFirst] + ".";
        if (middleInitialSelector < .8f) {
            int rand3 = Random.Range(0, 26);
            returnString += alphabet[rand3] + ".";
        } 
        // Returns last name in proper format: 'Smith, A.B.' or Smith, A.
        return returnString;
	}

    public static string generateLetter()
    {
        // Returns a random letter
        return alphabet[Random.Range(0, 25)].ToString();
    }


    public static string GetOpenSerialNumber()
    {
        string fmt = "000000";
        string returnString = serialNumberIndexer.ToString(fmt);
        serialNumberIndexer++;
        return returnString;
    }

}
