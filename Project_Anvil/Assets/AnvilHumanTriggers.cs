using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnvilHumanTriggers : MonoBehaviour {

    public AnvilHuman anvilHuman;

    public Animator animator;

    // Use this for initialization
    void Start () {
        anvilHuman = GetComponent<AnvilHuman>();
        animator = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        checkEnemy();
        checkAmmo();

    }


    public void checkEnemy()
    {
        if (anvilHuman.enemiesInMemory.Count >= 1)
        {
            animator.SetBool("EngageBool", true);
        }
        else
        {
            return;
        }
    }

    public void checkAmmo()
    {
        if (anvilHuman.ammo < 10)
        {
            animator.SetTrigger("Reload");
        }
        else
        {
            return;
        }
    }


}
