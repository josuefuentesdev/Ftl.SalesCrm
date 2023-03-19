using Ftl.SalesCrm.Contacts;
using Ftl.SalesCrm.LeadStatuses;
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
        private readonly IRepository<LeadStatus, Guid> _leadstatusRepository;

        public SalesCrmDataSeederContributor(IRepository<Contact, int> contactRepository, IRepository<Lifecyclestage, Guid> lifecycleRepository, IRepository<LeadStatus, Guid> leadstatusRepository)
        {
            _contactRepository = contactRepository;
            _lifecycleRepository = lifecycleRepository;
            _leadstatusRepository = leadstatusRepository;
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

            if (await _leadstatusRepository.GetCountAsync() <= 0)
            {
                await _leadstatusRepository.InsertAsync(
                    new LeadStatus
                    {
                        Label = "New",
                        InternalValue = "NEW",
                    },
                    autoSave: true
                );

                await _leadstatusRepository.InsertAsync(
                    new LeadStatus
                    {
                        Label = "Open",
                        InternalValue = "OPEN",
                    },
                    autoSave: true
                );

                await _leadstatusRepository.InsertAsync(
                    new LeadStatus
                    {
                        Label = "In Progress",
                        InternalValue = "IN_PROGRESS",
                    },
                    autoSave: true
                );

                await _leadstatusRepository.InsertAsync(
                    new LeadStatus
                    {
                        Label = "Open Deal",
                        InternalValue = "OPEN_DEAL",
                    },
                    autoSave: true
                );

                await _leadstatusRepository.InsertAsync(
                    new LeadStatus
                    {
                        Label = "Unqualified",
                        InternalValue = "UNQUALIFIED",
                    },
                    autoSave: true
                );

                await _leadstatusRepository.InsertAsync(
                    new LeadStatus
                    {
                        Label = "Attempted to Contact",
                        InternalValue = "ATTEMPTED_TO_CONTACT",
                    },
                    autoSave: true
                );

                await _leadstatusRepository.InsertAsync(
                    new LeadStatus
                    {
                        Label = "Connected",
                        InternalValue = "CONNECTED",
                    },
                    autoSave: true
                );

                await _leadstatusRepository.InsertAsync(
                    new LeadStatus
                    {
                        Label = "Bad Timing",
                        InternalValue = "BAD_TIMING",
                    },
                    autoSave: true
                );
            }


            if (await _contactRepository.GetCountAsync() <= 0)
            {
                var startLifecyclestatus = await _lifecycleRepository.FirstOrDefaultAsync(x => x.Name == "Lead");
                var startLeadStatus = await _leadstatusRepository.FirstOrDefaultAsync(x => x.InternalValue == "NEW");

                await _contactRepository.InsertAsync(
                    new Contact
                    {
                        Firstname = "John",
                        Lastname = "Doe",
                        Email = "jhondoe@gmail.com",
                        LifecyclestageId = startLifecyclestatus.Id,
                        LeadstatusId = startLeadStatus.Id,
                    },
                    autoSave: true
                );

                await _contactRepository.InsertAsync(
                    new Contact
                    {
                        Firstname = "Juan",
                        Lastname = "Perez",
                        Email = "jperez@gmail.com",
                        LifecyclestageId = startLifecyclestatus.Id,
                        LeadstatusId = startLeadStatus.Id,
                    },
                    autoSave: true
                );

            }
        }
    }
}