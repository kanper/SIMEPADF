<template>
    <v-dialog max-width="50%" persistent v-model="visibleEditDialog">
        <v-card>
            <v-card-title class="headline grey darken-3 white--text">Formulario de {{modelSpecification.modelTitle}}:
                Editar registro
            </v-card-title>
            <v-card-text>
                <v-container grid-list-md>
                    <v-layout wrap>
                        <v-flex xs12>
                            <form>
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
                                                label="Fecha de creación"
                                                prepend-icon="mdi-calendar"
                                                readonly
                                                v-model="startDate"
                                                v-on="on"
                                        ></v-text-field>
                                    </template>
                                    <v-date-picker @input="datePick = false" locale="es-es"
                                                   v-model="startDate"></v-date-picker>
                                </v-menu>
                            </form>
                        </v-flex>
                    </v-layout>
                </v-container>
                <small>* Indica que el campo es requerido</small>
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn @click="changeEditDialogVisibility" color="gray darken-1" flat>Cancelar</v-btn>
                <v-btn @click="update()" color="blue darken-1" flat>Actualizar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapActions, mapMutations, mapState} from 'vuex'

    export default {
        data() {
            return {
                datePick: false
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'visibleEditDialog', 'CRUDModel', 'services']),
            startDate: {
                get: function () {
                    if (this.CRUDModel.fechaCreacion === undefined){
                        return new Date().toISOString().substr(0, 10);
                    }
                    return this.CRUDModel.fechaCreacion.split('T')[0];
                },
                set: function (newValue) {
                    this.CRUDModel.fechaCreacion = newValue;
                }
            },
        },
        methods: {
            ...mapMutations(['changeEditDialogVisibility', 'closeAllDialogs', 'showInfo', 'addAlert']),
            ...mapActions(['loadDataTable']),
            update() {
                this.$validator.validateAll()
                    .then(v => {
                        if (v) {
                            this.services[this.modelSpecification.modelService].update(this.CRUDModel, this.CRUDModel[this.modelSpecification.modelPK], this.modelSpecification.modelParams)
                                .then(r => {
                                    this.loadDataTable();
                                    if (r.data) {
                                        this.addAlert({
                                            value: true,
                                            color: 'success',
                                            icon: 'mdi-checkbox-marked-circle-outline',
                                            text: 'El ' + this.modelSpecification.modelName + ' seleccionado se guardo correctamente.'
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
            }
        }
    }
</script>