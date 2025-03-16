using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class PlanetClass : MonoBehaviour
{

    // Variables 
    public float minMass = 1f; 
    public float maxMass = 10f;
    public float minRadius = 1f;
    public float maxRadius = 10f;

    public float mass { get; private set; }
    public float radius { get; private set; }
    public readonly float G = 6.67f;

    // List of all planets
    public static List<PlanetClass> allPlanets = new List<PlanetClass>();

    // Circle collider component
    // private CircleCollider2D circleCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set random mass and radius of planet
        mass = Random.Range(minMass, maxMass);
        radius = Random.Range(minRadius, maxRadius);

        // Set scale of planet
        transform.localScale = new Vector3(0.1f, 0.1f, 1f);

        // List all planets
        foreach (PlanetClass planet in allPlanets)
        {
            Debug.Log("Planet Mass: " + planet.mass + " Radius: " + planet.radius + " G: " + planet.G);
        }

        // Get circle collider component of planet
        CircleCollider2D circleCollider = GetComponent<CircleCollider2D>();

        // Assign circle collider radius to equal planet radius
        
        if(circleCollider != null)
        {
            circleCollider.radius = radius;
            Debug.Log("Circle collider radius assigned, r = " + circleCollider.radius);
        }
        else
        {
            Debug.LogError("Circle Collider 2D component not found on planet");
        }
        

    }

   
    // Update planet list
    private void Awake()
    {
        allPlanets.Add(this);
    }
    private void OnDestroy()
    {
        allPlanets.Remove(this);
    }
}
