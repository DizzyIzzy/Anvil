using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engage : ActionTasks {

	public float rotSpeed = 1.0f;
	public float speed = 2.0f;
	//public GameObject opponent;

	


	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		base.OnStateEnter(animator,stateInfo,layerIndex);
		//opponent = agent.GetComponent<AnvilHuman>().getEnemy();
		
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
		if(opponent != null)
		{
		var direction = opponent.transform.position - agent.transform.position;
		agent.transform.rotation = Quaternion.Slerp(agent.transform.rotation, Quaternion.LookRotation(direction),rotSpeed * Time.deltaTime);

		agent.transform.Translate(0, 0, Time.deltaTime * speed);
		}
		
	}


	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	}


}
