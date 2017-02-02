using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToTitle : MonoBehaviour
{
   void Start()
    {
        ModeSelect();
    }
   public void ModeSelect()
{
    StartCoroutine(LoadAfterDelay("title"));
}

IEnumerator LoadAfterDelay(string levelName)
{
        print("helo");
        yield return new WaitForSeconds(04); // wait 41 seconds
    SceneManager.LoadScene(levelName);

}
 }