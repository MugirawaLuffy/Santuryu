namespace Santuryu.CodeAnalysis
{
    public enum SyntaxKind
    {
        NumberToken,
        WhiteSpaceToken,
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        OpenParenthesisToken,
        CloseParenthesisToken,
        BadToken,
        EndOfFileToken,
        NumberExpression,
        BinaryExpression,
        ParenthesizedExpression
    }
}