using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game game;
        public GameFixture()
        {
            game = new Game();
        }

        private void rollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }

        private void rollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        private void rollStrike()
        {
            game.Roll(10);
        }

        [Fact]
        public void TestZeroPinGame()
        {
            rollMany(20, 0);
            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void TestOnePinGame()
        {
            rollMany(20, 1);
            Assert.Equal(20, game.GetScore());
        }

        [Fact]
        public void TestOneSpareGame()
        {
            game.Roll(6);
            game.Roll(4);
            rollMany(11, 10);
            Assert.Equal(290, game.GetScore());
        }

        [Fact]
        public void TestSpareAtLastFrameGame()
        {
            rollMany(18, 1);
            rollSpare();
            game.Roll(4);
            Assert.Equal(32, game.GetScore());
        }

        [Fact]
        public void TestAllSpareGame()
        {
            rollMany(21, 5);
            Assert.Equal(150, game.GetScore());
        }

        [Fact]
        public void TestOneStrikeGame()
        {
            rollStrike();
            rollMany(18, 1);
            Assert.Equal(30, game.GetScore());
        }

        [Fact]
        public void TestAllStrikeGame()
        {
            rollMany(12, 10);
            Assert.Equal(300, game.GetScore());
        }

        [Fact]
        public void TestStrikeAtLastFrameGame()
        {
            rollMany(18, 1);
            game.Roll(9);
            game.Roll(1);
            rollStrike();
            Assert.Equal(38, game.GetScore());
        }
    }
}

