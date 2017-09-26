using System.Collections.Generic;

public static class ScoreMaster
{
    /// <summary>
    /// Returns a list of cumulative scores, like a normal score card
    /// </summary>
    /// <param name="rolls">The rolls</param>
    /// <returns>List</returns>
    public static List<int> ScoreCumulative(List<int> rolls)
    {
        List<int> cumulativeScores = new List<int>();
        int runningTotal = 0;

        foreach (int frameScore in ScoreFrames(rolls))
        {
            runningTotal += frameScore;
            cumulativeScores.Add(runningTotal);
        }

        return cumulativeScores;
    }

    /// <summary>
    /// Returns a list of individual frame scores
    /// </summary>
    /// <param name="rolls">The rolls</param>
    /// <returns>List</returns>
    public static List<int> ScoreFrames(List<int> rolls)
    {
        List<int> frames = new List<int>();

        // index i points to second bowl of frame
        for (int i = 1; i < rolls.Count; i += 2)
        {
            if (frames.Count == 10)                             // prevents 11th frame score
            {
                break;
            }

            if (rolls[i - 1] + rolls[i] < 10)                   // this is a normal, open frame
            {
                frames.Add(rolls[i - 1] + rolls[i]);
            }

            if (rolls.Count - i <= 1)                           // ensure at least 1 look-ahead available
            {
                break;
            }

            if (rolls[i - 1] == 10)                             // strike
            {
                i--;                                            // strike frame has just one bowl
                frames.Add(10 + rolls[i + 1] + rolls[i + 2]);
            }
            else if (rolls[i - 1] + rolls[i] == 10)             // calculate spare bonus
            {
                frames.Add(10 + rolls[i + 1]);
            }
        }

        return frames;
    }
}
