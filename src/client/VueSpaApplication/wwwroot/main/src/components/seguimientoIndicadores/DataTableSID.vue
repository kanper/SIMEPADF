<template>
    <v-card outlined>
        <v-card-title>
            <h2 class="font-weight-light">{{modelSpecification.modelTitle}}</h2>
            <v-spacer></v-spacer>
        </v-card-title>
        <v-alert
                color="#2A3B4D"
                dark
                icon="mdi-firework"
                dense
                height="50"
                v-show="!optionPanelChecked"
                class="mx-4"
        >
            Seleccione el Año de consulta y el Trimestre para comenzar.

        </v-alert>
        <v-container v-show="optionPanelChecked">
            <v-row v-for="item in tracingData">
                <v-col cols="auto">
                    <v-card outlined >
                        <v-alert outlined class="my-0" dense type="success" icon="mdi-checkbox-marked-circle-outline"><strong>Objetivo: </strong>{{item.nombreObjetivo}}</v-alert>
                        <v-alert outlined class="my-0" dense type="info" icon="mdi-white-balance-incandescent"><strong>Resultado: </strong>{{item.nombreResultado}}</v-alert>
                        <v-alert v-if="item.indicadores.length === 0" outlined dense border="bottom" type="error" class="my-0">No se encontraron indicadores con registros para este objetivo/resultado</v-alert>
                        <v-row v-for="ind in item.indicadores">
                            <v-col cols="auto">
                                <v-divider></v-divider>
                                <v-simple-table>
                                    <template v-slot:default>
                                        <thead>
                                        <tr>
                                            <th>Indicador</th>
                                            <th>Organización responsable</th>
                                            <th>Desagregados</th>
                                            <th>Paises</th>
                                            <th>Socios internacionales</th>
                                            <th>TOTAL</th>
                                        </tr>
                                        </thead>
                                        <tbody>
                                        <tr>
                                            <td>{{ind.nombreIndicador}}</td>
                                            <td>{{ind.listaOrganizaciones}}</td>
                                            <td>
                                                <table>
                                                    <thead><tr><th></th></tr></thead>
                                                    <tbody>
                                                    <tr v-for="des in ind.desagregados"><td>{{des.nombre}}</td></tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td>
                                                <table>
                                                    <thead>
                                                    <tr>
                                                        <th v-for="pais in codigosPaises">{{pais.nombre}}</th>
                                                    </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr v-for="des in ind.desagregados"><td v-for="pais in codigosPaises">
                                                            {{getTableValueByCountry(pais.nombre,des.id,ind.registroSocios)}}
                                                        </td></tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td>
                                                <table>
                                                    <thead>
                                                    <tr>
                                                        <th v-for="socio in codigosSocios">{{socio.nombre}}</th>
                                                    </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr v-for="des in ind.desagregados">
                                                            <td v-for="socio in codigosSocios">
                                                                {{getTableValueByOrg(socio.id,des.id,ind.registroSocios)}}
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td>
                                                <table>
                                                    <thead><tr><th></th></tr></thead>
                                                    <tbody>
                                                    <tr v-for="des in ind.desagregados">
                                                        <td>{{getRowTotal(des.id, ind.registroSocios)}}</td>
                                                    </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        </tbody>
                                    </template>
                                </v-simple-table>
                            </v-col>
                        </v-row>
                    </v-card>
                </v-col>
            </v-row>
        </v-container>
    </v-card>
</template>

<script>
    import {mapMutations, mapState, mapActions} from 'vuex'

    export default {
        comments: [],
        data() {
            return {
                headers: [],
                dataTable: [],
                desagregado: '',
                socio: '',
                codigosPaises: null,
                codigosSocios: null,
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'services','optionPanelChecked','tracingData']),
            isTableVisible: {
                get: function () {
                    return this.optionPanelChecked;
                },
                set: function (newValue) {

                }
            }
        },
        methods: {
            ...mapMutations(['showInfo', 'changeNewDialogVisibility', 'closeAllDialogs', 'resetTableLoader','changeCellDialogVisibility','setTracingData','changeOptionPanelCheck']),
            ...mapActions(['loadTracingTable']),
            loadData: function() {
            },
            getTableValueByOrg(id, des, table){
                let result = 0;
                table.forEach(item => {
                    if(item.id === id && item.idDesagregado === des){
                        result = item.valor;
                    }
                });
                return result;
            },
            getTableValueByCountry(cod, des, table){
                let result = 0;
                table.forEach(item => {
                   if (item.codigo === cod && item.idDesagregado === des){
                       result += item.valor;
                   }
                });
                return result;
            },
            getRowTotal(des, table) {
                let result = 0;
                table.forEach(item => {
                    if(item.idDesagregado === des){
                        result += item.valor;
                    }
                });
                return result;
            }
        },
        created() {
            this.services.simpleIdentificadorService.getCodigoPaises()
                .then(r => {
                    this.codigosPaises = r.data;
                })
                .catch(e => {
                    this.showInfo(e.toString());
                });
            this.services.simpleIdentificadorService.getCodigoSocios()
                .then(r => {
                   this.codigosSocios = r.data;
                })
                .catch(e => {
                    this.showInfo(e.toString());
                });
        },
        destroyed() {
            this.setTracingData(null);
            if (this.optionPanelChecked){
                this.changeOptionPanelCheck();
            }
        }
    }
</script>
