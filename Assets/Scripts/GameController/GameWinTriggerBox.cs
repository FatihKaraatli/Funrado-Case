using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinTriggerBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEnd.instance.PlayerWin();
        }
    }
}
