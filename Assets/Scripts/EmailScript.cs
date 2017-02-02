using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmailScript : MonoBehaviour
{
	private float radius;
	// Use this for initialization

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

		//Speed = 2f * Power;

		/*if (endCounter > endtime) {
			foreach (var item in RingPoints) {
				if (item != null) {
					Destroy(item);
				}
			}
		}*/

		if (endCounter > endtime) {
			insertplace = true;
			endCounter = 0;
		}

		//transform.localPosition = transform.localPosition + transform.forward * Time.fixedDeltaTime * Speed;


		if (Powerenabled) {
			if (insertplace) {
				float theta = Random.Range(0, (2f * Mathf.PI) / 2);
				float x = radius * Mathf.Cos(theta);
				float z = radius * Mathf.Sin(theta);

				Vector3 pos = new Vector3(x, 1, z);

				GameObject newRingPoint = Instantiate(RingPoint, transform.position + pos, Quaternion.identity);
				//newRingPoint.layer = gameObject.layer;
				foreach (var colPoint in RingPoints) {
					if (colPoint != null) {
						Physics.IgnoreCollision(newRingPoint.GetComponent<Collider>(), colPoint.GetComponent<Collider>());
					}
				}
				newRingPoint.GetComponent<EmailPrefabScipt>().UpdateEndTime(EmailTime);

				//newRingPoint.transform.parent = gameObject.transform;
				RingPoints.Add(newRingPoint);
			}
		}

		foreach (var item in RingPoints) {
			if (item != null) {
				Vector3 newPos = item.transform.position + transform.forward * Time.fixedDeltaTime * 13f;
				item.transform.position = newPos;
			}
		}

		insertplace = false;
		if (GetRingPointNum() <= 0) {
			Destroy(gameObject);
		}
	}






}
