using ApiSample.BL.Interfaces;
using ApiSample.DA.Interfaces;
using ApiSample.DA.Repositories;
using ApiSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Services
{
    public class SampleService : ISampleService
    {
        public ISampleRepository SampleRepository { get; set; }

        public SampleService()
            : this(new SampleRepository())
        {
        }

        public SampleService(ISampleRepository sampleRepository)
        {
            this.SampleRepository = sampleRepository;
        }

        public IEnumerable<SampleModel> GetSamples()
        {
            return this.SampleRepository.GetSamples();
        }
    }
}
