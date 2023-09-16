using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public BirdScript bird;
    public LogicScript logic;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectsWithTag("Logic")[0].GetComponent<LogicScript>();
        bird = GameObject.FindGameObjectsWithTag("Player")[0].GetComponent<BirdScript>();
    }

    void Update()
    {

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            if (bird.birdIsAlive)
            {
                logic.AddScore(1);
            }

        }

    }
}
