using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPrefabScript : MonoBehaviour
{

	private float startMove;
	private float Counter;
	// Use this for initialization
	void Start()
	{
		startMove = 1f;
		Counter = 0f;
	}
	
	// Update is called once per frame
	void Update()
	{
		Counter += Time.deltaTime;
		if (Counter > startMove) {
			//Vector3 newPos = transform.position + transform.po * Time.deltaTime;
			transform.localPosition += transform.forward * Time.deltaTime * 10f;
		} else {
			transform.localPosition += transform.forward * Time.deltaTime * 5f;
		}
	}

	void OnBecameInvisible()
	{

		Destroy(gameObject);

	}
}
