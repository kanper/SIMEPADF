<template>
    <div>
        <TitleBar :enableAddBtn="false"/>
        <AppAlert/>
        <v-container>
            <v-layout>
                <v-flex>
                    <OptionPanel tracing="seguimientoPais"/>
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
    import OptionPanel from './OptionPanel';
    import DataTable from './DataTableSIP'

    export default {
        components: {
            InfoSnackbar,
            TitleBar,
            AppAlert,
            OptionPanel,
            DataTable
        },
        name: "seguimientoIndicadoresPais",
        data() {
            return {
                model: {
                    modelName: 'desagregado',
                    modelIcon: 'mdi-table-large',
                    modelTitle: 'Seguimiento de indicadores: Información por País',
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
