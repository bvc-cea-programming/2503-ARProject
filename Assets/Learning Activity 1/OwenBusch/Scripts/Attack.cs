using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Attack>())
        {
            _anim.SetBool("Punch", true);
            transform.LookAt(other.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Attack>())
        {
            _anim.SetBool("Punch", false);
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
