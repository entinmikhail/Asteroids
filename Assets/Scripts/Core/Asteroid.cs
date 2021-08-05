using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private float _maxSpeed = 5.0f;
    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        AddImpulse();
    }

    private void AddImpulse()
    {
        _rigidbody.AddForce(new Vector2(Random.Range(-_maxSpeed, _maxSpeed), Random.Range(-_maxSpeed, _maxSpeed)), ForceMode2D.Impulse);
    }
}
