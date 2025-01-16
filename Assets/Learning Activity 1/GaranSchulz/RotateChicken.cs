using UnityEngine;

public class RotateChicken : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        this.transform.Rotate(Random.Range(1f, 3f), Random.Range(5f, 10f), 0);
    }
}
