using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float minBallSpeed;
    public float maxBallSpeed;
    public float currentSpeed  = 0;
    public Vector2 currentDirection;

    [SerializeField] private float curvatureAmount;
    [SerializeField] private CarreteController carrete;

    private float curvaturePlane;

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.collider.tag == "carrete")
        {
            carrete.HandleBallCollision(collision.contacts[0].point);
        }
	}

	private void Update()
	{
        UpdatePosition();
	}

	private void UpdatePosition()
    {
        transform.position += (Vector3)currentDirection * currentSpeed * Time.deltaTime;
    }

}
