namespace LemonEdge.App.Chess
{
    /// <summary>
    /// Queens - Queens are thought of as one of the most powerful pieces on the board thanks to their movement capabilities; 
    /// they can move any number of vacant squares in any direction, including diagonally.
    /// </summary>
    public class Queen : ChessPiece
    {
        public override IEnumerable<Point> GetPossibleMoves(Point fromHere, ChessBoardSettings settings)
        {
            var possibleMoves = new List<Point>();

            //Queen can move as a bishop
            possibleMoves.AddRange((new Bishop()).GetPossibleMoves(fromHere, settings));

            //Queen can move as a rook
            possibleMoves.AddRange((new Rook()).GetPossibleMoves(fromHere, settings));

            return possibleMoves.Distinct();
        }
    }
}
