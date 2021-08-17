
using System.Linq;
using System.Linq.Expressions;

namespace VRS_Eng_Manage_Tool.Business
{
    public class ReplaceParameterVisitor<TResult> : ExpressionVisitor
    {
        private readonly ParameterExpression parameter;
        private readonly Expression replacement;

        public ReplaceParameterVisitor(ParameterExpression parameter, Expression replacement)
        {
            this.parameter = parameter;
            this.replacement = replacement;
        }

        public Expression<TResult> Visit<T>(Expression<T> node)
        {
            var parameters = node.Parameters.Where(p => p != parameter);
            return Expression.Lambda<TResult>(Visit(node.Body), parameters);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return node == parameter ? replacement : base.VisitParameter(node);
        }
    }
}