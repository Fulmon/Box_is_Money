using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    [SerializeField]InputManager inputManager;

    private void OnCollisionEnter(Collision collision)
    {
        if (!inputManager.selectedObjects.Contains(collision.gameObject))
        {
            Destroy(collision.gameObject);
        }
    }
}
