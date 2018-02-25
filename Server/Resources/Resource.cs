namespace HomeKookd.Resources
{
    public static class ValidationResource
    {
        public static class FieldName
        {
            public const string Email = "Email";
            public const string PhoneNumber = "PhoneNumber";
        }

        public static class ErrorMessage
        {
            public const string DuplicateEmail = "Duplicate Email";
            public const string DuplicatePhoneNumber = "Duplicate Phone Number";
        }
    }
}
