namespace Santuryu.CodeAnalysis.Syntax
{
    public enum SyntaxKind
    {
        //tokens
        BreakKeyword,
        ContinueKeyword,
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
        ReturnKeyword,

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
        IfStatement,
        VariableDeclaration,
        WhileStatement,
        DoWhileStatement,
        ForStatement,
        BreakStatement,
        ContinueStatement,
        ReturnStatement,
        ExpressionStatement,

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