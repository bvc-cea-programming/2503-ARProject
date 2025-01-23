using UnityEngine;

public class MatSwitch : MonoBehaviour
{
    [SerializeField] private Material[] mats;
    [SerializeField] private GameObject[] objects;
    public void SwitchMat()
    {
        int num = Random.Range(0, mats.Length);
        foreach (var obj in objects)
        {
            obj.GetComponent<MeshRenderer>().material = mats[num];
        }
    }
}
