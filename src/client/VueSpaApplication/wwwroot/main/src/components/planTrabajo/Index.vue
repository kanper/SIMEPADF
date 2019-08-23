<template>
    <div>
        <TitleBar :enableAddBtn="false"/>
        <AppAlert/>
        <v-container>
            <v-layout>
                <v-flex>
                    <DataTable :headers="dataTableHeaders" :options="dataTableOptions"/>
                </v-flex>
            </v-layout>
        </v-container>
        <DataInfo/>
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

    export default {
        components: {
            InfoSnackbar,
            DeleteDialog,
            DataTable,
            TitleBar,
            AppAlert,
            FormEdit,
            DataInfo
        },
        name: "plan-trabajo-index",
        data() {
            return {
                model: {
                    modelName: 'planTrabajo',                              //Nombre del modelo actual
                    modelIcon: 'mdi-drawing-box',    //Icono que se muestra en representación del modelo
                    modelTitle: 'Planes de trabajo',                            //Nombre que se muestra en representación del modelo
                    modelPath: '',                                      //URL que junto a la BASE es la ruta al servidor
                    modelService: 'planTrabajoService',                    //Nombre del servicio a utilizar
                    modelPK: 'proyectoId',                          //Llave primaria del modelo
                    modelStamp: 'nombreProyecto',                       //Valor único representativo del modelo
                    modelInfo: [                                        //Valores a mostrar para la información del modelo
                        {
                            name: 'Nombre proyecto',
                            value: 'nombreProyecto',
                            type: 'text'
                        },
                        {name: 'Plan de trabajo: fecha creación', value:'fecha', type:'date'}
                    ],
                    modelParams: {                                         //Parametros para el modelo
                    }
                },
                dataTableHeaders: [
                    {
                        text: 'Proyecto',   //Texto a mostrar en la cabecera de la columna
                        align: 'left',      //Alineación del contenido en la columna
                        value: 'nombreProyecto',    //Nombre del atributo que se colocara en la columna
                        width: '50%',       //Tamaño de la columna
                        type: 'text'        //Tipo del contenido a mostrar en la columna
                    },
                    {text: 'Monto original', align: 'center', value: 'montoOriginal', type: 'money'},
                    {text: 'Monto restante', align: 'center', value: 'montoRestante', type: 'money'},
                    {text: 'Plan trabajo', align: 'center', value: 'fecha', type: 'date'},
                    {text: 'Opciones', align: 'center', value: 'action', sortable: false, type: 'option'}
                ],
                dataTableOptions: [
                    {text: 'Crear plan de trabajo', type: 'link', icon: 'mdi-plus-circle-outline', action: 'create', class: 'mr-2', route: '', show: (row) => {return !row.isPlanTrabajo}},
                    {
                        text: 'Información',                //Texto que se muestra para el boton
                        type: 'info',                       //Tipo de boton [info|new|edit|delete|redirect]
                        icon: 'mdi-information-outline',    //Icono que se muestra para el boton
                        action: '',                         //Acción personalizada
                        class: 'mr-2',                      //Clase a agregar
                        route: '',
                        show: (row) => {return true}
                    },
                    {text: 'Editar', type: 'edit', icon: 'mdi-pencil', action: '', class: 'mr-2', route: '', show: (row) => {return row.isPlanTrabajo}},
                    {text: 'Eliminar', type: 'delete', icon: 'mdi-delete', action: '', route: '',class: 'mr-2', show: (row) => {return row.isPlanTrabajo}},
                    {text: 'Actividades', type: 'redirect', icon: 'mdi-puzzle', action: '', class: 'mr-3', route: 'plan-trabajo-actividad-index', show: (row) => {return row.isPlanTrabajo}}
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