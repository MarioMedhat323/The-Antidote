using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
	public float speed;
	public int damage = 10;
	// Use this for initialization
	void Start () {
		Controller player;
		player = FindObjectOfType<Controller>();
        if (player.transform.localScale.x < 0)
        {
			speed = -speed;
			transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);

		}
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
	}
	/*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
			
			Destroy(other.gameObject);
			Destroy(this.gameObject);
		}
    }*/

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			FindObjectOfType<WalkingEnemy>().EnemyDamage(damage);
			Destroy(this.gameObject);
		}
	}
}
