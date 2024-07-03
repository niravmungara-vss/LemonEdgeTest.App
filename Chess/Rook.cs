namespace LemonEdge.App.Chess
{
    /// <summary>
    /// Rooks - Rooks are allowed to move any number of vacant spaces in any direction except for diagonally.
    /// </summary>
    public class Rook : ChessPiece
    {
        public override IEnumerable<Point> GetPossibleMoves(Point fromHere, ChessBoardSettings settings)
        {
            var possibleMoves = new List<Point>();

            //Rook can move left
            for (var i = fromHere.X - 1; i >= 0; i--)
            {
                possibleMoves.Add(fromHere with { X = i });
            }

            //Rook can move right
            for (var i = fromHere.X + 1; i < settings.Width; i++)
            {
                possibleMoves.Add(fromHere with { X = i });
            }

            //Rook can move up
            for (var i = fromHere.Y - 1; i >= 0; i--)
            {
                possibleMoves.Add(fromHere with { Y = i });
            }

            //Rook can move down
            for (var i = fromHere.Y + 1; i < settings.Height; i++)
            {
                possibleMoves.Add(fromHere with { Y = i });
            }

            return possibleMoves.Distinct();
        }
    }
}
