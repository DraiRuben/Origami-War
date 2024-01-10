using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        DragAndDrop.Instance._collision.Add(other.gameObject);   
    }

    private void OnTriggerExit(Collider other)
    {
        DragAndDrop.Instance._collision.Remove(other.gameObject);
    }
}
