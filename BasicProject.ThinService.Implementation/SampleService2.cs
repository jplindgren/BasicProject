using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicProject.ThinService.Interface;

namespace BasicProject.ThinService.Implementation {
    public class SampleService2 : ISampleService2{
        private ISampleService sampleService;

        public SampleService2(ISampleService sampleService) {
            this.sampleService = sampleService;
        }

        public string Teste() {
            return sampleService.SampleService();
        }
    } //class
}
