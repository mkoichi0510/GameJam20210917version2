using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    static GameObject loadingImage;
    static GameObject menuImage;
    static Slider loadingSlider;
    static GameObject gameOver;
    static GameObject clear;
    static GameObject nextButton;
    static GameObject pauseButton;
    static GameObject pauseMenu;
    static Slider bgmSlider;
    static Slider seSlider;
    static GameObject soundPanel;
    public static AudioManager audioManager;
    static GameObject camera;
    static GameObject titleCanvas;
    static Rigidbody sphere;

    private void Start()
    {
        loadingImage = GameObject.FindWithTag("Loading");
        loadingSlider = loadingImage.GetComponentInChildren<Slider>();
        gameOver = GameObject.FindWithTag("GameOver");
        clear = GameObject.FindWithTag("Finish");
        nextButton = clear.transform.Find("NextButton").gameObject;
        pauseButton = GameObject.FindWithTag("Pause");
        pauseMenu = GameObject.FindWithTag("PauseMenu");
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
        soundPanel = GameObject.Find("SoundPanel");
        bgmSlider = GameObject.Find("BGMSlider").GetComponent<Slider>();
        seSlider = GameObject.Find("SESlider").GetComponent<Slider>();
        menuImage = GameObject.Find("MenuPanel");
        audioManager.SetBGM(Resources.Load("BGM/タイトルテーマ") as AudioClip);
        bgmSlider.value = audioManager.GetBgmVolume();
        seSlider.value = audioManager.GetSeVolume();
        bgmSlider.value = 0.5f;
        seSlider.value = 0.5f;
        audioManager.SetBgmVolume();
        audioManager.SetSeVolume();
        menuImage.SetActive(false);
        camera = GameObject.Find("UICamera");
        loadingImage.SetActive(false);
        gameOver.SetActive(false);
        clear.SetActive(false);
        pauseButton.SetActive(false);
        pauseMenu.SetActive(false);
        camera.SetActive(false);
        soundPanel.SetActive(false);
        audioManager.PlayBGM();
    }

    public static void SetLoadingSlider(float val)
    {
        loadingSlider.value = val;
    }
    public static void OpenLoadingImage()
    {
        loadingImage.SetActive(true);
    }

    public static void CloseLoadingImage()
    {
        loadingImage.SetActive(false);
    }
    public static void OpenGamaOverImage()
    {
        gameOver.SetActive(true);
    }

    public static void CloseGameOverImage()
    {
        gameOver.SetActive(false);
    }

    public static void OpenClearImage()
    {
        clear.SetActive(true);
    }

    public static void CloseClearImage()
    {
        clear.SetActive(false);
    }

    public static void OpenNextButton()
    {
        nextButton.SetActive(true);
    }

    public static void CloseNextButton()
    {
        nextButton.SetActive(false);
    }
    public static void OpenPauseButton()
    {
        pauseButton.SetActive(true);
    }

    public static void ClosePauseButton()
    {
        pauseButton.SetActive(false);
    }

    public static void OpenPauseMenu()
    {
        pauseMenu.SetActive(true);
    }

    public static void ClosePauseMenu()
    {
        pauseMenu.SetActive(false);
    }

    public static float GetBGMSliderVal()
    {
        return bgmSlider.value;
    }

    public static float GetSESliderVal()
    {
        return seSlider.value;
    }

    public static void SetUICamera()
    {
        camera.SetActive(true);
    }

    public static void CloseUICamera()
    {
        camera.SetActive(false);
    }

    public static void SetTitleCanvas()
    {
        titleCanvas = GameObject.Find("TitleCanvas");
    }

    public static void OpenTitleCanvas()
    {
        titleCanvas.SetActive(true);
    }

    public static void CloseTitleCanvas()
    {
        titleCanvas.SetActive(false);
    }

    public static void SetSphere(Rigidbody rigidbody)
    {
        rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        sphere = rigidbody;
    }

    public static Rigidbody GetSphere()
    {
        return sphere;
    }

    public static void StartGame()
    {
        sphere.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    }

    public static void FreezeSphere()
    {
        sphere.constraints = RigidbodyConstraints.FreezeAll;
    }

    public static void OpenMenu()
    {
        menuImage.SetActive(true);
    }

    public static void CloseMenu()
    {
        menuImage.SetActive(false);
    }

    public static void OpenSoundPanel()
    {
        soundPanel.SetActive(true);
    }

    public static void CloseSoundPanel()
    {
        soundPanel.SetActive(false);
    }

    public static void SetVolume()
    {
        audioManager.SetBgmVolume();
        audioManager.SetSeVolume();
    }
}
