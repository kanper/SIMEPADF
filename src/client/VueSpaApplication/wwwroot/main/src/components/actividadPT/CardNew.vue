<template xmlns:v-slot="http://www.w3.org/1999/XSL/Transform">
    <v-dialog max-width="50%" persistent v-model="visibleNewDialog">
        <v-card>
            <v-card-title class="headline grey darken-3 white--text">Formulario de {{modelSpecification.modelTitle}}:
                Agregar nuevo
            </v-card-title>
            <v-card-text>
                <v-container grid-list-md>
                    <v-layout wrap>
                        <v-flex xs12>
                            <v-chip color="primary" text-color="white">
                                $ {{montoActual}}
                                <v-icon right>mdi-check</v-icon>
                            </v-chip>
                            <form>
                                <v-text-field
                                        v-model="newModel.nombreActividad"
                                        v-validate="'required|max:100'"
                                        :counter="100"
                                        :error-messages="errors.collect('nombre actividad')"
                                        label="Nombre actividad"
                                        data-vv-name="nombreActividad"
                                        required
                                ></v-text-field>
                                <v-text-field
                                        v-model="newModel.monto"
                                        v-validate="fieldRules"
                                        :error-messages="errors.collect('monto')"
                                        label="Monto"
                                        data-vv-name="monto"
                                        required
                                ></v-text-field>
                                <v-menu
                                        :close-on-content-click="false"
                                        :nudge-right="40"
                                        full-width
                                        lazy
                                        min-width="290px"
                                        offset-y
                                        transition="scale-transition"
                                        v-model="datePick"
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
                                    <v-date-picker @input="datePick = false" locale="es-es"
                                                   v-model="newModel.fechaLimite"></v-date-picker>
                                </v-menu>
                            </form>
                        </v-flex>
                    </v-layout>
                </v-container>
                <small>* Indica que el campo es requerido</small>
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn @click="changeNewDialogVisibility" color="gray darken-1" flat>Cancelar</v-btn>
                <v-btn @click="save()" color="green darken-1" flat>Guardar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapActions, mapMutations, mapState} from 'vuex'

    export default {
        data() {
            return {
                newModel: {
                    id: 0,
                    nombreActividad: '',
                    fechaLimite: new Date().toISOString().substr(0, 10),
                    monto: 0.0
                },
                montoActual: 0.0,
                datePick: false
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'visibleNewDialog', 'services']),
            fieldRules () {
                return {
                    required: true,
                    decimal: 2,
                    min_value: 0.1,
                    max_value: this.montoActual
                }
            }
        },
        methods: {
            ...mapMutations(['changeNewDialogVisibility', 'closeAllDialogs', 'showInfo', 'addAlert']),
            ...mapActions(['loadDataTable']),
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
                this.newModel.fechaCreacion = new Date().toISOString().substr(0, 10);
                this.$validator.reset();
                this.getCurrentMount();
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
            }
        },
        created() {
            this.getCurrentMount();
        }
    }
</script>