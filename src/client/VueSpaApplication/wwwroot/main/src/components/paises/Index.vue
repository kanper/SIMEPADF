<template>
    <div>
        <TitleBar/>
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
        <DisableDialog/>
    </div>
</template>
<script>
    import {mapMutations} from 'vuex'
    import InfoSnackbar from '../common/SnackbarInfo'
    import TitleBar from '../common/NavbarTitle'
    import DeleteDialog from '../common/DialogDelete'
    import FormEdit from './CardEdit'
    import DataInfo from '../common/CardInfo'
    import AppAlert from '../common/Alert'
    import DataTable from '../common/DataTable'
    import FormNew from './CardNew'
    import DisableDialog from "../common/DisableDialog";

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
            DisableDialog
        },
        name: "PaisIndex",
        data() {
            return {
                model: {
                    modelName: 'pais',
                    modelIcon: 'mdi-map-marker-radius',
                    modelTitle: 'Paises',
                    modelService: 'paisService',
                    modelPK: 'id',
                    modelStamp: 'nombrePais',
                    modelInfo: [
                        {
                            name: 'Nombre Pais',
                            value: 'nombrePais',
                            type: 'text'
                        },
                        {
                            name: 'Siglas Pais',
                            value: 'siglaPais',
                            type: 'text'
                        }
                    ],
                    modelParams: {}
                },
                dataTableHeaders: [
                    {
                        text: 'Pais',
                        value: 'nombrePais',
                        align: 'start',
                        sortable: true,
                        filterable: true,
                        divider: false,
                        class: [],
                        width: '60%'
                    },
                    {
                        text: 'Siglas',
                        value: 'siglaPais',
                        align: 'start',
                        sortable: true,
                        filterable: true,
                        divider: false,
                        class: [],
                        width: ''
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
                    {
                        text: 'Editar',
                        type: 'edit',
                        icon: 'mdi-pencil',
                        color: '',
                        action: '',
                        class: 'mr-2',
                        route: '',
                        show: (row) => {
                            return true
                        },
                        disabled: false
                    },
                    {
                        text: 'Eliminar',
                        type: 'delete',
                        icon: 'mdi-delete',
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
