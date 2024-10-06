using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
/// <summary>
/// ”√”⁄≥°æ∞«–ªª
/// </summary>
public class SceneManagerGlobal : MonoSingleton<SceneManagerGlobal>
{
    public GameObject canvas;
    public TextMeshProUGUI loadingText;

    private void Start()
    {
        canvas.SetActive(false);
        loadingText.text = "0";
    }
    public void SwitchSceneToMain()
    {
        LoadSceneAsync("");
    }
    public void SwitchSceneToLevel_1()
    {
        LoadSceneAsync("");
    }
    public void QuitGame()
    {
        Application.Quit();
    }




    private bool isLoading = false;
    private int loadingProgres;
    public int LoadingProgres 
    {
        get { return loadingProgres; }
        private set 
        { 
            if(loadingProgres != value)
            {
                loadingProgres = value;
                OnLoadingProgresChange();
            }
        } 
    }

    private void OnLoadingProgresChange()
    {
        if (loadingText != null)
        {
            loadingText.text = loadingProgres.ToString();

        }
    }

    public void LoadSceneAsync(string sceneName, Action loadComplete = null)
    {
        if (isLoading)
        {
            Debug.LogError("Scene is already loading. New load request is ignored.");
            return;
        }

        isLoading = true;
        canvas.SetActive(true);
        LoadingProgres = 0;
        StartCoroutine(LoadSceneCoroutine(sceneName, loadComplete));

    }
    private IEnumerator LoadSceneCoroutine(string sceneName, Action loadComplete = null)
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneName);
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone && asyncOperation.progress < 0.9f)
        {
            int targetProgres = (int)(asyncOperation.progress * 100);
            while (LoadingProgres < targetProgres)
            {
                ++LoadingProgres;
                yield return null;
            }
        }
        while (LoadingProgres < 100)
        {
            LoadingProgres++;
            yield return null;
        }
        LoadingProgres = 100;
        asyncOperation.allowSceneActivation = true;
        loadComplete?.Invoke();
        isLoading = false;
        yield return null;
        canvas.SetActive(false);
    }

}
