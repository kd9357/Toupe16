using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
	private float radius;
	// Use this for initialization

	public GameObject RingPoint;
	//public List<GameObject> RingPoints;
	private List<GameObject> RingPoints;
	// = new List<GameObject>();
	private bool insertplace = false;
	private float endtime = 0.6f;
	private float endCounter = 0;
	public float Power;

	void Start()
	{
		//Power = 1.0;

		RingPoints = new List<GameObject>();
		GameObject pointt = Instantiate(RingPoint, new Vector3(0, 0, 0), Quaternion.identity);
		pointt.transform.parent = gameObject.transform;
		RingPoints.Add(pointt);
		radius = 0.5f;
	}

	public void SetPower(float p)
	{
		Power = p;
	}

	public float GetRadius()
	{
		return radius;
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

		if (endCounter > endtime) {
			foreach (var item in RingPoints) {
				if (item != null) {
					Destroy(item);
				}
			}
		}

		radius += Time.fixedDeltaTime * 10;
		endtime = 0.6f * Power;

		int i = 0;
		//0.04f
		//0.8f / radius
		for (float theta = 0f; theta < 2f * Mathf.PI; theta += 0.12f) {
			float x = radius * Mathf.Cos(theta);
			float z = radius * Mathf.Sin(theta);

			Vector3 pos = new Vector3(x, 1, z);

			if (i >= RingPoints.Count) {
				if (!insertplace) {
					GameObject newRingPoint = Instantiate(RingPoint, transform.position + pos, Quaternion.identity);
					//newRingPoint.layer = gameObject.layer;
					foreach (var colPoint in RingPoints) {
						if (colPoint != null) {
							Physics.IgnoreCollision(newRingPoint.GetComponent<Collider>(), colPoint.GetComponent<Collider>());
						}
					}
					newRingPoint.transform.parent = gameObject.transform;
					RingPoints.Add(newRingPoint);

				}
			} 

			if (RingPoints[i] != null) {
				RingPoints[i].transform.localPosition = new Vector3(x, 1, z);
			}


			//lineRenderer.SetPosition(i, pos);
			i += 1;
		}


		//for (int j = 0; j < RingPoints.Count; j++) {
		//	if (RingPoints[j] == null) {
		//		RingPoints.RemoveAt(j);
		//	}
		//}
		insertplace = true;
		if (GetRingPointNum() <= 0) {
			Destroy(gameObject);
		}
	}




}
