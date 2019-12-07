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
        <ReviewCardList />
    </div>
</template>

<script>
    import {mapMutations} from 'vuex'
    import InfoSnackbar from '../../common/SnackbarInfo'
    import TitleBar from '../../common/NavbarTitle'
    import DataInfo from '../CardInfo'
    import AppAlert from '../../common/Alert'
    import DataTable from '../../common/DataTable'
    import Confirmation from '../../common/ConfirmationDialog'
    import ReviewCardList from '../../registroRevision/CardList'

    export default {
        components: {
            InfoSnackbar,
            DataTable,
            TitleBar,
            AppAlert,
            DataInfo,
            Confirmation,
            ReviewCardList
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
                    modelParams: {
                        status:'',
                        country: '',
                        model: null
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
                    {text: 'Avance', align: 'center', value: 'avance', type: 'text'},
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
                    {text: 'Lista de revisiones', type: 'review-list', icon: 'mdi-share-variant', action: '', class: 'mr-2', route: '', show: (row) => {return true}},
                    {text: 'Subir Archivos', type: 'redirect', icon: 'mdi-cloud-download', action: '', class: 'mr-2', route: 'plan-trabajo-evidencias', show: (row) => {return row.isInProcess}},
                    {text: 'Descarga de Archivos', type: 'redirect', icon: 'mdi-cloud-download', action: '', class: 'mr-2', route: 'plan-trabajo-evidencias', show: (row) => {return !row.isInProcess}},
                    {text: 'Seguimiento de Proyecto', type: 'redirect', icon: 'mdi-cogs', action: '', class: 'mr-2', route: 'proyecto-seguimiento-seleccion', show: (row) => {return true}},
                    {text: 'Seguir revisión', type: 'link', icon: 'mdi-sync', action: 'active', class: 'mr-2', route: '', show: (row) => {return row.is3Review}},
                    {text: 'Enviar a revisión', type: 'link', icon: 'mdi-arrow-right-bold', action: '3review', class: 'mr-2', route: '', show: (row) => {return false}},
                    {text: 'Enviar a revisión', type: 'link', icon: 'mdi-arrow-right-bold', action: '2review', class: 'mr-2', route: '', show: (row) => {return false}},
                    {text: 'Enviar a revisión', type: 'link', icon: 'mdi-arrow-right-bold', action: '1review', class: 'mr-2', route: '', show: (row) => {return row.isInProcess}},
                    {text: 'Marcar como revisado', type: 'link', icon: 'mdi-check-all', action: 'mark', class: 'mr-2', route: '', show: (row) => {return !row.isInProcess}},
                    {text: 'Cancelar Proyecto', type: 'link', icon: ' mdi-close-circle-outline', action: 'cancel', class: 'mr-2', route: '', show: (row) => {return row.is3Review}},
                    {text: 'Finalizar proyecto', type: 'link', icon: 'mdi-sync-off', action: 'cancel', class: 'mr-2', route: '', show: (row) => {return row.is3Review}},
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
            setUserCountry(){
                if(window.User.RolId === "2"){
                    this.model.modelParams.country = "all"
                }else {
                    this.model.modelParams.country = window.User.Pais;
                }
            }
        },
        created() {
            this.clearAlerts();
            this.setUserPermission();
            this.setUserCountry();
            this.defineModel(this.model);
        },
        destroyed() {
            this.emptyDataTable();
        }
    };
</script>