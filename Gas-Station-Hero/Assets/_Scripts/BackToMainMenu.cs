using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public GameObject crossfadeImage;

    public void ToMainMenu() 
    {
        StartCoroutine(ToMainMenuCoroutine());
    }

    private IEnumerator ToMainMenuCoroutine() 
    {
        crossfadeImage.SetActive(true);
        crossfadeImage.GetComponent<Animator>().SetBool("fadeIn", true);
        yield return new WaitForSecondsRealtime(1.7f);
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenuScene");
    }
}
