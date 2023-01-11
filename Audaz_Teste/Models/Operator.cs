using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audaz_Teste.Models
{
    public class Operator : IModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }

    }
}
