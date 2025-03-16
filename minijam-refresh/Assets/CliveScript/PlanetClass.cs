using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Serialization;

public class PlanetClass : MonoBehaviour
{

    // Variables 
    public float minMass = 1f; 
    public float maxMass = 10f;
    public float minRadius = 1f;
    public float maxRadius = 10f;
    public float increaseDecreaseAmount;
    

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

        // List all planets
        foreach (PlanetClass planet in allPlanets)
        {
            Debug.Log("Planet Mass: " + planet.mass + " Radius: " + planet.radius + " G: " + planet.G);
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

    public void IncreaseScale()
    {
        transform.localScale += new Vector3(increaseDecreaseAmount, increaseDecreaseAmount, increaseDecreaseAmount);
    }

    public void IncreaseMass()
    {
        mass += increaseDecreaseAmount;
    }
    
    public void DecreaseScale()
    {
        transform.localScale -= new Vector3(increaseDecreaseAmount, increaseDecreaseAmount, increaseDecreaseAmount);
    }

    public void DecreaseMass()
    {
        mass -= increaseDecreaseAmount;
    }
}
