using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{

    public float speed;

    public enum Mode
    {
        normal,
        delayed,
        reversed


    }

    public Mode mode;

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            case Mode.normal:
                Normal();
                break;
            case Mode.reversed:
                Reversed();
                break;
        }
    }

    void Normal()
    {
        if (Input.GetKey("a")) MoveLeft();
        if (Input.GetKey("d")) MoveRight();
    }

    void Reversed()
    {
        if (Input.GetKey("d")) MoveLeft();
        if (Input.GetKey("a")) MoveRight();

    }
    void MoveLeft()
    {
        float movement = speed * Time.deltaTime;
        if (transform.position.x > -24) transform.Translate(-movement, 0f, 0f);
    }
    void MoveRight()
    {
        float movement = speed * Time.deltaTime;
        if (transform.position.x < 24) transform.Translate(movement, 0f, 0f);
    }

}
