using UnityEngine;

public class PlanetSpawner : MonoBehaviour
{
    // Variables
    public GameObject planetPrefab;
    public int maxPlanet = 5;
    public Vector2 spawnArea = new Vector2(8.5f, 4.5f);
    public float spawnInterval = 5f;
    public float despawnInterval = 5f;
    public int initialPlanetCount = 3;

    private int _currentPlanetCount = 0;
    private float _spawnTimer = 0f;
    private float _despawnTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < initialPlanetCount; i++)
        {
            SpawnPlanet();
        }
    }

    

    // Update is called once per frame
    void Update()
    {
        // Update spawn timer
        _spawnTimer += Time.deltaTime;

        // Spawn planet based on spawn interval
        if (_spawnTimer >= spawnInterval)
        {
            SpawnPlanet();
            _spawnTimer = 0f;
        }


        // Update despawn timer
        _despawnTimer += Time.deltaTime;

        // Despawn planet based on despawn interval
        if (_despawnTimer >= despawnInterval)
        {
            DespawnPlanet();
            _despawnTimer = 0f;
        }

    }

    void SpawnPlanet()
    {
        // Check if max planet count has been reached
        if (_currentPlanetCount < maxPlanet)
        {
            // Create new planet
            GameObject newPlanet = Instantiate(planetPrefab, new Vector3(Random.Range(-spawnArea.x, spawnArea.x), Random.Range(-spawnArea.y, spawnArea.y), 0), Quaternion.identity);
            _currentPlanetCount++;
        }
    }

    void DespawnPlanet()
    {
        /*
        // Despawn planet based on despawn interval
        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");

        if (planets.Length > 0) // Make sure there are planets before trying to remove one
        {
            GameObject randomPlanet = planets[Random.Range(0, planets.Length)];
            Destroy(randomPlanet);
            _currentPlanetCount--;
        }
        */
        
        GameObject[] planets = GameObject.FindGameObjectsWithTag("Planet");
        GameObject astronaut = GameObject.FindGameObjectWithTag("Astronaut"); // Make sure your astronaut is tagged as "Astronaut"

        if (planets.Length > 0 && astronaut != null) // Ensure planets exist and astronaut is in the scene
        {
            GameObject closestPlanet = planets[0]; // Assume first planet is closest initially
            float closestDistance = Vector2.Distance(astronaut.transform.position, planets[0].transform.position);

            // Loop through all planets to find the closest one
            foreach (GameObject planet in planets)
            {
                float distance = Vector2.Distance(astronaut.transform.position, planet.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPlanet = planet;
                }
            }

            // Destroy the closest planet
            Destroy(closestPlanet);
            _currentPlanetCount--;
        }
        

    }
}
