﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;

    // Start is called before the first frame update
    void Start() {
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(direction * speed * Time.deltaTime);
        if(transform.position.y<GameManager.bottomLeft.y + radius && direction.y < 0) {
            direction.y = -direction.y;
        }
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0) {
            direction.y = -direction.y;
        }
        
        // Game Over

        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0)
        {
            Debug.Log("Right wins");
            Time.timeScale = 0;
            enabled = false;
        }
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Left wins");
            Time.timeScale = 0;
            enabled = false;
        }
    }

    void restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Paddle") {
            bool isRight = other.GetComponent<Paddle>().isRight;

            // If hit right paddle while moving left, go right
            if (isRight == true && direction.x > 0){
                direction.x = -direction.x;
            }
            // If hit left paddle while moving right, go left
            if (isRight == false && direction.x < 0)
            {
                direction.x = -direction.x;
            }
        }
    }
}
