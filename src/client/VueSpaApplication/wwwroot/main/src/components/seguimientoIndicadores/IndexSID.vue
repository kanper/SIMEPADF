<template>
    <div>
        <TitleBar :enableAddBtn="false"/>
        <AppAlert/>
        <v-container>
            <v-layout>
                <v-flex>
                    <OptionPanel tracing="seguimientoDesagregados" :SDI_PDF="true" :SDI_SHEET="true"/>
                    <DataTable/>
                </v-flex>
            </v-layout>
        </v-container>
        <InfoSnackbar/>
    </div>
</template>
<script>
    import {mapMutations} from 'vuex'
    import InfoSnackbar from '../common/SnackbarInfo'
    import TitleBar from '../common/NavbarTitle'
    import AppAlert from '../common/Alert'
    import DataTable from './DataTableSID'
    import OptionPanel from "./OptionPanel";

    export default {
        components: {
            InfoSnackbar,
            DataTable,
            TitleBar,
            AppAlert,
            OptionPanel
        },
        name: "seguimientoIndicadoresDesagregado",
        data() {
            return {
                model: {
                    modelName: 'desagregado',
                    modelIcon: 'mdi-table-large',
                    modelTitle: 'Seguimiento de indicadores: Desagregados',
                    modelService: 'proyectoSeguimientoIndicadorService',
                    modelPK: 'id',
                    modelStamp: 'nombreDesagregado',
                    modelInfo: [],
                    modelParams: {
                    }
                },
                dataTableHeaders: [],
                dataTableOptions: [],
            }
        },
        methods: {
            ...mapMutations(['defineModel', 'clearAlerts', 'emptyDataTable']),
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
