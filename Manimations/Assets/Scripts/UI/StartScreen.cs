using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}

	public void OnStart()
	{
		SceneManager.LoadScene("Game");
	}
	public void OnQuit()
	{
		Application.Quit();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
