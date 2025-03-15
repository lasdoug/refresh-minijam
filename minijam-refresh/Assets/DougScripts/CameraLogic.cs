using UnityEngine;

public class CameraLogic : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float snappiness = 0.25f;
    
    private Vector3 endPosition;
    private Vector3 _offset;
    private Vector3 _currentVelocity;
    
    void OnEnable()
    {
        _offset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        endPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, endPosition, ref _currentVelocity, snappiness);
    }
}
