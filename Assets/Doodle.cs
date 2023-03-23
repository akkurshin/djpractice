using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Doodle : MonoBehaviour
{
    public static Doodle instance;
    float horizontal;
    public Rigidbody2D DoodleRigid;

    private float moveInput;
    private float speed = 10f;


    private float topScore = 0.0f;
    public Text scoreText;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }


    void FixedUpdate()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            horizontal = Input.acceleration.x;
        }

        if (Input.acceleration.x < 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.acceleration.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        moveInput = Input.GetAxis("Horizontal");
        DoodleRigid.velocity = new Vector2(moveInput * speed, DoodleRigid.velocity.y);

        //DoodleRigid.velocity = new Vector2(Input.acceleration.x * 10f, DoodleRigid.velocity.y);
    }

    private void Update()
    {
        if (Doodle.instance.DoodleRigid.velocity.y > 0 && transform.position.y > topScore)
        {
            topScore = transform.position.y;
        }
        scoreText.text = "Score:" + Mathf.Round(topScore).ToString();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "DeadZone")
        {
            SceneManager.LoadScene(1);
        }
    }

}