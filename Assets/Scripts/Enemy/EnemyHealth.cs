﻿using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
	public int startingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 2.5f;
	public int scoreValue = 10;
	public AudioClip deathClip;

	private Animator anim;
	private AudioSource enemyAudio;
	private ParticleSystem hitParticles;
	private CapsuleCollider capsuleCollider;
	private bool isDead;
	private bool isSinking;

	void Awake()
	{
		anim = GetComponent<Animator>();
		enemyAudio = GetComponent<AudioSource>();
		hitParticles = GetComponentInChildren<ParticleSystem>();
		capsuleCollider = GetComponent<CapsuleCollider>();

		currentHealth = startingHealth;
	}

	void Update()
	{
		if(isSinking)
			transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
	}

	void Death()
	{
		isDead = true;

		capsuleCollider.isTrigger = true;

		anim.SetTrigger("Dead");

		enemyAudio.clip = deathClip;
		enemyAudio.Play();
	}

	public void TakeDamage(int amount, Vector3 hitPoint)
	{
		if(isDead)
			return;

		enemyAudio.Play();

		currentHealth -= amount;

		hitParticles.transform.position = hitPoint;
		hitParticles.Play();

		if(currentHealth <= 0)
			Death();
	}

	public void StartSinking()
	{
		GetComponent<NavMeshAgent>().enabled = false;		//so that enemy will not follow player
		GetComponent<Rigidbody>().isKinematic = true;
		isSinking = true;

		Destroy(gameObject, 2f);
	}
}
