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
                                <v-textarea :counter="50" :error-messages="errors.collect('metodología')" auto-grow filled
                                            clearable data-vv-name="metodologia" label="Metodología *" required
                                            v-model="CRUDModel.metodologia" v-validate="'required|max:50'"
                                ></v-textarea>
                                <v-textarea :counter="50" :error-messages="errors.collect('linea base')" auto-grow filled
                                            clearable data-vv-name="lineaBase" label="Linea Base *" required
                                            v-model="CRUDModel.lineaBase" v-validate="'required|max:50'"
                                ></v-textarea>
                                <v-combobox
                                        v-model="CRUDModel.fuenteDato"
                                        :items="fuentes"
                                        item-text="nombre"
                                        label="Seleccionar la fuente de datos"
                                        required
                                ></v-combobox>
                                <v-combobox
                                        v-model="CRUDModel.frecuenciaMedicion"
                                        :items="frecuencias"
                                        item-text="nombre"
                                        label="Seleccionar la frecuencia de medición"
                                        required
                                ></v-combobox>
                                <v-combobox
                                        v-model="CRUDModel.nivelImpacto"
                                        :items="niveles"
                                        item-text="nombre"
                                        label="Seleccionar el nivel de impacto"
                                        required
                                ></v-combobox>
                                <v-combobox
                                        v-model="CRUDModel.desagregaciones"
                                        :items="desagregaciones"
                                        item-text="nombre"
                                        item-value="id"
                                        label="Seleccione una o varias desagregaciones"
                                        multiple
                                        required
                                ></v-combobox>
                            </form>
                        </v-flex>
                    </v-layout>
                </v-container>
                <small>* Indica que el campo es requerido</small>
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn @click="changeEditDialogVisibility" color="gray darken-1" text>Cancelar</v-btn>
                <v-btn @click="update()" color="blue darken-1" text>Actualizar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapActions, mapMutations, mapState} from 'vuex'

    export default {
        data() {
            return {
                fuentes: [],
                frecuencias: [],
                niveles: [],
                desagregaciones: []
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'visibleEditDialog', 'CRUDModel', 'services'])
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
        },
        created() {
            this.services.proyectoHelperService.getFuentes()
                .then(r => {
                    this.fuentes = r.data;
                })
                .catch(e => {
                    this.showInfo(e.toString());
                });
            this.services.proyectoHelperService.getFrecuencias()
                .then(r => {
                    this.frecuencias = r.data;
                })
                .catch(e => {
                    this.showInfo(e.toString());
                });
            this.services.proyectoHelperService.getNiveles()
                .then(r => {
                    this.niveles = r.data;
                })
                .catch(e => {
                    this.showInfo(e.toString());
                });
            this.services.proyectoHelperService.getDesagregaciones()
                .then(r => {
                    this.desagregaciones = r.data;
                })
                .catch(e => {
                    this.showInfo(e.toString());
                });
        }
    }
</script>