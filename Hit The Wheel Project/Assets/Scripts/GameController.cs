using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private const int MAX_SWORD_COUNT = 16;
    private const float DELAY = 1.5f;

    public string BEST_SCORE_KEY = "BSKey";

    private int goalSwordCount;
    private float destroyTime;

    public static int score, currentSwordCount, bestScore;

    [SerializeField]
    private GameObject shieldPref;
    private GameObject menuPanel, gamePanel;
    private Text scoreText, bestScoreText;
    private Vector2 shieldPos;
    [HideInInspector]
    public GameObject currentShield;

    private void Start()
    {
        menuPanel = GameObject.Find("MenuPanel");
        gamePanel = GameObject.Find("GamePanel");
        bestScoreText = GameObject.Find("BestScoreText").GetComponent<Text>();
        score = 0;
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        currentShield = GameObject.FindGameObjectWithTag("Shield");
        shieldPos = currentShield.transform.position;
        currentSwordCount = 0;
        goalSwordCount = 4;
        currentShield.SetActive(false);
        gamePanel.SetActive(false);
        bestScore = PlayerPrefs.GetInt(BEST_SCORE_KEY, 0);
    }

    private void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        bestScoreText.text = "Best Score: " + bestScore.ToString();
        if (currentSwordCount == goalSwordCount)
        {
            Destroy(currentShield);
            currentSwordCount = 0;
            destroyTime = Time.time;
            if (goalSwordCount < MAX_SWORD_COUNT)
            {
                goalSwordCount++;
            }
        }
        if (currentShield == null && Time.time > destroyTime + DELAY)
        {
            currentShield = Instantiate(shieldPref, shieldPos, Quaternion.identity);
            currentShield.GetComponent<SpriteRenderer>().color =
                new Color(
                Random.Range(0.5f, 1f), 
                Random.Range(0.5f, 1f), 
                Random.Range(0.5f, 1f));
        }
    }

    public void SwitchPause()
    {
        if (menuPanel.activeSelf)
        {
            if(currentShield != null)
            {
                currentShield.SetActive(true);
            }            
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
        gamePanel.SetActive(!gamePanel.activeSelf);
        menuPanel.SetActive(!menuPanel.activeSelf);
        
    }

    public void OnQuit()
    {
        Application.Quit();
    }
}
