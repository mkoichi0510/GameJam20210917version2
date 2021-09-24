using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArch : MonoBehaviour
{
    enum ROTATETYPE 
    {
        Right,
        Left
    }

    [SerializeField] ROTATETYPE rotateType;

    private GameObject targetObject;

    private Vector3 rotateAxis = Vector3.up;

    [SerializeField, Tooltip("速度係数")]
    private float speedFactor = 0.1f;

    private void Start()
    {
        targetObject = transform.root.gameObject;
        this.tag = "RotateArch";
    }
    private void Update()
    {
        if (targetObject == null) return;
        if (UIManager.GetSphere().constraints == RigidbodyConstraints.FreezeAll) return;

        // 指定オブジェクトを中心に回転する
        if(rotateType == ROTATETYPE.Right)
            this.transform.RotateAround(targetObject.transform.position,rotateAxis,360.0f / (1.0f / speedFactor) * Time.deltaTime);
        else
            this.transform.RotateAround(targetObject.transform.position, rotateAxis, -360.0f / (1.0f / speedFactor) * Time.deltaTime);

    }
}
