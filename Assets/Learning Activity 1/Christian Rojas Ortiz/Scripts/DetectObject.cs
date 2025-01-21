using UnityEngine;

public class DetectObject : MonoBehaviour
{
    private Animation _animation;
    [SerializeField] private string punch = "Punching";
    [SerializeField] private string idle = "Breathing Idle";

    private void Start()
    {
        _animation = GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Punching");
        if (other.gameObject.CompareTag("Player"))
        {
            _animation.Play(punch);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Breathing Idle");
        if (other.gameObject.CompareTag("Player"))
        {
            _animation.Play(idle);
        }
    }
}