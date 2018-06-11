using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// This will be used to generate names for NPC's. In the NPC's start() function, we can simply call: 'string myName = randomNameGenerator.generate();'
public static class randomNameGenerator: object {

	// Creates array of all last names in the lastName.txt file
	static string[] lines = System.IO.File.ReadAllLines(@"Assets\Resources\lastNamesCleaned.txt");
	// String of all chars that will be used for the First Name Initial and Middle Name Initial
	static string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    static string alphabetWithBlank = "ABCDEFGHIJKLMNOPQRSTUVWXYZ "; //blank space allows for no middle initial

    // Generates the randomized name
    public static string generateName(){

		int numLast = Random.Range (0, lines.Length - 1);
		int numFirst = Random.Range (0, 25);
		int numMiddle = Random.Range (0, 26);
        string returnString = lines[numLast] + ", " + alphabet[numFirst] + ".";
        if (numMiddle != 26) {
            returnString += alphabet[numMiddle] + ".";

        }
        // Returns last name in proper format: 'Smith, A.B.' or Smith, A.
        return returnString;
	}

    public static string generateLetter()
    {
        // Returns a random letter
        return alphabet[Random.Range(0, 25)].ToString();
    }

}
