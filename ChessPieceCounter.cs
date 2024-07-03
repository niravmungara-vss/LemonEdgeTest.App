using LemonEdge.App.Chess;
using LemonEdge.App.Keypad;
using LemonEdge.App.PhoneNumber;

namespace LemonEdge.App
{
    public class ChessPieceCounter
    {
        private readonly IKeyPad _keypad;
        private readonly IPhoneNumberValidator _validator;
        private readonly ChessPiece _chessPiece;
        private readonly bool? _whitePlayerToPlay;

        private int _validPhoneNumbersCount;

        public ChessPieceCounter(IKeyPad keypad, IPhoneNumberValidator validator, ChessPiece chessPiece, bool? whitePlayerToPlay = true)
        {
            _validator = validator;
            _chessPiece = chessPiece;
            _whitePlayerToPlay = whitePlayerToPlay;
            _keypad = keypad;
        }

        public int GetCount()
        {
            _validPhoneNumbersCount = 0;

            for (var x = 0; x < _keypad.Width; x++)
            {
                for (var y = 0; y < _keypad.Height; y++)
                {
                    var count = GetPhoneNumberCountStartingFromThisKeypadButton(x, y);
                    _validPhoneNumbersCount += count;
                    Console.WriteLine($"{count} valid phone numbers starting from {_keypad.GetButton(x, y)}");
                }
            }

            return _validPhoneNumbersCount;
        }

        private int GetPhoneNumberCountStartingFromThisKeypadButton(int x, int y)
        {
            var dialer = new RecursiveDialer(_keypad, _validator, _chessPiece, _whitePlayerToPlay);
            dialer.Dial(x, y);
            return dialer.ValidPhoneNumbers.Count;
        }
    }
}
