using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private TextMeshProUGUI deathCounterText;
    [SerializeField] private TextMeshProUGUI timeCounterText;
    [SerializeField] private TextMeshProUGUI levelCounterText;
    private int _deathCount = 0;
    private float _elapsedTime = 0f;
    private ObsticalSpawner _obsticalSpawner;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _obsticalSpawner = FindObjectOfType<ObsticalSpawner>();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
        timeCounterText.text = "Time: " + _elapsedTime.ToString("F2") + "s";
        levelCounterText.text = Mathf.FloorToInt(_obsticalSpawner.ObstacleSpeed).ToString();
    }

    public void IncrementDeathCount()
    {
        _deathCount++;
        deathCounterText.text = "Deaths: " + _deathCount;
        _obsticalSpawner.ResetElapsedTime();
        _elapsedTime = 0f; // Reset the elapsed time
    }
}