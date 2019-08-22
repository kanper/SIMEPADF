<template>
    <div>
        <TitleBar :enableBackBtn="true"/>
        <Banner color="grey" icon="mdi-drawing" title="Proyecto plan de trabajo" :text="bannerText"/>
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
    import {mapState,mapMutations} from 'vuex'
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
        name: "objetivo-index",
        data() {
            return {
                model: {
                    modelName: 'actividadPt',                              //Nombre del modelo actual
                    modelIcon: 'mdi-puzzle',    //Icono que se muestra en representación del modelo
                    modelTitle: 'Plan de trabajo: Actividades',                            //Nombre que se muestra en representación del modelo
                    modelPath: '',                                      //URL que junto a la BASE es la ruta al servidor
                    modelService: 'planActividadService',                    //Nombre del servicio a utilizar
                    modelPK: 'id',                          //Llave primaria del modelo
                    modelStamp: 'nombreActividad',                       //Valor único representativo del modelo
                    modelInfo: [                                        //Valores a mostrar para la información del modelo
                        {
                            name: 'Nombre actividad',
                            value: 'nombreActividad',
                            type: 'text'
                        },
                        {name: 'Fecha limite', value: 'fechaLimite', type: 'date'},
                        {name: 'Monto', value: 'monto', type: 'money'}
                    ],
                    modelParams: {                                         //Parametros para el modelo
                        idPlan: this.$route.params.id
                    }
                },
                dataTableHeaders: [
                    {
                        text: 'Actividad',   //Texto a mostrar en la cabecera de la columna
                        align: 'left',      //Alineación del contenido en la columna
                        value: 'nombreActividad',    //Nombre del atributo que se colocara en la columna
                        width: '45%',       //Tamaño de la columna
                        type: 'text'        //Tipo del contenido a mostrar en la columna
                    },
                    {text: 'Fecha limite', align: 'center', value: 'fechaLimite', type: 'date'},
                    {text: 'Monto', align: 'center', value: 'monto', type: 'money'},
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
                    {text: 'Productos', type: 'redirect', icon: 'mdi-apps', action: '', class: 'mr-3', route: 'actividad-producto-index', show: (row) => {return true}}
                ],
                bannerText: ''
            }
        },
        computed: {
            ...mapState(['services'])
        },
        methods: {
            ...mapMutations(['defineModel','clearAlerts','emptyDataTable']),
        },
        created() {
            this.clearAlerts();
            this.defineModel(this.model);
            this.services.proyectoService.get(this.$route.params.id)
                .then(r => {
                    this.bannerText = r.data.nombreProyecto;
                })
                .catch(e => {
                    this.showInfo(e.toString());
                });
        },
        destroyed() {
            this.emptyDataTable();
        }
    };
</script>