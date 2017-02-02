using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public Button startText;
	public Button exitText;

	// Use this for initialization
	void Start () {

		startText = startText.GetComponent<Button> ();
		exitText = exitText.GetComponent<Button> ();

	}

	public void StartLevel()
	{
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
	}

	public void ExitGame ()
	{
		Application.Quit ();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
