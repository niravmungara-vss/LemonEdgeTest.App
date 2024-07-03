using LemonEdge.App.Chess;
using LemonEdge.App.Keypad;
using LemonEdge.App.PhoneNumber;
using LemonEdge.App;

var keypad = new StandardTelephoneKeypad();
var phoneNumberValidator = new PhoneNumberValidator();

Console.WriteLine("\nRook");
var rookCount = new ChessPieceCounter(keypad, phoneNumberValidator, new Rook()).GetCount();

Console.WriteLine("\nBishop");
var bishopCount = new ChessPieceCounter(keypad, phoneNumberValidator, new Bishop()).GetCount();

Console.WriteLine("\nKnight");
var knightCount = new ChessPieceCounter(keypad, phoneNumberValidator, new Knight()).GetCount();

Console.WriteLine("\nKing");
var kingCount = new ChessPieceCounter(keypad, phoneNumberValidator, new King()).GetCount();

Console.WriteLine("\nQueen");
var queenCount = new ChessPieceCounter(keypad, phoneNumberValidator, new Queen()).GetCount();

Console.WriteLine("\nWhite Pawn");
var whitePawn = new ChessPieceCounter(keypad, phoneNumberValidator, new Pawn()).GetCount();

Console.WriteLine("\nBlack Pawn");
var blackPawn = new ChessPieceCounter(keypad, phoneNumberValidator, new Pawn(), false).GetCount();

Console.WriteLine($"Rook count is {rookCount}");
Console.WriteLine($"Bishop count is {bishopCount}");
Console.WriteLine($"Knight count is {knightCount}");
Console.WriteLine($"King count is {kingCount}");
Console.WriteLine($"Queen count is {queenCount}");
Console.WriteLine($"White Pawn count is {whitePawn}");
Console.WriteLine($"Black Pawn count is {blackPawn}");

Console.WriteLine("Press any key to continue...");
Console.Read();
