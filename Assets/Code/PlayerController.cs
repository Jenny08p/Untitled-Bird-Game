using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Text scoreText;

    //John: Added initial value to speed, jumpForce, and score
    public float speed = 3f;
    public float jumpForce = 2f;
    private int score = 0; 

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        SetScoreText();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);
    }

    private void Update()
    {
        //John: Changed Input.GetKey to Input.GetKeyDown, since I assume you want a more flappy bird flight thing
        //      Also replaced jumpVelocity with jumpForce;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.velocity = Vector2.up * jumpForce;
        }

        //John: Changed the Input.GetAxis("escape") to Input.GetKey(KeyCode.Escape), since "escape" isn't a set input and GetKey would be simpler.
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            SceneManager.LoadSceneAsync("GameOver");
        }

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetScoreText();
        }

        if (other.gameObject.CompareTag("Win"))
        {
            SceneManager.LoadSceneAsync("YouWin");
        }
    }

    void SetScoreText()
    {
        scoreText.text = ":" + score.ToString();
    }

}
