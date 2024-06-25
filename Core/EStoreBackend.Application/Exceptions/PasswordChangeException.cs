namespace EStoreBackend.Application.Exceptions
{
    public class PasswordChangeException : Exception
    {
        public PasswordChangeException() : base("Şifre güncelleme işlemi başarısız.")
        {
        }

        public PasswordChangeException(string? message) : base(message)
        {
        }

        public PasswordChangeException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
