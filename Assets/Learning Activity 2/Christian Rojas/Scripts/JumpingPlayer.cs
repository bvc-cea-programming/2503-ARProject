using System;
using UnityEngine;

public class JumpingPlayer : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private GameObject startPosition;
    private bool _hasJumped = false;
    
    private void Start()
    {
        //set the initial position of the player
        transform.position = startPosition.transform.position;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_hasJumped)
        {
            Jump();
            _hasJumped = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _hasJumped)
        {
            ResetPosition();
            _hasJumped = false;
        }
        
    }
    
    private void Jump()
    {
        transform.position += Vector3.up * jumpForce;
    }
    
    private void ResetPosition()
    {
        //reset the position of the player
        transform.position = startPosition.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.IncrementDeathCount();
            ResetPosition();
        }
    }
}