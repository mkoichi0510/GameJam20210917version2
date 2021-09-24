using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchController : MonoBehaviour
{
    Vector3 verticalJump = new Vector3(0,6,0);
    void Start()
    {
        this.tag = "Arch";
    }

    public void VerticalJump(Rigidbody rig)
    {
        if (rig.velocity.y <= 0 && rig.constraints != RigidbodyConstraints.FreezeAll)
        {
            UIManager.audioManager.SetSE(Resources.Load("SE/jump1") as AudioClip);
            UIManager.audioManager.PlaySE();
            rig.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
            rig.AddForce(verticalJump * rig.mass, ForceMode.Impulse);
        }
    }
}
