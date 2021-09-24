using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    // Start is called before the first frame update
    float inputData = default;
    int rotateNum = 0;
    public float inputVal = 0;
    public bool conflictR = false;
    public bool conflictL = false;

    [SerializeField] GameObject tower;

    //　キャラクターの角度
    private Quaternion rotation;
    //　変更する角度
    [SerializeField]
    private float rotateAngle = 45f;
    //　回転スピード
    [SerializeField]
    private float rotateSpeed = 1.5f;

    void Start()
    {
        this.tag = "Tower";
    }

    // Update is called once per frame
    void Update()
    {
        inputVal = Input.GetAxis("Horizontal");
        if (conflictR)
        {
            if(inputVal > 0)
                inputVal = 0;
            rotation = Quaternion.Euler(0f, transform.eulerAngles.y + inputVal * rotateAngle, 0f);

        }
        else if (conflictL)
        {
            if (inputVal < 0)
                inputVal = 0;
            rotation = Quaternion.Euler(0f, transform.eulerAngles.y + inputVal * rotateAngle, 0f);
        }
        else
        {
            rotation = Quaternion.Euler(0f, transform.eulerAngles.y + inputVal * rotateAngle, 0f);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
    }


}
