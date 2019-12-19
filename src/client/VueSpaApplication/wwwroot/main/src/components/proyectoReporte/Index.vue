<template>
    <div>
        <TitleBar :enableAddBtn="false" :enableBackBtn="false"/>
        <AppAlert/>
        <v-container>
            <v-layout>
                <v-flex>
                    <OptionPanel/>
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
    import OptionPanel from "./OptionPanel"

    export default {
        components: {
            InfoSnackbar,
            DataTable,
            TitleBar,
            AppAlert,
            DataInfo,
            OptionPanel
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
                        year: 0,
                        quarter: 0,
                        countries: 'all',
                        socios: 'all'
                    }
                },
                dataTableHeaders: [
                    {
                        text: 'Nombre Proyecto',
                        value: 'nombreProyecto',
                        align: 'start',
                        sortable: true,
                        filterable: true,
                        divider: false,
                        class: [],
                        width: '50%'
                    },
                    {
                        text: 'Estado',
                        value: 'estadoProyecto',
                        align: 'start',
                        sortable: true,
                        filterable: true,
                        divider: false,
                        class: [],
                        width: '25%'
                    },
                    {
                        text: 'Opciones',
                        value: 'action',
                        align: 'center',
                        sortable: false,
                        filterable: false,
                        divider: false,
                        class: [],
                        width: ''
                    }
                ],
                dataTableOptions: [
                    {
                        text: 'Generar reporte PDF',
                        type: 'info',
                        icon: 'mdi-file-pdf',
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
