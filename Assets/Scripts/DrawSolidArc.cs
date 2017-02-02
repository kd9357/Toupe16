using UnityEngine;
using System.Collections;

public class DrawSolidArc : MonoBehaviour
{
	public int segments;
	public float xradius;
	public float yradius;
	LineRenderer line;

	void Start()
	{

		line = gameObject.GetComponent<LineRenderer>();
		line.SetVertexCount(segments + 1);
		line.useWorldSpace = true;
	}

	void Update()
	{

		float Power = GetComponent<Attack>().GetPower();
		float x = 0f;
		float y = 0f;
		float z;
		float angle = 20f;

		for (int i = 0; i < (segments + 1); i++) {
			x = Mathf.Sin(Mathf.Deg2Rad * angle) * xradius;
			z = Mathf.Cos(Mathf.Deg2Rad * angle) * yradius;


			Vector3 circlepos = new Vector3(x, 0.001f, z) + transform.position;
			line.SetPosition(i, circlepos);

			angle += ((Power * 36f) / segments);
		}
	}
}