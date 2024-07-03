namespace LemonEdge.App.Chess
{
    public abstract class ChessPiece
    {
        public abstract IEnumerable<Point> GetPossibleMoves(Point fromHere, ChessBoardSettings settings);

        protected static bool IsValidPoint(ChessBoardSettings settings, int x, int y)
        {
            if (x < 0) return false;
            if (y < 0) return false;
            if (x >= settings.Width) return false;
            if (y >= settings.Height) return false;
            return true;
        }

        protected static void EvaluateAndAddMove(ChessBoardSettings settings, Point destination, List<Point> possibleMoves)
        {
            if (IsValidPoint(settings, destination.X, destination.Y)) possibleMoves.Add(destination);
        }
    }
}
