using UnityEngine;
using System.Collections;

public class UserPartical : MonoBehaviour {

    public float moveSpeed = 10f;

    // Use this for initialization
    void Start () {
        Game.userPartical = this;
    }


    void Update()
    {
        handleInput();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Finish")
        {
            print("UserPartical.OnTriggerEnter --> Finish");
            Game.goToNextLevel();
        }
        else if(other.gameObject.tag == "electron")
        {
            print("UserPartical.OnTriggerEnter --> electron");
            Game.handleCollision();
        }
    }

    void handleInput()
    {
        Touch[] myTouches = Input.touches;
        for (int i = 0; i < Input.touchCount; i++)
        {
            //Do something with the touches
            Vector2 move = Input.GetTouch(i).deltaPosition;
            float x = move.x;
            float z = move.y;
            transform.Translate(new Vector3(x, 0, z) * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.N))
            {
                Game.goToNextLevel();
            }
    }

    public void toStartingPosition()
    {
        transform.position = new Vector3(-15, 0, 0);
    }
}
