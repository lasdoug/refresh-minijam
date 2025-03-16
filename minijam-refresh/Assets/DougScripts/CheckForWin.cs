using System;
using UnityEngine;
using UnityEngine.Events;

public class CheckForWin : MonoBehaviour
{

    public UnityEvent OnWin;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Astronaut"))
        {
            print("win!!!");
            OnWin.Invoke();
        }
    }
}
