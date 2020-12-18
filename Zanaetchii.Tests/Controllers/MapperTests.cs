using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Zanaetchii.Profiles;

namespace Zanaetchii.Tests.Controllers
{
    [TestClass]
    public class MapperTests
    {
        private static IMapper _mapper;

        public MapperTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MapingProfiles());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

    }
}
