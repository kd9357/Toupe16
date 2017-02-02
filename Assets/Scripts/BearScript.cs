using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearScript : MonoBehaviour
{
	private float radius;
	// Use this for initialization
	private GameObject BearInstance;
	public GameObject RingPoint;
	//public List<GameObject> RingPoints;
	private List<GameObject> RingPoints;
	// = new List<GameObject>();
	private bool insertplace = true;
	private float endtime = 3f;
	private float endCounter = 0;
	private float EmailTime = 1;
	private float Power;
	private float Speed;
	private bool Powerenabled = true;

	void Start()
	{
		Speed = 6f;
		//Power = 1f;
		RingPoints = new List<GameObject>();

		radius = 2.5f;
	}

	public void SetPower(float p)
	{
		Power = p;
	}

	public float GetRadius()
	{
		return radius;
	}

	public void Disable()
	{
		Powerenabled = false;
		Destroy(BearInstance);
		Destroy(gameObject);
	}

	public int GetRingPointNum()
	{
		int i = 0;
		if (RingPoints != null) {
			for (int j = 0; j < RingPoints.Count; j++) {

				if (RingPoints[j] != null) {
					i++;
				}
			}
		} else {
			return 5;
		}
		return i;
	}

	// Update is called once per frame
	private void FixedUpdate()
	{



		endCounter += Time.fixedDeltaTime;
		//print(Power);
		endtime = 0.01f * Power;
		EmailTime = 1 - (Power * 0.06f);


		if (BearInstance == null) {
			Vector3 pos = transform.forward * 2;
			BearInstance = Instantiate(RingPoint, transform.position + pos, Quaternion.identity);
			//BearInstance.transform.rotation = transform.rotation;
			BearInstance.transform.parent = gameObject.transform;
		} else {
			//BearInstance.transform.position = BearInstance.transform.position + BearInstance.transform.forward * Time.fixedDeltaTime * 4;
			BearInstance.transform.localScale = new Vector3(Power / 1.5f, 3, Power / 4);



		}



		insertplace = false;
		//if (GetRingPointNum() <= 0) {
		//	Destroy(gameObject);
		//}
	}






}
