<template>
    <v-card outlined>
        <v-card-title>
            <h2 class="font-weight-light">{{modelSpecification.modelTitle}}</h2>
            <v-spacer></v-spacer>
        </v-card-title>
        <v-divider></v-divider>
        <v-alert
                color="#2A3B4D"
                dark
                icon="mdi-firework"
                dense
                height="50"
                v-show="!optionPanelChecked"
                class="mx-4 my-2"
        >
            Seleccione el Año de consulta para comenzar.

        </v-alert>
        <div class="text-center mt-4">
            <v-progress-circular
                    :size="50"
                    color="primary"
                    indeterminate
                    v-show="optionPanelChecked && isTracingDadaLoading"
            ></v-progress-circular>
        </div>
        <v-container v-show="optionPanelChecked">
            <v-row v-for="item in tracingData" :key="'Obj' + item.id + '-' + item.codigoResultado">
                <v-col cols="auto">
                    <v-card outlined >
                        <v-alert outlined class="my-0" dense type="success" icon="mdi-checkbox-marked-circle-outline"><strong>Objetivo: </strong>{{item.nombreObjetivo}}</v-alert>
                        <v-alert outlined class="my-0" dense type="info" icon="mdi-white-balance-incandescent"><strong>Resultado: </strong>{{item.nombreResultado}}</v-alert>
                        <v-alert v-if="item.indicadores.length === 0" outlined dense border="bottom" type="error" class="my-0">No se encontraron indicadores con registros para este objetivo/resultado</v-alert>
                        <v-row v-for="ind in item.indicadores" :key="'Ind' + item.id + '-' + ind.codigoActividad + '-' + ind.id">
                            <v-col cols="auto">
                                <v-divider></v-divider>
                                <v-simple-table>
                                    <template v-slot:default>
                                        <thead>
                                        <tr>
                                            <th>Indicador</th>
                                            <th>Avance meta global</th>
                                            <th>Nivel</th>
                                            <th>Desagregados</th>
                                            <th>Resultados {{parseInt(optionPanelProperties.year,10) - 1}}</th>
                                            <th>Q t1</th>
                                            <th>Q t2</th>
                                            <th>Q t3</th>
                                            <th>Q t4</th>
                                            <th>Total {{optionPanelProperties.year}}</th>
                                            <th>Meta {{optionPanelProperties.year}}</th>
                                            <th>Frecuencia</th>
                                            <th>Metodologia de recolección de datos</th>
                                            <th>Organizaciones responsables</th>
                                            <th>Fuente de datos</th>
                                        </tr>
                                        </thead>
                                        <tbody>
                                        <tr>
                                            <td>{{ind.nombreIndicador}}</td>
                                            <td>{{ind.avanceMetaAnual}}</td>
                                            <td>{{ind.niveles.join()}}</td>
                                            <td>{{ind.listaDesagregados}}</td>
                                            <td>{{numberWithCommas(ind.totalAnterior)}}</td>
                                            <td>{{numberWithCommas(ind.totalQ1)}}</td>
                                            <td>{{numberWithCommas(ind.totalQ2)}}</td>
                                            <td>{{numberWithCommas(ind.totalQ3)}}</td>
                                            <td>{{numberWithCommas(ind.totalQ4)}}</td>
                                            <td>{{numberWithCommas(ind.totalAnio)}}</td>
                                            <td>{{numberWithCommas(ind.metaAnual)}}</td>
                                            <td>{{ind.frecuencias.join()}}</td>
                                            <td>{{ind.metodologias.join()}}</td>
                                            <td>{{ind.listaOrganizaciones}}</td>
                                            <td>{{ind.fuentes.join()}}</td>
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
            ...mapState(['modelSpecification', 'services','optionPanelChecked','tracingData','isTracingDadaLoading','optionPanelProperties']),
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
            numberWithCommas(x) {
                if(x === null || x === undefined){
                    return 0;
                }
                return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
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
