namespace RPSLS.Application.WinnerCalculations.Implementation
{
    public class WinnerCalculation : IWinnerCalculation
    {
        public string CalculateWinner(int player1, int player2)
        {
            var result =  (Math.Abs(player1 - player2) % 2)
            switch
            {
                0 => player1 == player2 ? -1 : new[] { player1, player2 }.Min(),
                1 => new[] { player1, player2 }.Max(),
                _ => throw new Exception()
            };

            return result == -1 ? "tie" : result == player1 ? "win" : "lose";
        }
    }
}
