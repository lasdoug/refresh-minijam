
using UnityEngine;
using System.Collections.Generic;
using System.Collections;


public class Attractor : MonoBehaviour
{

    public Rigidbody2D rb;

    //called a bunch of times a second, for physics stuff
    void FixedUpdate()
    {   
        Planet[] planets = FindObjectsByType<Planet>(FindObjectsSortMode.None);
        //Attractor[] attractors = FindObjectsByType<Attractor>(FindObjectsSortMode.None);
        //print(attractors);
        foreach(Planet planet in planets){
            Attract(planet);
        }
    }

    //the obj to attract 
    void Attract(Planet objToAttract){

        Rigidbody2D rbToAttract = objToAttract.planetRb;

        Vector2 direction = rb.position - rbToAttract.position;
        float distance = Mathf.Clamp(direction.magnitude, 0.6f, Mathf.Infinity);

        float forceMagnitude =(rb.mass * rbToAttract.mass)/Mathf.Pow(distance, 2);
        Vector2 force = direction.normalized * forceMagnitude;
        Vector2 forceReal = -force;
        rb.AddForce(forceReal);
    }
}