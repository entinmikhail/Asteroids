using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalTeleporter : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SetPositionAndRotation(other.transform.position * new Vector2(-1, 1), other.transform.rotation);
    }
}
