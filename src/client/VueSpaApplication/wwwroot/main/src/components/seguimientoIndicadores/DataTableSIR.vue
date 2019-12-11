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
            Seleccione el Año de consulta para comenzar.

        </v-alert>
        <v-container v-show="optionPanelChecked">
            <v-row v-for="item in tracingData" :key="'Obj' + item.id">
                <v-col cols="auto">
                    <v-card outlined >
                        <v-alert outlined class="my-0" dense type="success" icon="mdi-checkbox-marked-circle-outline"><strong>Objetivo: </strong>{{item.nombreObjetivo}}</v-alert>
                        <v-alert outlined class="my-0" dense type="info" icon="mdi-white-balance-incandescent"><strong>Resultado: </strong>{{item.nombreResultado}}</v-alert>
                        <v-alert v-if="item.indicadores.length === 0" outlined dense border="bottom" type="error" class="my-0">No se encontraron indicadores con registros para este objetivo/resultado</v-alert>
                        <v-row v-for="ind in item.indicadores" :key="'Ind' + ind.id">
                            <v-col cols="auto">
                                <v-divider></v-divider>
                                <v-simple-table>
                                    <template v-slot:default>
                                        <thead>
                                        <tr>
                                            <th>Indicador</th>
                                            <th>Nivel</th>
                                            <th>Desagregados</th>
                                            <th>Resultados 20xx</th>
                                            <th>Q t1</th>
                                            <th>Q t2</th>
                                            <th>Q t3</th>
                                            <th>Q t4</th>
                                            <th>Total 20xx</th>
                                            <th>Meta 20xx</th>
                                            <th>Frecuencia</th>
                                            <th>Metodologia de recolección de datos</th>
                                            <th>Organizaciones responsables</th>
                                            <th>Fuente de datos</th>
                                        </tr>
                                        </thead>
                                        <tbody>
                                        <tr>
                                            <td>{{ind.nombreIndicador}}</td>
                                            <td>{{ind.nivel}}</td>
                                            <td>{{ind.listaDesagregados}}</td>
                                            <td>
                                                <table>
                                                    <tbody>
                                                    <tr><td>{{ind.totalAnterior}}</td></tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td>
                                                <table>
                                                    <tbody>
                                                    <tr><td>{{ind.totalQ1}}</td></tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td>
                                                <table>
                                                    <tbody>
                                                    <tr><td>{{ind.totalQ2}}</td></tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td>
                                                <table>
                                                    <tbody>
                                                    <tr><td>{{ind.totalQ3}}</td></tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td>
                                                <table>
                                                    <tbody>
                                                    <tr><td>{{ind.totalQ4}}</td></tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td>
                                                <table>
                                                    <tbody>
                                                    <tr><td>{{ind.totalQ1 + ind.totalQ2 + ind.totalQ3 + ind.totalQ4}}</td></tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td>{{ind.meta}}</td>
                                            <td>{{ind.frecuencia}}</td>
                                            <td>{{ind.metodologia}}</td>
                                            <td>{{ind.listaOrganizaciones}}</td>
                                            <td>{{ind.fuente}}</td>
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
            getTableValueByOrg(id, table){
                let result = 0;
                table.forEach(item => {
                    if(item.id === id){
                        result += item.valor;
                    }
                });
                return result;
            },
            getTableValueByCountry(cod, table){
                let result = 0;
                table.forEach(item => {
                   if (item.codigo === cod){
                       result += item.valor;
                   }
                });
                return result;
            },
            getRowTotal(des, table) {
                let result = 0;
                table.forEach(item => {
                    result += item.valor;
                });
                return result;
            },
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
