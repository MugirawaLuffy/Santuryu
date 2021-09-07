namespace Santuryu.CodeAnalysis.Syntax
{
    public sealed class GlobalStatementSyntax : MemberSyntax
    {
        public GlobalStatementSyntax(StatementSyntax statement)
        {
            Statement = statement;
        }

        public override SyntaxKind Kind => SyntaxKind.GlobalStatement;
        public StatementSyntax Statement { get; }
    }

    public abstract class MemberSyntax : SyntaxNode
    {
    }

    public sealed class ParameterSyntax : SyntaxNode
    {
        public ParameterSyntax(SyntaxToken identifier, TypeClauseSyntax type)
        {
            Identifier = identifier;
            Type = type;
        }

        public override SyntaxKind Kind => SyntaxKind.Parameter;
        public SyntaxToken Identifier { get; }
        public TypeClauseSyntax Type { get; }
    }
} 