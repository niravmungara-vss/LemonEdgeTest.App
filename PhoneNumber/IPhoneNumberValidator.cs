namespace LemonEdge.App.PhoneNumber
{
    public interface IPhoneNumberValidator
    {
        public bool ContainsInvalidCharacters(string phoneNumber);

        public bool BeginsWithInvalidCharacter(string phoneNumber);

        public int GetValidLength();

        public bool IsValid(string phoneNumber);
    }
}
