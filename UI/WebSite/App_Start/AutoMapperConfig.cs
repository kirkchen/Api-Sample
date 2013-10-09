using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;

namespace ApiSample.UI.WebSite
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            var profiles = DependencyResolver.Current.GetServices<Profile>();

            Mapper.Initialize(
                i =>
                {
                    foreach (var profile in profiles)
                    {
                        i.AddProfile(profile);
                    }
                }
            );
        }
    }
}