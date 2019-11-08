<template xmlns:v-slot="http://www.w3.org/1999/XSL/Transform">
    <v-dialog fullscreen v-model="visibleNewDialog" hide-overlay transition="dialog-bottom-transition">
        <v-card>
            <v-toolbar dark color="black">
                <v-btn icon dark @click="changeNewDialogVisibility">
                    <v-icon>mdi-close</v-icon>
                </v-btn>
                <v-toolbar-title>Formulario de {{modelSpecification.modelTitle}}: Plan de monitoreo y evaluación</v-toolbar-title>
                <v-spacer></v-spacer>
                <v-toolbar-items>
                    <v-btn dark text @click="save()">Guardar</v-btn>
                </v-toolbar-items>
            </v-toolbar>
            <v-card-text>
                <v-text-field
                        v-model="search"
                        append-icon=" mdi-magnify"
                        label="Buscar..."
                        single-line
                        hide-details
                ></v-text-field>
                <v-data-table
                        v-model="selected"
                        :headers="headers"
                        :items="indicadores"
                        :search="search"
                        item-key="id"
                        show-select
                        class="elevation-1"
                >
                </v-data-table>
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn @click="changeNewDialogVisibility" color="gray darken-1" text>Cancelar</v-btn>
                <v-btn @click="save()" color="green darken-1" text>Guardar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapActions, mapMutations, mapState} from 'vuex'

    export default {
        data() {
            return {
                search: '',
                selected: [],
                headers: [
                    {text: 'Objetivo', align: 'left', value: 'nombreObjetivo'},
                    {text: 'Resultado', align: 'left', value: 'nombreResultado'},
                    {text: 'Actividad', align: 'left', value: 'nombreActividad'},
                    {text: 'Indicador', align: 'left', value: 'nombreIndicador'},
                ],
                newModel: {

                },
                indicadores: [],
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'visibleNewDialog', 'services'])
        },
        methods: {
            ...mapMutations(['changeNewDialogVisibility', 'closeAllDialogs', 'showInfo', 'addAlert']),
            ...mapActions(['loadDataTable']),
            save() {
                this.$validator.validateAll()
                    .then(v => {
                        if (v) {
                            this.services[this.modelSpecification.modelService].add(this.selected, this.modelSpecification.modelParams)
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
                this.newModel.metodologia = '';
                this.newModel.lineaBase = '';
                this.$validator.reset();
            },
        },
        created() {
            this.services.proyectoHelperService.getUnselectedIndicadores(this.$route.params.id)
                .then(r => {
                   this.indicadores = r.data;
                })
                .catch(e =>{
                    this.showInfo(e.toString());
                });
        }
    }
</script>