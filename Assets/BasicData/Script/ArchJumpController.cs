using System.Collections;
using UnityEngine;

public class ArchJumpController : MonoBehaviour
{
   
    [SerializeField, Tooltip("飛ばしたい位置に空のオブジェクトを作成し、ここに割り当てる")]
    private GameObject TargetObject;
    private void Start()
    {
        this.tag = "Jump";
    }

    public IEnumerator TowerJump(Rigidbody spehere)
    {
        UIManager.audioManager.SetSE(Resources.Load("SE/回想") as AudioClip);
        UIManager.audioManager.PlaySE();
        spehere.transform.position = TargetObject.transform.position;
        spehere.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(1.0f);
        spehere.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    }
   
}
