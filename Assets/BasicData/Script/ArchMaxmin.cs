using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchMaxmin : MonoBehaviour
{
    [SerializeField] private Vector3 _maxScale;
    void Start()
    {
        
    }
    void Update()
    {
        transform.localScale = (Mathf.Sin(2 * Mathf.PI * Time.time) + 1) * 0.5f * _maxScale;
    }
}
