using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    StartScene,
    GameScene,
    EndScene
}

public class StartGameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// Load Main scene
    /// </summary>
    public void LoadGameScene()
    {
        SceneManager.LoadScene((int)Scenes.GameScene);
    }
}
