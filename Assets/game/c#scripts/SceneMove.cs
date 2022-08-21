using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneMove : MonoBehaviour
{
    public Animator animator;

    private int SceneNumer;
    private string SceneName;

    public void FadeSceneMove(int num)
    {
        SceneNumer = num;
        animator.SetTrigger("FadeOut");
    }
    // public void FadeSceneMove(string name)
    // {
    //     SceneName = name;
    //     animator.SetTrigger("FadeOut");
    // }
    private void LoadScene()
    {
        SceneManager.LoadScene(SceneNumer);
    }
    
    // public void LoadScene()
    // {
    //     SceneManager.LoadScene(SceneName);
    // }

    public void GameExit()
    {
        Application.Quit();
    }
}
