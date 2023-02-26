using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    public Controller controller;
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
            Caught();
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bottom")
        {
            Missed();
            Destroy(gameObject);
        }
    }



    public virtual void Caught() {}    //This function is called when the object hits the catcher.

    public virtual void Missed() {} //This function is called when the object exits the screen without being caught.
}
