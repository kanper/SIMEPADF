<template>
    <v-card class="mx-auto mb-1" outlined>
        <v-card-title class="font-weight-light">
            Opciones de búsqueda
        </v-card-title>
        <v-card-text>
            <v-row justify="space-between">
                <v-col cols="5" v-if="!onlyYear">
                    <v-menu
                            ref="menuStart"
                            v-model="menuStart"
                            :close-on-content-click="false"
                            :return-value.sync="startDate"
                            transition="scale-transition"
                            offset-y
                            max-width="290px"
                            min-width="290px"
                    >
                        <template v-slot:activator="{ on }">
                            <v-text-field
                                    v-model="startDate"
                                    label="Fecha de Inicio"
                                    prepend-icon="mdi-calendar"
                                    readonly
                                    v-on="on"
                                    @change="loadData"
                            ></v-text-field>
                        </template>
                        <v-date-picker
                                v-model="startDate"
                                type="month"
                                no-title
                                scrollable
                        >
                            <v-spacer></v-spacer>
                            <v-btn text color="primary" @click="menuStart = false">Cancelar</v-btn>
                            <v-btn text color="primary" @click="$refs.menuStart.save(startDate)">OK</v-btn>
                        </v-date-picker>
                    </v-menu>
                </v-col>
                <v-col cols="5" v-if="!onlyYear">
                    <v-menu
                            ref="menuEnd"
                            v-model="menuEnd"
                            :close-on-content-click="false"
                            :return-value.sync="endDate"
                            transition="scale-transition"
                            offset-y
                            max-width="290px"
                            min-width="290px"
                    >
                        <template v-slot:activator="{ on }">
                            <v-text-field
                                    v-model="endDate"
                                    label="Fecha de Fin"
                                    prepend-icon="mdi-calendar"
                                    readonly
                                    v-on="on"
                            ></v-text-field>
                        </template>
                        <v-date-picker
                                v-model="endDate"
                                type="month"
                                no-title
                                scrollable
                                @change="loadData"
                        >
                            <v-spacer></v-spacer>
                            <v-btn text color="primary" @click="menuEnd = false">Cancelar</v-btn>
                            <v-btn text color="primary" @click="$refs.menuEnd.save(endDate)">OK</v-btn>
                        </v-date-picker>
                    </v-menu>
                </v-col>
                <v-col cols="6" v-if="onlyYear">
                    <v-select
                            v-model="selectedYear"
                            :items="years"
                            chips
                            label="Año"
                            prepend-icon="mdi-calendar"
                            @change="loadData"
                    ></v-select>
                </v-col>
                <v-col cols="auto" class="text-center pl-0">
                    <v-row class="flex-column ma-0 fill-height" justify="center">
                        <v-col class="px-0">
                            <SDIPDFMaker v-if="SDI_PDF" />
                            <SPIPDFMaker v-if="SPI_PDF" />
                            <SRIPDFMaker v-if="SRI_PDF" />
                        </v-col>
                        <v-col class="px-0">
                            <SDISheetMaker v-if="SDI_SHEET"/>
                            <SPISheetMaker v-if="SPI_SHEET"/>
                            <SRISheetMaker v-if="SRI_SHEET"/>
                        </v-col>
                        <v-col class="px-0">
                            <v-tooltip bottom>
                                <template v-slot:activator="{ on }">
                                    <v-btn @click="resetTable" icon v-on="on"><v-icon color="blue">mdi-undo-variant</v-icon></v-btn>
                                </template>
                                <span>Reiniciar búsqueda</span>
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
    import SDIPDFMaker from "../pdf/SDIPDFMaker";
    import SPIPDFMaker from "../pdf/SPIPDFMaker";
    import SRIPDFMaker from "../pdf/SRIPDFMaker";
    import SDISheetMaker from "../sheet/SDISheetMaker";
    import SPISheetMaker from "../sheet/SPISheetMaker";
    import SRISheetMaker from "../sheet/SRISheetMaker";

    export default {
        name: "OptionPanel",
        props: {
            tracing: String, 
            onlyYear: {type: Boolean, default: false},
            SDI_PDF: {type: Boolean, default: false},
            SPI_PDF: {type: Boolean, default: false},
            SRI_PDF: {type: Boolean, default: false},
            SDI_SHEET: {type: Boolean, default: false},
            SPI_SHEET: {type: Boolean, default: false},
            SRI_SHEET: {type: Boolean, default: false},
            },
        components: {SDIPDFMaker, SPIPDFMaker, SRIPDFMaker, SDISheetMaker, SPISheetMaker, SRISheetMaker},
        data() {
            return {
                menuStart: false,
                menuEnd: false,
                restarted:false,
                startDate: null,
                endDate: null,
                years: [],
                panelProperties: {
                    year: 2000
                }
            }
        },
        computed: {
            selectedYear: {
                get: function () {
                    return this.startDate;
                },
                set: function (newValue) {
                    this.startDate = newValue;
                    this.endDate = newValue;
                    this.panelProperties.year = newValue;
                    this.resetPanelProperties();
                }
            }
        },
        methods: {
            ...mapMutations(['changeOptionPanelCheck','changeTracingDataLoading','setOptionPanelProperties']),
            ...mapActions(['loadTracingTable']),
            loadData(){
                if(this.startDate !== null && this.endDate !== null){
                    if(!this.restarted){
                        this.changeOptionPanelCheck();
                        this.restarted = true;
                    }
                    this.loadTable();
                }
            },
            loadTable(){
                this.changeTracingDataLoading();
                this.loadTracingTable({tracing:this.tracing, start:this.startDate, end:this.endDate});
            },
            resetTable(){

            },
            resetPanelProperties() {
                this.setOptionPanelProperties(this.panelProperties);
            }
        },
        created() {
            let currentYear = new Date().getFullYear();
            this.years.push({text:currentYear,value:currentYear});
            for(let i = 1; i < 20 ; i++){
                this.years.push({text:(currentYear - i),value:(currentYear - i) + ''});
            }
            this.resetPanelProperties();
        },
    }
</script>

<style scoped>

</style>