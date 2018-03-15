using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class leepyMover : MonoBehaviour {

	public List<Transform> points = new List <Transform> ();
	private int destPoint = 0;
	private NavMeshAgent agent;

	public leepyWalkingPath path;
	public float remainingDistance = 0.1f;
	public int pointCount;

	void Start () {

		points = path.waypoints;
		agent = GetComponent<NavMeshAgent>();

		// Disabling auto-braking allows for continuous movement
		// between points (ie, the agent doesn't slow down as it
		// approaches a destination point).
		agent.autoBraking = false;
		GotoNextPoint();
		pointCount = points.Count;
	}

	void GotoNextPoint() {
		// Returns if no points have been set up
		
		if (pointCount == 0)
			return;

		// Set the agent to go to the currently selected destination.
		agent.destination = points[destPoint].position;

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % points.Count;
		pointCount = pointCount - 1;
	}


	void Update () {
		// Choose the next destination point when the agent gets
		// close to the current one.
		if (agent.remainingDistance < remainingDistance)
			GotoNextPoint();
	}
}