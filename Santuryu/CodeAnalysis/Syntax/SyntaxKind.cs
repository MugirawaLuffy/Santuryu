namespace Santuryu.CodeAnalysis.Syntax
{
    public enum SyntaxKind
    {
        //tokens
        BadToken,
        EndOfFileToken,
        WhitespaceToken,
        NumberToken,
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        OpenParenthesisToken,
        CloseParenthesisToken,
        IdentifierToken,
        BangToken,
        AmpersandAmpersandToken,
        PipePipeToken,
        EqualsEqualsToken,
        BangEqualsToken,
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