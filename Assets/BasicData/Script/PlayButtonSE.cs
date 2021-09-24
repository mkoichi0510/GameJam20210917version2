using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButtonSE : MonoBehaviour
{
    [SerializeField] string seName;
   public void PlaySE()
    {
        UIManager.audioManager.SetSE(Resources.Load($"SE/{seName}") as AudioClip);
        UIManager.audioManager.PlaySE();
    }
}
