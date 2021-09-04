using System;
using System.Collections.Generic;
using Asteroids.Abstraction;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Asteroids.Core
{
    public class LaserShell : BaseShell
    {
        public override event Action<BaseShell> ShellDestroyed;

        private void Update()
        {
            
        }

        public override void Fire(Vector2 direction)
        {
            
            Debug.DrawRay(gameObject.transform.position, gameObject.transform.up, Color.red);
            
            RaycastHit2D[] hitList ;
            
            hitList = Physics2D.RaycastAll(gameObject.transform.position, gameObject.transform.up, 200);

            if (hitList != null)
            {
                Debug.Log(hitList);
            }
            foreach (var hit in hitList)
            {
                Debug.Log(hit);
            }

            // var hitList = Physics.RaycastAll(ray);
            
            if (hitList != null)
            {
                foreach (var hit in hitList)
                {
                    if (hit.collider.gameObject.CompareTag("Enemy"))
                    {
                        Debug.Log(hit);
                        Destroy(hit.collider.gameObject);
                        ShellDestroyed?.Invoke(this);
                    }
                }
            }
        }

        public override GameObject GetGameObject()
        {
            return gameObject;
        }
    }
}