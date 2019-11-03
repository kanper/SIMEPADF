<template>
    <v-tooltip bottom>
        <template v-slot:activator="{ on }">
            <v-icon :class="data.class" @click="doAction" v-on="on">{{data.icon}}</v-icon>
        </template>
        <span>{{data.text}}</span>
    </v-tooltip>
</template>

<script>
    import {mapActions, mapMutations, mapState} from 'vuex'

    export default {
        name: "data-table-option",
        props: ['data', 'modelId', 'model'],
        computed: {
            ...mapState(['services', 'CRUDModel', 'modelSpecification'])
        },
        methods: {
            ...mapMutations([
                'changeInfoDialogVisibility',
                'changeNewDialogVisibility',
                'changeEditDialogVisibility',
                'changeDeleteDialogVisibility',
                'changeConfirmationDialogVisibility',
                'changeExtraDialogVisibility',
                'closeAllDialogs',
                'setCRUDModel',
                'addAlert',
                'setTableRow',
                'setConfirmationId',
                'setConfirmationAction',
                'changeReviewLogListVisibility'
            ]),
            ...mapActions(['loadDataTable', 'loadReviewLogList']),
            loadModel(id) {
                this.services[this.modelSpecification.modelService].get(id, this.modelSpecification.modelParams)
                    .then(r => {
                        this.setCRUDModel(r.data);
                    })
                    .catch(e => {
                        this.showInfo(e.toString());
                    });
            },
            showInfoDialog(id) {
                this.loadModel(id);
                this.closeAllDialogs();
                this.changeInfoDialogVisibility();
            },
            showNewForm(id) {
                this.closeAllDialogs();
                this.showNewForm(id);
            },
            showEditForm(id) {
                this.loadModel(id);
                this.closeAllDialogs();
                this.changeEditDialogVisibility();
            },
            showDeleteConfirmation(id) {
                this.loadModel(id);
                this.closeAllDialogs();
                this.changeDeleteDialogVisibility();
            },
            showReviewLogList(id, status) {
                this.loadReviewLogList({id, status});
                this.closeAllDialogs();
                this.changeReviewLogListVisibility();
            },
            doAction() {
                switch (this.data.type) {
                    case 'info':
                        this.showInfoDialog(this.modelId);
                        break;
                    case 'edit':
                        this.showEditForm(this.modelId);
                        break;
                    case 'delete':
                        this.showDeleteConfirmation(this.modelId);
                        break;
                    case 'redirect':
                        this.$router.push({name: this.data.route, params: {id: this.modelId}});
                        break;
                    case 'link':
                        this.setConfirmationId(this.modelId);
                        this.setConfirmationAction(this.data.action);
                        this.changeConfirmationDialogVisibility();
                        break;
                    case 'new':

                        break;
                    case 'review-list':
                        this.showReviewLogList(this.modelId, this.model.estadoProyecto);
                        break;
                    case 'download':
                        this.services[this.modelSpecification.modelService].download(this.modelId);
                        break;
                    default:
                        console.error('Action type [' + this.data.type + '] invalid.');
                }
            }
        }
    }
</script>