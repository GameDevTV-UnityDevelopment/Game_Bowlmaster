using UnityEngine;

public class Pin : MonoBehaviour
{
    public float standingThreshold = 3f;
    public float distToRaise = 40f;

    private Rigidbody rigidBody;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    private void Start ()
    {
        rigidBody = GetComponent<Rigidbody>();
	}

    /// <summary>
    /// Indicates whether the pin is standing or not
    /// </summary>
    /// <returns>Bool</returns>
    public bool IsStanding()
    {
        Vector3 rotationInEuler = transform.rotation.eulerAngles;

        float tiltInX = Mathf.Abs(270 - rotationInEuler.x);
        float tiltInZ = Mathf.Abs(rotationInEuler.z);

        if(tiltInX < standingThreshold && tiltInZ < standingThreshold)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Raises the pin
    /// </summary>
    public void RaiseIfStanding()
    {
        if (IsStanding())
        {
            rigidBody.useGravity = false;
            transform.Translate(new Vector3(0, distToRaise, 0), Space.World);
            transform.rotation = Quaternion.Euler(270f, 0f, 0f);
        }
    }

    /// <summary>
    /// Lowers the pin
    /// </summary>
    public void Lower()
    {
        if (IsStanding())
        {
            transform.Translate(new Vector3(0, -distToRaise, 0), Space.World);
            rigidBody.useGravity = true;
        }
    }
}
