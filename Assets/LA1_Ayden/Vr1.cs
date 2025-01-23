using System;
using UnityEngine;

public class Vr1 : MonoBehaviour
{

    public BoxCollider box;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<VR2>())
        {
            Destroy(this.gameObject);
        }
    }

}
