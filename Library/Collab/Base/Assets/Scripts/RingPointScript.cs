using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPointScript : MonoBehaviour
{
	public GameObject CollisionRing;
	private GameObject CollisionRingInstance;
	// Use this for initialization
	void Start()
	{
		
	}
	
	// Update is called once per frame
	void Update()
	{

		
	}

	void OnTriggerStay(Collider collisionInfo)
	{
		print(collisionInfo.transform.name);
		if (collisionInfo.transform.name == "RingPoint(Clone)" && collisionInfo.transform.parent.name == "Ring" && collisionInfo.transform.parent != transform.parent) {
			//print("woww");
			if (CollisionRingInstance == null) {
				
				CollisionRingInstance = Instantiate(CollisionRing, collisionInfo.transform.position, Quaternion.identity);
			} else {
				CollisionRingInstance.transform.position = collisionInfo.transform.position;
			}
		}
			
	}

	void OnTriggerExit(Collider collisionInfo)
	{
		if (CollisionRingInstance != null) {
			Destroy(CollisionRingInstance);
		}
	}

	void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
