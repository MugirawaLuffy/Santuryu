namespace Santuryu.CodeAnalysis.Syntax
{
    public enum SyntaxKind
    {
        //tokens
        BadToken,
        EndOfFileToken,
        WhitespaceToken,
        NumberToken,
        StringToken,
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        OpenParenthesisToken,
        CloseParenthesisToken,
        IdentifierToken,
        BangToken,
        TildeToken,
        HatToken,
        AmpersandToken,
        PipeToken,
        AmpersandAmpersandToken,
        PipePipeToken,
        EqualsEqualsToken,
        BangEqualsToken,
        LessToken,
        LessOrEqualsToken,
        GreaterToken,
        GreaterOrEqualsToken,
        EqualsToken,
        OpenBraceToken,
        CloseBraceToken,
        CommaToken,

        //Keywords
        ElseKeyword,
        FalseKeyword,
        IfKeyword,
        TrueKeyword,
        LetKeyword,
        VarKeyword,
        WhileKeyword,
        ForKeyword,
        ToKeyword,

        //Nodes
        CompilationUnit,
        ElseClause,

        //Statements
        BlockStatement,
        ExpressionStatement,
        IfStatement,
        VariableDeclaration,
        WhileStatement,
        ForStatement,

        //Expressions
        LiteralExpression,
        BinaryExpression,
        UnaryExpression,
        ParenthesizedExpression,
        NameExpression,
        AssignmentExpression,
        CallExpression,

    }
}