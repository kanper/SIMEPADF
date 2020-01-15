<template>
    <v-dialog v-model="visibleProjectPdfDialog" max-width="500">
        <v-card>
            <v-card-title class="headline">Generar Reporte PDF</v-card-title>

            <v-card-text>
                <v-alert outlined color="#C51162" prominent border="left" icon="mdi-file-pdf">{{CRUDModel.nombreProyecto}}</v-alert>
                <v-row>
                    <v-col cols="6">
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
                                ></v-text-field>
                            </template>
                            <v-date-picker
                                    v-model="startDate"
                                    type="month"
                                    no-title
                                    scrollable
                                    :max="maxStartDate"
                                    @change="setBtnDisableStatus()"
                            >
                                <v-spacer></v-spacer>
                                <v-btn text color="primary" @click="menuStart = false">Cancelar</v-btn>
                                <v-btn text color="primary" @click="$refs.menuStart.save(startDate)">OK</v-btn>
                            </v-date-picker>
                        </v-menu>
                    </v-col>
                    <v-col cols="6">
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
                                    :min="minEndDate"
                                    :max="maxEndDate"
                                    @change="setBtnDisableStatus()"
                            >
                                <v-spacer></v-spacer>
                                <v-btn text color="primary" @click="menuEnd = false">Cancelar</v-btn>
                                <v-btn text color="primary" @click="$refs.menuEnd.save(endDate)">OK</v-btn>
                            </v-date-picker>
                        </v-menu>
                    </v-col>
                </v-row>
            </v-card-text>

            <v-card-actions>
                <v-btn color="grey darken-1" text @click="closeDialog()">Cancelar</v-btn>
                <v-spacer></v-spacer>
                <ProyectoPDFMaker :id="CRUDModel.id" :startDate="startDate" :endDate="endDate" :disableBtn="disableBtn"/>
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
                menuStart: false,
                menuEnd: false,
                startDate: null,
                endDate: null,
                disableBtn: true,
            }
        },
        computed: {
            ...mapState(['services','CRUDModel','visibleProjectPdfDialog']),
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
            },
            minEndDate: {
                get: function () {
                    if(this.startDate === null)
                        return null;
                    return this.startDate + '-01';
                },
            },
            maxEndDate: {
                get: function () {
                    return new Date().toISOString().substr(0, 10);
                }
            },
            maxStartDate: {
                get: function () {
                    if(this.endDate === null)
                        return new Date().toISOString().substr(0, 10);
                    return this.endDate + '-01';
                }
            }
        },
        methods: {
            ...mapMutations(['changeProjectPdfDialogVisibility']),
            closeDialog() {
                this.startDate = null;
                this.endDate = null;
                this.changeProjectPdfDialogVisibility();
            },
            setBtnDisableStatus() {
                this.disableBtn = this.startDate === null || this.endDate === null;
            }
        },
        created() {

        }
    }
</script>

<style scoped>

</style>