namespace LemonEdge.App.Chess
{
    /// <summary>
    /// Kings - With movements that are much more limited in scope, the King is simultaneously the most valuable and one of the weakest pieces on a chess board. 
    /// Kings can move one vacant square in any direction, including diagonally.
    /// </summary>
    public class King : ChessPiece
    {
        public override IEnumerable<Point> GetPossibleMoves(Point fromHere, ChessBoardSettings settings)
        {
            var possibleMoves = new List<Point>();

            //King can move one square in any direction
            EvaluateAndAddMove(settings, new Point(fromHere.X - 1, fromHere.Y - 1), possibleMoves);
            EvaluateAndAddMove(settings, new Point(fromHere.X, fromHere.Y - 1), possibleMoves);
            EvaluateAndAddMove(settings, new Point(fromHere.X + 1, fromHere.Y - 1), possibleMoves);
            EvaluateAndAddMove(settings, new Point(fromHere.X + 1, fromHere.Y), possibleMoves);
            EvaluateAndAddMove(settings, new Point(fromHere.X + 1, fromHere.Y + 1), possibleMoves);
            EvaluateAndAddMove(settings, new Point(fromHere.X, fromHere.Y + 1), possibleMoves);
            EvaluateAndAddMove(settings, new Point(fromHere.X - 1, fromHere.Y + 1), possibleMoves);
            EvaluateAndAddMove(settings, new Point(fromHere.X - 1, fromHere.Y), possibleMoves);

            return possibleMoves.Distinct();
        }
    }
}
