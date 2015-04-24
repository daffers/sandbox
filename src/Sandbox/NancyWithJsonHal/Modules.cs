using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using Nancy;

namespace NancyWithJsonHal
{
    public class RootModule : NancyModule
    {
        public RootModule()
        {
            Get["/"] = _ => { return "root"; };
        }

        
    }

    //a relation is an id which when included with a value is an embeded resource.
    //a relation can be a collection or a single thing, a collection it a type not an id
    //should be able to generate results and optionally have links embeded or not

    public class Resource
    {
        public List<Resource> Relations { get; set; }
    }
}