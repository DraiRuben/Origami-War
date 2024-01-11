using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCollisionDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("NotPlaceableOn"))
            DragAndDrop.Instance._collision.Add(other.gameObject);   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.gameObject.CompareTag("NotPlaceableOn"))
            DragAndDrop.Instance._collision.Remove(other.gameObject);
    }
}
