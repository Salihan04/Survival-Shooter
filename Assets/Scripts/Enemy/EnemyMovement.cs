﻿using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour 
{
	private Transform player;
	private NavMeshAgent nav;

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player").transform;
		nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		nav.SetDestination(player.position);
	}
}