using Audaz_Teste.Models;
using Audaz_Teste.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audaz_Teste.Controllers
{
    public class FareController
    {

        private OperatorService _operatorService;
        private FareService _fareService;


        public FareController()
        {
            _operatorService = new OperatorService();
            _fareService = new FareService();

        }

        public void CreateFare(Fare fare, string operatorCode)
        {
            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);

            if (selectedOperator == null)
            {
                var newOperator = new Operator { Id = Guid.NewGuid(), Code = operatorCode };
                _operatorService.Create(newOperator);
                selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            }

            fare.OperatorId = selectedOperator.Id;
            fare.Status = 1;
            fare.lastModifiedDate = DateTime.Now;

            var hasFare = _fareService.GetActiveFaresByOperator(fare);

            if (!hasFare)
                throw new Exception("Tarifa já registrada.");

            _fareService.Create(fare);

        }
        public List<Fare> GetAllFaresByOperator(string operatorCode)
        {
            var selectedOperator = _operatorService.GetOperatorByCode(operatorCode);
            if (operatorCode is null)
                throw new Exception("Operador não encontrado!");

            return _fareService.GetFaresByOperator(selectedOperator.Id); ;
        }
    }
}
