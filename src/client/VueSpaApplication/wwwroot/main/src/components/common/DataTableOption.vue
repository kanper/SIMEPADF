<template xmlns:v-slot="http://www.w3.org/1999/XSL/Transform">
    <v-tooltip bottom>
        <template v-slot:activator="{ on }">
            <v-icon :class="data.class" @click="doAction" v-on="on">{{data.icon}}</v-icon>
        </template>
        <span>{{data.text}}</span>
    </v-tooltip>
</template>

<script>
    import {mapMutations, mapState, mapActions} from 'vuex'

    export default {
        name: "data-table-option",
        props: ['data', 'modelId','model'],
        computed: {
            ...mapState(['services', 'CRUDModel', 'modelSpecification'])
        },
        methods: {
            ...mapMutations([
                'changeInfoDialogVisibility',
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
            ...mapActions(['loadDataTable','loadReviewLogList']),
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
            showExtraDialog(dialogId, row) {
                this.setTableRow(row);
                this.closeAllDialogs();
                this.changeExtraDialogVisibility(dialogId);
            },
            showReviewLogList(id, status) {
                this.loadReviewLogList({id,status});
                this.closeAllDialogs();
                this.changeReviewLogListVisibility();                
            },
            doAction() {
                switch (this.data.type) {
                    case 'info':
                        this.showInfoDialog(this.modelId);
                        break;
                    case 'new':
                        this.showExtraDialog(this.data.action, this.model);
                        break;
                    case 'edit':
                        this.showEditForm(this.modelId);
                        break;
                    case 'delete':
                        this.showDeleteConfirmation(this.modelId);
                        break;
                    case 'redirect':
                        this.$router.push({
                            name: this.data.route,
                            params: {
                                id: this.modelId
                            }
                        });
                        break;
                    case 'link':
                        this.setConfirmationId(this.modelId);
                        this.setConfirmationAction(this.data.action);
                        this.changeConfirmationDialogVisibility();
                        break;
                    case 'review-list':
                        this.showReviewLogList(this.modelId,"EN_PROCESO");
                        break;
                    default:
                        console.error('Action type [' + this.data.type + '] invalid.');
                }
            }
        }
    }
</script>

<style scoped>

</style>