using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class SwordController : MonoBehaviour
{
    private bool isHeat;
    private Rigidbody2D rb;
    private float speed;

    private void Start()
    {
        isHeat = false;
        speed = 10f;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!isHeat)
        {
            rb.MovePosition(transform.position + transform.up * speed * Time.fixedDeltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Shield")
        {
            isHeat = true;
            transform.SetParent(col.transform);
            GameController.score++;
            GameController.currentSwordCount++;
            if (GameController.score > GameController.bestScore)
            {
                GameController.bestScore = GameController.score;
                PlayerPrefs.SetInt
                    (GameObject.Find("GameController").GetComponent<GameController>().BEST_SCORE_KEY, 
                    GameController.bestScore);
            }
        }
        if (col.gameObject.tag == "Sword")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
