using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameOverScreen : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
	
	}
	public void onRestart()
	{
		SceneManager.LoadScene("Game");
	}
	public void onQuit()
	{
		SceneManager.LoadScene("StartScreen");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
