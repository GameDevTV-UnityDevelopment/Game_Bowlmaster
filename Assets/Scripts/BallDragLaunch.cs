using UnityEngine;

[RequireComponent (typeof(Ball))]
public class BallDragLaunch : MonoBehaviour {

    private Vector3 dragStart, dragEnd;
    private float startTime, endTime;

    private Ball ball;

    /// <summary>
    /// Use this for initialisation
    /// </summary>
	private void Start ()
    {
        ball = GetComponent<Ball>();
	}

    /// <summary>
    /// Moves the ball to the left or right
    /// </summary>
    /// <param name="amount"></param>
    public void MoveStart(float amount)
    {
        if (!ball.inPlay)
        {
            float xPos = Mathf.Clamp(ball.transform.position.x + amount, -50f, 50f);
            float yPos = ball.transform.position.y;
            float zPos = ball.transform.position.z;

            ball.transform.position = new Vector3(xPos, yPos, zPos);
        }
    }

    /// <summary>
    /// Capture time and position of drag start / mouse click
    /// </summary>
    public void DragStart()
    {
        if (!ball.inPlay)
        {
            dragStart = Input.mousePosition;
            startTime = Time.time;
        }
    }

    /// <summary>
    /// Launch the ball
    /// </summary>
    public void DragEnd()
    {
        if (!ball.inPlay)
        {
            dragEnd = Input.mousePosition;
            endTime = Time.time;

            float dragDuration = endTime - startTime;

            float launchSpeedX = (dragEnd.x - dragStart.x) / dragDuration;
            float launchSpeedZ = (dragEnd.y - dragStart.y) / dragDuration;

            Vector3 launchVelocity = new Vector3(launchSpeedX, 0f, launchSpeedZ);

            ball.Launch(launchVelocity);
        }
    }
}