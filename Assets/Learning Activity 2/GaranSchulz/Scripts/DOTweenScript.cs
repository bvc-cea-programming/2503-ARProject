using UnityEngine;
using DG.Tweening;
using UnityEditor;

public class DOTweenScript : MonoBehaviour
{
    public void Test()
    {
        this.transform.DOShakeScale(2f, 1f);
        this.transform.DOShakePosition(2f, 0.01f);
    }
}
