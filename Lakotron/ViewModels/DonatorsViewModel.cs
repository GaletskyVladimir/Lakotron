using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lakotron.ViewModels
{
    public class DonatorsViewModel
    {
        public IEnumerable<Donator> Donators { get; set; }
    }
}
