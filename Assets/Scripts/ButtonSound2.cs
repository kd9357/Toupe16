using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSound2 : MonoBehaviour
{
    public AudioSource source;
    public AudioClip click;
    public AudioClip click2;
    public AudioClip click3;
    public AudioClip click4;
    
    public void Onclick()
    {
        source.PlayOneShot(click);
    }
    
    public void Onclick2()
    {
        source.PlayOneShot(click2);
    }
    public void Onclick3()
    {
        source.PlayOneShot(click3);
    }
    public void Onclick4()
    {
        source.PlayOneShot(click4);
    }
}