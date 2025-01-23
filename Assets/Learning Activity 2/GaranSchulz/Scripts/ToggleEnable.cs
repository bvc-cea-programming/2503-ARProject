using UnityEngine;

public class ToggleEnable : MonoBehaviour
{
    private bool theBool;
    public void Toggle()
    {
        theBool = !theBool;
        this.gameObject.SetActive(theBool);
    }
}
