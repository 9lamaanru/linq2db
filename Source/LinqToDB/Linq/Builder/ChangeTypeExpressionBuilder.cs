﻿using System.Linq.Expressions;

using LinqToDB.Expressions;

namespace LinqToDB.Linq.Builder
{
	sealed class ChangeTypeExpressionBuilder : ISequenceBuilder
	{
		public int BuildCounter { get; set; }

		public bool CanBuild(ExpressionBuilder builder, BuildInfo buildInfo)
		{
			return buildInfo.Expression is ChangeTypeExpression;
		}

		ISequenceBuilder GetBuilder(ExpressionBuilder builder, BuildInfo buildInfo)
		{
			return builder.GetBuilder(buildInfo)!;
		}

		public IBuildContext? BuildSequence(ExpressionBuilder builder, BuildInfo buildInfo)
		{
			var expr = (ChangeTypeExpression)buildInfo.Expression;
			var info = new BuildInfo(buildInfo, expr.Expression);

			return GetBuilder(builder, info).BuildSequence(builder, info);
		}

		public SequenceConvertInfo? Convert(ExpressionBuilder builder, BuildInfo buildInfo, ParameterExpression? param)
		{
			return null;
		}

		public bool IsSequence(ExpressionBuilder builder, BuildInfo buildInfo)
		{
			var expr = (ChangeTypeExpression)buildInfo.Expression;
			var info = new BuildInfo(buildInfo, expr.Expression);

			return GetBuilder(builder, info).IsSequence(builder, info);
		}
	}
}
