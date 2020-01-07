<template>
    <v-dialog max-width="50%" persistent v-model="visibleDeleteDialog">
        <v-card>
            <v-card-title class="headline red darken-2 white--text">Eliminar {{modelSpecification.modelTitle}}
            </v-card-title>
            <v-card-text>
                <v-card-subtitle>
                    ¿Confirma eliminar el siguiente {{modelSpecification.modelTitle}} de la lista?
                </v-card-subtitle>                
                <v-list-item three-line>
                    <v-list-item-icon>
                        <v-icon large color="grey lighten-1">mdi-delete-variant</v-icon>
                    </v-list-item-icon>
                    <v-list-item-content>
                        <v-list-item-title>Nombre:</v-list-item-title>
                        <v-list-item-subtitle>{{ CRUDModel.identificador }}</v-list-item-subtitle>
                    </v-list-item-content>                                        
                </v-list-item>
                <v-alert
                        icon="mdi-shield-lock-outline"
                        prominent
                        text
                        type="error"
                        v-show="!CRUDModel.removible"
                >
                    El registro "{{ CRUDModel.identificador }}" no puede ser eliminado hasta que se remuevan las dependencias existentes.
                </v-alert>
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn @click="changeDeleteDialogVisibility" color="gray darken-1" text>Cancelar</v-btn>
                <v-btn @click="deleteSelectedElements" color="red darken-1" text :disabled="!CRUDModel.removible">Eliminar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapActions, mapMutations, mapState} from 'vuex'

    export default {
        computed: {
            ...mapState(['modelSpecification', 'services', 'visibleDeleteDialog', 'CRUDModel'])
        },
        methods: {
            ...mapMutations(['changeDeleteDialogVisibility', 'closeAllDialogs', 'showInfo', 'addAlert']),
            ...mapActions(['loadDataTable']),
            deleteSelectedElements() {
                let modelId = this.CRUDModel.codigo === null ? this.CRUDModel.id : this.CRUDModel.codigo;
                this.services[this.modelSpecification.modelService].remove(modelId, this.modelSpecification.modelParams)
                    .then(r => {
                        this.loadDataTable();
                        if (r.data) {
                            this.addAlert({
                                value: true,
                                color: 'success',
                                icon: 'mdi-checkbox-marked-circle-outline',
                                text: 'El ' + this.modelSpecification.modelName + ' seleccionado se elimino correctamente.'
                            });
                        } else {
                            this.addAlert({
                                value: true,
                                color: 'error',
                                icon: 'mdi-close-circle-outline',
                                text: 'Ocurrio un problema al tratar de eliminar el ' + this.modelSpecification.modelName + ' seleccionado.'
                            });
                        }
                    })
                    .catch(e => {
                        this.showInfo(e.toString());
                    });
                this.closeAllDialogs();
            }
        }
    }
</script>