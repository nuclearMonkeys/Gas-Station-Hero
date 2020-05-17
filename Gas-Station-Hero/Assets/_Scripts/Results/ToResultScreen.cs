using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToResultScreen : MonoBehaviour
{
    public Animator animator;
    public GameObject crossfadeImage;

    // void Start() 
    // {
    //     StartCoroutine(StartDay());
    // }

    public void ToResults() 
    {
        StartCoroutine(ToResultsCoroutine());
    }

    // private IEnumerator StartDay() 
    // {
    //     crossfadeImage.SetActive(true);
    //     crossfadeImage.GetComponent<Animator>().SetBool("fadeOut", true);
    //     yield return new WaitForSecondsRealtime(1.7f);
    //     crossfadeImage.SetActive(false);
    // }

    private IEnumerator ToResultsCoroutine() 
    {
        crossfadeImage.SetActive(true);
        animator.SetBool("fadeIn", true);
        yield return new WaitForSecondsRealtime(1.7f);
        gameObject.SetActive(false);
        SceneManager.LoadScene("ResultsTest");
    }
}
