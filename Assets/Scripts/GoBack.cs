using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    public float TransitionTime = 1f;

    void Start()
    {
        //StartCoroutine(TransitionTimer(TransitionTime));
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("TestSceneAaron");
        }
    }

    IEnumerator TransitionTimer(float time)
    {
        yield return new WaitForSeconds(time);

    }
}
