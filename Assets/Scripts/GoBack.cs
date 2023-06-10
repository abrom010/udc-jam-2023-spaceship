using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    public float TransitionTime = 1f;

    void Start()
    {
        StartCoroutine(TransitionTimer(TransitionTime));
    }

    IEnumerator TransitionTimer(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("TestSceneAaron");
    }
}
