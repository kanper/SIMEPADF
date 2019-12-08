<template>
    <v-card class="mx-auto mb-1" outlined>
        <v-card-text>
            <div>Opciones de busqueda</div>
            <v-row justify="space-between">
                <v-col cols="6">
                    <v-select
                            v-model="year"
                            :items="years"
                            chips
                            label="Año"
                            prepend-icon="mdi-calendar"
                            @change="loadData"
                    ></v-select>
                </v-col>
                <v-col cols="4">
                    <v-select
                            v-model="quarter"
                            :items="quarters"
                            chips
                            label="Trimestre"
                            prepend-icon="mdi-calendar-multiple"
                            @change="loadData"
                    ></v-select>
                </v-col>

                <v-col cols="auto" class="text-center pl-0">
                    <v-row class="flex-column ma-0 fill-height" justify="center">
                        <v-col class="px-0">
                            <PDFMaker />
                        </v-col>
                        <v-col class="px-0">
                            <v-tooltip bottom>
                                <template v-slot:activator="{ on }">
                                    <v-btn @click="resetTable" icon v-on="on"><v-icon color="blue">mdi-undo-variant</v-icon></v-btn>
                                </template>
                                <span>Reiniciar</span>
                            </v-tooltip>
                        </v-col>
                    </v-row>
                </v-col>
            </v-row>
        </v-card-text>
    </v-card>
</template>

<script>
    import {mapMutations, mapActions} from 'vuex'
    import PDFMaker from "../pdf/PDFMaker";

    export default {
        name: "OptionPanel",
        components: {PDFMaker},
        component: {
            PDFMaker
        },
        data() {
            return {
                quarters:[{text:'Q1',value:'1'}, {text:'Q2',value:'2'}, {text:'Q3',value:'3'}, {text:'Q4',value:'4'}],
                quarter: null,
                years: [],
                year: null,
                restarted:false
            }
        },
        computed: {

        },
        methods: {
            ...mapMutations(['changeOptionPanelCheck']),
            ...mapActions(['loadTracingTable']),
            resetTable() {
                this.year = null;
                this.quarter = null;
                if(this.restarted){
                    this.changeOptionPanelCheck();
                    this.restarted = false;
                }
            },
            loadData(){
                if(this.quarter !== null && this.year !== null){
                    if(!this.restarted){
                        this.changeOptionPanelCheck();
                        this.restarted = true;
                    }
                    this.loadTable(this.year, this.quarter);
                }
            },
            loadTable(year,quarter){
                this.loadTracingTable({year:year,quarter:quarter});
            }
        },
        created() {
            let currentYear = new Date().getFullYear();
            this.years.push({text:currentYear,value:currentYear});
            for(let i = 1; i < 20 ; i++){
                this.years.push({text:(currentYear - i),value:(currentYear - i) + ''});
            }
        }
    }
</script>

<style scoped>

</style>