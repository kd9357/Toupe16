using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPointScript : MonoBehaviour
{
	//public GameObject CollisionRing;
	private GameObject CollisionRingInstance;
	// Use this for initialization
	void Start()
	{
	}


	void OnBecameInvisible()
	{

		Destroy(gameObject);

	}
}
