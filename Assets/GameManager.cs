using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public Ball ball;
    public Paddle paddle;

    public static Vector2 topRight;
    public static Vector2 bottomLeft;

    GameObject[] menuObjects;

    // Start is called before the first frame update
    void Start() {
        Time.timeScale = 1;
        menuObjects = GameObject.FindGameObjectsWithTag("ShowOnMenu");
        hideMenu();
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        // Create ball
        Instantiate(ball);

        // Create the two paddles
        Paddle paddle1 = Instantiate(paddle) as Paddle;
        Paddle paddle2 = Instantiate(paddle) as Paddle;
        paddle1.Init(true);  // right
        paddle2.Init(false); // left

    }

    void Update()
    {
        //uses the esc button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Debug.Log("menu");
                Time.timeScale = 0;
                showMenu();
            }
            else if (Time.timeScale == 0)
            {
                Debug.Log("resume");
                Time.timeScale = 1;
                hideMenu();
            }
        }
    }

    public void restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void menuControl()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            showMenu();
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            hideMenu();
        }
    }

    public void showMenu()
    {
        foreach (GameObject obj in menuObjects)
        {
            obj.SetActive(true);
        }
    }

    //hides objects with ShowOnPause tag
    public void hideMenu()
    {
        foreach (GameObject obj in menuObjects)
        {
            obj.SetActive(false);
        }
    }

    public void exit()
    { 
        Time.timeScale = 0;
    }
}
