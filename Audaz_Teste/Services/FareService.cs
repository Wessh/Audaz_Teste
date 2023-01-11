using Audaz_Teste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Audaz_Teste.Services
{
    public class FareService
    {
        private Repository _repository = new Repository();

        public void Create(Fare fare)
        {
            _repository.Insert(fare);
        }

        public void Update(Fare fare)
        {
            _repository.Update(fare);
        }

        public Fare GetFareById(Guid fareId)
        {
            var fare = _repository.GetById<Fare>(fareId);
            return fare;
        }

        public List<Fare> GetFares()
        {
            var fares = _repository.GetAll<Fare>();
            return fares;
        }

        public List<Fare> GetFaresByOperator(Guid operatorId)
        {
            var fares = _repository.GetAll<Fare>().Where(result => result.OperatorId == operatorId);
            return fares.ToList();
        }

        public bool GetActiveFaresByOperator(Fare fare)
        {
            DateTime dateToCompare = DateTime.Now.AddMonths(-6);
            var activeFare = GetFares().FirstOrDefault(result => result.OperatorId == fare.OperatorId && result.Status == 1 && result.lastModifiedDate >= dateToCompare && result.Value == fare.Value);
            return activeFare is null;
        }
    }
}
