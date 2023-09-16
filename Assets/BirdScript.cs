using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectsWithTag("Logic")[0].GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {

        // Check if there are any active touches
        if (Input.touchCount > 0 && birdIsAlive)
        {
            // Loop through all active touches
            foreach (Touch touch in Input.touches)
            {
                // Check if the touch phase is "Began" (when the touch just started)
                if (touch.phase == TouchPhase.Began)
                {
                    // Apply upward velocity to the Rigidbody when the screen is touched
                    myRigidbody.velocity = Vector2.up * flapStrength;


                }
            }
        }


        if (transform.position.y > 14 || transform.position.y < -14)
        {
            logic.GameOver();
            birdIsAlive = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        logic.GameOver();
        birdIsAlive = false;

    }
}
