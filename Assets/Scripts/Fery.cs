using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fery : MonoBehaviour
{
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.transform.tag == "ball")
		{
			collision.gameObject.GetComponent<BallBehavior>().GetCarrete().GetComponentInChildren<GameManager>().ResetBall();
		}
	}
}
