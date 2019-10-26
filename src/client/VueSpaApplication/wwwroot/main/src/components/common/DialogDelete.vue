<template>
    <v-dialog max-width="50%" persistent v-model="visibleDeleteDialog">
        <v-card>
            <v-card-title class="headline red darken-2 white--text">Eliminar {{modelSpecification.modelTitle}}
            </v-card-title>
            <v-card-text>
                ¿Confirma eliminar los siguientes {{modelSpecification.modelTitle}} de la lista?
                <v-list two-line>
                    <v-list-tile avatar ripple>
                        <v-list-tile-content>
                            <v-list-tile-title>Nombre</v-list-tile-title>
                            <v-list-tile-sub-title>{{ CRUDModel[modelSpecification.modelStamp] }}
                            </v-list-tile-sub-title>
                        </v-list-tile-content>
                        <v-list-tile-action>
                            <v-icon color="grey lighten-1">mdi-delete-variant</v-icon>
                        </v-list-tile-action>
                    </v-list-tile>
                    <v-divider color="red"></v-divider>
                </v-list>
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn @click="changeDeleteDialogVisibility" color="gray darken-1" text>Cancelar</v-btn>
                <v-btn @click="deleteSelectedElements" color="red darken-1" text>Eliminar</v-btn>
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
                this.services[this.modelSpecification.modelService].remove(this.CRUDModel[this.modelSpecification.modelPK], this.modelSpecification.modelParams)
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