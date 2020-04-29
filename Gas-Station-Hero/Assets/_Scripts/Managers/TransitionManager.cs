using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is basically a scene manager. I changed the name so
// that it won't be confused with Unity's scene manager

public class TransitionManager : MonoBehaviour
{
    
    public static TransitionManager instance = null;

    private void Awake() 
    {
        if(!instance) 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
            return;
        }
    }

    public void TransitionScene(string scene) 
    {
        SceneManager.LoadScene(scene);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
