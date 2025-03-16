using UnityEngine;

public class Supernova : PlanetClass
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isRepulsing = true;
        if (isRepulsing)
        {
            Debug.Log("Supernova is repulsing");
        }
    }
}
