using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{

    public float speed;

    public bool delayed;
    public float delay;

    public bool reversed;

    public bool slowed;
    public float slowMultiplier;

    void Update()
    {
        float direction = 0;
        if (Input.GetKey("a")) direction =-1;
        if (Input.GetKey("d")) direction = 1;

        if (reversed) direction *= -1;


        if (direction != 0)
        {
            if (delayed) StartCoroutine(DelayedMove(direction));

            else Move(direction);
        }
    }

    IEnumerator DelayedMove(float direction)
    {
        yield return new WaitForSeconds(delay);
        Move(direction);

    }

    void Move(float direction)
    {
        float movement = speed * Time.deltaTime;
        if (slowed) movement *= slowMultiplier;
        if (transform.position.x * direction < 24) transform.Translate(movement * direction, 0f, 0f);
    }
}
