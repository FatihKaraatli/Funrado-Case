using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyerByTime : MonoBehaviour
{
    [Header("Destroy Countdown")]
    [SerializeField] private float time;

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
