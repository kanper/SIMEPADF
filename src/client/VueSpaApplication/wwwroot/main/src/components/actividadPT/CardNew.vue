<template xmlns:v-slot="http://www.w3.org/1999/XSL/Transform">
    <v-dialog max-width="55%" persistent v-model="visibleNewDialog">
        <v-card>
            <v-card-title class="headline grey darken-3 white--text">Formulario de {{modelSpecification.modelTitle}}:
                Agregar nuevo
            </v-card-title>
            <v-card-text>
                <v-container grid-list-md>
                    <v-layout wrap>
                        <v-chip color="primary" text-color="white">
                            $ {{montoActual}} Monto restante
                            <v-icon right>mdi-check</v-icon>
                        </v-chip>
                        <v-flex xs12>

                            <form>
                                <NewUniqueEntity identifierName="Nombre de la actividad" :identifierValue="this.newModel.nombreActividad"/>
                                <v-textarea
                                        v-model="newModel.nombreActividad"
                                        auto-grow filled clearable
                                        v-validate="'required|max:1000'"
                                        :counter="1000"
                                        :error-messages="errors.collect('nombre actividad')"
                                        label="Nombre actividad"
                                        data-vv-name="nombreActividad"
                                        required
                                        @input="validateIdentifier()"
                                ></v-textarea>
                                <v-text-field
                                        v-model="newModel.monto"
                                        v-validate="fieldRules"
                                        :error-messages="errors.collect('monto')"
                                        label="Monto"
                                        data-vv-name="monto"
                                        required
                                ></v-text-field>
                                <v-combobox
                                    :items="paises"
                                    item-text="nombre"
                                    label="Seleccione el pais o paises"
                                    multiple
                                    required
                                    v-model="newModel.paises"
                                ></v-combobox>
                                <v-menu
                                        :close-on-content-click="false"
                                        :nudge-right="40"
                                        min-width="290px"
                                        offset-y
                                        transition="scale-transition"
                                        v-model="datePick"
                                >
                                    <template v-slot:activator="{ on }">
                                        <v-text-field
                                                label="Fecha inicio"
                                                prepend-icon="mdi-calendar"
                                                readonly
                                                v-model="newModel.fechaInicio"
                                                v-on="on"
                                        ></v-text-field>
                                    </template>
                                    <v-date-picker @input="datePick = false" locale="es-es"
                                                   v-model="startDate" :max="startDateLimit"></v-date-picker>
                                </v-menu>
                                <v-menu
                                        :close-on-content-click="false"
                                        :nudge-right="40"
                                        min-width="290px"
                                        offset-y
                                        transition="scale-transition"
                                        v-model="datePick1"
                                >
                                    <template v-slot:activator="{ on }">
                                        <v-text-field
                                                label="Fecha limite"
                                                prepend-icon="mdi-calendar"
                                                readonly
                                                v-model="newModel.fechaLimite"
                                                v-on="on"
                                        ></v-text-field>
                                    </template>
                                    <v-date-picker @input="datePick1 = false" locale="es-es"
                                                   v-model="endDate" :min="endDateLimit"></v-date-picker>
                                </v-menu>
                            </form>
                        </v-flex>
                    </v-layout>
                </v-container>
                <small>* Indica que el campo es requerido</small>
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn @click="changeNewDialogVisibility" color="gray darken-1" text>Cancelar</v-btn>
                <v-btn @click="save()" color="green darken-1" text :disabled="disableSaveBtn()">Guardar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapActions, mapMutations, mapState} from 'vuex'
    import NewUniqueEntity from "../validation/NewUniqueEntity";

    export default {
        components: {NewUniqueEntity},
        props: {
            paises: {type: Array},
        },
        data() {
            return {
                todat: new Date(),
                newModel: {
                    id: 0,
                    nombreActividad: '',
                    fechaInicio: new Date().toISOString().substr(0, 10),
                    fechaLimite: new Date().toISOString().substr(0, 10),
                    monto: 0.0,
                    paises: []
                },
                montoActual: 0.0,
                datePick: false,
                datePick1: false,
                endDateLimit: "",
                startDateLimit:  ""
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'visibleNewDialog', 'services','isUniqueEntity']),
            fieldRules () {
                return {
                    required: true,
                    decimal: 2,
                    min_value: 0.1,
                    max_value: this.montoActual
                }
            },
            startDate: {
                get: function () {
                    return this.newModel.fechaInicio;
                },
                set: function (newValue) {
                    if (Date.parse(this.newModel.fechaLimite) >= Date.parse(newValue) || Date.parse(this.newModel.fechaLimite) === Date.parse(this.newModel.fechaInicio)){
                        this.newModel.fechaInicio = newValue;
                        this.endDateLimit = newValue.substr(0, 10);
                    }
                }
            },
            endDate: {
                get: function () {
                    return this.newModel.fechaLimite;
                },
                set: function (newValue) {
                    if (Date.parse(this.newModel.fechaInicio) <= Date.parse(newValue) || Date.parse(this.newModel.fechaLimite) === Date.parse(this.newModel.fechaInicio)){
                        this.newModel.fechaLimite = newValue;
                        this.startDateLimit = newValue.substr(0, 10);
                    }
                }
            }
        },
        methods: {
            ...mapMutations(['changeNewDialogVisibility', 'closeAllDialogs', 'showInfo', 'addAlert']),
            ...mapActions(['loadDataTable','validateNewEntity']),
            save() {
                this.$validator.validateAll()
                    .then(v => {
                        if (v) {
                            this.services[this.modelSpecification.modelService].add(this.newModel, this.modelSpecification.modelParams)
                                .then(r => {
                                    this.loadDataTable();
                                    this.clearForm();
                                    if (r.data) {
                                        this.addAlert({
                                            value: true,
                                            color: 'success',
                                            icon: 'mdi-checkbox-marked-circle-outline',
                                            text: 'El nuevo ' + this.modelSpecification.modelName + ' se guardo correctamente.'
                                        });
                                    } else {
                                        this.addAlert({
                                            value: true,
                                            color: 'error',
                                            icon: 'mdi-close-circle-outline',
                                            text: 'Ocurrio un problema al tratar de guardar el ' + this.modelSpecification.modelName + ' seleccionado.'
                                        });
                                    }
                                })
                                .catch(e => {
                                    this.showInfo(e.toString());
                                });
                            this.closeAllDialogs();
                        } else {
                            this.showInfo(this.$validator.errors.all().toString());
                        }
                    })
                    .catch(e => {
                        this.showInfo(e.toString());
                    });
            },
            clearForm(){
                this.newModel.nombreActividad = '';
                this.newModel.monto = 0.0;
                this.newModel.fechaInicio = new Date().toISOString().substr(0, 10);
                this.newModel.fechaLimite = new Date().toISOString().substr(0, 10);
                this.newModel.monto = [];
                this.$validator.reset();
                this.getCurrentMount();
                this.startDateLimit = '';
                this.endDateLimit = '';
            },
            getCurrentMount()
            {
                this.services.planTrabajoService.get(this.$route.params.id)
                    .then(r => {
                        this.montoActual = r.data.montoRestante;
                    })
                    .catch(e => {
                        this.showInfo(e.toString());
                    });
            },
            validateIdentifier() {
                if(this.newModel.nombreActividad !== null)
                    if(this.newModel.nombreActividad.length > 0)
                        this.validateNewEntity({entityName:"actividadPT",identifier:this.newModel.nombreActividad});
            },
            disableSaveBtn(){
                return !this.isUniqueEntity;
            },
        },
        created(){
            this.getCurrentMount();
        }
    }
</script>