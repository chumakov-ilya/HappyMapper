namespace AutoMapper.ConfigurationAPI.QueryableExtensions.Impl
{
    //public class ExpressionBasedResolverResultConverter : IExpressionResultConverter
    //{
    //    public ExpressionResolutionResult GetExpressionResolutionResult(
    //        ExpressionResolutionResult expressionResolutionResult, PropertyMap propertyMap)
    //    {
    //        return ExpressionResolutionResult(expressionResolutionResult, ((IMemberResolver) valueResolver).GetExpression);
    //    }

    //    private static ExpressionResolutionResult ExpressionResolutionResult(
    //        ExpressionResolutionResult expressionResolutionResult, LambdaExpression lambdaExpression)
    //    {
    //        var oldParameter = lambdaExpression.Parameters.Single();
    //        var newParameter = expressionResolutionResult.ResolutionExpression;
    //        var converter = new ParameterConversionVisitor(newParameter, oldParameter);

    //        Expression currentChild = converter.Visit(lambdaExpression.Body);
    //        Type currentChildType = currentChild.Type;

    //        return new ExpressionResolutionResult(currentChild, currentChildType);
    //    }

    //    public ExpressionResolutionResult GetExpressionResolutionResult(ExpressionResolutionResult expressionResolutionResult,
    //        ConstructorParameterMap propertyMap, IValueResolver valueResolver)
    //    {
    //        return ExpressionResolutionResult(expressionResolutionResult, null);
    //    }

    //    public bool CanGetExpressionResolutionResult(ExpressionResolutionResult expressionResolutionResult,
    //        IValueResolver valueResolver)
    //    {
    //        return valueResolver is IMemberResolver;
    //    }
    //}
}