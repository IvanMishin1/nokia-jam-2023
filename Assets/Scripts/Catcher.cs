using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catcher : MonoBehaviour
{

    public float speed;

    // Update is called once per frame
    void Update()
    {
        float movement = speed * Time.deltaTime;

        if (Input.GetKey("a")) transform.Translate(-movement, 0f, 0f);

        if (Input.GetKey("d")) transform.Translate(movement, 0f, 0f);
    }
}
