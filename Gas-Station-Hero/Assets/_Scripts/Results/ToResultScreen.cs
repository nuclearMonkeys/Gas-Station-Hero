using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToResultScreen : MonoBehaviour
{
    public Animator animator;
    public GameObject crossfadeImage;

    public void ToResults() 
    {
        StartCoroutine(ToResultsCoroutine());
    }

    IEnumerator ToResultsCoroutine() 
    {
        crossfadeImage.SetActive(true);
        animator.SetBool("fadeIn", true);
        yield return new WaitForSecondsRealtime(1.7f);
        gameObject.SetActive(false);
        SceneManager.LoadScene("ResultsTest");
    }
}
