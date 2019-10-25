<template>
    <div>
        <TitleBar :enable-add-btn="false" :enableBackBtn="true"/>
        <Banner color="grey" icon="mdi-book" title="Nombre Proyecto" :text="bannerText"/>
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
        name: "actividad-evidencia-index",
        data() {
            return {
                model: {
                    modelName: 'evidencia',                              //Nombre del modelo actual
                    modelIcon: 'mdi-cloud-upload',    //Icono que se muestra en representación del modelo
                    modelTitle: 'Actividades: Plan de trabajo',                            //Nombre que se muestra en representación del modelo
                    modelPath: '',                                      //URL que junto a la BASE es la ruta al servidor
                    modelService: 'planTrabajoActividadService',                    //Nombre del servicio a utilizar
                    modelPK: 'id',                          //Llave primaria del modelo
                    modelStamp: 'nombreActividad',                       //Valor único representativo del modelo
                    modelInfo: [                                        //Valores a mostrar para la información del modelo                
                    ],
                    modelParams: {                                         //Parametros para el modelo
                        id: this.$route.params.id
                    }
                },
                dataTableHeaders: [
                    {
                        text: 'Actividad',   //Texto a mostrar en la cabecera de la columna
                        align: 'left',      //Alineación del contenido en la columna
                        value: 'nombreActividad',    //Nombre del atributo que se colocara en la columna
                        width: '35%',       //Tamaño de la columna
                        type: 'text'        //Tipo del contenido a mostrar en la columna
                    },
                    {text: 'Paises', align: 'left', value: 'paises', width: '30%', type: 'array'},
                    {text: 'Fecha Inicio', align: 'left', value: 'fechaInicio', width: '5%', type: 'date'},
                    {text: 'Fecha Fin', align: 'left', value: 'fechaFin', width: '5%', type: 'date'},
                    {text: 'Fecha Limite', align: 'left', value: 'fechaLimite', width: '5%', type: 'date'},
                    {text: 'Opciones', align: 'center', value: 'action', sortable: false, type: 'option'},
                ],
                dataTableOptions: [
                    {
                        text: 'Subir archivo a esta actividad',                //Texto que se muestra para el boton
                        type: 'redirect',                       //Tipo de boton [info|new|edit|delete|redirect]
                        icon: 'mdi-folder-upload',    //Icono que se muestra para el boton
                        action: '',                         //Acción personalizada
                        class: 'mr-2',                      //Clase a agregar
                        route: 'producto-evidencias',
                        show: (row) => {return true}
                    },                    
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