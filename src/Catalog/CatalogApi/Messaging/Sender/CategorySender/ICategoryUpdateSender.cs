using CatalogApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi.Messaging.Sender.CategorySender
{
    public interface ICategoryUpdateSender
    {
        void SendCategory(Category category);
    }
}
