namespace Tennis
{
    class TennisGame : ITennisGame
    {
        private int _mScore1;
        private int _mScore2;
        private string _player1Name;
        private string _player2Name;

        public TennisGame(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _mScore1 += 1;
            else
                _mScore2 += 1;
        }

        public string GetScore()
        {
            var score = "";
            if (_mScore1 == _mScore2)
            {
                switch (_mScore1)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
            }
            else if (_mScore1 >= 4 || _mScore2 >= 4)
            {
                var minusResult = _mScore1 - _mScore2;
                switch (minusResult)
                {
                    case 1:
                        score = "Advantage player1";
                        break;
                    case -1:
                        score = "Advantage player2";
                        break;
                    default:
                    {
                        score = minusResult >= 2 ? "Win for player1" : "Win for player2";
                        break;
                    }
                }
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    int tempScore;
                    if (i == 1) tempScore = _mScore1;
                    else { score += "-"; tempScore = _mScore2; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }
    }
}

