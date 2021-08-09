using System;
using Asteroids.Abstraction;
using UnityEngine;
using Random = UnityEngine.Random;

public class Asteroid : MonoBehaviour, IHealthModel
{
    private Rigidbody2D _rigidbody;
    private float _maxSpeed = 3.0f;
    private float _curHealth = 1.0f;
    public event Action Died;
    public event HealthChangeHandler HealthIsChanged;
    private void Start()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        AddImpulse();
        
        Died += Destroy;
    }

    private void AddImpulse()
    {
        _rigidbody.AddForce(new Vector2(Random.Range(-_maxSpeed, _maxSpeed), Random.Range(-_maxSpeed, _maxSpeed)), ForceMode2D.Impulse);
    }

    public void Destroy()
    {
        Debug.Log("pbuh");
        Destroy(gameObject);
        
        Died -= Destroy;
    }
    
    public float GetCurrentHealth() => _curHealth;
  

    public void ChangeHealth(float changeValue)
    {
        var prevValue = _curHealth;
        Debug.Log("zxc");
        _curHealth += changeValue;
        
        if(_curHealth <= 0)
            Died?.Invoke();
        
        HealthIsChanged?.Invoke(_curHealth, prevValue);
    }
}
