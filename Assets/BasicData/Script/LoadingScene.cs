using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;

public class LoadingScene : MonoBehaviour
{

    private AsyncOperation async;
    public static int currentSceneNum = 0;
    

    public void LoadNextScene()
    {
        InitImage();
        UIManager.OpenLoadingImage();
        UIManager.audioManager.StopBGM();
        StartCoroutine(LoadScene(SceneManager.GetSceneAt(SceneManager.sceneCount-1).buildIndex + 1));
    }
    public void LoadScene(Button selectButton)
    {
        if (currentSceneNum > 1)
            UIManager.FreezeSphere();
        Time.timeScale = 1;
        SelectMoveScene select = selectButton.GetComponent<SelectMoveScene>();
        UIManager.OpenLoadingImage();
        InitImage();
        UIManager.audioManager.StopBGM();
        StartCoroutine(LoadScene((int)select.sceneName));
    }


    public void LoadSameScene()
    {
        if (currentSceneNum > 1)
            UIManager.FreezeSphere();
        Time.timeScale = 1;
        InitImage();
        UIManager.OpenLoadingImage();
        UIManager.SetUICamera();
        UIManager.audioManager.StopBGM();
        StartCoroutine(LoadScene(currentSceneNum));
    }

    IEnumerator LoadScene(int sceneNum)
    {
        if (currentSceneNum == sceneNum)
            SceneManager.UnloadSceneAsync(currentSceneNum);

        async = SceneManager.LoadSceneAsync(sceneNum, LoadSceneMode.Additive);

        while (!async.isDone)
        {
            UIManager.SetLoadingSlider(async.progress);
            Debug.Log(async.progress);
            yield return null;
        }
        yield return new WaitUntil(() => UIManager.audioManager.GetBgmVolume() == 0);
        yield return new WaitForSeconds(0.5f);
        if (currentSceneNum != sceneNum)
            SceneManager.UnloadSceneAsync(currentSceneNum);
        currentSceneNum = sceneNum;
        if (currentSceneNum != 0)
        {
            UIManager.OpenPauseButton();
            if (currentSceneNum > 1 && currentSceneNum < 5)
                UIManager.audioManager.SetBGM(Resources.Load("BGM/SampleStage") as AudioClip);
            else if (currentSceneNum >= 5 && currentSceneNum < 7)
                UIManager.audioManager.SetBGM(Resources.Load("BGM/中級") as AudioClip);
            else if (currentSceneNum >= 7 && currentSceneNum <= 8)
                UIManager.audioManager.SetBGM(Resources.Load("BGM/上級") as AudioClip);
            else if (currentSceneNum == 9)
                UIManager.audioManager.SetBGM(Resources.Load("BGM/エンディングテーマ") as AudioClip);
        }
        UIManager.CloseUICamera();
        UIManager.CloseLoadingImage();
        if (currentSceneNum == 0)
        {
            UIManager.OpenTitleCanvas();
            UIManager.audioManager.SetBGM(Resources.Load("BGM/タイトルテーマ") as AudioClip);
        }

        UIManager.audioManager.SetBgmVolume();
        UIManager.audioManager.PlayBGM();
        UIManager.SetLoadingSlider(0);
        UIManager.StartGame();
    }


    void InitImage()
    {
        UIManager.CloseClearImage();
        UIManager.CloseGameOverImage();
        UIManager.ClosePauseMenu();
        UIManager.ClosePauseButton();
        UIManager.CloseMenu();
        UIManager.CloseSoundPanel();
        
    }
}