using UnityEngine;
using DG.Tweening;

public class TargetController : MonoBehaviour
{
    [SerializeField] private GameObject targetObject;
    public void OnTargetFound()
    {
        targetObject.transform.localScale = 0.66f * Vector3.one;
        targetObject.transform.DOScale(Vector3.zero, 1f).From();
    }
}
