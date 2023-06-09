namespace ConsoleApp1;

public static class StringChecker
{
    private static readonly Dictionary<char, char> SymbolsPairs = new Dictionary<char, char>()
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' },
    };

    public static bool IsBalanced(string str)
    {
        var openingSymbolsStack = new Stack<char>();
        var isCurrentlyCommented = false;

        for (var i = 0; i < str.Length; i++)
        {
            var symbol = str[i];

            if (!isCurrentlyCommented)
            {
                if (IsOpeningComments(symbol, str, i))
                {
                    isCurrentlyCommented = true;
                    i++;
                }
                else if (IsOpeningSymbol(symbol))
                {
                    openingSymbolsStack.Push(symbol);
                }
                else if (IsClosingSymbol(symbol))
                {
                    if (IsOpeningStackEmpty(openingSymbolsStack) ||
                        !AreSymbolsMatching(openingSymbolsStack.Pop(), symbol))
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (IsClosingComments(symbol, str, i))
                {
                    isCurrentlyCommented = false;
                    i++;
                }
            }
        }

        return IsOpeningStackEmpty(openingSymbolsStack) && !isCurrentlyCommented;
    }


    private static bool IsOpeningSymbol(char symbol)
    {
        return SymbolsPairs.ContainsKey(symbol);
    }

    private static bool IsClosingSymbol(char symbol)
    {
        return SymbolsPairs.ContainsValue(symbol);
    }

    private static bool IsOpeningComments(char symbol, string str, int index)
    {
        return symbol.ToString() == "/" && index < str.Length - 1 && str.Substring(index + 1, 1) == "*";
    }

    private static bool IsClosingComments(char symbol, string str, int index)
    {
        return symbol.ToString() == "*" && index < str.Length - 1 && str.Substring(index + 1, 1) == "/";
    }

    private static bool IsOpeningStackEmpty(Stack<char> stack)
    {
        return stack.Count == 0;
    }

    private static bool AreSymbolsMatching(char opening, char closing)
    {
        return SymbolsPairs[opening] == closing;
    }
}