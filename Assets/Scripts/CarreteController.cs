using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarreteController : MonoBehaviour
{
    [SerializeField] private float carreteSpeed;
    [SerializeField] private Transform circleTransform;
    [SerializeField] private BallBehavior ball;

    private float horizontal;


	private void HandleInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        circleTransform.Rotate(new Vector3(0,0,horizontal * carreteSpeed * Time.deltaTime));
    }

    void Update()
    {
        HandleInput();
    }

    public void HandleBallCollision(Vector2 collisionPoint)
    {
        var pivotPoint = (Vector2)transform.position;
        var direction = (collisionPoint - pivotPoint).normalized;
        ball.currentDirection = direction;
        Debug.Log(carreteSpeed * horizontal);
        ball.currentSpeed = Mathf.Clamp(horizontal * carreteSpeed,ball.minBallSpeed,ball.maxBallSpeed);
    }
}
