using LemonEdge.App.Chess;
using LemonEdge.App.Keypad;
using LemonEdge.App.PhoneNumber;

namespace LemonEdge.App
{
    public class RecursiveDialer
    {
        private readonly IKeyPad _keypad;
        private readonly IPhoneNumberValidator _validator;
        private readonly ChessPiece _chessPiece;

        public List<string> ValidPhoneNumbers = new();
        public string CurrentPhoneNumber => string.Join("", _digits);

        private readonly List<char> _digits = new();
        private readonly ChessBoardSettings _chessBoardSettings;

        public RecursiveDialer(IKeyPad keypad, IPhoneNumberValidator validator, ChessPiece chessPiece, bool? whitePlayerToPlay = true)
        {
            _validator = validator;
            _chessPiece = chessPiece;
            _keypad = keypad;
            _chessBoardSettings = CreateChessBoardSettings(keypad, whitePlayerToPlay);
        }

        public void PressButton(int x, int y)
        {
            _digits.Add(_keypad.GetButton(x, y));
        }

        public void UnpressLastButton()
        {
            _digits.RemoveAt(_digits.Count - 1);
        }

        public void Dial(int x, int y)
        {
            PressButton(x, y);

            if (_validator.IsValid(CurrentPhoneNumber))
            {
                if (!ValidPhoneNumbers.Contains(CurrentPhoneNumber))
                {
                    ValidPhoneNumbers.Add(CurrentPhoneNumber);
                }
                UnpressLastButton();
                return;
            }

            if (_validator.ContainsInvalidCharacters(CurrentPhoneNumber))
            {
                UnpressLastButton();
                return;
            }

            if (_validator.BeginsWithInvalidCharacter(CurrentPhoneNumber))
            {
                UnpressLastButton();
                return;
            }

            if (CurrentPhoneNumber.Length < _validator.GetValidLength())
            {
                var possibleMoves = _chessPiece.GetPossibleMoves(new Point(x, y), _chessBoardSettings);
                foreach (var destination in possibleMoves)
                {
                    Dial(destination.X, destination.Y);
                }
            }

            UnpressLastButton();
        }

        private ChessBoardSettings CreateChessBoardSettings(IKeyPad keypad, bool? whitePlayerToPlay)
        {
            return new ChessBoardSettings(keypad.Width, keypad.Height, whitePlayerToPlay);
        }
    }
}
