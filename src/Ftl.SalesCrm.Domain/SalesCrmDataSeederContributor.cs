using Ftl.SalesCrm.Contacts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Ftl.SalesCrm
{
    public class SalesCrmDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Contact, int> _contactRepository;

        public SalesCrmDataSeederContributor(IRepository<Contact, int> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _contactRepository.GetCountAsync() <= 0)
            {
                await _contactRepository.InsertAsync(
                    new Contact
                    {
                    Firstname = "John",
                    Lastname = "Doe",
                    Email = "jhondoe@gmail.com"
                    },
                    autoSave: true
                );

                await _contactRepository.InsertAsync(
                    new Contact
                    {
                        Firstname = "Juan",
                        Lastname = "Perez",
                        Email = "jperez@gmail.com"
                    },
                    autoSave: true
                );

            }
        }
    }
}