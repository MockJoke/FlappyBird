using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    [SerializeField] private Rigidbody2D BirdRB;
    [SerializeField] private float speed;
    [SerializeField] private float GameTime;
    [SerializeField] private int score = 0;
    [SerializeField] private int time = 0;
    [SerializeField] private int HighScore = 0;
    [SerializeField] private GameObject can;
    [SerializeField] private GameObject GameOver;
    [SerializeField] private Text TimeBoard, ScoreBoard;
    [SerializeField] private Animator animator;
    private string difficulty;
    
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
        BirdRB.velocity = new Vector2(speed, BirdRB.velocity.y);    //set speed in x and current velocity which is -9.8 m/s in y to let bird move in x 

        if (Input.GetMouseButtonDown(0))
        {
            BirdRB.velocity = new Vector2(BirdRB.velocity.x, speed);    //set speed in y and current velocity which is already speed 5f in x to let bird move in y 
        }

        Move();

        GameTime += Time.deltaTime;

        time = Mathf.FloorToInt(GameTime);
        TimeBoard.text = "TIME:" + time;

        //score = time;
        ScoreBoard.text = "" + score;

        
        if(HighScore < score)
        {
            HighScore = score;
            PlayerPrefs.SetInt("HighScore",HighScore); 
        }

        //print(GameTime);
    }

    private void SetSpeedBasedOnDifficulty(string difficultyLevel)
    {
        switch (difficultyLevel)
        {
            case nameof(Difficulty.Easy):
                speed = 5f;
                break;
            case nameof(Difficulty.Medium):
                speed = 7f;
                break;
            case nameof(Difficulty.Hard):
                speed = 9f;
                break;
        }
    }
    
    private void Move()
    {
        BirdRB.velocity = new Vector2(speed, BirdRB.velocity.y);    //set speed in x and current velocity which is -9.8 m/s in y to let bird move in x 

        if (Input.GetMouseButtonDown(0))
        {
            BirdRB.velocity = new Vector2(BirdRB.velocity.x, speed);    //set speed in y and current velocity which is already speed 5f in x to let bird move in y 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("pipes"))
        {
            //FlappyBird.velocity = new Vector2(0f, 0f);
            //Vector2 pos = new Vector2(transform.position.x, -4.5f);
            //FlappyBird.position = pos;
            animator.SetTrigger("BirdDie");

            Time.timeScale = 0;

            can.GetComponent<CanvasGroup>().interactable = false;
            GameOver.SetActive(true); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("counter"))
        {
            score++; 
        }
    }

    public void OkBtn()
    {
        GameTime = 0;
        score = 0;

        can.GetComponent<CanvasGroup>().interactable = true;
        GameOver.SetActive(false);
        SceneManager.LoadScene("Play");
    }

    private void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
