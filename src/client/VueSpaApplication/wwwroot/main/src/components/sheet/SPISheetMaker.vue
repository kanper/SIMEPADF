<template>
    <v-tooltip bottom>
        <template v-slot:activator="{ on }">
            <v-btn @click="generate" icon v-on="on" :disabled="disableBtn"><v-icon color="green">mdi-file-excel</v-icon></v-btn>
        </template>
        <span>Generar Hoja de Cálculo</span>
        <table id="hidden-sheet" hidden>
            <thead>
            <tr><th :colspan="getTableLength()">FUNDACIÓN PANAMERICANA PARA EL DESARROLLO</th></tr>
            <tr><th :colspan="getTableLength()">Reporte por países</th></tr>
            <tr><th>Fecha:</th><th :colspan="getTableLength() - 1">{{getCurrentDate()}}</th></tr>
            </thead>
            <tbody v-for="wrapper in tracingData">
            <tr><td :colspan="getTableLength()"></td></tr>
            <tr><td :colspan="getTableLength()"></td></tr>
            <tr><td>Objetivo:</td><td :colspan="getTableLength() - 1">{{wrapper.nombreObjetivo}}</td></tr>
            <tr><td>Resultado:</td><td :colspan="getTableLength() - 1">{{wrapper.nombreResultado}}</td></tr>

            <tr>
                <td rowspan="2">Indicador</td>
                <td rowspan="2">Nivel</td>
                <td rowspan="2">Organización responsable</td>
                <td :colspan="codigosPaises.length">Países</td>
                <td :colspan="codigosSocios.length">Socios Internacionales</td>
                <td rowspan="2">Total</td>
            </tr>
            <tr>
                <td v-for="pais in codigosPaises">{{pais.nombre}}</td>
                <td v-for="socio in codigosSocios">{{socio.nombre}}</td>
            </tr>
            <tr v-for="ind in wrapper.indicadores">
                <td>{{ind.nombreIndicador}}</td>
                <td>{{getArrayAsList(ind.niveles)}}</td>
                <td>{{ind.listaOrganizaciones}}</td>
                <td v-for="pais in codigosPaises">{{getCountryBody(ind.registroSocios, pais.nombre)}}</td>
                <td v-for="socio in codigosSocios">{{getSocioBody(ind.registroSocios, socio.id)}}</td>
                <td>{{getTotal(ind.registroSocios)}}</td>
            </tr>
            </tbody>
        </table>
    </v-tooltip>
</template>

<script>
    import {mapState} from 'vuex'
    import XLSX from 'xlsx';
    export default {
        props: ['disableBtn'],
        name: "SPISheetMaker",
        data() {
            return {
                codigosPaises: null,
                codigosSocios: null
            }
        },
        computed: {
            ...mapState(['services','tracingData','optionPanelProperties'])
        },
        methods: {

            generate() {
                let table = document.getElementById("hidden-sheet");
                let wb = XLSX.utils.book_new();
                let mainWS = XLSX.utils.table_to_sheet(table);
                XLSX.utils.book_append_sheet(wb, mainWS, 'Registros');
                XLSX.writeFile(wb, 'book.xlsx')
            },
            getCurrentDate(){
                const today = new Date();
                return today.getDate() + '/' + (today.getMonth() + 1) + '/' + today.getFullYear();
            },
            getCountryBody(reg, nombre) {
                let result = 0;
                reg.forEach((r) => {
                    if (r.codigo === nombre)
                        result += r.valor;
                });
                return this.numberWithCommas(result);
            },
            getSocioBody(reg, id) {
                let result = 0;
                reg.forEach((r) => {
                    if (r.id === id)
                        result += r.valor;
                });
                return this.numberWithCommas(result);
            },
            getTotal(reg) {
                let result = 0;
                reg.forEach((r) => {result += r.valor;});
                return result;
            },
            numberWithCommas(x) {
                if(x === null || x === undefined){
                    return 0;
                }
                return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
            },
            getArrayAsList(arr) {
                if (arr === null || arr === undefined){
                    return 'Vácio';
                }
                return arr.join();
            },
            getTableLength(){
                return this.codigosSocios.length + this.codigosPaises.length + 4;
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
        }
    }
</script>

<style scoped>

</style>