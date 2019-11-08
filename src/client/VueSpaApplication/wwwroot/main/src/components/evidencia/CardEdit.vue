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
                            <v-text-field
                                    v-model="nombre"
                                    v-validate="'required|max:100'"
                                    :counter="100"
                                    :error-messages="errors.collect('nombreArchivo')"
                                    label="Nombre archivo *"
                                    data-vv-name="Nombre del archivo"
                                    required
                            ></v-text-field>
                            <small>{{nombreCompleto}}</small>
                            <v-textarea
                                    outlined
                                    name="descripcion"
                                    label="Descripción"
                                    v-model="CRUDModel.descripcionArchivo"
                                    counter
                            ></v-textarea>
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
                tipoArchivo: '',
                nombreCompleto: '',
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'visibleEditDialog', 'CRUDModel', 'services']),
            nombre: {
                get: function () {
                    this.nombreCompleto = this.CRUDModel.nombreArchivo;
                    return this.splitFileName(this.CRUDModel.nombreArchivo);
                },
                set: function (newValue) {
                    this.CRUDModel.nombreArchivo = newValue + '.' + this.tipoArchivo;
                }
            }
        },
        methods: {
            ...mapMutations(['changeEditDialogVisibility', 'closeAllDialogs', 'showInfo', 'addAlert']),
            ...mapActions(['loadDataTable']),
            update() {
                this.$validator.validateAll()
                    .then(v => {
                        if (v) {
                            this.services[this.modelSpecification.modelService].updateFile(this.CRUDModel[this.modelSpecification.modelPK],this.CRUDModel)
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
            },
            splitFileName(fileName) {
                if(fileName === undefined || fileName === null) {
                    return '';
                }
                this.tipoArchivo = fileName.split('.')[1];
                return fileName.split('.')[0];
            }
        }
    }
</script>