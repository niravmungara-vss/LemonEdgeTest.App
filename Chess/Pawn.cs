namespace LemonEdge.App.Chess
{
    /// <summary>
    /// Pawns - Aside from the opening move, pawns can only move one space forward per turn. In terms of capturing, 
    /// pawns are permitted to move one space forward diagonally to capture an opponent's piece.
    /// </summary>
    public class Pawn : ChessPiece
    {
        public override IEnumerable<Point> GetPossibleMoves(Point fromHere, ChessBoardSettings settings)
        {
            var possibleMoves = new List<Point>();

            if (settings.WhitePlayerToPlay!.Value)
            {
                //White pawn can move up one square at a time
                if (fromHere.Y > 0) possibleMoves.Add(fromHere with { Y = fromHere.Y - 1 });
            }
            else
            {
                //Black pawn can move down one square at a time
                if (fromHere.Y < settings.Height - 1) possibleMoves.Add(fromHere with { Y = fromHere.Y + 1 });
            }

            return possibleMoves.Distinct();
        }
    }
}
