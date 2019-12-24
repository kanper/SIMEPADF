<template>
    <v-dialog v-model="visibleProjectPdfDialog" max-width="350">
        <v-card>
            <v-card-title class="headline">Generar Reporte PDF</v-card-title>

            <v-card-text>
                <v-alert outlined color="#C51162" prominent border="left" icon="mdi-file-pdf">{{CRUDModel.nombreProyecto}}</v-alert>
                <v-select
                        v-model="quarter"
                        :items="quarters"
                        label="Seleccione el Trimestre"
                        outlined
                ></v-select>
            </v-card-text>

            <v-card-actions>
                <v-btn color="grey darken-1" text @click="changeProjectPdfDialogVisibility()">Cancelar</v-btn>
                <v-spacer></v-spacer>
                <ProyectoPDFMaker :id="CRUDModel.id" :quarter="quarter" :year="year"/>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapState,mapMutations} from 'vuex'
    import ProyectoPDFMaker from "../pdf/ProyectoPDFMaker";
    export default {
        name: "ProjectPdfDialog",
        components: {
            ProyectoPDFMaker
        },
        data() {
            return {
                quarters:[{text:'Q1',value:'1'}, {text:'Q2',value:'2'}, {text:'Q3',value:'3'}, {text:'Q4',value:'4'}],
                quarter: null,
                years:[],
                year: new Date().getFullYear()
            }
        },
        computed: {
            ...mapState(['services','CRUDModel','visibleProjectPdfDialog'])
        },
        methods: {
            ...mapMutations(['changeProjectPdfDialogVisibility']),
        }
    }
</script>

<style scoped>

</style>