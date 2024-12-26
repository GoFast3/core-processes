using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public GameObject playerPrefab;
    private GameObject player;

    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;

    public Button shortDistanceButton;
    public Button mediumDistanceButton;
    public Button longDistanceButton;

    public Button startButton;

    
    [SerializeField] float EasySpead;
    [SerializeField] float MediumSpead;
    [SerializeField] float HardSpead;

    [SerializeField] private float shortDistance ;
    [SerializeField] private float mediumDistance;
    [SerializeField] private float longDistance ;



    private void Start()
    {
        easyButton.onClick.AddListener(() => { Debug.Log("Easy button clicked!"); SetDifficulty(EasySpead); });
        mediumButton.onClick.AddListener(() => { Debug.Log("Medium button clicked!"); SetDifficulty(MediumSpead); });
        hardButton.onClick.AddListener(() => { Debug.Log("Hard button clicked!"); SetDifficulty(HardSpead); });
        startButton.onClick.AddListener(() => { Debug.Log("Start button clicked!"); StartGame(); });

        shortDistanceButton.onClick.AddListener(() => SetSpawnDistance(shortDistance));
        mediumDistanceButton.onClick.AddListener(() => SetSpawnDistance(mediumDistance));
        longDistanceButton.onClick.AddListener(() => SetSpawnDistance(longDistance));

        PlayerPrefs.SetFloat("minSpawnDistance", 0);

        PlayerPrefs.SetFloat("forwardSpeed", 0);
        // יצירת השחקן בסצנה
        player = Instantiate(playerPrefab);
    }

    public void SetDifficulty(float speed)
    {
        // שמירה עם המפתח הנכון
        PlayerPrefs.SetFloat("forwardSpeed", speed);
        Debug.Log("Speed set to: " + PlayerPrefs.GetFloat("forwardSpeed"));
    }

    public void SetSpawnDistance(float distance)
    {
        PlayerPrefs.SetFloat("minSpawnDistance", distance);
        Debug.Log("Spawn distance set to: " + PlayerPrefs.GetFloat("minSpawnDistance"));
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");  // מעבר לסצנה הראשית
    }
}