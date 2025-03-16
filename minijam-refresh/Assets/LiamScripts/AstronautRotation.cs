using Unity.Mathematics;
using UnityEngine;

public class AstronautRotation : MonoBehaviour
{
    public Rigidbody2D astronaut;

    public void rotateAstronaut(float maxForce, Planet planetPos){
        //float angle = Mathf.Atan2((astronaut.position.y-planetPos.y), (astronaut.position.x-planetPos.x))*(Mathf.PI/180);
        //print("angle: "+angle);
        //astronaut.rotation = angle;

        Vector2 direction = planetPos.planetRb.position - astronaut.position; 
        //astronaut.transform.up = direction.normalized; 
        float speed = 15f;
        var step = speed*Time.deltaTime;


        float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg-90;
        //Quaternion.AngleAxis()
        //astronaut.transform.up;
        var desiredRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        astronaut.transform.rotation = Quaternion.RotateTowards(astronaut.transform.rotation, desiredRotation, step);
        // print("angle: "+angle);
        //print("astronaut rotation: "+astronaut.transform.rotation+" step : "+step+" direction: "+direction+" Quaternion.Euler(direction.normalized): "+Quaternion.Euler(direction.normalized)+" astronaut.transform.rotation: "+astronaut.transform.rotation);
    
    
    }
}
