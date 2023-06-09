using NUnit.Framework;

namespace ConsoleApp1;

public class UseCaseTests
{
    [Test]
    public void SimpleBalancedString()
    {
        const string input = "( { [ () [] ] } )";
        const bool expected = true;

        var result = StringChecker.IsBalanced(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void BalancedStringWithCharacters()
    {
        const string input = "(a{b[c(d)e[f]g]h}i)";
        const bool expected = true;

        var result = StringChecker.IsBalanced(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void UnbalancedString()
    {
        const string input = "( ]";
        const bool expected = false;

        var result = StringChecker.IsBalanced(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void SymbolsPairsButInWrongOrder()
    {
        const string input = ")(";
        const bool expected = false;

        var result = StringChecker.IsBalanced(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void SymbolsPairsButItsEntangle()
    {
        const string input = "( [ ) ]";
        const bool expected = false;

        var result = StringChecker.IsBalanced(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void SymbolsAreCommented()
    {
        const string input = "{ /* ) */ }";
        const bool expected = true;

        var result = StringChecker.IsBalanced(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void SymbolsArNotCorrectlyMatchAfterComments() // Old False Positive
    {
        const string input = "{ /* ) ( */ )}";
        const bool expected = false;

        var result = StringChecker.IsBalanced(input);
        Assert.AreEqual(expected, result);
    }
    
    [Test]
    public void MultipleSymbolsAreCommented()
    {
        const string input = "{ /*/ ) */ }";
        const bool expected = true;

        var result = StringChecker.IsBalanced(input);
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void WeirdString()
    {
        const string input = "X/**";
        const bool expected = false;

        var result = StringChecker.IsBalanced(input);
        Assert.AreEqual(expected, result);
    }
}

