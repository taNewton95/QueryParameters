﻿using QueryParameters.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryParameters.AspNetCore.Mvc.Parsers
{
    public interface ISortParser : IParser
    {

        SortElementExpression[] Parse(string sort);

    }
}
