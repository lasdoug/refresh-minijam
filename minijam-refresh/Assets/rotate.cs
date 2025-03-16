using System;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float rotateAmount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Astronaut"))
        {
            print("fired");
            Rigidbody2D _rb = other.gameObject.GetComponent<Rigidbody2D>();
            if (_rb != null)
            {
                _rb.position = new Vector3(-16.9f, 0f, 0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateAmount));
    }
}
