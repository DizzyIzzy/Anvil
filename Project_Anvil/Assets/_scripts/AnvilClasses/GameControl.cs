using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	public static GameControl control;
    private MasterBlackBoard masterBlackBoard;
    [SerializeField]
    private List<string> factionsList = new List<string>();
    void Awake () {
        
      
        if (control == null) {
			DontDestroyOnLoad (gameObject);
			control = this;
		} 
		else if (control != this) 
		{
			Destroy (gameObject);
		}
        
	}

    private void Start()
    {
        
    }
    //establish and populate factions in the hierarchy so agents can be assigned.

  
	void OnGUI()
	{
		//OnGUI.Label(Put Lat long Data Here)
	}

    public List<string> getFactionList()
    {
        return factionsList;
    }
}
