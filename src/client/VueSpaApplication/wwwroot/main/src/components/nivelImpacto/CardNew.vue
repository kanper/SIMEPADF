<template>
    <v-dialog max-width="50%" persistent v-model="visibleNewDialog">
        <v-card>
            <v-card-title class="headline grey darken-3 white--text">Formulario de {{modelSpecification.modelTitle}}:
                Agregar nuevo
            </v-card-title>
            <v-card-text>
                <v-container grid-list-md>
                    <v-layout wrap>
                        <v-flex xs12>
                            <form>
                                <NewUniqueEntity identifierName="Nombre del nivel" :identifierValue="this.newModel.nombreNivel"/>
                                <v-text-field
                                        v-model="newModel.nombreNivel"
                                        v-validate="'required|max:100'"
                                        :counter="100"
                                        :error-messages="errors.collect('nombreNivel')"
                                        label="Nombre Nivel"
                                        data-vv-name="nombreNivel"
                                        required
                                        @input="validateIdentifier()"
                                ></v-text-field>
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
        data() {
            return {
                newModel: {
                    id: 0,
                    nombreNivel: ''
                }
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'visibleNewDialog', 'services', 'isUniqueEntity'])
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
                this.newModel.nombreNivel = '';
                this.$validator.reset();
            },
            validateIdentifier() {
                if(this.newModel.nombreNivel !== null)
                    if(this.newModel.nombreNivel.length > 0)
                        this.validateNewEntity({entityName:"nivel",identifier:this.newModel.nombreNivel});
            },
            disableSaveBtn(){
                return !this.isUniqueEntity;
            }
        }
    }
</script>