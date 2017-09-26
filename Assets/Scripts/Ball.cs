using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 launchVelocity;
    public bool inPlay = false;

    private Rigidbody rigidBody;
    private AudioSource audioSource;
    private Vector3 ballStartPos;

	/// <summary>
    /// Use this for intialisation
    /// </summary>
	void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.useGravity = false;

        ballStartPos = transform.position;
    }

    /// <summary>
    /// Launches the ball
    /// </summary>
    public void Launch(Vector3 velocity)
    {
        inPlay = true;

        rigidBody.useGravity = true;
        rigidBody.velocity = velocity;

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    /// <summary>
    /// Resets the ball's position on the lane
    /// </summary>
    public void Reset()
    {
        inPlay = false;
        transform.position = ballStartPos;
        transform.rotation = Quaternion.identity;
        rigidBody.velocity = Vector3.zero;
        rigidBody.angularVelocity = Vector3.zero;
        rigidBody.useGravity = false;
    }
}