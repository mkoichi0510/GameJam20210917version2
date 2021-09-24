using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject stageSelect;
    
    void Start()
    {
        if(SceneManager.sceneCount == 1)
        {
            SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        }
        else
        {
            UIManager.SetTitleCanvas();
            UIManager.CloseTitleCanvas();
        }
    }

    public void OpenStageSelect()
    {
        stageSelect.SetActive(true);
    }

    public void CloseStageSelect()
    {
        stageSelect.SetActive(false);
    }
}
