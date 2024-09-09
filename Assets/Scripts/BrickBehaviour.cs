using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBehaviour : MonoBehaviour
{
	[SerializeField] private int hp;
	[SerializeField] private int score;

	private GameManager gameManager;
	public float difficulty;

	public void Start()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	public void OnCollisionEnter2D(Collision2D collision)
	{
		var ball = collision.gameObject.GetComponent<BallBehavior>();
		//var ballPosition = ball.transform.position;
		//if ()
		hp--;
		ball.rb.velocity*= difficulty;
		if (hp == 0)
		{
			gameManager.score += score;
			gameManager.CheckHpUpdate();
			gameManager.UpdateViewModels();
			Destroy(gameObject);
		}
	}
}
