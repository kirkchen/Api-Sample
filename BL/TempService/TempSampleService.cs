using ApiSample.BL.Interfaces;
using ApiSample.DA.Interfaces;
using ApiSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.TempServices
{
    public class TempSampleService : ISampleService
    {
        public ISampleRepository SampleRepository { get; set; }        

        public TempSampleService(ISampleRepository sampleRepository)
        {
            this.SampleRepository = sampleRepository;
        }

        public IEnumerable<SampleModel> GetSamples()
        {
            return this.SampleRepository.GetSamples().Take(3);
        }
    }
}
