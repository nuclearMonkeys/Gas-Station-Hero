using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        Color temp = crossfadeImage.GetComponent<Image>().color;
        temp.a = 0f;
        crossfadeImage.GetComponent<Image>().color = temp;
        crossfadeImage.GetComponent<Animator>().SetBool("fadeIn", true);
        yield return new WaitForSecondsRealtime(0.7f);
        gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenuScene");
    }
}
