using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MLVSoft_Common.Business.Excel.PredicateBuilder
{
    public static class PredicateBuilder<T>
    {
        public static BinaryExpression Equal(Condition condition, ParameterExpression parameter)
        {
            return Expression.Equal(
                Expression.MakeMemberAccess(parameter, typeof(T).GetMember(condition.FieldName)[0]),
                Expression.Constant(condition.Value));
        }

        public static BinaryExpression NotEqual(Condition condition, ParameterExpression parameter)
        {
            return Expression.NotEqual(
                Expression.MakeMemberAccess(parameter, typeof(T).GetMember(condition.FieldName)[0]),
                Expression.Constant(condition.Value));
        }

        public static BinaryExpression GreaterThan(Condition condition, ParameterExpression parameter)
        {
            return Expression.GreaterThan(
                Expression.MakeMemberAccess(parameter, typeof(T).GetMember(condition.FieldName)[0]), 
                Expression.Constant(long.Parse(condition.Value.ToString())));
        }

        public static BinaryExpression LessThan(Condition condition, ParameterExpression parameter)
        {
            return Expression.LessThan(
                Expression.MakeMemberAccess(parameter, typeof(T).GetMember(condition.FieldName)[0]),
                Expression.Constant(long.Parse(condition.Value.ToString())));
        }

        public static Expression GetExpression(Condition condition, ParameterExpression parameter)
        {
            Expression result = null;

            switch (condition.Operation)
            {
                case Operation.Equal:
                    result = PredicateBuilder<T>.Equal(condition, parameter);
                    break;

                case Operation.NotEqual:
                    result = PredicateBuilder<T>.NotEqual(condition, parameter);
                    break;

                case Operation.GreaterThan:
                    result = PredicateBuilder<T>.GreaterThan(condition, parameter);
                    break;

                case Operation.LessThan:
                    result = PredicateBuilder<T>.LessThan(condition, parameter);
                    break;
            }

            return result;
        }

        public static Func<T, bool> BuildPredicateExpresions(List<Condition> conditions)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            Expression currentExpr = PredicateBuilder<T>.GetExpression(conditions.First(), parameter);
            Expression nextExpr = null;

            foreach (var condition in conditions.Skip(1))
            {
                nextExpr = PredicateBuilder<T>.GetExpression(condition, parameter);
                switch (condition.Operator)
                {
                    case Operator.And:
                        currentExpr = Expression.And(currentExpr, nextExpr);
                        break;
                    case Operator.Or:
                        currentExpr = Expression.Or(currentExpr, nextExpr);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return Expression.Lambda<Func<T, bool>>(currentExpr, parameter).Compile();
        }
    }
}