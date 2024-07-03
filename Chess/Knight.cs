namespace LemonEdge.App.Chess
{
    /// <summary>
    /// Knights - Knights' movements are iconic because of their weird patterning; they can move in an 'L' shape in a 2-1 or 1-2 fashion. 
    /// Simply put, Knights can move either two spaces in any direction--save for diagonally--and then one space in any cardinal direction or one space in 
    /// any direction--save diagonally--and then two spaces in any cardinal direction. 
    /// They're also permitted to jump over occupied squares so long as it ends in a capture or on a vacant square.
    /// </summary>
    public class Knight : ChessPiece
    {
        public override IEnumerable<Point> GetPossibleMoves(Point fromHere, ChessBoardSettings settings)
        {
            var possibleMoves = new List<Point>();

            //Knight can move 2 left 1 up
            EvaluateAndAddMove(settings, new Point(fromHere.X - 2, fromHere.Y - 1), possibleMoves);
            //Knight can move 1 left 2 up
            EvaluateAndAddMove(settings, new Point(fromHere.X - 1, fromHere.Y - 2), possibleMoves);

            //Knight can move 2 right 1 up
            EvaluateAndAddMove(settings, new Point(fromHere.X + 2, fromHere.Y - 1), possibleMoves);
            //Knight can move 1 right 2 up
            EvaluateAndAddMove(settings, new Point(fromHere.X + 1, fromHere.Y - 2), possibleMoves);

            //Knight can move 2 left 1 down
            EvaluateAndAddMove(settings, new Point(fromHere.X - 2, fromHere.Y + 1), possibleMoves);
            //Knight can move 1 left 2 down 
            EvaluateAndAddMove(settings, new Point(fromHere.X - 1, fromHere.Y + 2), possibleMoves);

            //Knight can move 2 right 1 down
            EvaluateAndAddMove(settings, new Point(fromHere.X + 2, fromHere.Y + 1), possibleMoves);
            //Knight can move 1 right 2 down
            EvaluateAndAddMove(settings, new Point(fromHere.X + 1, fromHere.Y + 2), possibleMoves);

            return possibleMoves.Distinct();
        }
    }
}
