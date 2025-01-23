using System;
using UnityEngine;

public class VR2 : MonoBehaviour
{
    
    public BoxCollider box;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Vr1>())
        {
            Destroy(this.gameObject);
        }
    }
}
