using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    int damage = 1000;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")

            FindObjectOfType<LevelManager>().RespawnPlayer();
    }*/
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<LevelManager>().RespawnPlayer();
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
    }
}