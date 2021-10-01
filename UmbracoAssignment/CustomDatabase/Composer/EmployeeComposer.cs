using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Composing;
using UmbracoAssignment.CustomDatabase.Components;

namespace UmbracoAssignment.CustomDatabase
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class EmployeeComposer : ComponentComposer<EmployeeComponent>
    {
    }
}