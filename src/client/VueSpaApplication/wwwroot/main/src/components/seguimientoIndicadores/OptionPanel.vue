<template>
    <v-card class="mx-auto mb-1" outlined>
        <v-card-title class="font-weight-light">
            Opciones de búsqueda
        </v-card-title>
        <v-card-text>
            <v-row justify="space-between">
                <v-col cols="5">
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
                <v-col cols="5">
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

                <v-col cols="auto" class="text-center pl-0">
                    <v-row class="flex-column ma-0 fill-height" justify="center">
                        <v-col class="px-0">
                            <PDFMaker />
                        </v-col>
                        <v-col class="px-0">
                            <SheetMaker />
                        </v-col>
                    </v-row>
                </v-col>
            </v-row>
        </v-card-text>
    </v-card>
</template>

<script>
    import {mapMutations, mapActions} from 'vuex'
    import PDFMaker from "../pdf/SDIPDFMaker";
    import SheetMaker from "../sheet/SDISheetMaker"

    export default {
        name: "OptionPanel",
        props: {tracing: String, hideQuarter: {type: Boolean, default: false}},
        components: {PDFMaker,SheetMaker},
        data() {
            return {
                menuStart: false,
                menuEnd: false,
                restarted:false,
                startDate: null,
                endDate: null
            }
        },
        computed: {

        },
        methods: {
            ...mapMutations(['changeOptionPanelCheck','changeTracingDataLoading']),
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
        },
        created() {
        },
    }
</script>

<style scoped>

</style>