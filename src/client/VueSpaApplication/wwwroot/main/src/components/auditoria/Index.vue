<template>
    <div>
        <TitleBar :enableAddBtn="false" :enableBackBtn="false"/>
        <AppAlert/>
        <v-container>
            <v-layout>
                <v-flex>
                    <OptionPanel />
                    <DataTable :headers="dataTableHeaders" :options="dataTableOptions"/>
                </v-flex>
            </v-layout>
        </v-container>
        <DataInfo/>
        <InfoSnackbar/>
    </div>
</template>
<script>
    import {mapState, mapMutations} from 'vuex'
    import InfoSnackbar from '../common/SnackbarInfo'
    import TitleBar from '../common/NavbarTitle'
    import DataInfo from '../common/CardInfo'
    import AppAlert from '../common/Alert'
    import DataTable from '../common/DataTable'
    import Banner from '../common/BannerCard'
    import OptionPanel from "./OptionPanel";

    export default {
        components: {
            InfoSnackbar,
            DataTable,
            TitleBar,
            AppAlert,
            DataInfo,
            Banner,
            OptionPanel
        },
        name: "AuditoriaIndex",
        data() {
            return {
                model: {
                    modelName: 'auditoria',
                    modelIcon: 'mdi-account-search',
                    modelTitle: 'Auditoria',
                    modelService: 'auditoriaService',
                    modelPK: 'id',
                    modelStamp: 'nombreUsuario',
                    modelInfo: [

                    ],
                    modelParams: {
                        auditClass: 'all'
                    }
                },
                dataTableHeaders: [
                    {
                        text: 'Acción',
                        value: 'summary',
                        align: 'start',
                        sortable: true,
                        filterable: true,
                        divider: false,
                        class: [],
                        width: '50%'
                    },
                    {
                        text: 'Realizada Por',
                        value: 'byUser',
                        align: 'start',
                        sortable: true,
                        filterable: true,
                        divider: false,
                        class: [],
                        width: '25%'
                    },
                    {
                        text: 'Fecha',
                        value: 'auditAt',
                        align: 'start',
                        sortable: true,
                        filterable: true,
                        divider: false,
                        class: [],
                        width: '25%'
                    }
                ],
                dataTableOptions: [
                    {
                        text: 'Información',
                        type: 'info',
                        icon: 'mdi-information-outline',
                        color: '',
                        action: '',
                        class: 'mr-2',
                        route: '',
                        show: (row) => {
                            return true
                        },
                        disabled: false
                    },
                ],
            }
        },
        methods: {
            ...mapMutations(['defineModel', 'clearAlerts', 'emptyDataTable']),
        },
        created() {
            this.clearAlerts();
            this.defineModel(this.model);
        },
        destroyed() {
            this.emptyDataTable();
        }
    };
</script>
