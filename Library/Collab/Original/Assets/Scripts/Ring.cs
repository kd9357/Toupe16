using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ring : MonoBehaviour
{
	private float radius;
	// Use this for initialization

	public GameObject RingPoint;
	private List<GameObject> RingPoints;

	void Start()
	{
		RingPoints = new List<GameObject>();
		//RingPoints.Add(Instantiate(RingPoint, new Vector3(0, 0, 0), Quaternion.identity));
		radius = 0.5f;
	}

	public int GetRingPointNum()
	{
		return RingPoints.Count;
	}
	
	// Update is called once per frame
	private void FixedUpdate()
	{
		radius += Time.fixedDeltaTime;
		//print (radius);


		int i = 0;
		for (float theta = 0f; theta < 2f * Mathf.PI; theta += 0.05f) {
			float x = radius * Mathf.Cos(theta);
			float z = radius * Mathf.Sin(theta);

			Vector3 pos = new Vector3(x, 1, z);
			if (i + 1 > RingPoints.Count) {
				GameObject newRingPoint = Instantiate(RingPoint, pos, Quaternion.identity);
				newRingPoint.transform.parent = gameObject.transform;
				RingPoints.Add(newRingPoint);
			} else {
				if (RingPoints[i] != null) {
					RingPoints[i].transform.localPosition = new Vector3(x, 1, z);
				}
			}
            if (RingPoints[i] == null)
            {
                RingPoints.RemoveAt(i);
            }
			//lineRenderer.SetPosition(i, pos);
			i += 1;
		}

		
	}






}
