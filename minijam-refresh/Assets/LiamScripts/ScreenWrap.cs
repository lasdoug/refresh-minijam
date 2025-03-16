using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    public Rigidbody2D astronaut;

    // Update is called once per frame
    void Update()
    {
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        float rightSideOfScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
        float leftSideOfScreen = Camera.main.ScreenToWorldPoint(new Vector2(0f,0f)).x;
        
        float topOfScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
        float bottomOfScreen = Camera.main.ScreenToWorldPoint(new Vector2(0f,0f)).y;
        
        if (screenPos.x <= 0 && astronaut.linearVelocity.x < 0){
            transform.position = new Vector2(rightSideOfScreen, transform.position.y);
        }
        else if (screenPos.x >= Screen.width && astronaut.linearVelocity.x > 0){
            transform.position = new Vector2(leftSideOfScreen, transform.position.y);
        }
        else if (screenPos.y >= Screen.height && astronaut.linearVelocity.y > 0){
            transform.position = new Vector2(transform.position.x, bottomOfScreen);
        }
        else if (screenPos.y <= 0 && astronaut.linearVelocity.y < 0){
            transform.position = new Vector2(transform.position.x, topOfScreen);
        }

        
    }   
}
