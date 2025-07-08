public static class MysteryStack1 {
    public static bool Run(string text) {
        // Clean input: remove spaces and make lowercase
        var cleaned = new string(text.ToLower().Where(char.IsLetterOrDigit).ToArray());

        var stack = new Stack<char>();
        foreach (var letter in cleaned)
            stack.Push(letter);

        var reversed = "";
        while (stack.Count > 0)
            reversed += stack.Pop();

        return cleaned == reversed;
    }
}
