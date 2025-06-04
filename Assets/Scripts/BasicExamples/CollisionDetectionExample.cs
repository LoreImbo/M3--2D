using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionExample : MonoBehaviour
{
    private int _pickupsCount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"OnTriggerEnter2D {collision.gameObject.name}");

        if (collision.CompareTag( Consts.Tags.Pickup ))
        {
            collision.gameObject.SetActive(false);
            _pickupsCount++;
            Debug.Log($"Collected {_pickupsCount} pickups!");
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log($"OnTriggerStay2D {collision.gameObject.name}");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log($"OnTriggerExit2D {collision.gameObject.name}");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"OnCollisionEnter2D {collision.collider.gameObject.name}");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log($"OnCollisionStay2D {collision.collider.gameObject.name}");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log($"OnCollisionExit2D {collision.collider.gameObject.name}");
    }

}
