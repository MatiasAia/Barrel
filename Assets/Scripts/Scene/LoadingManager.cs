using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{
    public static LoadingManager instance;

    string nextScene;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string scene)
    {
        nextScene = scene;
        FadeManager.instance.Fade(() => LoadSceneAsync(Utilities.LOADING_SCENE), true);
    }

    void LoadScene()
    {
        LoadSceneAsync(nextScene);
    }

    void LoadSceneAsync(string scene)
    {
        StartCoroutine(LoadingScene(scene));
    }

    IEnumerator LoadingScene(string scene)
    {
        AsyncOperation Async = SceneManager.LoadSceneAsync(scene);
        Async.allowSceneActivation = false;

        while (Async.progress < 0.9f)
        {
            yield return new WaitForEndOfFrame();
        }

        // Aca hacer el fadeIn con FadeOut
        if (scene != Utilities.LOADING_SCENE)
            FadeManager.instance.Fade(() => { Async.allowSceneActivation = true; FadeManager.instance.Fade(() => { }, false); }, true, Utilities.DEFAULT_TIME_LOADING);
        else
        {
            Async.allowSceneActivation = true;
            FadeManager.instance.Fade(() => LoadScene(), false);
        }
    }

    public void ResetScene()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }
}
