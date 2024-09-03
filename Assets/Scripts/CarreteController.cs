using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarreteController : MonoBehaviour
{
    [SerializeField] private float carreteSpeed;
    [SerializeField] private Transform circleTransform;
    [SerializeField] private BallBehavior ball;
    [SerializeField] private float curveReduction;

    private float horizontal;


	private void HandleInput()
    {
        horizontal = Input.GetAxis("Horizontal");
        //circleTransform.Rotate(new Vector3(0,0,horizontal * carreteSpeed * Time.deltaTime)); - староый контроль;
        transform.position += new Vector3(horizontal * carreteSpeed * Time.deltaTime, 0);
    }

    void Update()
    {
        HandleInput();
    }

    public void SetBallIndtance(GameObject ballInstance)
    {
        ball = ballInstance.GetComponent<BallBehavior>();
    }

    public void ResetBall()
    {
        Destroy(ball.gameObject);
        ball = null;
    }

    public void HandleBallCollision(Vector2 collisionPoint)
    {
        var pivotPoint = new Vector2(transform.position.x, transform.position.y - transform.localScale.y);
        var direction = (collisionPoint - pivotPoint).normalized;
        ball.currentDirection = direction;
        Debug.Log(carreteSpeed * horizontal);
        ball.currentSpeed = Mathf.Clamp(horizontal * carreteSpeed,ball.minBallSpeed,ball.maxBallSpeed);
    }
}
