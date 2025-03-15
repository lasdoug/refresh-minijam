using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Planet : MonoBehaviour
{

    // Variables 
    public float minMass = 1f; 
    public float maxMass = 10f;
    public float minRadius = 1f;
    public float maxRadius = 10f;

    public float mass { get; private set; }
    public float radius { get; private set; }

    // List of all planets
    public static List<Planet> allPlanets = new List<Planet>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Set random mass and radius of planet
        mass = Random.Range(minMass, maxMass);
        radius = Random.Range(minRadius, maxRadius);

        // Set scale of planet
        transform.localScale = new Vector3(radius * 2, radius * 2, radius);

        // List all planets
        Debug.Log(allPlanets);
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
