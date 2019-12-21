<template>
    <v-tooltip bottom>
        <template v-slot:activator="{ on }">
            <v-btn @click="generate" icon v-on="on"><v-icon color="green">mdi-file-excel</v-icon></v-btn>
        </template>
        <span>Generar Hoja de Cálculo</span>
    </v-tooltip>
</template>

<script>
    import {mapState} from 'vuex'
    import XLSX from 'xlsx';
    export default {
        name: "SDISheetMaker",
        data() {
            return {
                sheetContent: "<table><thead><tr><th>Titulo</th></tr></thead><tbody><tr><td>Prueba de sheetjs</td></tr></tbody></table>"
            }
        },
        computed: {
            ...mapState(['services','tracingData'])
        },
        methods: {

            generate() {
                let tables = document.getElementsByTagName("table");
                let wb = XLSX.utils.book_new();
                for(let i = 0; i < tables.length; i++) {
                    let mainWS = XLSX.utils.table_to_sheet(tables[i]);
                    XLSX.utils.book_append_sheet(wb, mainWS, 'Desagregados' + i);
                }
                XLSX.writeFile(wb, 'book.xlsx')
            }
        }
    }
</script>

<style scoped>

</style>