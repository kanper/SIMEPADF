<template>
    <v-dialog max-width="50%" persistent v-model="visibleNewDialog">
        <v-card>
            <v-card-title class="headline grey darken-3 white--text">Almacenamiento de {{modelSpecification.modelTitle}}:
                Cargar archivo
            </v-card-title>
            <v-card-text>
                <v-container grid-list-md>
                    <v-layout wrap>
                        <v-flex xs12>
                            <form enctype="multipart/form-data" method="post">
                                <v-file-input
                                        v-model="file"
                                        label="Subir archivo..."
                                        autofocus
                                        chips
                                        show-size
                                        accept=".doc,.docx,.pdf"
                                ></v-file-input>
                            </form>
                        </v-flex>
                    </v-layout>
                </v-container>
                <small>* Indica que el campo es requerido</small>
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn @click="changeNewDialogVisibility" color="gray darken-1" text>Cancelar</v-btn>
                <v-btn @click="upload()" color="green darken-1" text>Subir archivo</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapActions, mapMutations, mapState} from 'vuex'

    export default {
        data() {
            return {
                file: null,
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'visibleNewDialog', 'services', 'CRUDModel'])
        },
        methods: {
            ...mapMutations(['changeNewDialogVisibility', 'closeAllDialogs', 'showInfo', 'addAlert']),
            ...mapActions(['loadDataTable']),
            upload(){
                let formData = new FormData();
                formData.append('file',this.file,this.file.name);
                this.services[this.modelSpecification.modelService].upload(this.CRUDModel[this.modelSpecification.modelPK], formData)
                    .then(r => {
                        this.loadDataTable();
                        if (r.data) {
                            this.addAlert({
                                value: true,
                                color: 'success',
                                icon: 'mdi-checkbox-marked-circle-outline',
                                text: 'El archivo fue guardado correctamente.'
                            });
                        } else {
                            this.addAlert({
                                value: true,
                                color: 'error',
                                icon: 'mdi-close-circle-outline',
                                text: 'Ocurrio un problema al tratar de guardar el archivo seleccionado.'
                            });
                        }
                    })
                    .catch(e => {
                        this.showInfo(e.toString());
                    });
                this.closeAllDialogs();
                this.clearForm();
            },
            clearForm(){
                this.file = null;
                this.$validator.reset();
            }
        }
    }
</script>