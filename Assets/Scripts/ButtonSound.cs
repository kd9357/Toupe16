using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSound : MonoBehaviour
{

    public AudioSource source;
    public AudioClip hover;
    public AudioClip click;
    public AudioClip hover2;
    public AudioClip click2;

    public void loadNextScene()
    {
        StartCoroutine(LoadingLevel());
    }

    IEnumerator LoadingLevel()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);

    }

    public void Onhover()
    {
        source.PlayOneShot(hover);
    }

    public void Onclick()
    {
        source.PlayOneShot(click);
    }

    public void Onhover2()
    {
        source.PlayOneShot(hover2);
    }

    public void Onclick2()
    {
        source.PlayOneShot(click2);
    }
}