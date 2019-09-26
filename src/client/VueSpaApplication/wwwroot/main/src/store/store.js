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
        modelSpecification:{},
        snackbarInformationVisible: false,
        snackbarInformationText: '',
        visibleNewDialog: false,
        visibleEditDialog: false,
        visibleDeleteDialog: false,
        visibleInfoDialog: false,
        visibleConfirmationDialog: false,
        confirmationId: 0,
        confirmationAction: '',
        extraDialog: [
            {visible: false},
            {visible: false},
            {visible: false},
        ],
        CRUDModel: {},
        dataTable: [],
        tableRow: {},
        alerts: []
    },
    mutations: {
        setModelName(state, name) {
            state.modelTitle = name;
        },
        changeDrawer(state) {
            state.drawer = !state.drawer;
        },
        defineModel(state, model) {
            state.modelSpecification = model;
        },
        showInfo(state, text) {
            state.snackbarInformationText = text;
            state.snackbarInformationVisible = true;
        },
        closeInfo(state) {
            state.snackbarInformationVisible = false;
        },
        changeNewDialogVisibility(state) {
            state.visibleNewDialog = !state.visibleNewDialog;
        },
        changeEditDialogVisibility(state) {
            state.visibleEditDialog = !state.visibleEditDialog;
        },
        changeDeleteDialogVisibility(state) {
            state.visibleDeleteDialog = !state.visibleDeleteDialog;
        },
        changeInfoDialogVisibility(state) {
            state.visibleInfoDialog = !state.visibleInfoDialog;
        },
        changeExtraDialogVisibility(state, dialogId) {
            state.extraDialog[dialogId].visible = !state.extraDialog[dialogId].visible;
        },
        changeConfirmationDialogVisibility(state){
            state.visibleConfirmationDialog = !state.visibleConfirmationDialog;
        },
        closeAllDialogs(state) {
            state.visibleNewDialog = false;
            state.visibleEditDialog = false;
            state.visibleDeleteDialog = false;
            state.visibleInfoDialog = false;
        },
        setCRUDModel(state, model) {
            state.CRUDModel = model;
        },
        updateDataTable(state, dataAction) {
            this.state.dataTable = dataAction;
        },
        addAlert(state, alert) {
            state.alerts.push(alert);
        },
        clearAlerts(state) {
            state.drawer = false;
            state.snackbarInformationVisible = false;
            state.alerts = [];
        },
        emptyDataTable(state){
            state.dataTable = [];
        },
        setTableRow(state, row)
        {
            state.tableRow = row;
        },
        setConfirmationId(state, id){
            state.confirmationId = id;
        },
        setConfirmationAction(state, action){
            state.confirmationAction = action;
        }
    }
    ,
    actions: {
        loadDataTable: async function ({commit}) {
            services[this.state.modelSpecification.modelService].getAll(this.state.modelSpecification.modelParams)
                .then(r => {
                    commit('updateDataTable', r.data);
                })
                .catch(e => {
                    commit('showInfo', e.toString())
                });
        }
    }
})
