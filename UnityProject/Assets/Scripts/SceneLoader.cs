using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
 
    public void LoadSceneDatos(){
        SceneManager.LoadScene(1);
    }
    public void LoadScene3(){
        SceneManager.LoadScene(2);
    }
    public void LoadSceneLeaderboard(){
        SceneManager.LoadScene(6);
    }
    public void LoadSceneMain(){
        SceneManager.LoadScene(0);
    }
    public void ExitGame(){
        Application.Quit();
    }
}
