using Newtonsoft.Json.Converters;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class hide : MonoBehaviour
{
    private string spriteNames = "";
    private SpriteRenderer SpriteRenderer;
    private Sprite[] sprites;
    [SerializeField] private Sprite FightSprite;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (globalvars.Fight == true)
        {
            SpriteRenderer.enabled = true;
        }
        else
        {
            SpriteRenderer.enabled = false;
        }
    }
}
