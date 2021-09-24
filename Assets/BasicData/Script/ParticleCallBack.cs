using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCallBack : MonoBehaviour
{
    [SerializeField] GameObject sphere;

    private void OnParticleSystemStopped()
    {
        sphere.SetActive(false);
        UIManager.OpenGamaOverImage();
    }
}
