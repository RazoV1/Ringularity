using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
	[SerializeField] private int hp;
	public float difficulty;

	public void OnCollisionEnter2D(Collision2D collision)
	{
		var ball = collision.gameObject.GetComponent<BallBehavior>();
		//var ballPosition = ball.transform.position;
		//if ()
		hp--;
		ball.rb.velocity*= difficulty;
		if (hp == 0)
		{
			Destroy(gameObject);
		}
	}
}
