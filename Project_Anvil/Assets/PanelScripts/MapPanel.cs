using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPanel : MonoBehaviour {
	public GameObject mapPanel;

	public CameraController cameraMove;


	// Use this for initialization
	void Start () {
		//cameraMove = GetComponent<CameraController>();
		mapPanel = GameObject.Find("MapPanel");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void GetLeftInput()
	{
		Debug.Log("Map");
		cameraMove.mapMove();
	}
	public void GetRightInput()
	{
		Debug.Log("Map");
		cameraMove.mapMove();
	}
	public void GetUpInput()
	{
		Debug.Log("Map");
		cameraMove.mapMove();
	}
	public void GetDownInput()
	{
		Debug.Log("Map");
		cameraMove.mapMove();
	}


}
