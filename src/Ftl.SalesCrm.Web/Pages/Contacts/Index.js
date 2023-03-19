$(function () {
    var l = abp.localization.getResource('SalesCrm');
    var createModal = new abp.ModalManager(abp.appPath + 'Contacts/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Contacts/EditModal');

    var dataTable = $('#ContactsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            pagging: true,
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(ftl.salesCrm.contacts.contact.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible: abp.auth.isGranted('SalesCrm.Contacts.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible: abp.auth.isGranted('SalesCrm.Contacts.Delete'),
                                    confirmMessage: function (data) {
                                        return l('ContactDeletionConfirmationMessage', data.record.name);
                                    },
                                    action: function (data) {
                                        ftl.salesCrm.contacts.contact
                                            .delete(data.record.id)
                                            .then(function () {
                                                abp.notify.info(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: l('LifecyclestageName'),
                    data: "lifecyclestageName"
                },
                {
                    title: l('LeadstatusLabel'),
                    data: "leadstatusLabel"
                },
                {
                    title: l('OwnerUserName'),
                    data: "ownerUserName"
                },
                {
                    title: l('Firstname'),
                    data: "firstname"
                },
                {
                    title: l('Lastname'),
                    data: "lastname"
                },
                {
                    title: l('Email'),
                    data: "email"
                },
                {
                    title: l('Phone'),
                    data: "phone"
                },
                {
                    title: l('Mobilephone'),
                    data: "mobilephone"
                },

            ]
        })
    );

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewContactButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});