using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject obj;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 0, 2f);
    }

    private void SpawnObject()
    {
        Instantiate(obj, transform.position, Quaternion.identity);
    }
}
