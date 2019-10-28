<template>
    <v-dialog max-width="50%" persistent v-model="visibleEditDialog">
        <v-card>
            <v-card-title class="headline grey darken-3 white--text">Almacenamiento de {{modelSpecification.modelTitle}}:
                Editar archivos
            </v-card-title>
            <v-card-text>
                <v-container grid-list-md>
                    <v-layout wrap>
                        <v-flex xs12>
                            <form>
                                  <v-file-input 
                                    v-model="file" 
                                    label="Subir archivo..." 
                                    autofocus 
                                    chips 
                                    show-size 
                                    accept=".doc,.docx,.pdf"                                    
                                    ></v-file-input>                             
                                  
                                  <v-textarea
                                    outlined
                                    name="descripcion"
                                    label="Descripción (Opcional)"
                                    v-model="descripcion"
                                    counter
                                    ></v-textarea>
                            </form>
                        </v-flex>
                    </v-layout>
                </v-container>            
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn @click="changeEditDialogVisibility" color="gray darken-1" text>Cancelar</v-btn>
                <v-btn @click="upload()" color="blue darken-1" text>Subir archivo</v-btn>
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
                descripcion:''
            }
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
            },
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
            }
        }
    }
</script>