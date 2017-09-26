using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    private List<int> rolls = new List<int>();

    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;

    /// <summary>
    /// Use this for initialization
    /// </summary>    
    private void Start ()
    {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball = GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();
	}

    /// <summary>
    /// Handles the bowling of a ball
    /// </summary>
    /// <param name="pinFall">The number of fallen pins</param>
    public void Bowl(int pinFall)
    {
        try
        {
            rolls.Add(pinFall);
            ball.Reset();

            pinSetter.PerformAction(ActionMaster.NextAction(rolls));
        }
        catch
        {
            Debug.LogWarning("Something went wrong in Bowl");
        }

        try
        {
            scoreDisplay.FillRolls(rolls);
            scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));
        }
        catch
        {
            Debug.LogWarning("FillRollCard errored");
        }
    }
}
