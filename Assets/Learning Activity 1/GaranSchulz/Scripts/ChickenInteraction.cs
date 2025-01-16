using UnityEngine;

public class ChickenInteraction : MonoBehaviour
{
    private bool inProx;
    private GameObject objectToLookAt;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<ChickenInteraction>())
            return;
        inProx = true;
        objectToLookAt = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        inProx = false;
    }

    private void FixedUpdate()
    {
        if(inProx)
            transform.LookAt(objectToLookAt.transform.position);
    }
}
