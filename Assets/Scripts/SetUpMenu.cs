using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetUpMenu : MonoBehaviour {

	public Button startText;
    public Button startText2;
    public Button startText3;
    public Button exitText;

	// Use this for initialization
	void Start () {

		startText = startText.GetComponent<Button> ();
        startText2 = startText2.GetComponent<Button>();
        startText3 = startText3.GetComponent<Button>();
        exitText = exitText.GetComponent<Button> ();

	}

	public void StartLevel()
	{
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
	}
    public void StartLevel2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(3);
    }
    public void StartLevel3()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(4);
    }
    public void ExitGame ()
	{
        SceneManager.LoadScene(0);
    }
}
