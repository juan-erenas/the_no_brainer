using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGameScene()
    {
        LoadSceneNamed("Game");
    }

    public void LoadMenuScene()
    {
        LoadSceneNamed("Main_Menu");
    }

    private void LoadSceneNamed(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }



}
