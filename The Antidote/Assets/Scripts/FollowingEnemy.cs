using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowingEnemy : EnemyController
{
	private Controller player;
	public float speedtowardplayer;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<Controller>();
	}

	// Update is called once per frame
	void Update()
	{
		transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedtowardplayer * Time.deltaTime);
		if (player.transform.position.x < gameObject.transform.position.x && isFacingRight)
		{
			Flip();
		}
		if (player.transform.position.x > gameObject.transform.position.x && !isFacingRight)
		{
			Flip();
		}

	}
}

