using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryParameters.Entities
{
    public class SortElementCollection : IEnumerable<SortElementExpression>
    {

        private readonly List<SortElementExpression> ChildElements = new();

        public IEnumerator<SortElementExpression> GetEnumerator()
        {
            return ChildElements?.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ChildElements?.GetEnumerator();
        }

    }
}
