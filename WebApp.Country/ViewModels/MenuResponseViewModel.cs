using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Country.ViewModels
{
    public class MenuResponseViewModel
    {
        public List<Contracts.Models.Feature> Features { get; set; }
        public Contracts.Models.User User { get; set; }
    }
}
