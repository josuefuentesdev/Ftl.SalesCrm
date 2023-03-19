using Ftl.SalesCrm.Contacts;
using Ftl.SalesCrm.Lifecyclestages;
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
        private readonly IRepository<Lifecyclestage, Guid> _lifecycleRepository;

        public SalesCrmDataSeederContributor(IRepository<Contact, int> contactRepository, IRepository<Lifecyclestage, Guid> lifecycleRepository)
        {
            _contactRepository = contactRepository;
            _lifecycleRepository = lifecycleRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _lifecycleRepository.GetCountAsync() <= 0)
            {
                await _lifecycleRepository.InsertAsync(
                        new Lifecyclestage
                        {
                            Name = "Subscriber"
                        },
                        autoSave: true
                    );

                await _lifecycleRepository.InsertAsync(
                        new Lifecyclestage
                        {
                            Name = "Lead"
                        },
                        autoSave: true
                    );

                await _lifecycleRepository.InsertAsync(
                        new Lifecyclestage
                        {
                            Name = "Marketing Qualified Lead"
                        },
                        autoSave: true
                    );

                await _lifecycleRepository.InsertAsync(
                        new Lifecyclestage
                        {
                            Name = "Sales Qualified Lead"
                        },
                        autoSave: true
                    );

                await _lifecycleRepository.InsertAsync(
                        new Lifecyclestage
                        {
                            Name = "Opportunity"
                        },
                        autoSave: true
                    );

                await _lifecycleRepository.InsertAsync(
                        new Lifecyclestage
                        {
                            Name = "Customer"
                        },
                        autoSave: true
                    );

                await _lifecycleRepository.InsertAsync(
                        new Lifecyclestage
                        {
                            Name = "Evangelist"
                        },
                        autoSave: true
                    );

                await _lifecycleRepository.InsertAsync(
                        new Lifecyclestage
                        {
                            Name = "Other"
                        },
                        autoSave: true
                    );
            }

            if (await _contactRepository.GetCountAsync() <= 0)
            {
                var leadItem = await _lifecycleRepository.FirstOrDefaultAsync(x => x.Name == "Lead");

                await _contactRepository.InsertAsync(
                    new Contact
                    {
                        Firstname = "John",
                        Lastname = "Doe",
                        Email = "jhondoe@gmail.com",
                        LifecyclestageId = leadItem.Id,
                    },
                    autoSave: true
                );

                await _contactRepository.InsertAsync(
                    new Contact
                    {
                        Firstname = "Juan",
                        Lastname = "Perez",
                        Email = "jperez@gmail.com",
                        LifecyclestageId = leadItem.Id,
                    },
                    autoSave: true
                );

            }
        }
    }
}