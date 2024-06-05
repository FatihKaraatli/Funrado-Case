using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouchDetection : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            other.gameObject.GetComponent<Keys>().SetTaken();
        }
        else if (other.CompareTag("Book"))
        {
            other.gameObject.GetComponent<Books>().SetTaken();
        }
        else if (other.CompareTag("Enemy") && PlayerLifeState.instance.GetLifeState())
        {
            HitDetect.instance.DeathDecider(this.gameObject, other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Door"))
        {
            collision.gameObject.GetComponent<Doors>().SetLockOn();
        }
    }
}
