<template>
    <div>
        <TitleBar :enableAddBtn="false" :enableBackBtn="false"/>
        <AppAlert/>
        <v-container>
            <v-layout>
                <v-flex>
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

    export default {
        components: {
            InfoSnackbar,
            DataTable,
            TitleBar,
            AppAlert,
            DataInfo,
            Banner
        },
        name: "ProyectoReporteIndex",
        data() {
            return {
                model: {
                    modelName: 'proyectoReporte',
                    modelIcon: 'mdi-file-pdf-box',
                    modelTitle: 'Reportes',
                    modelService: 'proyectoReporteService',
                    modelPK: 'id',
                    modelStamp: 'nombreProyecto',
                    modelInfo: [

                    ],
                    modelParams: {
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
                        value: 'by',
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
