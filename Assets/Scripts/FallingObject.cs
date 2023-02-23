using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    float speed;
    public float positionChange;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        //GetComponent<Rigidbody2D>().velocity += new Vector2(0f, -speed);
    }

    private void Update()
    {
        positionChange += speed * Time.deltaTime;
        if (positionChange > 1)
        {
            transform.Translate(0, -1, 0);
            positionChange -= 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Catcher")
        {
            Destroy(gameObject);
        }
    }
}
