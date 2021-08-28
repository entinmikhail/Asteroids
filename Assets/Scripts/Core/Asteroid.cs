using System;
using Asteroids.Abstraction;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour, IResourceModel
{
    private Rigidbody2D _rigidbody;
    private float _maxSpeed = 3.0f;
    private float _curHealth = 1.0f;
    public event Action ResourceEnded;
    public event ResourceChangeHandler ResourceValueChanged;
    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        AddImpulse();
        
        ResourceEnded += Destroy;
    }

    private void AddImpulse()
    {
        _rigidbody.AddForce(new Vector2(Random.Range(-_maxSpeed, _maxSpeed), Random.Range(-_maxSpeed, _maxSpeed)), ForceMode2D.Impulse);
    }

    public void Destroy()
    {
        Debug.Log("pbuh");
        Destroy(gameObject);
        
        ResourceEnded -= Destroy;
    }
    
    public float GetCurrentResourceValue() => _curHealth;
  

    public void ChangeResource(float changeValue)
    {
        var prevValue = _curHealth;
        Debug.Log("zxc");
        _curHealth += changeValue;
        
        if(_curHealth <= 0)
            ResourceEnded?.Invoke();
        
        ResourceValueChanged?.Invoke(_curHealth, prevValue);
    }
}
