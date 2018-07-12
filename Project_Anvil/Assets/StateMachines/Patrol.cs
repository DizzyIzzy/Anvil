using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//public class Patrol : ActionTasks {
public class Patrol : StateMachineBehaviour {

	Vector3 currentPosition;
	private List<Vector3> points;

	public float rotSpeed = 1.0f;
	public float speed = 2.0f;

	public GameObject agent;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//base.OnStateEnter(animator, stateInfo,layerIndex);

		agent = animator.gameObject;

		points = new List<Vector3>();

		currentPosition = agent.transform.localPosition;

		Vector3 patrol1 = currentPosition;
		Vector3 patrol2 = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + 20);
		points.Add(patrol1);
		points.Add(patrol2);



	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		//Debug.Log("Update" );
		agent.transform.position = Vector3.Lerp(points[0], points[1], Mathf.PingPong(Time.time * speed, 1.0f));
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}


}
