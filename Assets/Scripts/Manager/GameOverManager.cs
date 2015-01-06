﻿using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour 
{
	public PlayerHealth playerHealth;
	public float restartDelay = 5f;

	private Animator anim;
	private float restartTimer;

	void Awake()
	{
		anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(playerHealth.currentHealth <= 0)
		{
			anim.SetTrigger("GameOver");

			restartTimer += Time.deltaTime;

			if(restartTimer >= restartDelay)
				Application.LoadLevel(Application.loadedLevel);
		}
	}
}
