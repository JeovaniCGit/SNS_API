namespace SNS.Utilities
{
    public static class InputSanitization
    {
        public static string? FirstLetterToUpperCase(this string? input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return string.Join(" ", input.Split(' ')
                .Where(word => !string.IsNullOrWhiteSpace(word))
                .Select(word => char.ToUpper(word[0]) + word.Substring(1).ToLower()));
        }
    }
}
