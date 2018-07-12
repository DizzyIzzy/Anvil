using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionTasks : StateMachineBehaviour {

	public GameObject agent;
	//Could expand into list of opponents
	public GameObject opponent;
	//public float speed;
	//public float rotSpeed;
	//public float accuracy;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		agent = animator.gameObject;
		
		opponent = agent.GetComponent<AnvilHuman>().getEnemy();
	}
}
