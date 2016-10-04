using System;
using AutoMapper.ConfigurationAPI;

namespace OrdinaryMapper
{
    /// <summary>
    /// Re-branding to avoid AutoMapperConfigurationException.
    /// </summary>
    public class HappyMapperConfigurationException : Exception
    {
        public AutoMapperConfigurationException.TypeMapConfigErrors[] Errors { get; }
        public TypePair? Types { get; }
        public PropertyMap PropertyMap { get; set; }

        public HappyMapperConfigurationException(AutoMapperConfigurationException amce) : base(amce.Message, amce)
        {
            Errors = amce.Errors;
            Types = amce.Types;
            PropertyMap = amce.PropertyMap;
        }
    }
}