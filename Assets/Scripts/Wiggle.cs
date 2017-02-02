using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour
{

    //public float speed = 20f;
    //public bool updateOn = true;
	public float rotFl;
	// Use this for initialization

	void Start () {

	}

	// Update is called once per frame
	void Update () {
		transform.localEulerAngles = new Vector3(60, 0, -Mathf.PingPong(Time.time * 30, rotFl));
		/*if( check something so that switch occurs){
         transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * 50, -rotFl));    
         }*/
	}
}

/*
    void Start()
    {
        StartCoroutine(updateOn());
    }


    void Update()
    {

        if (updateOn == true)
        {
            transform.Rotate(Vector3(0, 0, 1), speed * Time.deltaTime);
        }

        IEnumerator = updateOn()
{ 
            yield return new WaitForSeconds(3.0f);
            updateOn = false;
        }
    }
}
*/