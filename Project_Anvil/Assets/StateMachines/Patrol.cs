using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : NPCBaseFSM {

	GameObject[] waypoints;
	int currentWP;

    Vector3 currentPosition;
    private List<Vector3> points;


    /*
	void Awake()
	{
		waypoints = GameObject.FindGameObjectsWithTag("waypoint");
	}	
    */

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        base.OnStateEnter(animator, stateInfo, layerIndex);

      

        points = new List<Vector3>();

        currentPosition = agent.transform.localPosition;

        Vector3 patrol1 = currentPosition;
        Vector3 patrol2 = new Vector3(currentPosition.x, currentPosition.y, currentPosition.z + 20);
        points.Add(patrol1);
        points.Add(patrol2);
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        agent.transform.position = Vector3.Lerp(points[0], points[1], Mathf.PingPong(Time.time * speed, 1.0f));
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}

}
