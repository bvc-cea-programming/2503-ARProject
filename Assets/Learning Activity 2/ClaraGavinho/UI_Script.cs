using UnityEngine;

public class UI_Script : MonoBehaviour
{
    [SerializeField] private GameObject UI;
    public void UISetOn()
    {
        UI.SetActive(true);
    }

    public void UISetOff()
    {
        UI.SetActive(false);
    }
}
