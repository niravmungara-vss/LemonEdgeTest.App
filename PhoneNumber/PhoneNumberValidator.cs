namespace LemonEdge.App.PhoneNumber
{
    public class PhoneNumberValidator : IPhoneNumberValidator
    {
        public bool IsValid(string phoneNumber)
        {
            if (phoneNumber.Length != GetValidLength()) return false;
            if (ContainsInvalidCharacters(phoneNumber)) return false;
            if (BeginsWithInvalidCharacter(phoneNumber)) return false;
            return true;
        }

        public bool ContainsInvalidCharacters(string phoneNumber)
        {
            //cannot contain a * or #
            var invalidCharacters = new[] { '*', '#' };
            foreach (var c in invalidCharacters)
            {
                if (phoneNumber.Contains(c)) return true;
            }
            return false;
        }

        public bool BeginsWithInvalidCharacter(string phoneNumber)
        {
            //cannot start with 0 or 1
            var invalidFirstCharacters = new[] { '0', '1' };
            foreach (var c in invalidFirstCharacters)
            {
                if (phoneNumber[0] == c) return true;
            }

            return false;
        }

        //seven digits in length
        public int GetValidLength() => 7;
    }
}
