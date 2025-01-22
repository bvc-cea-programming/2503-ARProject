using UnityEngine;

public class ChickenInteraction : MonoBehaviour
{
    private bool inProx;
    private GameObject objectToLookAt;
    private LineRenderer line;

    private void Awake()
    {
        inProx = false;
        line = GetComponent<LineRenderer>();
        line.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.GetComponent<ChickenInteraction>())
            return;
        inProx = true;
        line.enabled = true;
        objectToLookAt = other.gameObject;
    }

    private void OnTriggerExit(Collider other)
    {
        line.enabled = false;
        inProx = false;
    }

    private void FixedUpdate()
    {
        if (inProx)
        {
            transform.LookAt(objectToLookAt.transform.position);
            line.SetPosition(1, objectToLookAt.transform.position);
            line.SetPosition(0, this.transform.position);
        }
    }
}
