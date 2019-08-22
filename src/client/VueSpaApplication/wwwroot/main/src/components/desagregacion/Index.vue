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
            FormNew
        },
        name: "desagregacion-index",
        data() {
            return {
                model: {
                    modelName: 'desagregacion',                              //Nombre del modelo actual
                    modelIcon: 'mdi-arrange-send-backward',                         //Icono que se muestra en representación del modelo
                    modelTitle: 'Desagregaciones',                       //Nombre que se muestra en representación del modelo
                    modelPath: '',                                        //URL que junto a la BASE es la ruta al servidor
                    modelService: 'desagregacionService',                    //Nombre del servicio a utilizar
                    modelPK: 'id',                                        //Llave primaria del modelo
                    modelStamp: 'nombreDesagregacion',                                 //Valor único representativo del modelo
                    modelInfo: [                                          //Valores a mostrar para la información del modelo
                        { name: 'Nombre', value: 'nombreDesagregacion', type: 'text'}
                    ],
                    modelParams: {                                         //Parametros para el modelo
                    }
                },
                dataTableHeaders: [
                    {
                        text: 'Nombre Desagregación',   //Texto a mostrar en la cabecera de la columna
                        align: 'left',      //Alineación del contenido en la columna
                        value: 'nombreDesagregacion',    //Nombre del atributo que se colocara en la columna
                        width: '75%',       //Tamaño de la columna
                        type: 'text'        //Tipo del contenido a mostrar en la columna
                    },
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
                        show: (row) => {return true}
                    },
                    {text: 'Editar', type: 'edit', icon: 'mdi-pencil', action: '', class: 'mr-2', route: '', show: (row) => {return true}},
                    {text: 'Eliminar', type: 'delete', icon: 'mdi-delete', action: '', class: 'mr-2', route: '', show: (row) => {return true}},
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