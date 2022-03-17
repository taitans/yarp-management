
var l = abp.localization.getResource("YarpManagement");

var _proxyConfigAppService = window.taitans.yarpManagement.proxyConfig;

var _dataTable = null;

var _valueModal = new abp.ModalManager(
    abp.appPath + 'YarpManagement/ProxyConfigs/ValueModal'
);

abp.ui.extensions.entityActions.get('yarpManagement.proxyConfig.history').addContributor(
    function (actionList) {
        return actionList.addManyTail(
            [
                {
                    text: l('Value'),
                    action: function (data) {
                        _valueModal.open({
                            id: data.record.id,
                        });
                    },
                },
                //{
                //    text: l('Permissions'),
                //    visible: function (data) { 
                //    },
                //    action: function (data) {

                //    },
                //},
            ]
        );
    }
);

abp.ui.extensions.tableColumns.get('yarpManagement.proxyConfig.history').addContributor(
    function (columnList) {
        columnList.addManyTail(
            [
                {
                    title: l("Actions"),
                    rowAction: {
                        items: abp.ui.extensions.entityActions.get("yarpManagement.proxyConfig.history").actions.toArray()
                    }
                },
                {
                    title: l("DisplayName:CreateTime"),
                    data: "createTime"
                },
                {
                    title: l("Version"),
                    data: "version",
                    orderable: false,
                    render: function (data, type, row) {
                        var name = '<span>' + $.fn.dataTable.render.text().display(data) + '</span>'; //prevent against possible XSS
                        if (row.isCurrent) {
                            name +=
                                '<span class="badge rounded-pill bg-danger ms-1">' +
                                l('DisplayName:IsCurrent') +
                                '</span>';
                        }

                        return name;
                    },
                },
            ]
        );
    },
    0 //adds as the first contributor
);

$(function () {
    _dataTable = $('#historys').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            processing: true,
            searching: false,
            paging: false,
            scrollX: true,
            serverSide: true,
            ajax: abp.libs.datatables.createAjax(_proxyConfigAppService.getHistoryList, { name: '@Model.HistoryInfoModel.Name' }),
            columnDefs: abp.ui.extensions.tableColumns.get('yarpManagement.proxyConfig.history').columns.toArray(),
        })
    );

    _valueModal.onResult(function () {
        _dataTable.ajax.reload();
    });

});