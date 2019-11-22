<template>
    <div>
        <TitleBar :enableAddBtn="false" :enableBackBtn="true"/>
        <Banner color="grey" icon="mdi-clipboard-check" title="Proyecto" :text="bannerText"/>
        <AppAlert/>
        <v-container>
            <v-layout>
                <v-flex>
                    <DataTable :headers="dataTableHeaders" :options="dataTableOptions"/>
                </v-flex>
            </v-layout>
        </v-container>
        <DataInfo/>
        <FormNew/>
        <FormEdit/>
        <DeleteDialog/>
        <InfoSnackbar/>
    </div>
</template>
<script>
    import {mapState, mapMutations} from 'vuex'
    import InfoSnackbar from '../common/SnackbarInfo'
    import TitleBar from '../common/NavbarTitle'
    import DeleteDialog from '../common/DialogDelete'
    import FormEdit from './CardEdit'
    import DataInfo from '../common/CardInfo'
    import AppAlert from '../common/Alert'
    import DataTable from '../common/DataTable'
    import FormNew from './CardNew'
    import Banner from '../common/BannerCard'

    export default {
        components: {
            InfoSnackbar,
            DeleteDialog,
            DataTable,
            TitleBar,
            AppAlert,
            FormEdit,
            DataInfo,
            FormNew,
            Banner
        },
        name: "SeguimientoDesagregadosIndex",
        data() {
            return {
                model: {
                    modelName: 'proyectoSeguimiento',
                    modelIcon: 'mdi-flag-variant',
                    modelTitle: 'Seguimiento: Selección de indicador',
                    modelService: 'proyectoSeguimientoIndicadorService',
                    modelPK: 'id',
                    modelStamp: 'nombreIndicador',
                    modelInfo: [],
                    modelParams: {
                        id: this.$route.params.id
                    }
                },
                dataTableHeaders: [
                    {
                        text: 'Indicador',
                        value: 'nombreIndicador',
                        align: 'start',
                        sortable: true,
                        filterable: true,
                        divider: false,
                        class: [],
                        width: '25%'
                    },
                    {
                        text: 'Objetivo',
                        value: 'nombreObjetivo',
                        align: 'start',
                        sortable: true,
                        filterable: true,
                        divider: false,
                        class: [],
                        width: '25%'
                    },
                    {
                        text: 'Resultado',
                        value: 'nombreResultado',
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
                        text: 'Adminstrar seguimientos',
                        type: 'redirect',
                        icon: 'mdi-table-edit',
                        color: '',
                        action: '',
                        class: 'mr-2',
                        route: 'proyecto-seguimiento-registro',
                        show: (row) => {
                            return true
                        },
                        disabled: false
                    },
                ],
                bannerText: ''
            }
        },
        computed: {
            ...mapState(['services'])
        },
        methods: {
            ...mapMutations(['defineModel', 'clearAlerts', 'emptyDataTable']),
        },
        created() {
            this.clearAlerts();
            this.defineModel(this.model);
            this.services.simpleIdentificadorService.getProyecto(this.$route.params.id)
                .then(r => {
                    this.bannerText = r.data.nombre;
                })
                .catch(e => {
                    this.showInfo(e.toString());
                })
        },
        destroyed() {
            this.emptyDataTable();
        }
    };
</script>
