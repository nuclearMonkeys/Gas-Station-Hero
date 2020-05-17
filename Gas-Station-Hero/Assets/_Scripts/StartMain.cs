using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMain : MonoBehaviour
{
    public GameObject crossfadeImage;

    private void Start() 
    {
        StartCoroutine(Fade());     
    }
    
    private IEnumerator Fade() 
    {
        crossfadeImage.SetActive(true);
        crossfadeImage.GetComponent<CanvasGroup>().alpha = 1.0f;
        crossfadeImage.GetComponent<Animator>().SetBool("fadeOut", true);
        yield return new WaitForSecondsRealtime(1.7f);
        crossfadeImage.GetComponent<CanvasGroup>().alpha = 0.0f;
        crossfadeImage.SetActive(false);
    }
}
