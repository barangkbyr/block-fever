namespace Assets.Extensions {
    public static class TextExtension {
        public static string StrikeThrough(this string text) {
            return $"<s>{text}</s>";
        }

        public static string StrikeThrough(this int number) {
            return number.ToString().StrikeThrough();
        }

        public static string Bold(this string text) {
            return $"<b>{text}</b>";
        }

        public static string Bold(this int number) {
            return number.ToString().Bold();
        }
    }
}