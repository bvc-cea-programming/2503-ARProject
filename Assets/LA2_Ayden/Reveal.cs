using UnityEngine;
using UnityEngine.UIElements;

public class Reveal : MonoBehaviour
{

    public Button button;

    public GameObject[] objects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (var obj in objects)
        {
            if (obj.GetComponent<MeshRenderer>())
            {
                obj.SetActive(false);
            }
        }
    }

    public void Press()
    {
        foreach (var obj in objects)
        {
            if (obj.GetComponent<MeshRenderer>())
            {
                if (!obj.activeSelf)
                {
                    obj.SetActive(true);
                }
                else
                {
                    obj.SetActive(false);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
