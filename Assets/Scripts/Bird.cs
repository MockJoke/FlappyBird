using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D BirdRB;
    [SerializeField] private float speedX = 5f;
    [SerializeField] private float speedY = 5f;
    [SerializeField] private GameObject can;
    [SerializeField] private GameObject GameOverScreenObj;
    [SerializeField] private GameObject PauseScreenObj;
    [SerializeField] private Text TimeBoard; 
    [SerializeField] private Text GameOverScoreBoard;
    [SerializeField] private Text PauseScoreBoard;
    [SerializeField] private Animator animator;
    
    private int score = 0;
    private float gameTime;
    private int timeCounter = 0;
    private int HighScore = 0;
    private string difficulty;
    
    private static readonly int BirdDieAnimHash = Animator.StringToHash("BirdDie");

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        
        if (BirdRB == null)
            BirdRB = GetComponent<Rigidbody2D>();

        HighScore = PlayerPrefs.GetInt("HighScore", 0);

        difficulty = PlayerPrefs.GetString("difficulty"); 
        
        SetSpeedBasedOnDifficulty(difficulty);
    }
    
    void Update()
    {
        Move();

        gameTime += Time.deltaTime;
        timeCounter = Mathf.FloorToInt(gameTime);
        TimeBoard.text = "TIME: " + timeCounter;
        
        if(HighScore < score)
        {
            HighScore = score;
            PlayerPrefs.SetInt("HighScore", HighScore); 
        }
    }

    private void SetSpeedBasedOnDifficulty(string difficultyLevel)
    {
        switch (difficultyLevel)
        {
            case nameof(Difficulty.Easy):
                speedX = 5f;
                break;
            case nameof(Difficulty.Medium):
                speedX = 7f;
                break;
            case nameof(Difficulty.Hard):
                speedX = 9f;
                break;
        }
    }
    
    private void Move()
    {
        BirdRB.velocity = new Vector2(speedX, BirdRB.velocity.y);    //set speed in x and current velocity which is -9.8 m/s in y to let bird move in x 

        if (Input.GetMouseButtonDown(0))
        {
            BirdRB.velocity = new Vector2(BirdRB.velocity.x, speedY);    //set speed in y and current velocity which is already speed 5f in x to let bird move in y
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("pipes"))
        {
            animator.SetTrigger(BirdDieAnimHash);

            Time.timeScale = 0;

            can.GetComponent<CanvasGroup>().interactable = false;
            GameOverScreenObj.SetActive(true);
            GameOverScoreBoard.text = "" + score;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("counter"))
        {
            score++; 
        }
    }

    public void OkBtn()
    {
        gameTime = 0;
        score = 0;

        can.GetComponent<CanvasGroup>().interactable = true;
        GameOverScreenObj.SetActive(false);
        SceneManager.LoadScene("Play");
    }

    public void PauseBtn()
    {
        Time.timeScale = 0;

        can.GetComponent<CanvasGroup>().interactable = false;
        PauseScreenObj.SetActive(true);
        PauseScoreBoard.text = "" + score;
    }

    public void ResumeBtn()
    {
        Time.timeScale = 1;
        
        can.GetComponent<CanvasGroup>().interactable = true;
        PauseScreenObj.SetActive(false);
    }
    
    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
