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
                            <EditUniqueEntity identifierName="Nombre del socio" :identifierValue="this.CRUDModel.nombreSocio"/>
                            <v-text-field
                                        v-model="CRUDModel.nombreSocio"
                                        v-validate="'required|max:100'"
                                        :counter="100"
                                        :error-messages="errors.collect('nombreSocio')"
                                        label="Nombre Socio*"
                                        data-vv-name="nombreSocio"
                                        required
                                        @input="validateIdentifier()"
                                ></v-text-field>
                                <v-text-field
                                        v-model="CRUDModel.siglasSocio"
                                        v-validate="'required|max:20'"
                                        :counter="20"
                                        :error-messages="errors.collect('siglasSocio')"
                                        label="Siglas Socio*"
                                        data-vv-name="siglasSocio"
                                        required
                                ></v-text-field>
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
            return {}
        },
        computed: {
            ...mapState(['modelSpecification', 'visibleEditDialog', 'CRUDModel', 'services','isUniqueEntity'])
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
                        } else {
                            this.showInfo(this.$validator.errors.all().toString());
                        }
                    })
                    .catch(e => {
                        this.showInfo(e.toString());
                    });
            },
            validateIdentifier() {
                if(this.CRUDModel.nombreSocio !== null)
                    if(this.CRUDModel.nombreSocio.length > 0)
                        this.validateEditEntity({entityName:"socio",id:this.CRUDModel.id,identifier:this.CRUDModel.nombreSocio});
            },
            disableSaveBtn(){
                return !this.isUniqueEntity;
            }
        }
    }
</script>