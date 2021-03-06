﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSearch.Common
{
    public class SearchResult<T> : IQueryable<T>
    {
        private readonly IQueryable<T> query;

        public SearchResult(IQueryable<T> query, IEnumerable<string> terms)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            if (terms == null)
            {
                throw new ArgumentNullException("terms");
            }

            this.query = query;
            this.Terms = terms;
        }

        public IEnumerable<string> Terms { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            return this.query.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.query.GetEnumerator();
        }

        public Type ElementType
        {
            get { return this.query.ElementType; }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return this.query.Expression; }
        }

        public IQueryProvider Provider
        {
            get { return this.query.Provider; }
        }
    }
}
