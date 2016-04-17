using UnityEngine;
using System.Collections;

public class Destructable : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.collider.CompareTag("Hit"))
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
