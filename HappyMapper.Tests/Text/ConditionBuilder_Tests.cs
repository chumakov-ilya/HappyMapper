﻿using System;
using System.Linq.Expressions;
using HappyMapper.AutoMapper.ConfigurationAPI;
using HappyMapper.AutoMapper.ConfigurationAPI.Configuration;
using AutoMapper.Extended.Net4;
using HappyMapper.Text;
using NUnit.Framework;

namespace HappyMapper.Tests.Text
{
    public class ConditionBuilder_Tests
    {
        public class A { public int P1 { get; set; } }
        public class B { public int P1 { get; set; } }

        [Test]
        public void Condition_IsNotNull_PrintCode()
        {
            string srcFieldName = "x";
            string destFieldName = "y";

            var propertyMap = CreatePropertyMap<A, B>("P1", "P1");

            var context = new PropertyNameContext(propertyMap);
            var coder = new Recorder();

            Expression<Func<A, bool>> exp = src => src.P1 != 0;
            propertyMap.OriginalCondition = new OriginalStatement(exp);

            using (var condition = new ConditionPrinter(context, coder)) { }

            string template = coder.ToAssignment().RelativeTemplate.Replace(Environment.NewLine, "");

            Assert.AreEqual("if ({0}.P1 != 0){{}}", template);
        }

        [Test]
        public void Condition_IsNull_NoCodeAppears()
        {
            string srcFieldName = "x";
            string destFieldName = "y";

            var propertyMap = CreatePropertyMap<A, B>("P1", "P1");

            var context = new PropertyNameContext(propertyMap);
            var coder = new Recorder();

            using (var condition = new ConditionPrinter(context, coder)) { }

            Assert.IsNullOrEmpty(coder.ToAssignment().RelativeTemplate);
        }

        //migrate to PropertyMapFactory
        private static PropertyMap CreatePropertyMap<TSrc, TDest>(string srcPropertyName, string destPropertyName)
        {
            var factory = new TypeMapFactory();

            PropertyMap propertyMap = new PropertyMap(
                typeof (TDest).GetProperty(destPropertyName),
                factory.CreateTypeMap(typeof (TSrc), typeof (TDest),
                    new MapperConfigurationExpression()));

            propertyMap.ChainMembers(new[] {typeof (TSrc).GetProperty(srcPropertyName)});
            return propertyMap;
        }
    }
}