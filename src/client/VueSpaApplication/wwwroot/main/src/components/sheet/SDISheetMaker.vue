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

            }
        },
        computed: {
            ...mapState(['services','tracingData'])
        },
        methods: {
            generate() {
                let mainWS = XLSX.utils.json_to_sheet(this.tracingData);
                let wb = XLSX.utils.book_new();
                XLSX.utils.book_append_sheet(wb, mainWS, 'Desagregados');
                XLSX.writeFile(wb, 'book.xlsx')
            }
        }
    }
</script>

<style scoped>

</style>