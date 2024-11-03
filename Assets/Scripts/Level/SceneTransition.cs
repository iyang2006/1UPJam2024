using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public static SceneTransition instance;

    private void Awake()
    {
    if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    else
        {
            Destroy(gameObject);   
        }
    }
    public void NextLevel(int SceneSelect)
    {
        SceneManager.LoadSceneAsync(SceneSelect);
    }

}
