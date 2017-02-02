using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine;

public class Attack : MonoBehaviour
{
	public string AttackButton;
	public string SecondAttackButton;
	private List<GameObject> Rings;
	public GameObject FirstPrefab;
	public GameObject SecondPrefab;

	private GameObject Player1;
	private GameObject Player2;

	private GameObject Email;
	private GameObject Coin;

	private float Power;


	// Use this for initialization
	void Start()
	{
		Power = 0;
		Rings = new List<GameObject>();

	}

	public float GetPower()
	{
		return Power;
	}

	private void fireAttack(GameObject ringPrefab)
	{
		GameObject newRing = Instantiate(ringPrefab, transform.position, Quaternion.identity);
		//print(Power);
		if (Power < 2f) {
			newRing.GetComponent<Ring>().SetPower(Power / 2f);
			Power = 0;
		} else {
			Power -= 2f;
			newRing.GetComponent<Ring>().SetPower(2f / 2f);
		}
		Rings.Add(newRing);
	}


	private void waveAttack(GameObject ringPrefab)
	{
		GameObject newWave = Instantiate(ringPrefab, transform.position, Quaternion.identity);
		newWave.transform.rotation = transform.rotation;
		if (Power < 5f) {
			newWave.GetComponent<WaveScript>().SetPower(Power / 4);
			Power = 0;
		} else {
			Power -= 5f;
			newWave.GetComponent<WaveScript>().SetPower(5 / 4);
		}
		Rings.Add(newWave);
	}

	private void EmailAttack(GameObject Prefab)
	{
		if (Email == null) {
			Email = Instantiate(Prefab, transform.position, Quaternion.identity);
			Email.transform.rotation = transform.rotation;
		} else {
			Email.transform.position = transform.position;
		}
		if (Power > 0) {
			Power -= 4f * Time.deltaTime;
		} else {
			Power = 0;
		}
		Email.GetComponent<EmailScript>().SetPower(10 - Power + 3);
	}

	private void CoinAttack(GameObject Prefab)
	{
		if (Coin == null) {
			Coin = Instantiate(Prefab, transform.position, Quaternion.identity);

		} else {
			Coin.transform.position = transform.position;
			Coin.transform.rotation = transform.rotation;

		}
		if (Power > 0) {
			Power -= 4f * Time.deltaTime;
		} else {
			Power = 0;
		}
		Coin.GetComponent<CoinScript>().SetPower(10 - Power + 3);
	}

	private void BearAttack(GameObject Prefab)
	{
		if (Coin == null) {
			Coin = Instantiate(Prefab, transform.position, Quaternion.identity);

		} else {
			Coin.transform.position = transform.position;
			Coin.transform.rotation = transform.rotation;

		}
		if (Power > 0) {
			Power -= 4f * Time.deltaTime;
		} else {
			Power = 0;
		}
		Coin.GetComponent<BearScript>().SetPower(Power);
	}



	private void Update()
	{
		//print(Power);
		Power += Time.deltaTime * 3;
		if (Power > 10) {
			Power = 10;
		}

		if (CrossPlatformInputManager.GetButtonDown(AttackButton)) {
			fireAttack(FirstPrefab);
		}
		//if (transform.name == "Trump") {
		if (CrossPlatformInputManager.GetButtonDown(SecondAttackButton)) {
			waveAttack(SecondPrefab);
		}
		//}
		if (false) {
			if (transform.name == "Hilary") {
				if (CrossPlatformInputManager.GetButton(SecondAttackButton)) {
					EmailAttack(SecondPrefab);
				}
				if (CrossPlatformInputManager.GetButtonUp(SecondAttackButton)) {
					Email.GetComponent<EmailScript>().Disable();
					Email = null;
				}
			}
			if (transform.name == "Bernie") {
				if (CrossPlatformInputManager.GetButton(SecondAttackButton)) {
					CoinAttack(SecondPrefab);
				}
				if (CrossPlatformInputManager.GetButtonUp(SecondAttackButton)) {
					Coin.GetComponent<CoinScript>().Disable();
					Coin = null;
				}
			}
			if (transform.name == "Putin") {
				if (CrossPlatformInputManager.GetButton(SecondAttackButton)) {
					BearAttack(SecondPrefab);
				}
				if (CrossPlatformInputManager.GetButtonUp(SecondAttackButton)) {
					Coin.GetComponent<BearScript>().Disable();
					Coin = null;
				}
			}
		}

	}

}
