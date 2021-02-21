namespace Santuryu.CodeAnalysis.Syntax
{
    public enum SyntaxKind
    {
        //tokens
        BadToken,
        EndOfFileToken,
        WhiteSpaceToken,
        NumberToken,
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        OpenParenthesisToken,
        CloseParenthesisToken,
        IdentifierToken,
        //Keywords
        FalseKeyword,
        TrueKeyword,
        //Expressions
        LiteralExpression,
        BinaryExpression,
        UnaryExpression,
        ParenthesizedExpression,



    }
}