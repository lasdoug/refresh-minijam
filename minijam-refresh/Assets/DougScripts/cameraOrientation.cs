using UnityEngine;

public class cameraOrientation : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _playerRb;
    [SerializeField] private GameObject _planet;
    [SerializeField] private float _rotateSpeed;
    
    // Update is called once per frame
    void Update()
    {
        Vector2 dir =  _playerRb.transform.position - _planet.transform.position;
        // print(dir);
        transform.up = Vector2.LerpUnclamped(transform.up, dir, Time.deltaTime * _rotateSpeed);
    }
}
