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

        //Expressions
        LiteralExpression,
        UnaryExpression,
        VariableExpression,
        AssignmentExpression,
        BinaryExpression,
    }
}