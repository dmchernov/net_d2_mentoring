using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ExpressionTree
{
    public class MyVisitor : ExpressionVisitor
    {
        private readonly IDictionary<string, object> _values;

        public MyVisitor(IDictionary<string, object> values)
        {
            _values = values;
        }

        public MyVisitor() : this(new Dictionary<string, object>()) { }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            ParameterExpression param = null;
            ConstantExpression constant = null;
            switch (node.NodeType)
            {
                case ExpressionType.Add:
                    if (node.Left.NodeType == ExpressionType.Parameter)
                    {
                        param = (ParameterExpression)node.Left;
                    }
                    else if (node.Left.NodeType == ExpressionType.Constant)
                    {
                        constant = (ConstantExpression)node.Left;
                    }

                    if (node.Right.NodeType == ExpressionType.Parameter)
                    {
                        param = (ParameterExpression)node.Right;
                    }
                    else if (node.Right.NodeType == ExpressionType.Constant)
                    {
                        constant = (ConstantExpression)node.Right;
                    }

                    if (param != null && constant != null && constant.Type == typeof(int) && (int)constant.Value == 1)
                    {
                        return Expression.Increment(param);
                    }
                    break;
                case ExpressionType.Subtract:
                    if (node.Left.NodeType == ExpressionType.Parameter)
                    {
                        param = (ParameterExpression)node.Left;
                    }
                    else if (node.Left.NodeType == ExpressionType.Constant)
                    {
                        constant = (ConstantExpression)node.Left;
                    }

                    if (node.Right.NodeType == ExpressionType.Parameter)
                    {
                        param = (ParameterExpression)node.Right;
                    }
                    else if (node.Right.NodeType == ExpressionType.Constant)
                    {
                        constant = (ConstantExpression)node.Right;
                    }

                    if (param != null && constant != null && constant.Type == typeof(int) && (int)constant.Value == 1)
                    {
                        return Expression.Decrement(param);
                    }
                    break;
            }

            return base.VisitBinary(node);
        }

        private bool _firstVisit = true;
        protected override Expression VisitParameter(ParameterExpression node)
        {
            if (!_firstVisit)
            {
                if (_values.ContainsKey(node.Name))
                    return VisitConstant(Expression.Constant(_values[node.Name]));
            }

            _firstVisit = false;
            var result = base.VisitParameter(node);
            return result;

        }

        public override Expression Visit(Expression node)
        {
            /*var pNode = node as ParameterExpression;
            if (pNode != null)
            {
                if (_values.ContainsKey(pNode.Name))
                    return Expression.Constant(_values[pNode.Name]);
            }*/
            return base.Visit(node);
        }

        protected override Expression VisitLambda<T>(Expression<T> node)
        {
            //var e = node.Body as LambdaExpression;
            //e.Parameters[0].
            //if (_values.ContainsKey(node.Name))
            //return Expression.Constant(_values[node.Name]);
            //return Expression.Constant(Expression.Lambda<Func<object>>(node).Compile().Invoke());
            //return VisitConstant(Expression.Constant(_values[node.Name]));

            //return Expression.Lambda<T>(Visit(node.Body), Expression.Parameter(typeof(string), "a"));
            var parameters = VisitAndConvert(node.Parameters, "VisitLambda");
            return base.VisitLambda(node);
        }

        protected override Expression VisitUnary(UnaryExpression node)
        {
            return base.VisitUnary(node);
        }
    }
}
