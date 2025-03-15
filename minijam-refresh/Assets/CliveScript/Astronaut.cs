using UnityEngine;

public class Astronaut : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Planet"))
        {
            Debug.Log("Astronaut collided with a planet! Game Over!");
            // Implement game over logic here (e.g., restart scene, show UI)
        }
    }
    
}
