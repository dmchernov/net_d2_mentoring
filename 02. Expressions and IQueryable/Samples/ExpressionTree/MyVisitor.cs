using System;
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

		protected override Expression VisitParameter(ParameterExpression node)
		{
			if (_values.ContainsKey(node.Name))
			{
				var valueType = _values[node.Name].GetType();
				if (valueType != node.Type)
					throw new ArgumentException("Mismatch between parameter types");

				var r = VisitConstant(Expression.Constant(_values[node.Name], valueType));
				return r;
			}

			return base.VisitParameter(node);
		}

		protected override Expression VisitLambda<T>(Expression<T> node)
		{
			if (_values.Keys.Count > 0)
			{
				if (_values.Keys.Count != node.Parameters.Count)
				{
					throw new InvalidOperationException("Mismatch between parameter count");
				}

				var result = Visit(node.Body);
				var lambda = Expression.Lambda(result);
				return lambda;
			}

			return base.VisitLambda(node);
		}
	}
}
