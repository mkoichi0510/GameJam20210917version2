using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    public bool jump;
    
    void Start()
    {
        jump = false;
        UIManager.SetSphere(_rigidbody);
    }

    void Update()
    {
        
        if (_rigidbody.velocity.x == 0 && _rigidbody.velocity.y > 6)
        {
            _rigidbody.velocity = new Vector3(0,6,0);
        }

        if (_rigidbody.velocity.y < -6)
        {
            _rigidbody.velocity = new Vector3(0, -6, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("obstacle") || collision.gameObject.tag.Equals("RotateArch"))
        {
            ObstacleController obstacle = collision.gameObject.GetComponent<ObstacleController>();
            obstacle.GameOver();
        }
        else if (collision.gameObject.tag.Equals("Jump") && !jump)
        {
            jump = true;
            ArchJumpController archJump = collision.gameObject.GetComponent<ArchJumpController>();
            StartCoroutine(archJump.TowerJump(_rigidbody));
        }
        else if (collision.gameObject.tag.Equals("Arch") && !jump)
        {
            jump = true;
            ArchController arch = collision.gameObject.GetComponent<ArchController>();
            arch.VerticalJump(_rigidbody);
        }

        if (collision.gameObject.tag.Equals("Arch") || (collision.gameObject.tag.Equals("Jump")))
        {
            StartCoroutine(CheckJump());
            
        }


        IEnumerator CheckJump()
        {
            yield return null;
            Vector3 mini = new Vector3(0, 0.1f, 0);
            _rigidbody.AddForce(mini * _rigidbody.mass, ForceMode.Impulse);
            jump = false;
        }
    }


}
