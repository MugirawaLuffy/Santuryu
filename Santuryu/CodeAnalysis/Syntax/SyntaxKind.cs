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
        ColonToken,
        CommaToken,
        IdentifierToken,

        //Keywords
        ElseKeyword,
        FalseKeyword,
        IfKeyword,
        TrueKeyword,
        LetKeyword,
        VarKeyword,
        WhileKeyword,
        DoKeyword,
        ForKeyword,
        ToKeyword,
        FunctionKeyword,

        //Nodes
        CompilationUnit,
        FunctionDeclaration,
        GlobalStatement,
        Parameter,
        TypeClause,
        ElseClause,

        //Statements
        BlockStatement,
        ExpressionStatement,
        IfStatement,
        VariableDeclaration,
        WhileStatement,
        DoWhileStatement,
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