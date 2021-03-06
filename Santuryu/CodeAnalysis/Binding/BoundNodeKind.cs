namespace Santuryu.CodeAnalysis.Binding
{
    internal enum BoundNodeKind
    {
        //Statements
        BlockStatement,
        ExpressionStatement,
        //Expressions
        LiteralExpression,
        UnaryExpression,
        VariableExpression,
        AssignmentExpression,
        BinaryExpression,
    }
}