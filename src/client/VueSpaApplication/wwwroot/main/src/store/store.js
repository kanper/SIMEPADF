import Vue from 'vue'
import Vuex from 'vuex'
import services from './services'

Vue.use(Vuex);

export default new Vuex.Store({
    state: {
        services,
        development: false,
        drawer: false,
        modelTitle: '',
        modelSpecification: {},
        snackbarInformationVisible: false,
        snackbarInformationText: '',
        visibleNewDialog: false,
        visibleEditDialog: false,
        visibleDeleteDialog: false,
        visibleInfoDialog: false,
        visibleConfirmationDialog: false,
        visibleCellDialog: false,
        visibleRejectDialog: false,
        visibleProjectPdfDialog: false,
        visibleDisableCRUDDialog: false,
        confirmationId: 0,
        confirmationAction: '',
        CRUDModel: {},
        CRUDAvailable: false,
        dataTable: [],
        tableRow: {},
        alerts: [],
        reviewLogList: [],
        visibleReviewLogList: false,
        reviewLog: {},
        visibleReviewLog: false,
        isTableLoading: true,
        tableCellValue: '',
        optionPanelChecked: false,
        tracingData: [],
        notifications: [],
        isTracingDadaLoading: false,
        isNotificationLoading: true,
        optionPanelProperties: {},
        isUniqueEntity: true,
    },
    mutations: {
        setModelName: (state, name) => state.modelTitle = name,
        changeDrawer: (state) => state.drawer = !state.drawer,
        defineModel: (state, model) => state.modelSpecification = model,
        showInfo: (state, text) => {
            state.snackbarInformationText = text;
            state.snackbarInformationVisible = true;
        },
        closeInfo: (state) => state.snackbarInformationVisible = false,
        changeNewDialogVisibility: (state) => state.visibleNewDialog = !state.visibleNewDialog,
        changeEditDialogVisibility: (state) => state.visibleEditDialog = !state.visibleEditDialog,
        changeDeleteDialogVisibility: (state) => state.visibleDeleteDialog = !state.visibleDeleteDialog,
        changeInfoDialogVisibility: (state) => state.visibleInfoDialog = !state.visibleInfoDialog,
        changeConfirmationDialogVisibility: (state) => state.visibleConfirmationDialog = !state.visibleConfirmationDialog,
        changeReviewLogListVisibility: (state) => state.visibleReviewLogList = !state.visibleReviewLogList,
        changeReviewLogVisibility: (state) => state.visibleReviewLog = !state.visibleReviewLog,
        changeCellDialogVisibility: (state) => state.visibleCellDialog = !state.visibleCellDialog,
        changeOptionPanelCheck: (state) => state.optionPanelChecked = !state.optionPanelChecked,
        changeRejectDialogVisibility: (state) => state.visibleRejectDialog = !state.visibleRejectDialog,
        changeProjectPdfDialogVisibility: (state) => state.visibleProjectPdfDialog = !state.visibleProjectPdfDialog,
        changeTracingDataLoading: (state) => state.isTracingDadaLoading = !state.isTracingDadaLoading,
        changeDisableDialog: (state) => state.visibleDisableCRUDDialog = !state.visibleDisableCRUDDialog,
        stopNotificationLoading: (state) => state.isNotificationLoading = false,
        disableModelCRUD: (state) => state.CRUDAvailable = false,
        enableModelCRUD: (state) => state.CRUDAvailable = true,
        closeAllDialogs: (state) => {
            state.visibleNewDialog = false;
            state.visibleEditDialog = false;
            state.visibleDeleteDialog = false;
            state.visibleInfoDialog = false;
            state.visibleRejectDialog = false;
            state.visibleReviewLog = false;
            state.visibleReviewLogList = false;
            state.isUniqueEntity = true;
        },
        setCRUDModel: (state, model) => state.CRUDModel = model,
        updateDataTable: (state, dataAction) => state.dataTable = dataAction,
        addAlert: (state, alert) => state.alerts.push(alert),
        clearAlerts: (state) => {
            state.drawer = false;
            state.snackbarInformationVisible = false;
            state.alerts = [];
        },
        emptyDataTable: (state) => state.dataTable = [],
        setTableRow: (state, row) => state.tableRow = row,
        setConfirmationId: (state, id) => state.confirmationId = id,
        setConfirmationAction: (state, action) => state.confirmationAction = action,
        setReviewLogList: (state, data) => state.reviewLogList = data,
        setReviewLog: (state, data) => state.reviewLog = data,
        resetTableLoader: (state) => state.isTableLoading = true,
        stopTableLoading: (state) => state.isTableLoading = false,
        setTableCellValue: (state, newValue) => state.tableCellValue = newValue,
        setTracingData: (state, data) => state.tracingData = data,
        fillNotifications: (state, data) => state.notifications = data,
        setOptionPanelProperties: (state, properties) => state.optionPanelProperties = properties,
        setUniqueEntityStatus: (state, status) => state.isUniqueEntity = status,
    }
    ,
    actions: {
        loadDataTable: async function ({commit}) {
            services[this.state.modelSpecification.modelService].getAll(this.state.modelSpecification.modelParams)
                .then(r => {                    
                    commit('updateDataTable', r.data);
                })
                .catch(e => {
                    commit('showInfo', e.toString());
                })
                .finally(() => commit('stopTableLoading'));
        },
        loadReviewLogList: async function ({commit}, obj) {
            services.registroRevisionService.findAllReview(obj.id, obj.status)
                .then(r => {
                    commit('setReviewLogList', r.data);
                })
                .catch(e => {
                    commit('showInfo', e.toString);
                });
        },
        loadReviewLog: async function ({commit}, id, status, country) {
            services.registroRevisionService.findReview(id, status, country)
                .then(r => {
                    commit('setReviewLog', r.data);
                })
                .catch(e => {
                    commit('showInfo', e.toString);
                });
        },
        loadTracingTable: async function ({commit}, params) {
            services.seguimientoIndicadorService[params.tracing](params.start, params.end)
                .then(r => {
                    commit('setTracingData', r.data);
                })
                .catch(e => {
                    commit('showInfo', e.toString);
                })
                .finally(() => commit('changeTracingDataLoading'));
        },
        findAllNotifications: async function ({commit}, params) {
            services.alertaService.getAlerts(params.rol, params.country)
                .then(r => {
                    commit('fillNotifications', r.data);
                })
                .catch(e => {
                    commit('showInfo', e.toString);
                })
                .finally(() => commit('stopNotificationLoading'));
        },
        saveNotification: async function ({commit}, params) {
            services.alertaService.add(params)
                .then(r => {
                    commit('fillNotifications', r.data);
                })
                .catch(e => {
                    commit('showInfo', e.toString);
                })
        },
        validateNewEntity: async function ({commit}, params) {
            services.validationService.validateNew(params.entityName, params.identifier)
                .then(r => {
                    commit('setUniqueEntityStatus', r.data);
                })
                .catch(e => {
                    commit('showInfo', e.toString);
                })
        },
        validateEditEntity: async function ({commit}, params) {
            services.validationService.validateUpdate(params.entityName,params.id,params.identifier)
                .then(r => {
                    commit('setUniqueEntityStatus', r.data);
                })
                .catch(e => {
                    commit('showInfo', e.toString);
                })
        }
    }
})
