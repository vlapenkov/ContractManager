using Domain;
using Domain.Events;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ContractManager.EventHandlers
{
    public class BillObjectAddedEventHandler : INotificationHandler<BillObjectAddedEvent>
    {
        ContractsDbContext _db;
        public BillObjectAddedEventHandler(ContractsDbContext db)
        {
            _db = db;
        }
        public async Task Handle(BillObjectAddedEvent notification, CancellationToken cancellationToken)
        {
            //Console.WriteLine(notification.BillObject);
            _db.Add(new FakeEntity { Name = notification.BillObject.Name, ContractId = notification.Contract.Id });

        }
    }
}
