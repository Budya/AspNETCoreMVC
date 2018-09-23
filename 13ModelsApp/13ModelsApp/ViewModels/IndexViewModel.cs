using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _13ModelsApp.Models;

namespace _13ModelsApp.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Phone> Phones { get; set; }
        public IEnumerable<CompanyModel> Companies { get; set; }
    }
}
