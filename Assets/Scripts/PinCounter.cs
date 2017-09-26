using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour
{
    public Text standingDisplay;

    private GameManager gameManager;
    private bool ballOutOfPlay = false;
    private int lastStandingCount = -1;
    private int lastSettledCount = 10;
    private float lastChangeTime;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start ()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
	}

    /// <summary>
    /// Update is called once per frame
    /// </summary>    
    void Update ()
    {
        standingDisplay.text = CountStanding().ToString();

        if (ballOutOfPlay)
        {
            UpdateStandingCountAndSettle();
            standingDisplay.color = Color.red;
        }
    }

    /// <summary>
    /// Resets the pin counter
    /// </summary>
    public void Reset()
    {
        lastSettledCount = 10;
    }

    /// <summary>
    /// Handles the ball leaving the lane
    /// </summary>
    /// <param name="other">The other object involved in the collision</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Ball")
        {
            ballOutOfPlay = true;
        }
    }

    /// <summary>
    /// Updates the standing count
    /// </summary>
    private void UpdateStandingCountAndSettle()
    {
        int currentStanding = CountStanding();

        if (currentStanding != lastStandingCount)
        {
            lastChangeTime = Time.time;

            lastStandingCount = currentStanding;
            return;
        }

        float settleThreshold = 3f; // How long to wait to consider pins settled

        if ((Time.time - lastChangeTime) > settleThreshold)  // If last change > 3 seconds ago
        {
            PinsHaveSettled();
        }
    }

    /// <summary>
    /// Provides a period of time for settling pins before resetting
    /// </summary>
    private void PinsHaveSettled()
    {
        int standing = CountStanding();
        int pinFall = lastSettledCount - standing;
        lastSettledCount = standing;

        gameManager.Bowl(pinFall);

        lastStandingCount = -1;     // Indicates that the pins have settled, and ball not back in box
        ballOutOfPlay = false;
        standingDisplay.color = Color.green;
    }

    /// <summary>
    /// Returns the number of standing pins
    /// </summary>
    /// <returns>Int</returns>
    private int CountStanding()
    {
        int standing = 0;

        foreach (Pin pin in GameObject.FindObjectsOfType<Pin>())
        {
            if (pin.IsStanding())
            {
                standing++;
            }
        }

        return standing;
    }
}
