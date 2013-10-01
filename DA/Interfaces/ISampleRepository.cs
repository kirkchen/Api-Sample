using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSample.Models;

namespace ApiSample.DA.Interfaces
{
    public interface ISampleRepository
    {
        IEnumerable<SampleModel> GetSamples();
    }
}
