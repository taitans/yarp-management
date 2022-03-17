(function ($) {

    var l = abp.localization.getResource("YarpManagement");

    var _proxyConfigAppService = window.taitans.yarpManagement.proxyConfig;

    var _createModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'YarpManagement/ProxyConfigs/CreateModal'
    });

    var _editModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'YarpManagement/ProxyConfigs/EditModal'
    });

    var _viewChangeHistoryModal = new abp.ModalManager({
        viewUrl: abp.appPath + 'YarpManagement/ProxyConfigs/ViewChangeHistoryModal',
   /*     scriptUrl: '/Pages/YarpManagement/ProxyConfigs/view-change-history-modal.js', //Lazy Load URL*/
    });

    var _dataTable = null;

    abp.ui.extensions.entityActions.get("yarpManagement.proxyConfig").addContributor(
        function (actionList) {
            return actionList.addManyTail(
                [
                    {
                        text: l('Edit'),
                        visible: abp.auth.isGranted('YarpManagement.ProxyConfigs.Update'),
                        action: function (data) {
                            _editModal.open({
                                id: data.record.id
                            });
                        }
                    },
                    {
                        text: l('ViewChangeHistory'),
                        visible: abp.auth.isGranted('YarpManagement.ProxyConfigs.ViewChangeHistory'),
                        action: function (data) {
                            _viewChangeHistoryModal.open({
                                name: data.record.name
                            })
                        }
                    },
                    {
                        text: l('Reload'),
                        visible: abp.auth.isGranted('YarpManagement.ProxyConfigs.Reload'),
                        confirmMessage: function (data) {
                            return l('ProxyConfigReloadConfirmationMessage', data.record.name);
                        },
                        action: function (data) {
                            _proxyConfigAppService
                                .reload(data.record.id)
                                .then(function () {
                                    _dataTable.ajax.reload();
                                    abp.notify.success(l('DisplayName:ReloadSuccessfully'));
                                });
                            //_tenantAppService
                            //    .applyDatabaseMigrations(data.record.id)
                            //    .then(function () {
                            //        abp.notify.info(l('ProxyConfigReloadConfirmationMessage'));
                            //    });
                        }
                    }
                ]
            );
        }
    );

    abp.ui.extensions.tableColumns.get("yarpManagement.proxyConfig").addContributor(
        function (columnList) {
            columnList.addManyTail(
                [
                    {
                        title: l("Actions"),
                        rowAction: {
                            items: abp.ui.extensions.entityActions.get("yarpManagement.proxyConfig").actions.toArray()
                        }
                    },
                    {
                        title: l("Name"),
                        data: "name"
                    },
                    {
                        title: l("Version"),
                        data: "version",
                        orderable: false
                    },
                ]
            );
        },
        0 //adds as the first contributor
    );


    $(function () {

        var _$wrapper = $('#ProxyConfigsWrapper');

        _dataTable = _$wrapper.find('table').DataTable(
            abp.libs.datatables.normalizeConfiguration({
                order: [[1, 'asc']],
                processing: true,
                paging: true,
                scrollX: true,
                serverSide: true,
                ajax: abp.libs.datatables.createAjax(_proxyConfigAppService.getList),
                columnDefs: abp.ui.extensions.tableColumns.get('yarpManagement.proxyConfig').columns.toArray(),
            })
        );

        _createModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _editModal.onResult(function () {
            _dataTable.ajax.reload();
        });

        _viewChangeHistoryModal.onClose(function () {
            window.location.reload();
        });

        _$wrapper.find('button[name=CreateProxyConfig]').click(function (e) {
            e.preventDefault();
            _createModal.open();
        });
    });

})(jQuery);