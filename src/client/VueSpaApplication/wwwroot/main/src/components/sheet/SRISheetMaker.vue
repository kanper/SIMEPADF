<template>
    <v-tooltip bottom>
        <template v-slot:activator="{ on }">
            <v-btn @click="generate" icon v-on="on" :disabled="disableBtn"><v-icon color="green">mdi-file-excel</v-icon></v-btn>
        </template>
        <span>Generar Hoja de Cálculo</span>
        <table id="hidden-sheet" hidden>
            <thead>
            <tr><th colspan="14">FUNDACIÓN PANAMERICANA PARA EL DESARROLLO</th></tr>
            <tr><th colspan="14">Reporte por región</th></tr>
            <tr><th>Fecha:</th><th colspan="13">{{getCurrentDate()}}</th></tr>
            </thead>
            <tbody v-for="wrapper in tracingData">
            <tr><td colspan="14"></td></tr>
            <tr><td colspan="14"></td></tr>
            <tr><td>Objetivo:</td><td colspan="13">{{wrapper.nombreObjetivo}}</td></tr>
            <tr><td>Resultado:</td><td colspan="13">{{wrapper.nombreResultado}}</td></tr>

            <tr>
                <td>Indicador</td>
                <td>Nivel</td>
                <td>Desagregados</td>
                <td>Resultados {{(parseInt(optionPanelProperties.year,10) - 1)}}</td>
                <td>Q t1</td>
                <td>Q t2</td>
                <td>Q t3</td>
                <td>Q t4</td>
                <td>Total {{optionPanelProperties.year}}</td>
                <td>Meta {{optionPanelProperties.year}}</td>
                <td>Frecuencia</td>
                <td>Metodologia de recolección de datos</td>
                <td>Organizaciones responsables</td>
                <td>Fuente de datos</td>
            </tr>
            <tr v-for="ind in wrapper.indicadores">
                <td>{{ind.nombreIndicador}}</td>
                <td>{{getArrayAsList(ind.niveles)}}</td>
                <td>{{ind.listaDesagregados}}</td>
                <td>{{numberWithCommas(ind.totalAnterior)}}</td>
                <td>{{numberWithCommas(ind.totalQ1)}}</td>
                <td>{{numberWithCommas(ind.totalQ2)}}</td>
                <td>{{numberWithCommas(ind.totalQ3)}}</td>
                <td>{{numberWithCommas(ind.totalQ4)}}</td>
                <td>{{numberWithCommas(ind.totalQ1 + ind.totalQ2 + ind.totalQ3 + ind.totalQ4)}}</td>
                <td>{{numberWithCommas(ind.meta)}}</td>
                <td>{{getArrayAsList(ind.frecuencias)}}</td>
                <td>{{getArrayAsList(ind.metodologias)}}</td>
                <td>{{ind.listaOrganizaciones}}</td>
                <td>{{getArrayAsList(ind.fuentes)}}</td>
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
        name: "SDISheetMaker",
        data() {
            return {

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
            }
        }
    }
</script>

<style scoped>

</style>