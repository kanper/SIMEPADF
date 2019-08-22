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
        <FormNew />
        <FormEdit />
        <DeleteDialog/>
        <InfoSnackbar/>
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
        },
        name: "objetivo-index",
        data() {
            return {
                model: {
                    modelName: 'proyecto',                              //Nombre del modelo actual
                    modelIcon: 'mdi-briefcase',                         //Icono que se muestra en representación del modelo
                    modelTitle: 'Proyectos',                            //Nombre que se muestra en representación del modelo
                    modelPath: '',                                      //URL que junto a la BASE es la ruta al servidor
                    modelService: 'proyectoService',                    //Nombre del servicio a utilizar
                    modelPK: 'id',                                      //Llave primaria del modelo
                    modelStamp: 'nombreProyecto',                       //Valor único representativo del modelo
                    modelInfo: [                                        //Valores a mostrar para la información del modelo
                        {
                            name: 'Nombre proyecto',
                            value: 'nombreProyecto',
                            type: 'text'
                        },
                        { name: 'Estado', value: 'estadoProyecto',type: 'text'},
                        { name: 'Fecha Aprobación', value: 'fechaAprobacion', type: 'date'},
                        { name: 'Fecha Inicio', value: 'fechaInicio', type: 'date'},
                        { name: 'Fecha Fin', value: 'fechaFin', type: 'date'},
                        { name: 'Beneficiarios', value: 'beneficiarios', type: 'number'},
                        { name: 'Monto proyecto', value: 'montoProyecto', type: 'money'},
                        { name: 'Paises', value: 'paises', type: 'array'},
                        { name: 'Socios internacionales', value: 'socios', type: 'array'},
                        { name: 'Organizaciones', value: 'organizaciones', type: 'array'},
                    ],
                    modelParams: {                                         //Parametros para el modelo

                    }
                },
                dataTableHeaders: [
                    {
                        text: 'Nombre',                      //Texto a mostrar en la cabecera de la columna
                        align: 'left',                       //Alineación del contenido en la columna
                        value: 'nombreProyecto',             //Nombre del atributo que se colocara en la columna
                        width: '35%',                        //Tamaño de la columna
                        type: 'text'                         //Tipo del contenido a mostrar en la columna
                    },
                    {text: 'Estado', align: 'center', value: 'estadoProyecto', type: 'text'},
                    {text: 'Aprobación', align: 'center', value: 'fechaAprobacion', type: 'date'},
                    {text: 'Inicio', align: 'center', value: 'fechaInicio', type: 'date'},
                    {text: 'Final', align: 'center', value: 'fechaFin', type: 'date'},
                    {text: 'Opciones', align: 'center', value: 'action', sortable: false, type: 'option'}
                ],
                dataTableOptions: [
                    {
                        text: 'Información',                //Texto que se muestra para el boton
                        type: 'info',                       //Tipo de boton [info|new|edit|delete|redirect]
                        icon: 'mdi-information-outline',    //Icono que se muestra para el boton
                        action: '',                         //Acción personalizada
                        class: 'mr-2',                      //Clase a agregar
                        route: '',
                        show: (row) => {return true},       //Mostrar opción sí
                    },
                    {text: 'Editar', type: 'edit', icon: 'mdi-pencil', action: '', class: 'mr-2', route: '', show: (row) => {return true}},
                    {text: 'Indicadores', type: 'redirect', icon: 'mdi-flag-triangle', action: '', class: 'mr-2', route: 'plan-index', show: (row) => {return true}},
                    {text: 'Activar proyecto', type: 'link', icon: 'mdi-checkbox-marked-circle-outline', action: 'active', class: 'mr-2', route: '', show: (row) => {return row.isIncomplete}},
                    {text: 'Cancelar proyecto', type: 'link', icon: 'mdi-close-circle-outline', action: 'cancel', class: 'mr-2', route: '', show: (row) => {return !row.isCancelled}},
                    {text: 'Eliminar', type: 'delete', icon: 'mdi-delete', action: '', class: 'mr-2', route: '', show: (row) => {return row.isCancelled}}
                ],
            }
        },
        methods: {
            ...mapMutations(['defineModel','clearAlerts','emptyDataTable']),
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