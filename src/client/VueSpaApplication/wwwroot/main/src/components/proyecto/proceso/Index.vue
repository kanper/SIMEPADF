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
        <InfoSnackbar/>
        <Confirmation />
    </div>
</template>

<script>
    import {mapMutations} from 'vuex'
    import InfoSnackbar from '../../common/SnackbarInfo'
    import TitleBar from '../../common/NavbarTitle'
    import DataInfo from '../../common/CardInfo'
    import AppAlert from '../../common/Alert'
    import DataTable from '../../common/DataTable'
    import Confirmation from '../../common/ConfirmationDialog'

    export default {
        components: {
            InfoSnackbar,
            DataTable,
            TitleBar,
            AppAlert,
            DataInfo,
            Confirmation
        },
        name: "objetivo-index",
        data() {
            return {
                model: {
                    modelName: 'proyecto',                              //Nombre del modelo actual
                    modelIcon: 'mdi-briefcase',                         //Icono que se muestra en representación del modelo
                    modelTitle: 'Proyectos en Proceso',                            //Nombre que se muestra en representación del modelo
                    modelPath: '',                                      //URL que junto a la BASE es la ruta al servidor
                    modelService: 'proyectoOnProcessService',                    //Nombre del servicio a utilizar
                    modelPK: 'id',                                      //Llave primaria del modelo
                    modelStamp: 'nombreProyecto',                       //Valor único representativo del modelo
                    modelInfo: [                                        //Valores a mostrar para la información del modelo
                        {
                            name: 'Nombre proyecto',
                            value: 'nombreProyecto',
                            type: 'text'
                        },
                        { name: 'Clasificaión', value: 'clasificacion',type: 'text'},
                        { name: 'Estado', value: 'estado',type: 'text'},
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
                        status:''
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
                    {text: 'Clasificacion',align: 'center', value: 'clasificacion', type: 'text'},
                    {text: 'Estado', align: 'center', value: 'estado', type: 'text'},
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
                    {text: 'Enviar a revisión', type: 'link', icon: 'mdi-reply', action: 'cancel', class: 'mr-2', route: '', show: (row) => {return true}},
                ],
            }
        },
        methods: {
            ...mapMutations(['defineModel','clearAlerts','emptyDataTable']),
            setUserPermission() {
                switch (window.User.RolId) {
                    case '2':
                        this.model.modelParams.status = '3REVISION';
                        break;
                    case '3':
                        this.model.modelParams.status = '2REVISION';
                        break;
                    case '4':
                        this.model.modelParams.status = 'EN_PROCESO';
                        break;
                    case '5':
                        this.model.modelParams.status = '1REVISION';
                        break;
                    default:
                        this.model.modelParams.status = 'INVALID';
                }
            },
        },
        created() {
            this.clearAlerts();
            this.setUserPermission();
            this.defineModel(this.model);
        },
        destroyed() {
            this.emptyDataTable();
        }
    };
</script>