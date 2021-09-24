using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (LoadingScene.currentSceneNum == 9)
            UIManager.CloseNextButton();
        else
            UIManager.OpenNextButton();
        
        UIManager.OpenClearImage();
        collision.gameObject.SetActive(false);
    }
}
