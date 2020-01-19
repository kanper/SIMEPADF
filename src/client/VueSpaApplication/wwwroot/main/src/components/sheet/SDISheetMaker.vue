<template>
    <v-tooltip bottom>
        <template v-slot:activator="{ on }">
            <v-btn @click="generate" icon v-on="on" :disabled="disableBtn"><v-icon color="green">mdi-file-excel</v-icon></v-btn>
        </template>
        <span>Generar Hoja de Cálculo</span>
        <table class="hidden-sheet" hidden v-for="wrapper in tracingData">
            <thead>
            <tr><th :colspan="getTableLength()">FUNDACIÓN PANAMERICANA PARA EL DESARROLLO</th></tr>
            <tr><th :colspan="getTableLength()">Reporte de Desagregados</th></tr>
            <tr><th>Fecha:</th><th :colspan="getTableLength() - 1">{{getCurrentDate()}}</th></tr>
            </thead>
            <tbody v-for="ind in wrapper.indicadores">
            <tr><td :colspan="getTableLength()"></td></tr>
            <tr><td :colspan="getTableLength()"></td></tr>
            <tr><td>Objetivo:</td><td :colspan="getTableLength() - 1">{{wrapper.nombreObjetivo}}</td></tr>
            <tr><td>Resultado:</td><td :colspan="getTableLength() - 1">{{wrapper.nombreResultado}}</td></tr>
            <tr>
                <td rowspan="2">Indicador</td>
                <td rowspan="2">Organizaciones Responsables</td>
                <td rowspan="2">Desagregados</td>
                <td :colspan="codigosPaises.length">Países</td>
                <td :colspan="codigosSocios.length">Socios Internacionales</td>
                <td rowspan="2">Total</td>
            </tr>
            <tr>
                <td v-for="pais in codigosPaises">{{pais.nombre}}</td>
                <td v-for="socio in codigosSocios">{{socio.nombre}}</td>
            </tr>
            <tr>
                <td :rowspan="ind.desagregados.length + 1">{{ind.nombreIndicador}}</td>
                <td :rowspan="ind.desagregados.length + 1">{{ind.listaOrganizaciones}}</td>
            </tr>
            <tr v-for="des in ind.desagregados">
                <td>{{des.nombre}}</td>
                <td v-for="pais in codigosPaises">{{getCountryBody(des.id,pais.nombre,ind.registroSocios)}}</td>
                <td v-for="socio in codigosSocios">{{getSocioBody(des.id,socio.id,ind.registroSocios)}}</td>
                <td>{{getTotal(des.id, ind.registroSocios)}}</td>
            </tr>
            </tbody>
        </table>
    </v-tooltip>
</template>

<script>
    import {mapState} from 'vuex'
    import XLSX from 'xlsx';
    export default {
        name: "SDISheetMaker",
        props: ['disableBtn'],
        data() {
            return {
                codigosPaises: null,
                codigosSocios: null,
                indicadorTableCount: 0
            }
        },
        computed: {
            ...mapState(['services','tracingData','optionPanelProperties'])
        },
        methods: {

            generate() {
                let table = document.getElementsByClassName("hidden-sheet");
                let wb = XLSX.utils.book_new();
                for (let index = 0; index < table.length; index ++){
                    if(table[index].nodeName === 'TABLE'){
                        let WS = XLSX.utils.table_to_sheet(table[index]);
                        XLSX.utils.book_append_sheet(wb, WS, 'Hoja-' + (index + 1));
                    }
                }
                XLSX.writeFile(wb, 'book.xlsx')
            },
            getCurrentDate(){
                const today = new Date();
                return today.getDate() + '/' + (today.getMonth() + 1) + '/' + today.getFullYear();
            },
            getCountryBody(des, pais, reg) {
                let result = 0;
                reg.forEach((r) => {
                    if (r.codigo === pais && r.idDesagregado === des)
                        result += r.valor;
                });
                return this.numberWithCommas(result);
            },
            getSocioBody(des, socio, reg) {
                let result = 0;
                reg.forEach((r) => {
                    if (r.id === socio && r.idDesagregado === des)
                        result += r.valor;
                });
                return this.numberWithCommas(result);
            },
            getTotal(des, reg) {
                let result = 0;
                reg.forEach((r) => {
                    if (r.idDesagregado === des)
                        result += r.valor;
                });
                return this.numberWithCommas(result);
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
        }
    }
</script>

<style scoped>

</style>