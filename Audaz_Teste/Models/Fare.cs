using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audaz_Teste.Models
{
    public class Fare : IModel
    {
        public Guid Id { get; set; }
        public Guid OperatorId { get; set; }
        /// <summary>
        /// 1 Desativado
        /// --
        /// 2 Ativado
        /// </summary>
        public int Status { get; set; }
        public decimal Value { get; set; }
        public DateTime lastModifiedDate { get; set; }
    }
}
