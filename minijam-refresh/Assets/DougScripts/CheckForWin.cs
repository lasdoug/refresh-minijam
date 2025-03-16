using System;
using UnityEngine;

public class CheckForWin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spaceship"))
        {
            print("win");
        }
    }
}
