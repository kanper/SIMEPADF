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
        confirmationId: 0,
        confirmationAction: '',
        CRUDModel: {},
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
        tracingData: null,
        notifications: []
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
        closeAllDialogs: (state) => {
            state.visibleNewDialog = false;
            state.visibleEditDialog = false;
            state.visibleDeleteDialog = false;
            state.visibleInfoDialog = false;
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
            services.seguimientoIndicadorService.seguimientoDesagregados(params.year, params.quarter)
                .then(r => {
                    commit('setTracingData', r.data);
                })
                .catch(e => {
                    commit('showInfo', e.toString);
                })
        },
        findAllNotifications: async function ({commit}, params) {
            services.alertaService.getAlerts(params.rol, params.country)
                .then(r => {
                    commit('fillNotifications', r.data);
                })
                .catch(e => {
                    commit('showInfo', e.toString);
                })
        },
        saveNotification: async function ({commit}, params) {
            services.alertaService.add(params)
                .then(r => {
                    commit('fillNotifications', r.data);
                })
                .catch(e => {
                    commit('showInfo', e.toString);
                })
        }
    }
})
