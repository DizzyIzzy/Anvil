using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour {
    private string myString;
    [SerializeField]
    private Text myText;
    [SerializeField]
    private ScrollListControl scrollListControl;


    // public void SetText(string textString)
    // set the text for a list of buttons
    public void SetText(string textString)
    {
        myText.text = textString;
        myString = textString;
    }
    // public void OnClick()
    // method called when the button is clicked. must be assigned in the inspector to function
    public void OnClick()
    {
        scrollListControl.ButtonClicked(myString);
    }
}
