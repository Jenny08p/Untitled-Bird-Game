using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;

    public float speed;
    public float jumpForce;

    public Text scoreText;

    private int score; 
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        score = 0;

        SetScoreText();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float jumpVelcocity = 2f;
            rb2d.velocity = Vector2.up * jumpVelcocity; 
            float moveHorizontal = Input.GetAxis("Horizontal");
        }

        if (Input.GetKey("escape"))
            Application.Quit();
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            other.gameObject.SetActive(false);
            Application.LoadLevel("GameOver");
        }

        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            score = score + 1;
            SetScoreText();
        }

        if (other.gameObject.CompareTag("Win"))
        {
            Application.LoadLevel("YouWin");
        }
    }

    void SetScoreText()
    {
        scoreText.text = ":" + score.ToString();
    }

}
