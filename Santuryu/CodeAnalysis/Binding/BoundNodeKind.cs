namespace Santuryu.CodeAnalysis.Binding
{
    internal enum BoundNodeKind
    {
        //Statements
        BlockStatement,
        ExpressionStatement,
        VariableDeclaration,
        IfStatement,
        WhileStatement,
        ForStatement,
        LabelStatement,
        GotoStatement,
        ConditionalGotoStatement,

        //Expressions
        ErrorExpression,
        LiteralExpression,
        UnaryExpression,
        VariableExpression,
        AssignmentExpression,
        BinaryExpression,
    }
}