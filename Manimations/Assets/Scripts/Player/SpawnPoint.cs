using UnityEngine;
using System.Collections;

public class SpawnPoint : MonoBehaviour {

	public PlayerController player;
	// Use this for initialization
	void Start () 
	{
		player.transform.position = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//if (player.)
	
	}
}
