using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour
{
    public Text[] rollTexts, frameTexts;

    /// <summary>
    /// Displays the score for the specified rolls
    /// </summary>
    /// <param name="rolls">The rolls</param>
    public void FillRolls(List<int> rolls)
    {
        string scoresString = FormatRolls(rolls);

        for (int i = 0; i < scoresString.Length; i++)
        {
            rollTexts[i].text = scoresString[i].ToString();
        }
    }

    /// <summary>
    /// Displays the score for the specified frames
    /// </summary>
    /// <param name="frames">The frames</param>
    public void FillFrames(List<int> frames)
    {
        for (int i = 0; i < frames.Count; i++)
        {
            frameTexts[i].text = frames[i].ToString();
        }
    }

    /// <summary>
    /// Formats the scores from each roll as a string
    /// </summary>
    /// <param name="rolls">The rolls</param>
    /// <returns>String</returns>
    public static string FormatRolls(List<int> rolls)
    {
        string output = "";

        for(int i = 0; i < rolls.Count; i++)
        {
            int box = output.Length + 1;                                        // score box 1 to 21

            if(rolls[i] == 0)                                                   // always enter 0 as -
            {
                output += "-";
            }
            else if((box % 2 == 0 || box ==21) && rolls[i-1] + rolls[i] == 10)  // spare anywhere
            {
                output += "/";
            }
            else if (box >= 19 && rolls[i] == 10)                               // strike in frame 10
            {
                output += "X";
            }
            else if(rolls[i] == 10)                                             // strike in frame 1 to 9
            {
                output += "X ";
            }
            else
            {
                output += rolls[i].ToString();                                  // normal 1 to 9 bowl
            }
        }

        return output;
    }
}
