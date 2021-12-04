using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    Rigidbody2D FlappyBird;
    public float speed;
    public float GameTime;
    public int score=0, time, HighScore = 0, difficulty; 
    public GameObject can, GameOver;
    public Text TimeBoard, ScoreBoard;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        FlappyBird = GetComponent<Rigidbody2D>();

        HighScore = PlayerPrefs.GetInt("HighScore", 0);

        difficulty = PlayerPrefs.GetInt("difficulty"); 

    }

    // Update is called once per frame
    void Update()
    {
        FlappyBird.velocity = new Vector2(speed, FlappyBird.velocity.y);    //set speed in x and current velocity which is -9.8 m/s in y to let bird move in x 

        if (Input.GetMouseButtonDown(0))
        {
            FlappyBird.velocity = new Vector2(FlappyBird.velocity.x, speed);    //set speed in y and current velocity which is already speed 5f in x to let bird move in y 
        }

        if (difficulty == 1)
        {
            BirdSpeedinEasyDiff(); 
        }
        else if(difficulty == 2)
        {
            BirdSpeedinMedDiff(); 
        }
        else if(difficulty == 3)
        {
            BirdSpeedinHardDiff(); 
        }

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

    public void BirdSpeedinEasyDiff()
    {
        speed = 5f; 

        FlappyBird.velocity = new Vector2(speed, FlappyBird.velocity.y);    //set speed in x and current velocity which is -9.8 m/s in y to let bird move in x 

        if (Input.GetMouseButtonDown(0))
        {
            FlappyBird.velocity = new Vector2(FlappyBird.velocity.x, speed);    //set speed in y and current velocity which is already speed 5f in x to let bird move in y 
        }
    }

    public void BirdSpeedinMedDiff()
    {
        speed = 7f; 

        FlappyBird.velocity = new Vector2(speed, FlappyBird.velocity.y);    //set speed in x and current velocity which is -9.8 m/s in y to let bird move in x 

        if (Input.GetMouseButtonDown(0))
        {
            FlappyBird.velocity = new Vector2(FlappyBird.velocity.x - 2f, speed);    //set speed in y and current velocity which is already speed 5f in x to let bird move in y 
        }

    }

    public void BirdSpeedinHardDiff()
    {
        speed = 9f; 

        FlappyBird.velocity = new Vector2(speed, FlappyBird.velocity.y);    //set speed in x and current velocity which is -9.8 m/s in y to let bird move in x 

        if (Input.GetMouseButtonDown(0))
        {
            FlappyBird.velocity = new Vector2(FlappyBird.velocity.x - 2f, speed);    //set speed in y and current velocity which is already speed 5f in x to let bird move in y 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "pipes")
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
        if(collision.gameObject.tag == "counter")
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
