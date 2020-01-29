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
                                <EditUniqueEntity identifierName="Nombre del indicador" :identifierValue="this.CRUDModel.nombreIndicador"/>
                                <v-textarea :counter="1000" :error-messages="errors.collect('nombre')" auto-grow filled
                                            clearable data-vv-name="nombre" label="Nombre *" required
                                            v-model="CRUDModel.nombreIndicador" v-validate="'required|max:1000'"
                                            @input="validateIdentifier()"
                                ></v-textarea>

                                <v-switch v-model="usePercent" label="Usar porcentaje"></v-switch>

                                <v-text-field :error-messages="errors.collect('metaGlobal')"
                                              clearable data-vv-name="metaGlobal" label="Meta Global *" required
                                              v-model="metaGlobal" v-validate="'required|min_value:0|max_value:2147483646|numeric'"
                                ></v-text-field>

                                <v-text-field :error-messages="errors.collect('meta')" :disabled="usePercent"
                                              clearable data-vv-name="meta" label="Meta Anual *" required
                                              v-model="metaAnual" v-validate="'required|numeric|min_value:0|max_value:'+ maxNum"
                                ></v-text-field>

                                <v-subheader class="pl-0">Porcetaje para la meta</v-subheader>
                                <v-flex text-xs-left>
                                  <span
                                          class="display-3 font-weight-light"
                                          v-text="porcentajeMeta"
                                  ></span>
                                    <span class="subheading font-weight-light mr-1">%</span>
                                </v-flex>
                                <v-slider
                                        v-if="usePercent"
                                        v-model="porcentajeMeta"
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
                <v-btn @click="update()" color="blue darken-1" text :disabled="disableSaveBtn()">Actualizar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapActions, mapMutations, mapState} from 'vuex'
    import EditUniqueEntity from "../validation/EditUniqueEntity";

    export default {
        components: {EditUniqueEntity},
        data() {
            return {
                slider: 0.0,
                usePercent: false,
                percentBase: 0,
                maxNum : 0,
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'visibleEditDialog', 'CRUDModel', 'services','isUniqueEntity']),
            porcentajeMeta: {
                get: function () {
                   if(Number.isNaN(this.CRUDModel.metaGlobal) || this.CRUDModel.metaGlobal === 0) {
                       return 0.0;
                   }else {
                       if(Number.isNaN(this.CRUDModel.valorMeta) || this.CRUDModel.valorMeta === 0){
                           return 0.0;
                       }else {
                           return (this.CRUDModel.valorMeta * 100) / this.CRUDModel.metaGlobal;
                       }
                   }
                },
                set: function (newValue) {
                    this.CRUDModel.valorMeta = ((newValue / 100) * this.CRUDModel.metaGlobal).toFixed(0);
                }
            },
            valorBase: {
                get: function () {
                    return this.CRUDModel.valorMeta;
                },
                set: function (newValue) {
                    if(newValue > 0 && newValue !== undefined){
                        this.percentBase = newValue;
                        this.CRUDModel.valorMeta = newValue;
                        this.CRUDModel.tipoBeneficiario = 'N';
                    }
                    this.usePercent = false;
                    this.slider = 0.0;
                }
            },
            metaGlobal: {
                get: function () {
                    return this.CRUDModel.metaGlobal;
                },
                set: function (newValue) {
                    this.CRUDModel.metaGlobal = newValue;
                    this.maxNum = newValue;
                }
            },
            metaAnual: {
                get: function () {
                    return this.CRUDModel.valorMeta;
                },
                set: function (newValue) {
                    this.CRUDModel.valorMeta = newValue;
                }
            }
        },
        methods: {
            ...mapMutations(['changeEditDialogVisibility', 'closeAllDialogs', 'showInfo', 'addAlert']),
            ...mapActions(['loadDataTable','validateEditEntity']),
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
                            this.resetForm();
                        } else {
                            this.showInfo(this.$validator.errors.all().toString());
                        }
                    })
                    .catch(e => {
                        this.showInfo(e.toString());
                    });
            },
            increment() {
                if(this.porcentajeMeta < 99.99)
                this.porcentajeMeta += 0.1;
            },
            decrement() {
                if(this.porcentajeMeta > 0.01)
                this.porcentajeMeta -= 0.1;
            },
            resetForm(){
                this.percentBase = 0;
                this.slider = 0.0;
                this.usePercent = false;
            },
            validateIdentifier() {
                if(this.CRUDModel.nombreIndicador !== null)
                    if(this.CRUDModel.nombreIndicador.length > 0)
                        this.validateEditEntity({entityName:"indicador",id:this.CRUDModel.id,identifier:this.CRUDModel.nombreIndicador});
            },
            disableSaveBtn(){
                return !this.isUniqueEntity;
            }
        }
    }
</script>