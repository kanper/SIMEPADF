<template>
    <div>
        <TitleBar :enable-add-btn="false" :enableBackBtn="true"/>
        <Banner color="grey" icon="mdi-puzzle" title="Plan de trabajo: Actividad" :text="bannerText"/>
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
    import {mapState, mapMutations} from 'vuex'
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
        name: "producto-evidencia-index",
        data() {
            return {
                model: {
                    modelName: 'evidencia',                              //Nombre del modelo actual
                    modelIcon: 'mdi-cloud-upload',    //Icono que se muestra en representación del modelo
                    modelTitle: 'Evidencias de plan de trabajo',                            //Nombre que se muestra en representación del modelo
                    modelPath: '',                                      //URL que junto a la BASE es la ruta al servidor
                    modelService: 'evidenciaService',                    //Nombre del servicio a utilizar
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
                        text: 'Producto',   //Texto a mostrar en la cabecera de la columna
                        align: 'left',      //Alineación del contenido en la columna
                        value: 'nombreProducto',    //Nombre del atributo que se colocara en la columna
                        width: '50%',       //Tamaño de la columna
                        type: 'text'        //Tipo del contenido a mostrar en la columna
                    },
                    {text: 'Evidencia', align: 'left', value: 'nombreArchivo', width: '30%', type: 'boolean'},                    
                    {text: 'Opciones', align: 'center', value: 'action', sortable: false, type: 'option'},
                ],
                dataTableOptions: [
                    {
                        text: 'Subir archivo',                //Texto que se muestra para el boton
                        type: 'info',                       //Tipo de boton [info|new|edit|delete|redirect]
                        icon: 'mdi-upload',    //Icono que se muestra para el boton
                        action: '',                         //Acción personalizada
                        class: 'mr-2',                      //Clase a agregar
                        route: '',
                        show: (row) => {return true}
                    },
                    {text: 'Editar archivo', type: 'edit', icon: 'mdi-download', action: '', class: 'mr-2', route: '', show: (row) => {return true}},
                    {text: 'Eliminar archivo', type: 'delete', icon: 'mdi-delete', action: '', class: 'mr-2', route: '', show: (row) => {return true}},                    
                ],
                bannerText: ''
            }
        },
        methods: {
            ...mapMutations(['defineModel','clearAlerts','emptyDataTable']),
        },
        computed: {
            ...mapState(['services'])
        },
        created() {
            this.clearAlerts();
            this.defineModel(this.model);
            this.services.simpleIdentificadorService.getActividadPT(this.$route.params.id)
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