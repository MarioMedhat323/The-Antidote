using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject Checkpoint;
    public Transform enemy;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void RespawnPlayer()
    {
        FindObjectOfType<Controller>().transform.position = Checkpoint.transform.position;
    }

    public void RespawnEnemy()
    {
        Instantiate(enemy, Checkpoint.transform.position, Checkpoint.transform.rotation);
    }
}