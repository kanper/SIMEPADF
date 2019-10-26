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
                                <v-text-field
                                        v-model="CRUDModel.nombrePais"
                                        v-validate="'required|max:50'"
                                        :counter="50"
                                        :error-messages="errors.collect('nombrePais')"
                                        label="Nombre Pais*"
                                        data-vv-name="nombrePais"
                                        required
                                ></v-text-field>
                                <v-text-field
                                        v-model="CRUDModel.siglaPais"
                                        v-validate="'required|max:10'"
                                        :counter="10"
                                        :error-messages="errors.collect('siglaPais')"
                                        label="Siglas Pais*"
                                        data-vv-name="siglaPais"
                                        required
                                ></v-text-field>
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
            return {}
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
        }
    }
</script>