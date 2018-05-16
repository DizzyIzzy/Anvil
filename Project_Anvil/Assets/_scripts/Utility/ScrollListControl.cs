using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollListControl : MonoBehaviour {


    public GameObject buttonTemplate;

    // Use this for initialization
    void Start () {
        GenerateLocationButtons();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GenerateLocationButtons()
    {

        for (int i = 0; i < 5;/*change to length of location list later*/ i++)
        {
            GameObject button = Instantiate(buttonTemplate) as GameObject;
            button.SetActive(true);

            button.GetComponent<ButtonListButton>().SetText("button # " + i);

            button.transform.SetParent(buttonTemplate.transform.parent, false);
        }
    }
}
