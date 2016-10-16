using System;
using System.Collections.Generic;
using System.Reflection;

namespace HappyMapper.AutoMapper.ConfigurationAPI.Configuration.Conventions
{
    public interface IGetTypeInfoMembers
    {
        IEnumerable<MemberInfo> GetMemberInfos(TypeDetails typeInfo);
        IGetTypeInfoMembers AddCondition(Func<MemberInfo, bool> predicate);
    }
}