using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchesRoteto : MonoBehaviour
{
    bool m_xPlus = true;
    public GameObject archemove;
    void Update()
    {
        if (m_xPlus)
        {
            transform.position += new Vector3(0f,2f * Time.deltaTime, 0f);
            if (transform.localPosition.y >= 2)
                m_xPlus = false;
        }
        else
        {
            transform.position -= new Vector3(0f,2f * Time.deltaTime, 0f);
            if (transform.localPosition.y <= -2)
                m_xPlus = true;
        }
    }
}
