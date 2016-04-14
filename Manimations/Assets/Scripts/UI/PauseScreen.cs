using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour {

	public GameObject pauseScreen;
	public bool paused;
	// Use this for initialization
	void Start () 
	{

		paused = false;
		//pauseScreen.SetActive(false);
	
	}
	public void OnContinue()
	{
		paused = !paused;
	}
	public void OnQuit()
	{
		SceneManager.LoadScene("StartScreen");
	}
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown("Pause"))
		{
			paused = !paused;
		}

		if (paused)
		{
			pauseScreen.SetActive(true);
			Time.timeScale = 0;
		}
		else
		{
			pauseScreen.SetActive(false);
			Time.timeScale = 1;
		}
	
	}
}
