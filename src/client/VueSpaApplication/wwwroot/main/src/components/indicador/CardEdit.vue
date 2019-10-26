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
                                <v-textarea :counter="1000" :error-messages="errors.collect('nombre')" auto-grow box
                                            clearable data-vv-name="nombre" label="Nombre *" required
                                            v-model="CRUDModel.nombreIndicador" v-validate="'required|max:1000'"
                                ></v-textarea>

                                <v-switch v-model="usePercent" label="Agregar porcentaje"></v-switch>

                                <v-text-field :error-messages="errors.collect('meta')" v-if="!usePercent"
                                              clearable data-vv-name="meta" label="Meta *" required
                                              v-model="CRUDModel.valorMeta" v-validate="'required|min_value:0|max_value:2147483646|numeric'"
                                ></v-text-field>
                                <v-subheader class="pl-0">Porcetaje para la meta</v-subheader>
                                <v-flex text-xs-left>
                                  <span
                                          class="display-3 font-weight-light"
                                          v-text="slider"
                                  ></span>
                                    <span class="subheading font-weight-light mr-1">%</span>
                                </v-flex>
                                <v-slider
                                        v-if="usePercent"
                                        v-model="slider"
                                        thumb-label
                                        min="0.0"
                                        max="100.0"
                                        step="0.1"
                                >
                                    <template v-slot:prepend>
                                        <v-icon
                                                @click="decrement"
                                        >
                                            mdi-minus
                                        </v-icon>
                                    </template>

                                    <template v-slot:append>
                                        <v-icon
                                                @click="increment"
                                        >
                                            mdi-plus
                                        </v-icon>
                                    </template>
                                </v-slider>
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
                slider: 0.0,
                usePercent: false
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
                        this.setModelSelectedValue();
                        if (v) {
                            this.services[this.modelSpecification.modelService].update(this.CRUDModel, this.CRUDModel[this.modelSpecification.modelPK], this.modelSpecification.modelParams)
                                .then(r => {
                                    this.loadDataTable();
                                    this.resetSlider();
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
            },
            increment() {
                if(this.slider < 99.99)
                this.slider += 0.1;
            },
            decrement() {
                if(this.slider > 0.01)
                this.slider -= 0.1;
            },
            setModelSelectedValue() {
                if (this.usePercent) {
                    this.CRUDModel.valorMeta = 0;
                    this.CRUDModel.porcentajeMeta = this.slider;
                } else {
                    this.CRUDModel.porcentajeMeta = 0.0;
                }
            },
            resetSlider(){
                this.slider = 0.0;
                this.usePercent = false;
            }
        }
    }
</script>