using JetBrains.Annotations;
using UnityEngine;

public class Planet : MonoBehaviour
{
    public enum PlanetType{Regular, Impulse}
    public PlanetType planetType;
    public Rigidbody2D planetRb;
    
}
