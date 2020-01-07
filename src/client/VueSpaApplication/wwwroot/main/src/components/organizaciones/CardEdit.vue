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
                                <EditUniqueEntity identifierName="Nombre de la organizacion" :identifierValue="this.CRUDModel.nombreOrganizacion"/>
                                <v-text-field
                                        v-model="CRUDModel.nombreOrganizacion"
                                        v-validate="'required|max:100'"
                                        :counter="100"
                                        :error-messages="errors.collect('nombreOrganizacion')"
                                        label="Nombre Organizacion*"
                                        data-vv-name="nombreOrganizacion"
                                        required
                                        @input="validateIdentifier()"
                                ></v-text-field>
                                <v-text-field
                                        v-model="CRUDModel.siglasOrganizacion"
                                        v-validate="'required|max:20'"
                                        :counter="20"
                                        :error-messages="errors.collect('siglasOrganizacion')"
                                        label="Siglas Organizacion*"
                                        data-vv-name="siglasOrganizacion"
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
                if(this.CRUDModel.nombreOrganizacion !== null)
                    if(this.CRUDModel.nombreOrganizacion.length > 0)
                        this.validateEditEntity({entityName:"organizacion",id:this.CRUDModel.id,identifier:this.CRUDModel.nombreOrganizacion});
            },
            disableSaveBtn(){
                return !this.isUniqueEntity;
            }
        }
    }
</script>