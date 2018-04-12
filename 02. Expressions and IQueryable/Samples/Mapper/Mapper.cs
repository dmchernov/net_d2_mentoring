﻿using System;

namespace Mapper
{
    public class Mapper<TSource, TDestination>
    {
        private readonly Func<TSource, TDestination> _mapFunction;

        internal Mapper(Func<TSource, TDestination> mapFunction)
        {
            _mapFunction = mapFunction;
        }

        public TDestination Map(TSource source)
        {
            return _mapFunction(source);
        }
    }
}
