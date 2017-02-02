using UnityEngine;
using System.Collections;

public class DestroyNow : MonoBehaviour
{

    public GameObject AudioObject;

    // Use this for initialization
    void Start()
    {
        AudioObject = GameObject.Find("BackgroundMusic");
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(AudioObject);
    }
}