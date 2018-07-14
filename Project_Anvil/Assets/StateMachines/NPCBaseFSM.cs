using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour {

	public GameObject agent;
	public GameObject opponent;
    public float speed; //= 2.0f;
    public float rotSpeed; // = 1.0f;
    public float distAccuracy; //= 3.0f;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) 
	{
		agent = animator.gameObject;
        speed = agent.GetComponent<AnvilHuman>().speed;
        rotSpeed = agent.GetComponent<AnvilHuman>().rotSpeed;
        distAccuracy = agent.GetComponent<AnvilHuman>().distAccuracy;
        //opponent = agent.GetComponent<TankAI>().GetPlayer();
    }
}
