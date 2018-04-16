using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Mapper
{
	public class MappingGenerator
	{
		public Mapper<TSource, TDestination> Generate<TSource, TDestination>()
		{
			var mapFunction = CreateMapFunction<TSource, TDestination>();
			return new Mapper<TSource, TDestination>(mapFunction);
		}

		private Func<TSource, TTarget> CreateMapFunction<TSource, TTarget>()
		{
			return BuildMapAction<TSource, TTarget>().Compile();
		}

		private Expression<Func<TDestination>> CreateInstance<TDestination>()
		{
			return Expression.Lambda<Func<TDestination>>(Expression.New(typeof(TDestination)));
		}

		private Expression<Func<TSource, TTarget>> BuildMapAction<TSource, TTarget>()
		{
			var source = Expression.Parameter(typeof(TSource), "source");

			var statements = new List<Expression>();
			var createInstanceStatement = CreateInstance<TTarget>();
			var target = Expression.Constant(createInstanceStatement.Compile().Invoke(), typeof(TTarget));
			statements.Add(target);
			foreach (var propertyInfo in typeof(TSource).GetProperties())
			{
				var sourceProperty = Expression.Property(source, propertyInfo.Name);
				var targetPropertyInfo = typeof(TTarget).GetProperty(propertyInfo.Name);
				if (targetPropertyInfo != null && propertyInfo.PropertyType == targetPropertyInfo.PropertyType)
				{
					var targetProperty = Expression.Property(target, targetPropertyInfo.Name);
					Expression value = sourceProperty;
					Expression statement = Expression.Assign(targetProperty, value);

					if (!sourceProperty.Type.IsValueType || Nullable.GetUnderlyingType(sourceProperty.Type) != null)
					{
						var valueNotNull = Expression.NotEqual(sourceProperty, Expression.Constant(null, sourceProperty.Type));
						statement = Expression.IfThen(valueNotNull, statement);
					}
					statements.Add(statement);
				}
			}

			var returnTarget = Expression.Label(typeof(TTarget));
			var returnExpression = Expression.Return(returnTarget, target, typeof(TTarget));
			var returnLabel = Expression.Label(returnTarget, Expression.Default(typeof(TTarget)));

			var body = statements.Count == 1 ? statements[0] : Expression.Block(statements);
			if (!source.Type.IsValueType)
			{
				var sourceNotNull = Expression.NotEqual(source, Expression.Constant(null, source.Type));
				body = Expression.IfThen(sourceNotNull, body);
			}

			body = Expression.Block(body, returnExpression, returnLabel);

			if (body.CanReduce)
				body = body.ReduceAndCheck();

			body = body.ReduceExtensions();

			var lambda = Expression.Lambda<Func<TSource, TTarget>>(body, source);

			return lambda;
		}
	}
}
