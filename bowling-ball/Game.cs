using System;

namespace BowlingBall
{
    public class Game
    {
        private int[] rolls = new int[21];
        private const int spareScore = 10;
        private const int strikeScore = 10;
        int currentRoll = 0;

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        public int GetScore()
        {
            try
            {
                int score = 0;
                int rollIndex = 0;
                StateType stateType;
                for (int frame = 0; frame < 10; frame++)
                {
                    stateType = GetStateType(rollIndex);
                    switch (stateType)
                    {
                        case StateType.Spare:
                            score = GetSpareScore(score, rollIndex, rolls);
                            rollIndex = rollIndex + 2;
                            break;
                        case StateType.Strike:
                            score = GetStrikeScore(score, rollIndex, rolls);
                            rollIndex++;
                            break;
                        case StateType.Invalid:
                            throw new InvalidOperationException();
                        case StateType.None:
                            score = GetNormalScore(score, rollIndex, rolls);
                            rollIndex = rollIndex + 2;
                            break;
                    }

                }
                return score;
            }
            catch(Exception ex)
            {
                throw new InvalidOperationException();
            }
        }

        #region private methods
        private StateType GetStateType(int rollIndex)
        {
            StateType stateType;
            if (rolls[rollIndex] + rolls[rollIndex + 1] == 10)
            {
                stateType = StateType.Spare;
            }
            else if (rolls[rollIndex] == 10)
            {
                stateType = StateType.Strike;
            }
            else if (rolls[rollIndex] + rolls[rollIndex + 1] > 10)
            {
                stateType = StateType.Invalid;
            }
            else
            {
                stateType = StateType.None;
            }
            return stateType;
        }

        private int GetSpareScore(int score,int rollIndex, int[] rolls)
        {
            score = score + spareScore + rolls[rollIndex + 2];
            return score;
        }
        private int GetStrikeScore(int score, int rollIndex, int[] rolls)
        {
            score = score + strikeScore + rolls[rollIndex + 1] + rolls[rollIndex + 2];
            return score;
        }
        private int GetNormalScore(int score, int rollIndex, int[] rolls)
        {
            score = score + rolls[rollIndex] + rolls[rollIndex + 1];
            return score;
        }
        #endregion 

    }
}

