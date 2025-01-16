using UnityEngine;
using DG.Tweening;
public class TargetController : MonoBehaviour
{
    [SerializeField] private GameObject[] targetObjects;
    public void OnTargetFound()
    {
        foreach (GameObject obj in targetObjects)
        {
            obj.transform.localScale = Vector3.one;
            obj.transform.DOScale(Vector3.zero, 1f).From();
        }
    }
}
