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
        name: "usuario-index",
        data() {
            return {
                model: {
                    modelName: 'usuario',                              //Nombre del modelo actual
                    modelIcon: 'mdi-account-circle',    //Icono que se muestra en representación del modelo
                    modelTitle: 'Usuarios',                            //Nombre que se muestra en representación del modelo
                    modelPath: '',                                      //URL que junto a la BASE es la ruta al servidor
                    modelService: 'usuarioService',                    //Nombre del servicio a utilizar
                    modelPK: 'id',                          //Llave primaria del modelo
                    modelStamp: 'nombrePersonal',                       //Valor único representativo del modelo
                    modelInfo: [                                        //Valores a mostrar para la información del modelo
                        {
                            name: 'Nombre',
                            value: 'nombrePersonal'
                        },
                        { name: 'Apellido', value: 'apellidoPersonal'},
                        { name: 'Fecha Afilacion', value: 'fechaAfilacion'},
                        { name: 'Cargo', value: 'cargo'},
                        { name: 'email', value: 'email'},
                        { name: 'Telefono', value: 'phoneNumber'},
                        { name: 'Pais', value: 'pais'},
                        { name: 'Rol', value: 'name'},
                    ],
                    modelParams: {                                         //Parametros para el modelo
                    }
                },
                dataTableHeaders: [
                    {
                        text: 'Nombre',   //Texto a mostrar en la cabecera de la columna
                        align: 'left',      //Alineación del contenido en la columna
                        value: 'nombrePersonal',    //Nombre del atributo que se colocara en la columna
                        width: '20%',       //Tamaño de la columna
                        type: 'text'        //Tipo del contenido a mostrar en la columna
                    },
                    {text: 'Apellido', align: 'center', value: 'apellidoPersonal', type: 'text'},
                    {text: 'Cargo', align: 'center', value: 'cargo', type: 'text'},
                    {text: 'Rol', align: 'center', value: 'name', type: 'text'},
                    {text: 'Telefono', align: 'center', value: 'phoneNumber', type: 'text'},
                    {text: 'Correo', align: 'center', value: 'email', type: 'text'},
                    {text: 'Opciones', align: 'center', value: 'action', sortable: false, type: 'option'}
                ],
                dataTableOptions: [
                    {
                        text: 'Información',                //Texto que se muestra para el boton
                        type: 'info',                       //Tipo de boton [info|new|edit|delete|redirect]
                        icon: 'mdi-information-outline',    //Icono que se muestra para el boton
                        
                        action: '',                         //Acción personalizada
                        class: 'mr-2',                      //Clase a agregar
                        route: '',                          //Ruta a redirigir
                        params: {},
                        show: (row) => {return true}                          //Parametros para la ruta a redirigir
                    },
                    //{text: 'Editar', type: 'edit', icon: 'mdi-pencil', action: '', class: 'mr-2', route: '', show: (row) => {return true}},
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