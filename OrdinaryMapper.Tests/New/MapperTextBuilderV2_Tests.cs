﻿using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace OrdinaryMapper.Tests.New
{
    public class MapperTextBuilderV2_Tests
    {
        [Test]
        public void CreateText_Simple()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<A, B>();
            });

            var typeMaps = config.TypeMaps;

            foreach (var kvp in typeMaps)
            {
                TypePair typePair = kvp.Key;
                TypeMap map = kvp.Value;

                string text = MapperTextBuilderV2.CreateText(map, typeMaps);
            }
        }
        [Test]
        public void CreateMapper_Nested()
        {
            var typeMaps = new Dictionary<TypePair, TypeMap>();
            CreateMap<A, B>(typeMaps);
            //CreateMap<NestedA, NestedB>(typeMaps);


            foreach (var kvp in typeMaps)
            {
                TypePair typePair = kvp.Key;
                TypeMap map = kvp.Value;

                var context = new MapContext(typePair.SrcType, typePair.DestType);

                string text = MapperTextBuilderV2.CreateText(map, typeMaps);
            }
        }

        public void CreateMap<TSrc, TDest>(Dictionary<TypePair, TypeMap> typeMaps)
        {
            var typePair = new TypePair(typeof(TSrc), typeof(TDest));

            TypeMap map;
            typeMaps.TryGetValue(typePair, out map);

            if (map == null) typeMaps.Add(typePair, new TypeMap(typePair, typeof(Action<TSrc, TDest>)));
        }

        public class A
        {
            public string Name { get; set; }
            public NestedA Child { get; set; }
        }

        public class NestedA
        {
            public int Id { get; set; }
        }

        public class B
        {
            public string Name { get; set; }
            public NestedB Child { get; set; }
        }

        public class NestedB
        {
            public int Id { get; set; }
        }
    }
}