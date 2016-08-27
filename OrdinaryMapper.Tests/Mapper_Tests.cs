﻿using System;
using NUnit.Framework;
using OrdinaryMapper.Benchmarks;
using OrdinaryMapper.Benchmarks.Types;
using OrdinaryMapper.Tests.Tools;

namespace OrdinaryMapper.Tests
{
    public class Mapper_Tests
    {
        [Test]
        public void Mapper_MapSimpleReferenceTypes_Success()
        {
            Mapper mapper = new Mapper();
            mapper.CreateMap<Src, Dest>();
            mapper.Compile();

            var src = new Src();
            var dest = new Dest();

            mapper.Map(src, dest);

            var result = ObjectComparer.AreEqual(src, dest);

            Assert.IsTrue(result.Success);
        }

        [Test]
        public void Mapper_MapNestedReferenceTypes_Success()
        {
            Mapper mapper = new Mapper();
            mapper.CreateMap<NestedSrc, NestedDest>();
            mapper.Compile();

            var src = new NestedSrc();
            var dest = new NestedDest();

            mapper.Map(src, dest);

            var result = ObjectComparer.AreEqual(src, dest);

            result.Errors.ForEach(Console.WriteLine);
            Assert.IsTrue(result.Success);
        }
    }
}