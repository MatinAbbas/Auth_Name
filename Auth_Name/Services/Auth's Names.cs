using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Rhino.Mocks.Constraints;
using System.Reflection;
namespace Auth_Name.Controllers


{

    public class Auth_s_Names
    {
        public void Find()
        {
            var Asembley = Assembly.GetAssembly(typeof(Program));
            var ControllersList = Asembley.GetTypes()
                .Where(type => typeof(Microsoft.AspNetCore.Mvc.Controller).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly))
                .Where(type => !type.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                .Where(type => type.GetCustomAttributes(typeof(Microsoft.AspNetCore.Authorization.AuthorizeAttribute),true).Any())

                .Select(type => new
                {
                    Controller = type.DeclaringType.Name,
                    Action = type.Name,
                    ReturnType = type.ReturnType.Name,
                    Attribute = string.Join(",", type.GetCustomAttributes()
                .Select(x => x.GetType().Name.Replace("Attributes", "")))
                })
                .OrderBy(type => type.Controller).ThenBy(type => type.Action).ToList();
                       
        }
    } 
}
