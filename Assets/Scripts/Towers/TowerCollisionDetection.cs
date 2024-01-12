using UnityEngine;

public class TowerCollisionDetection : MonoBehaviour
{
    private void Start()
    {
        float ScaleMultiplier = GetComponent<TowerBehaviour>().Stats.Range * 2;
        transform.GetChild(0).localScale *= ScaleMultiplier;
        transform.GetChild(1).localScale *= ScaleMultiplier;
    }
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
