using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonBase<GameManager>
{
    [SerializeField]
    private int SceneNum;

    AsyncOperation async;

    [SerializeField]
    public Animator loadingAnim;
    private int FadeInBool = Animator.StringToHash("FadeIn");
    private int FadeOutBool = Animator.StringToHash("FadeOut");

    private void Start() 
    {
        loadingAnim = GetComponent<Animator>();
    }

    public void ChangeScene()
    {
        async = SceneManager.LoadSceneAsync(SceneNum);
        async.allowSceneActivation = true;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        StartCoroutine(LoadSceneAnimation());
    }

/// <summary>
/// 渐入渐出动画
/// </summary>
/// <returns></returns>
    IEnumerator LoadSceneAnimation()
    {
        loadingAnim.SetBool(FadeInBool,true);
        loadingAnim.SetBool(FadeOutBool,false);

        yield return new WaitForSeconds(1);

        loadingAnim.SetBool(FadeInBool,false);
        loadingAnim.SetBool(FadeOutBool,true);
    }
}

