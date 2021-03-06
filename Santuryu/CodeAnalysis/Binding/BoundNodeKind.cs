namespace Santuryu.CodeAnalysis.Binding
{
    internal enum BoundNodeKind
    {
        //Statements
        BlockStatement,
        ExpressionStatement,
        VariableDeclaration,

        //Expressions
        LiteralExpression,
        UnaryExpression,
        VariableExpression,
        AssignmentExpression,
        BinaryExpression,
    }
}