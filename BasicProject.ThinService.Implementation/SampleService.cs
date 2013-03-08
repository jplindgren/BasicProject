using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BasicProject.ThinService.Interface;

namespace BasicProject.ThinService.Implementation {
    public class SampleService : ISampleService{
        string ISampleService.SampleService() {
            return "Teste Spring";
        }
    } //end class
}
