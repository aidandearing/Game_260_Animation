using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	public PlayerController player;
	public float timer;
	public bool playerDead;
	public float respawnAmount;
	// Use this for initialization
	void Start () 
	{
		playerDead = false;
		player.transform.position = transform.position;
		respawnAmount = 5.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerDead)
		{
			timer += Time.deltaTime;
		}
		if (timer > respawnAmount)
		{
			player.transform.position = transform.position;
			timer = 0.0f; 
			playerDead = false;
		}

	}
	void Respawn()
	{
		playerDead = true;
	}
}
