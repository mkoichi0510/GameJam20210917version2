using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] GameObject tower;

    public void FreezeTower(string tag)
    {

        tower = GameObject.FindWithTag("Tower");
        TowerController towerController = tower.GetComponent<TowerController>();
        if (tag.Equals("WallL"))
        {
            towerController.conflictR = true;
            towerController.conflictL = false;
        }
        else if (tag.Equals("WallR"))
        {
            towerController.conflictR = false;
            towerController.conflictL = true;
        }
        else
        {
            towerController.conflictR = false;
            towerController.conflictL = false;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            FreezeTower(this.tag);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        FreezeTower("");
    }

}
