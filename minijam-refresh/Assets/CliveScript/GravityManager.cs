using UnityEngine;

public class GravityManager : MonoBehaviour
{
    // Variables
    public GameObject astronaut;
    private Rigidbody2D astronautRb; // Variable to store the Rigidbody2D component of the astronaut

    // Initialise
    private void Start()
    {
        astronaut = GameObject.FindGameObjectWithTag("Astronaut");
        astronautRb = astronaut.GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component of the astronaut
    }
    
    // Apply gravity to each planet
    private void FixedUpdate()  // Built in method that runs at fixed intervals, used for physics-related calculations
    {
        foreach (PlanetClass planet in PlanetClass.allPlanets)
        {
            Debug.Log("Planet Mass: " + planet.mass + " Radius: " + planet.radius + " G: " + planet.G);
            if (planet.isRepulsing)
            {
                ApplyRepulsion(planet);
                
            }
            else
            {
                ApplyGravity(planet);
                Debug.Log("Planet is attracting");
            }
        }

    }

    // Apply gravity method 
    void ApplyGravity(PlanetClass planet)
    {
        Vector2 direction = planet.transform.position - astronaut.transform.position;   // Direction vector between planet and astronaut
        float distance = direction.magnitude;   // Distance magnitude between planet and astronaut

        // Prevents division by zero
        if (distance <= 0)
        {
            Debug.LogError("Distance between planet and astronaut is zero");
            return;
        }

        // Calculate force magnitude and direction
        float forceMagnitude = planet.G * (planet.mass * astronautRb.mass) / (distance * distance); // Calculate force magnitude
        Vector2 force = direction.normalized * forceMagnitude;  // Normalised direction vector and scaled by force magnitude

        // Apply force to astronaut
        astronautRb.AddForce(force);    // Apply force to astronaut
    }

    // Apply repulsion force 
    void ApplyRepulsion(PlanetClass planet)
    {
        Vector2 direction = planet.transform.position - astronaut.transform.position;   // Direction vector between planet and astronaut
        float distance = direction.magnitude;   // Distance magnitude between planet and astronaut

        // Prevents division by zero
        if (distance <= 0)
        {
            Debug.LogError("Distance between planet and astronaut is zero");
            return;
        }

        // Calculate force magnitude and direction
        float forceMagnitude = planet.G * (planet.mass * astronautRb.mass) / (distance * distance); // Calculate force magnitude
        Vector2 force = -direction.normalized * forceMagnitude;  // Normalised direction vector and scaled by force magnitude

        // Apply force to astronaut
        astronautRb.AddForce(force);    // Apply force to astronaut
        Debug.Log("Planet is repulsing");
    }
}
