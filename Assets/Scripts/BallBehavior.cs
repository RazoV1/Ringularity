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
    public Rigidbody2D rb;
    [SerializeField] private CarreteController carrete;

    private float curvaturePlane;

    public void SetCarrete(CarreteController carrete)
    {
        this.carrete = carrete;
    }
    public CarreteController GetCarrete()
    {
        return this.carrete;
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
        if (collision.collider.tag == "carrete")
        {
            carrete.HandleBallCollision(collision.contacts[0].point);
            UpdatePosition();
        }
		//UpdatePosition();
	}

	private void UpdatePosition()
    {
        //transform.position += (Vector3)currentDirection * currentSpeed * Time.deltaTime;
        rb.velocity = (Vector3)currentDirection * currentSpeed;
	}

}
