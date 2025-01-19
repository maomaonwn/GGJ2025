using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBase<GameManager>
{
    [SerializeField]
    private int SceneNum;

    AsyncOperation async;

    public void ChangeScene()
    {
        async = SceneManager.LoadSceneAsync(SceneNum);
        async.allowSceneActivation = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scene1");
    }
}
