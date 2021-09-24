using System.Collections;
using UnityEngine;

public class ArchJumpController : MonoBehaviour
{
   
    [SerializeField, Tooltip("��΂������ʒu�ɋ�̃I�u�W�F�N�g���쐬���A�����Ɋ��蓖�Ă�")]
    private GameObject TargetObject;
    private void Start()
    {
        this.tag = "Jump";
    }

    public IEnumerator TowerJump(Rigidbody spehere)
    {
        UIManager.audioManager.SetSE(Resources.Load("SE/��z") as AudioClip);
        UIManager.audioManager.PlaySE();
        spehere.transform.position = TargetObject.transform.position;
        spehere.constraints = RigidbodyConstraints.FreezeAll;
        yield return new WaitForSeconds(1.0f);
        spehere.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
    }
   
}
