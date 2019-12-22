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
            Seleccionar la Fecha de Inicio y la Fecha de Fin para iniciar la búsqueda

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
                                            <th>Nivel</th>
                                            <th>Organización responsable</th>
                                            <th>Países</th>
                                            <th>Socios internacionales</th>
                                            <th>TOTAL</th>
                                        </tr>
                                        </thead>
                                        <tbody>
                                        <tr>
                                            <td>{{ind.nombreIndicador}}</td>
                                            <td>{{ind.niveles.join()}}</td>
                                            <td>{{ind.listaOrganizaciones}}</td>
                                            <td>
                                                <table>
                                                    <thead>
                                                    <tr>
                                                        <th v-for="pais in codigosPaises">{{pais.nombre}}</th>
                                                    </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                            <td v-for="pais in codigosPaises">
                                                                {{getTableValueByCountry(pais.nombre,ind.registroSocios)}}
                                                            </td>
                                                        </tr>
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
                                                        <tr>
                                                            <td v-for="socio in codigosSocios">
                                                                {{getTableValueByOrg(socio.id,ind.registroSocios)}}
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                            <td>
                                                <table>
                                                    <thead><tr><th></th></tr></thead>
                                                    <tbody>
                                                    <tr>
                                                        <td>{{getRowTotal(ind.registroSocios)}}</td>
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
            ...mapState(['modelSpecification', 'services','optionPanelChecked','tracingData','isTracingDadaLoading']),
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
                return this.numberWithCommas(result);
            },
            getTableValueByCountry(cod, table){
                let result = 0;
                table.forEach(item => {
                   if (item.codigo === cod){
                       result += item.valor;
                   }
                });
                return this.numberWithCommas(result);
            },
            getRowTotal(table) {
                let result = 0;
                table.forEach(item => {
                    result += item.valor;
                });
                return this.numberWithCommas(result);
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
