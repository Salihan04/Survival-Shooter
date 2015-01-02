using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour 
{
	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public AudioClip deathClip;
	public float flashSpeed = 5f;
	public Color flashColor = new Color(1f, 0f, 0f, 1f);

	private Animator anim;
	private AudioSource playerAudio;
	private PlayerMovement playerMovement;
	private bool isDead;
	private bool damaged;

	void Awake()
	{
		anim = GetComponent<Animator>();
		playerAudio = GetComponent<AudioSource>();
		playerMovement = GetComponent<PlayerMovement>();
		currentHealth = startingHealth;
	}

	void Update()
	{
		if(damaged)
			damageImage.color = flashColor;
		else
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);

		damaged = false;
	}

	public void TakeDamage(int amount)
	{
		damaged = true;

		currentHealth -= amount;

		healthSlider.value = currentHealth;

		playerAudio.Play();

		if(currentHealth <= 0 && !isDead)
			Death();
	}

	void Death()
	{
		//To make sure health slider is fully red when the player is dead
		GameObject healthFill = GameObject.FindGameObjectWithTag("HealthFill");
//		Destroy(healthFill);

		Image image = healthFill.GetComponentInChildren<Image>();
		image.enabled = false;

		isDead = true;

		anim.SetTrigger("Die");

		playerAudio.clip = deathClip;
		playerAudio.Play ();

		playerMovement.enabled = false;
	}
}
