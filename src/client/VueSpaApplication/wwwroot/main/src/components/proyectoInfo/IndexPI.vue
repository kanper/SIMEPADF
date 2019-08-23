<template>
    <div>
        <TitleBar :enableBackBtn="true" :enableAddBtn="false"/>
        <Banner color="grey" icon="mdi-briefcase" title="Proyecto" :text="bannerText"/>
        <AppAlert/>
        <v-container>
            <v-layout>
                <v-flex>
                    <DataTable :headers="dataTableHeaders" :options="dataTableOptions"/>
                </v-flex>
            </v-layout>
        </v-container>
        <DataInfo/>
        <DeleteDialog/>
        <InfoSnackbar/>
    </div>
</template>

<script>
    import {mapState,mapMutations} from 'vuex'
    import InfoSnackbar from '../common/SnackbarInfo'
    import TitleBar from '../common/NavbarTitle'
    import DeleteDialog from '../common/DialogDelete'
    import DataInfo from '../common/CardInfo'
    import AppAlert from '../common/Alert'
    import DataTable from '../common/DataTable'
    import Banner from '../common/BannerCard'

    export default {
        components: {
            InfoSnackbar,
            DeleteDialog,
            DataTable,
            TitleBar,
            AppAlert,
            DataInfo,
            Banner
        },
        name: "proyecto-info-index",
        data() {
            return {
                model: {
                    modelName: 'proyectoInfo',                              //Nombre del modelo actual
                    modelIcon: 'mdi-information-outline',    //Icono que se muestra en representación del modelo
                    modelTitle: 'Información de proyecto',                            //Nombre que se muestra en representación del modelo
                    modelPath: '',                                      //URL que junto a la BASE es la ruta al servidor
                    modelService: 'proyectoInfoService',                    //Nombre del servicio a utilizar
                    modelPK: 'codigoActividad',                          //Llave primaria del modelo
                    modelStamp: 'nombreProyecto',                       //Valor único representativo del modelo
                    modelInfo: [                                        //Valores a mostrar para la información del modelo
                        {
                            name: 'Productos',
                            value: 'productos',
                            type: 'list'
                        }
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
                        width: '40%',       //Tamaño de la columna
                        type: 'text'        //Tipo del contenido a mostrar en la columna
                    },
                    {text: 'Productos', align: 'center', value: 'numeroProductos', sortable: true, type: 'number'},
                    {text: 'Monto', align: 'center', value: 'monto', sortable: true, type: 'money'},
                    {text: 'Fecha limite', align: 'center', value: 'fechaLimite', sortable: true, type: 'date'},
                    {text: 'Opciones', align: 'center', value: 'action', sortable: false, type: 'option'}
                ],
                dataTableOptions: [
                    {
                        text: 'Información',                //Texto que se muestra para el boton
                        type: 'info',                       //Tipo de boton [info|new|edit|delete|redirect]
                        icon: 'mdi-information-outline',    //Icono que se muestra para el boton
                        action: '',                         //Acción personalizada
                        class: 'mr-2',                      //Clase a pagregar
                        route: '',
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