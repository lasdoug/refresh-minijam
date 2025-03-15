
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UIElements;


public class Attractor : MonoBehaviour
{

    public Rigidbody2D rb;

    public AstronautRotation astronautRotation;
    public float maxForce = 0f;

    public Planet maxForcePlanet;

    //called a bunch of times a second, for physics stuff
    void FixedUpdate()
    {   
        Planet[] planets = FindObjectsByType<Planet>(FindObjectsSortMode.None);
        //Attractor[] attractors = FindObjectsByType<Attractor>(FindObjectsSortMode.None);
        //print(attractors);
        foreach(Planet planet in planets){
            AttractStandard(planet);
        }
        astronautRotation.rotateAstronaut(maxForce, maxForcePlanet);
    }

    //the obj to attract 
    void AttractStandard(Planet objToAttract){
        Rigidbody2D rbToAttract = objToAttract.planetRb;

        Vector2 direction = rb.position - rbToAttract.position;
        float distance = Mathf.Clamp(direction.magnitude, 0.6f, Mathf.Infinity);

        float forceMagnitude =(rb.mass * rbToAttract.mass)/Mathf.Pow(distance, 2);
    
        Vector2 force = direction.normalized * forceMagnitude;
        
        if (objToAttract.planetType == Planet.PlanetType.Regular){
            //print("planet is regular");
            Vector2 forceReal = -force;

            if (Mathf.Abs(forceMagnitude) > maxForce){
                maxForce = forceMagnitude;
                //astronautRotation.rotateAstronaut(maxForce, rbToAttract.position);
                print("max force: "+maxForce);
                maxForcePlanet = objToAttract;
            }
            //rb.transform.up = -direction.normalized;

            rb.AddForce(forceReal);
        }

        if (objToAttract.planetType == Planet.PlanetType.Impulse){
            //print("planet is impulse");

            if(distance <= 1.5f){
                rb.AddForce(force, ForceMode2D.Impulse);
                print("within distance");
            }
        }

        


            
        
    }
}