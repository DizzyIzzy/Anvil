using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TaskController : MonoBehaviour {

	public List<Task> agentTasks;

	public AnvilAgent agentToOrder;

	// Use this for initialization
	void Start () {

		agentTasks = new List<Task>();

		agentTasks.Add(new Task("move", 1));
		agentTasks.Add(new Task("breathe", 5));
		agentTasks.Add(new Task("attack", 3));
		agentTasks.Add(new Task("defend", 2));
		agentTasks.Add(new Task("not die", 10));

		for (int i = 0; i < 5; i++)
		{
			Debug.Log("Unsorted Priority: " + agentTasks.ElementAt<Task>(i).priority);
		}

		List<Task> sortedList = agentTasks.OrderBy(o => o.priority).ToList();

		for (int i = 0; i < 5; i++)
		{
				Debug.Log("Sorted Priority: " + sortedList.ElementAt<Task>(i).priority);
		}

	}

	public void AddTask(Task addTask)
	{
		agentTasks.Add(addTask);
		agentTasks = agentTasks.OrderBy(o => o.priority).ToList();

	}

	public void RemoveTask(Task removeTask)
	{
		agentTasks.Remove(removeTask);
		agentTasks = agentTasks.OrderBy(o => o.priority).ToList();
	}


	public void doTaskList()
	{
		for(int i = agentTasks.Count - 1; i > 0; i--)
		{
			agentTasks.ElementAt<Task>(i).doTask();
			agentTasks.RemoveAt(i);
		}
	}




	// Update is called once per frame
	void Update ()
	{

	}
}
