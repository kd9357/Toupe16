using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailPrefabScipt : MonoBehaviour
{

	private float endTime = 4;
	private float Counter = 0;
	// Use this for initialization
	void Start()
	{
		
	}

	public void UpdateEndTime(float e)
	{
		endTime = e;
	}
	
	// Update is called once per frame
	void Update()
	{
		Counter += Time.deltaTime;
		if (Counter > endTime) {
			Destroy(gameObject);
		}
	}

	void OnBecameInvisible()
	{

		Destroy(gameObject);

	}
}
