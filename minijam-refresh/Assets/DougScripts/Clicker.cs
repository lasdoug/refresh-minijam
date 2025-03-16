using UnityEngine;
using UnityEngine.InputSystem;

public class Clicker : MonoBehaviour
{
    private Camera _camera;
    // private PlanetClass _activePlanet;
    
    // Update is called once per frame
    
    Vector3 point = Vector3.zero;
    void Update()
    {
        _camera = Camera.main;
        Mouse mouse = Mouse.current;
        Vector2 mousePosition = Input.mousePosition;
        // print(mousePosition);
        var worldPoint = _camera.ScreenToWorldPoint(mousePosition);
            
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(-Vector3.forward, Vector3.zero);
        float distance;

        if (plane.Raycast(ray, out distance))
        {
            point = ray.GetPoint(distance);
        }
            
        var collider = Physics2D.OverlapPoint(point);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (collider != null)
            {
                if (collider.GetComponent<PlanetClass>() != null)
                {
                    var _planet = collider.GetComponent<PlanetClass>();
                    _planet.IncreaseScale();
                    _planet.IncreaseMass();
                }
            }
            else
            {
                print("did not hit");
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (collider != null)
            {
                if (collider.GetComponent<PlanetClass>() != null)
                {
                    var _planet = collider.GetComponent<PlanetClass>();
                    _planet.DecreaseScale();
                    _planet.DecreaseMass();
                }
            }
            else
            {
                print("did not hit");
            }
        }
    }
}
