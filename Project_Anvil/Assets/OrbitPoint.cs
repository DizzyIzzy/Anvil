using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitPoint : MonoBehaviour {

	public Transform objectToOrbit;		//Object to orbit
	public Vector3 orbitAxis = Vector3.up; //Which vector we are using to orbit
	public float orbitRadius = 75.0f; //The radius of the orbit
	public float orbitRadiusCorrentionSpeed = .5f; //How quickly we go to new position
	public float orbitRotationSpeed = 10.0f; //Speed of rotation around the object
	public float orbitAlignToDirectionSpeed = 0.5f; //Realign speed to direction of travel
	public float orbitHeight;


	private Vector3 orbitDesiredPosition;
	private Vector3 previousPosition;
	private Vector3 relativePos;
	private Quaternion rotation;
	private Transform thisTransform;


	void Start()
	{
		thisTransform = transform;
		
	}

	//---------------------------------------------------------------------------------------------------------------------

	void Update()
	{
		orbitHeight = objectToOrbit.transform.position.y;

		//Movement
		thisTransform.RotateAround(objectToOrbit.position, orbitAxis, orbitRotationSpeed * Time.deltaTime);
		orbitDesiredPosition = (thisTransform.position - objectToOrbit.position).normalized * orbitRadius + objectToOrbit.position;
		thisTransform.position = Vector3.Slerp(thisTransform.position, orbitDesiredPosition, Time.deltaTime * orbitRadiusCorrentionSpeed);

		//Rotation
		relativePos = thisTransform.position - previousPosition;
		rotation = Quaternion.LookRotation(relativePos);
		thisTransform.rotation = Quaternion.Slerp(thisTransform.rotation, rotation, orbitAlignToDirectionSpeed * Time.deltaTime);
		previousPosition = thisTransform.position;

		//Vector3 newHeight = new Vector3(0.0f, orbitHeight, 0.0f);
		transform.position = new Vector3(transform.position.x, orbitHeight, transform.position.z);
	}









	/* Potential Orbit Script
	GameObject cube;
	public Transform center;
	public Vector3 axis = Vector3.up;
	public Vector3 desiredPosition;
	public float radius = 2.0f;
	public float radiusSpeed = 0.5f;
	public float rotationSpeed = 80.0f;


	void Start()
	{
		//cube = GameObject.FindWithTag("Cube");
		center = cube.transform;
		transform.position = (transform.position - center.position).normalized * radius + center.position;
		//radius = 2.0f;
	}

	void Update()
	{
		transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
		desiredPosition = (transform.position - center.position).normalized * radius + center.position;
		transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);

		//Vector3 tangentVector = Quaternion.Euler(0, 90, 0) * (transform.position - center.position);
		//transform.rotation = Quaternion.LookRotation(tangentVector);
	}
	*/
}
