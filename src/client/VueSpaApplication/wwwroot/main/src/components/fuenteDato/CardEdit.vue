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
                                <EditUniqueEntity identifierName="Nombre de la fuente" :identifierValue="this.CRUDModel.nombreFuente"/>
                                <v-textarea
                                        v-model="CRUDModel.nombreFuente"
                                        v-validate="'required|max:500'"
                                        auto-grow filled
                                        :counter="500"
                                        :error-messages="errors.collect('nombreFuente')"
                                        label="Nombre fuente de datos"
                                        data-vv-name="nombreFuente"
                                        required
                                        @input="validateIdentifier()"
                                ></v-textarea>
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
                if(this.CRUDModel.nombreFuente !== null)
                    if(this.CRUDModel.nombreFuente.length > 0)
                        this.validateEditEntity({entityName:"fuente",id:this.CRUDModel.id,identifier:this.CRUDModel.nombreFuente});
            },
            disableSaveBtn(){
                return !this.isUniqueEntity;
            }
        }
    }
</script>