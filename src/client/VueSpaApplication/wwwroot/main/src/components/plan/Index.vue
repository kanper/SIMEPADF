<template>
    <div>
        <TitleBar :enableBackBtn="true"/>
        <Banner color="grey" icon="mdi-clipboard" title="Proyecto" :text="bannerText"/>
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
        name: "plan-index",
        data() {
            return {
                model: {
                    modelName: 'plan',                              //Nombre del modelo actual
                    modelIcon: 'mdi-elevation-rise',    //Icono que se muestra en representación del modelo
                    modelTitle: 'Plan Monitoreo y Evaluación',                            //Nombre que se muestra en representación del modelo
                    modelPath: '',                                      //URL que junto a la BASE es la ruta al servidor
                    modelService: 'planMonitoreoEvaluacionService',                    //Nombre del servicio a utilizar
                    modelPK: 'indicadorId',                          //Llave primaria del modelo
                    modelStamp: 'nombreIndicador',                       //Valor único representativo del modelo
                    modelInfo: [                                        //Valores a mostrar para la información del modelo
                        {
                            name: 'Proyecto',
                            value: 'nombreProyecto',
                            type: 'text'
                        },
                        {name: 'Indicador', value: 'nombreIndicador', type: 'text'},
                        {name: 'Metodología', value: 'metodologia', type: 'text'},
                        {name: 'Linea base', value: 'lineaBase', type: 'text'},
                        {name: 'Fuente dato', value: 'fuenteDato', type: 'obj'},
                        {name: 'Frecuencia de medición', value: 'frecuenciaMedicion', type: 'obj'},
                        {name: 'Nivel de impacto', value: 'nivelImpacto', type: 'obj'},
                        {name: 'Desagregaciones', value: 'desagregaciones', type: 'array'},
                    ],
                    modelParams: {                                         //Parametros para el modelo
                        idProyecto: this.$route.params.id
                    },
                },
                dataTableHeaders: [
                    {
                        text: 'Indicador',   //Texto a mostrar en la cabecera de la columna
                        align: 'left',      //Alineación del contenido en la columna
                        value: 'nombreIndicador',    //Nombre del atributo que se colocara en la columna
                        width: '60%',       //Tamaño de la columna
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
                    {text: 'Configurar Indicador', type: 'edit', icon: 'mdi-square-edit-outline', action: '', class: 'mr-2', route: '', show: (row) => {return true}},
                    {text: 'Eliminar', type: 'delete', icon: 'mdi-delete', action: '', route: '',class: 'mr-2', show: (row) => {return true}},
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
            this.services.simpleIdentificadorService.getProyecto(this.$route.params.id)
                .then(r => {
                    this.bannerText = r.data.nombre;
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
