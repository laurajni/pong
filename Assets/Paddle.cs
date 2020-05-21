using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {
    [SerializeField]
    float speed;

    float height;

    string input;
    public bool isRight;

    // Start is called before the first frame update
    void Start() {
        height = transform.localScale.y;
    }

    public void Init( bool isRightPaddle ) {
        isRight = isRightPaddle;
        Vector2 pos = Vector2.zero;

        if (isRightPaddle) { // place on right of screen
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x; // shift a bit to the left
                                                           // Vector2.right is a default vector with values 1, 0
                                                           // transform.localScale.x is the width of the paddle
            input = "PaddleRight";
        } else {           // place on left of screen
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;
            input = "PaddleLeft";
        }
        // Updates the paddle's position to whatever you want to set it to
        transform.position = pos;
        transform.name = input;
    }

    // Update is called once per frame
    void Update() {
        // GetAxis is a number btwn -1(down) to 1(up)
        float move = Input.GetAxis(input) * (Time.deltaTime * speed);
        if(transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0) {
            move = 0;
        }
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0) {
            move = 0;
        }
        transform.Translate(move * Vector2.up);
    }
}
