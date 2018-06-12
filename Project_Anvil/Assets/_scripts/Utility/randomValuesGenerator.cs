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
    public static string GenerateName(){

		int numLast = Random.Range (0, lines.Length - 1);
		int numFirst = Random.Range (0, 26);
        
        float middleInitialSelector = Random.Range (0, 1f); // about 80% of people have a middle initial
      
        string returnString = lines[numLast] + ", " + generateNameInitialFromNameDistribution() + ".";
        if (middleInitialSelector < .8f) {
           returnString += generateNameInitialFromNameDistribution() + ".";
        } 
        // Returns last name in proper format: 'Smith, A.B.' or Smith, A.
        return returnString;
	}

    public static string generateLetterFromFlatDistribution()
    {
        // Returns a random letter
        return alphabet[Random.Range(0, 25)].ToString();
    }

    public static string generateNameInitialFromNameDistribution()
    {
        int indexer = 0;
        float rand = Random.Range(0f, 1f);
        string returnString;

        foreach (float value in alphabetDistribution)
        {
            if (value < rand)
            {
                indexer++;
            }
            else
            {
                returnString = alphabet[indexer].ToString();
                return returnString;
            }

        }
        returnString = alphabet[indexer].ToString();
        return returnString;
    }

    public static string GenerateRank()
    {
        string[,] ranks = new string[17, 2] {
   //     "Private ","Private First Class ", "Lance Corporal ","Corporal ", "Sergeant","Staff Sergeant",
        //    "Gunnery Sergeant","1stSgt/MSgt	","SgtMaj","Warrant Officer ", "Second Lieutenant ", "First Lieutenant ",
        //    "Captain ","Major ","Lieutenant Colonel	","Colonel ", "General"
        {"Private","01"},
{"Private First Class","02"},
{"Lance Corporal","03"},
{"Corporal","04"},
{"Sergeant","05"},
{"Staff Sergeant","06"},
{"Gunnery Sergeant","07"},
{"1stSgt/MSgt","08"},
{"SgtMaj/MGySgt","09"},
{"Warrant Officer","10"},
{"Second Lieutenant","11"},
{"First Lieutenant","12"},
{"Captain","13"},
{"Major","14"},
{"Lieutenant Colonel","15"},
{"Colonel","16"},
{"General Officer","17"}
            };

    float[] rankDistribution = new float[17] {
            0.05275f,0.15202f,0.38749f,0.59359f,0.73798f,0.81564f,0.85969f,0.88041f,0.88873f,
            0.89991f,0.90990f,0.92909f,0.96503f,0.98564f,0.99587f,0.99956f,1.00000f
        };
        int indexer = 0;
        float rand = Random.Range(0f, 1f);
        string returnString;

        foreach (float value in rankDistribution)
        {
            if (value < rand)
            {
                indexer++;
            }
            else
            {
                returnString = ranks[indexer, 1].ToString();
                returnString += ranks[indexer,0].ToString();
                
                return returnString;
            }

        }
        returnString = ranks[indexer,1].ToString();
        returnString += ranks[indexer,0].ToString();
        
        return returnString;
    }

    public static string GetOpenSerialNumber()
    {
        string fmt = "00000";
        string returnString = serialNumberIndexer.ToString(fmt);
        returnString += Get5DigitRandomIntString();
        serialNumberIndexer++;
        return returnString;
    }

    public static string Get5DigitRandomIntString()
    {
        string fmt = "00000";
        string returnString = Random.Range(0,99999).ToString(fmt);
        return returnString;
    }

    public static string GetHashedSerialNumber()
    {
        int seed = Random.Range(0, 4999);
        string fmt = "00000";
        string fmt2 = "0000000000";
        string serialString1 = serialNumberIndexer.ToString(fmt);
        serialNumberIndexer++;
        string serialString2 = (serialNumberIndexer+seed).ToString(fmt);
        string returnString = serialString1 + serialString2;
        returnString = (Mathf.Abs(returnString.GetHashCode())).ToString(fmt2);
        serialNumberIndexer++;
        return returnString;
    }




}
