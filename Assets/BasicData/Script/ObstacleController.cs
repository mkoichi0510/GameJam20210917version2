using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
     [SerializeField] GameObject [] towerControllers = default;
     [SerializeField] ParticleSystem particle = default;
     [SerializeField] GameObject sphere;
     GameObject[] rotateArches = default;

    private void Start()
    {
        this.tag = "obstacle";
    }

    public void GameOver()
    {
        UIManager.audioManager.SetSE(Resources.Load("SE/explosion") as AudioClip);
        particle = GameObject.FindWithTag("Particle").GetComponent<ParticleSystem>();
        rotateArches = GameObject.FindGameObjectsWithTag("RotateArch");
        towerControllers= GameObject.FindGameObjectsWithTag("Tower");
        sphere = GameObject.FindWithTag("Player");
        foreach (GameObject rotateArch in rotateArches)
            rotateArch.GetComponent<RotateArch>().enabled = false;
        foreach (GameObject tower in towerControllers)
            tower.GetComponent<TowerController>().enabled = false;
        particle.Play();
        UIManager.audioManager.PlaySE();
        sphere.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        sphere.transform.localScale = new Vector3(0, 0, 0);
    }

}
