﻿using QueryParameters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QueryParameters.Handlers
{
    public class DefaultGreaterThanHandler : IFilterHandler
    {

        public Expression GetExpression<T>(FilterElementExpression filterElementExpression, ParameterExpression parameterExpression)
        {
            var propertyFieldExpression = ((IHandler)this).GetPropertyFieldExpression<T>(filterElementExpression.Identifier.Identifier, parameterExpression);
            return Expression.GreaterThan(propertyFieldExpression, Expression.Constant(filterElementExpression.Value.Value));
        }

    }
}
