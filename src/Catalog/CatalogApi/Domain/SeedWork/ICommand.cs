using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Domain.SeedWork
{
    public interface ICommand<T> : IRequest<T>
    {
    }
}
