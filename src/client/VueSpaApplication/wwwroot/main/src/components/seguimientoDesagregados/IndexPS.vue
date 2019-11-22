<template>
    <div>
        <TitleBar :enableAddBtn="false" :enableBackBtn="true"/>
        <Banner color="grey" icon="mdi-clipboard-check" title="Indicador" :text="bannerText"/>
        <AppAlert/>
        <v-container>
            <v-layout>
                <v-flex>
                    <ExtraInfo main_title="Organizaciones responsables" :info="extraInfo"/>
                    <DataTable/>
                </v-flex>
            </v-layout>
        </v-container>
        <InfoSnackbar/>
    </div>
</template>
<script>
    import {mapState, mapMutations} from 'vuex'
    import InfoSnackbar from '../common/SnackbarInfo'
    import TitleBar from '../common/NavbarTitle'
    import AppAlert from '../common/Alert'
    import DataTable from './DataTable'
    import Banner from '../common/BannerCard'
    import ExtraInfo from "../common/ExtraInfo"

    export default {
        components: {
            ExtraInfo,
            InfoSnackbar,
            DataTable,
            TitleBar,
            AppAlert,
            Banner
        },
        name: "SeguimientoDesagregadosIngresoIndex",
        data() {
            return {
                model: {
                    modelName: 'desagregado',
                    modelIcon: 'mdi-table-large',
                    modelTitle: 'Seguimiento: Agregar registro',
                    modelService: 'proyectoSeguimientoIndicadorService',
                    modelPK: 'id',
                    modelStamp: 'nombreDesagregado',
                    modelInfo: [],
                    modelParams: {
                        idProyecto: this.$route.params.idProyecto,
                        idIndicador: this.$route.params.idIndicador
                    }
                },
                dataTableHeaders: [],
                dataTableOptions: [],
                bannerText: '',
                extraInfo: ''
            }
        },
        computed: {
            ...mapState(['services'])
        },
        methods: {
            ...mapMutations(['defineModel', 'clearAlerts', 'emptyDataTable']),
        },
        created() {
            this.clearAlerts();
            this.defineModel(this.model);
            this.services.simpleIdentificadorService.getIndicador(this.$route.params.idIndicador)
                .then(r => {
                    this.bannerText = r.data.nombre;
                })
                .catch(e => {
                    this.showInfo(e.toString());
                });
            this.services.proyectoSeguimientoRegistroService.getOrganizaciones(this.$route.params.idProyecto)
                .then(r => {
                    this.extraInfo = r.data.map(function (item) {
                        return item.nombre;
                    }).join(", ");
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
