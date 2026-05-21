using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MoveToNextScene : MonoBehaviour
{
    public float TimertonextScene;
    

    private void Start()
    {
        StartCoroutine(MoveNextScene());
    }

    private IEnumerator MoveNextScene()
    {
        yield return new WaitForSeconds(TimertonextScene);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

