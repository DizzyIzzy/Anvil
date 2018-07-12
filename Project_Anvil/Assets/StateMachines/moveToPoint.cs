using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveToPoint : ActionTasks {
	Vector3 currentPosition;
	private List<Vector3> points;

	//public GameObject agent;

	public float speed;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter(animator, stateInfo,layerIndex);

		points = new List<Vector3>();

		currentPosition = agent.transform.localPosition;

		Vector3 patrol1 = currentPosition;
		Vector3 patrol2 = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + 10);
		points.Add(patrol1);
		points.Add(patrol2);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

		agent.transform.position = Vector3.Lerp(points[0], points[1],Time.time * speed);


		/* 	This will work for anvil waypoints
		speed = 0.05f;

		Vector2d goTo = new Vector2d(waypoint.latitude, waypoint.longitude);
		goToPoint.transform.localPosition = Conversions.GeoToWorldPosition(goTo, _map.CenterMercator, _map.WorldRelativeScale).ToVector3xz();
		goToPoint.transform.localPosition += new Vector3(0, 10, 0);

		Vector3 lookAtGoal = new Vector3(goToPoint.transform.localPosition.x, goToPoint.transform.localPosition.y, goToPoint.transform.localPosition.z);
		Vector3 direction = lookAtGoal - this.transform.position;


		this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * rotSpeed);
		this.transform.position = Vector3.MoveTowards(this.transform.position, goToPoint.transform.position, speed);


		if (this.transform.position == goToPoint.transform.localPosition)
		{
			moveNow = false;
		}
		*/
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}


}
