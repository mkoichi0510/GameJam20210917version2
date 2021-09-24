using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ButtonController : MonoBehaviour
{ 
    public void Pause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            UIManager.OpenPauseMenu();
        }
        else
        {
            Time.timeScale = 1;
            UIManager.ClosePauseMenu();
        }
    }

    public void OpenMenu()
    {
        UIManager.OpenMenu();
    }

    public void CloseMenu()
    {
        UIManager.CloseMenu();
    }

    public void OpenSoundPanel()
    {
        UIManager.OpenSoundPanel();
    }

    public void CloseSoundPanel()
    {
        UIManager.CloseSoundPanel();
    }

    public void SetVol()
    {
        UIManager.SetVolume();
    }

}
