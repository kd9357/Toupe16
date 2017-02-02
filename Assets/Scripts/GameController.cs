using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	private GameObject Player1;
	private GameObject Player2;
	private Vector3 player1Start;
	private Vector3 player2Start;
	//private int maxRounds;
	private int currentRound;
	private bool matchOver;
	private int player1Wins;
	private int player2Wins;
	private int prevWinner;
	private float timeDuration;
	private bool canMove;
    
	//UI elements
	public Text Ready;
	public Text Go;
	public Text Winner1;
	public Text Winner2;
	public Text RoundDisplay;
	public Text Player1GameWin;
	public Text Player2GameWin;
	private RectTransform readyRectTransform;
	private Vector2 textStartSize, textEndSize;
	private Coroutine TextCoroutine;
	public GameObject Player1LifeIcon;
	public GameObject Player1LifeIcon2;
	public GameObject Player2LifeIcon;
	public GameObject Player2LifeIcon2;

	//Sound
	public AudioSource player1Audio;
	public AudioSource player2Audio;

	//FX
	public GameObject BloodSplatter;
	// Use this for initialization
	void Start()
	{
		//maxRounds = 3;
		currentRound = 1;
		Player1 = GameObject.FindGameObjectWithTag("Player1");
		Player2 = GameObject.FindGameObjectWithTag("Player2");
		player1Wins = 0;
		player2Wins = 0;
		timeDuration = 1.5f;
		player1Start = new Vector3(5.0f, .01f, 0f);
		player2Start = new Vector3(-5.0f, .01f, 0f);
		prevWinner = 0;

		if (Ready != null) {
			Ready.enabled = false;
		
			Go.enabled = false;
			Winner1.enabled = false;
			Winner2.enabled = false;
			RoundDisplay.enabled = false;
			Player1GameWin.enabled = false;
			Player2GameWin.enabled = false;
		
			readyRectTransform = Ready.GetComponent<RectTransform>();
		
			textStartSize = new Vector2(300, 200);
			textEndSize = new Vector2(340, 200);
			Player1LifeIcon.GetComponent<SpriteRenderer>().enabled = false;
			Player2LifeIcon.GetComponent<SpriteRenderer>().enabled = false;
			Player1LifeIcon2.GetComponent<SpriteRenderer>().enabled = false;
			Player2LifeIcon2.GetComponent<SpriteRenderer>().enabled = false;
		
			StartCoroutine(LoadMatch());
		}
	}
	
	//Check if game finish in here
	IEnumerator LoadMatch()
	{
		player1Audio.Stop();
		player2Audio.Stop();
		if (prevWinner != 0) {
			if (prevWinner == 1) {
				if (player1Wins == 2)
					Player1LifeIcon2.GetComponent<SpriteRenderer>().enabled = true;
				if (player1Wins == 1)
					Player1LifeIcon.GetComponent<SpriteRenderer>().enabled = true;
				//player1Audio.Play();
				Winner1.enabled = true;
			} else if (prevWinner == 2) {
				if (player2Wins == 2)
					Player2LifeIcon2.GetComponent<SpriteRenderer>().enabled = true;
				if (player2Wins == 1)
					Player2LifeIcon.GetComponent<SpriteRenderer>().enabled = true;
				//player2Audio.Play();
				Winner2.enabled = true;
			}
			yield return new WaitForSeconds(2f);
		}
		Winner1.enabled = false;
		Winner2.enabled = false;

		//Game finish
		if (player1Wins >= 3 || player2Wins >= 3) {
			if (prevWinner == 1)
				SceneManager.LoadScene("ClintonWin");
			else
				SceneManager.LoadScene("TrumpWin");
		} else {
			prevWinner = 0;
			Player1.transform.position = player1Start;
			Player2.transform.position = player2Start;
			canMove = false;
			RoundDisplay.text = "ROUND " + currentRound;
			RoundDisplay.enabled = true;
			yield return new WaitForSeconds(timeDuration);
			RoundDisplay.enabled = false;

			Ready.enabled = true;
			float elapsedTime = 0;
			//May remove scaling effect
			while (elapsedTime < timeDuration) {
				float t = elapsedTime / timeDuration;
				readyRectTransform.sizeDelta = Vector2.Lerp(textStartSize, textEndSize, t * 1f);
				elapsedTime += Time.deltaTime;
				yield return null;
			}
			Ready.enabled = false;
			Go.enabled = true;
			yield return new WaitForSeconds(0.6f);
			Go.enabled = false;
			canMove = true;
			matchOver = false;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (!canMove) {
			//Should change so player cannot fire as well

			if (Player1 != null) {
				
				//Player1 = GameObject.FindGameObjectWithTag("Player1");
				//Player2 = GameObject.FindGameObjectWithTag("Player2");
				Player1.transform.position = player1Start;
				Player2.transform.position = player2Start;
			}
	
			 
		} else {
			if (Player1.transform.position.y <= -7 && !matchOver) {
				matchOver = true;
				player2Wins++;
				prevWinner = 2;
				GameObject death = Instantiate(BloodSplatter, Player1.transform.position, Quaternion.identity);
				currentRound++;
				StartCoroutine(LoadMatch());
			} else if (Player2.transform.position.y <= -7 && !matchOver) {
				matchOver = true;
				player1Wins++;
				prevWinner = 1;
				GameObject death = Instantiate(BloodSplatter, Player2.transform.position, Quaternion.identity);
				currentRound++;
				StartCoroutine(LoadMatch());
			}
		}
	}
}
