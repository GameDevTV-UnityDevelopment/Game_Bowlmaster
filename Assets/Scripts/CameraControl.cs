using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Ball ball;

    private Vector3 offset;

    /// <summary>
    /// Use this for initialisation
    /// </summary>
	private void Start ()
    {
        offset = transform.position - ball.transform.position;
	}
	
	/// <summary>
    /// Update is called once per frame
    /// </summary>
	private void Update ()
    {
        // in front of head pin
        if (ball.transform.position.z <= 1829f)
        {
            transform.position = ball.transform.position + offset;
        }
	}
}