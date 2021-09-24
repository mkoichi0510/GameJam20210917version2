using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{int counter = 0;
    float move = 0.005f;
 
    void Update()
    {
        Vector3 p = new Vector3(-move, 0, 0);
        transform.Translate(p);
        counter++;
        
        //countが50になれば-1を掛けて逆方向に動かす
        if (counter == 200)
        {
            counter = 0;
            move *= -1;
        }
    }
}
