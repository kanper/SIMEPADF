<template xmlns:v-slot="http://www.w3.org/1999/XSL/Transform">
    <v-dialog fullscreen v-model="visibleNewDialog" hide-overlay transition="dialog-bottom-transition">
        <v-card>
            <v-toolbar dark color="black">
                <v-btn icon dark @click="changeNewDialogVisibility">
                    <v-icon>mdi-close</v-icon>
                </v-btn>
                <v-toolbar-title>Formulario de {{modelSpecification.modelTitle}}: Agregar nuevo</v-toolbar-title>
                <v-spacer></v-spacer>
                <v-toolbar-items>
                    <v-btn dark flat @click="save()">Guardar</v-btn>
                </v-toolbar-items>
            </v-toolbar>
            <v-card-text>
                <v-container grid-list-md>
                    <v-layout row wrap>
                        <v-flex xs12>
                            <v-textarea :counter="500" :error-messages="errors.collect('nombre')" auto-grow box
                                        clearable data-vv-name="nombre" label="Nombre *" required
                                        v-model="newModel.nombreProyecto" v-validate="'required|max:500'"
                            ></v-textarea>
                            <v-switch v-model="regionalCheck" label="Regional"></v-switch>
                        </v-flex>
                        <v-flex xs6>
                            <v-text-field
                                    :error-messages="errors.collect('montoObjetivo')"
                                    data-vv-name="monto"
                                    label="Monto en USD"
                                    required
                                    v-model="newModel.montoProyecto"
                                    v-validate="'required|min_value:0|decimal:2'"
                            ></v-text-field>
                            <v-text-field
                                    :error-messages="errors.collect('beneficiarios')"
                                    data-vv-name="beneficiarios"
                                    label="Numero de Beneficiarios"
                                    required
                                    v-model="newModel.beneficiarios"
                                    v-validate="'required|min_value:0|numeric'"
                            ></v-text-field>
                            <v-spacer></v-spacer>
                            <v-menu
                                    :close-on-content-click="false"
                                    :nudge-right="40"
                                    full-width
                                    lazy
                                    min-width="290px"
                                    offset-y
                                    transition="scale-transition"
                                    v-model="datePickApro"
                            >
                                <template v-slot:activator="{ on }">
                                    <v-text-field
                                            label="Fecha aprobación"
                                            prepend-icon="mdi-calendar"
                                            readonly
                                            v-model="newModel.fechaAprobacion"
                                            v-on="on"
                                    ></v-text-field>
                                </template>
                                <v-date-picker @input="datePickApro = false" locale="es-es"
                                               v-model="newModel.fechaAprobacion"></v-date-picker>
                            </v-menu>
                            <v-spacer></v-spacer>
                            <v-menu
                                    :close-on-content-click="false"
                                    :nudge-right="40"
                                    full-width
                                    lazy
                                    min-width="290px"
                                    offset-y
                                    transition="scale-transition"
                                    v-model="datePickInicio"
                            >
                                <template v-slot:activator="{ on }">
                                    <v-text-field
                                            label="Fecha inicio"
                                            prepend-icon="mdi-calendar"
                                            readonly
                                            v-model="newModel.fechaInicio"
                                            v-on="on"
                                    ></v-text-field>
                                </template>
                                <v-date-picker @input="datePickInicio = false" locale="es-es"
                                               v-model="newModel.fechaInicio"></v-date-picker>
                            </v-menu>
                            <v-spacer></v-spacer>
                            <v-menu
                                    :close-on-content-click="false"
                                    :nudge-right="40"
                                    full-width
                                    lazy
                                    min-width="290px"
                                    offset-y
                                    transition="scale-transition"
                                    v-model="datePickFin"
                            >
                                <template v-slot:activator="{ on }">
                                    <v-text-field
                                            label="Fecha Fin"
                                            prepend-icon="mdi-calendar"
                                            readonly
                                            v-model="newModel.fechaFin"
                                            v-on="on"
                                    ></v-text-field>
                                </template>
                                <v-date-picker @input="datePickFin = false" locale="es-es"
                                               v-model="newModel.fechaFin"></v-date-picker>
                            </v-menu>
                        </v-flex>
                        <v-flex xs6>
                            <v-combobox v-if="newModel.regional === true"
                                    :items="paises"
                                    item-text="nombre"
                                    label="Seleccione uno o varios paises"
                                    multiple
                                    required
                                    v-model="newModel.paises"
                            ></v-combobox>
                            <v-combobox v-if="newModel.regional === false"
                                    :items="paises"
                                    item-text="nombre"
                                    label="Seleccione un pais"
                                    required
                                    v-model="regionPais"
                            ></v-combobox>
                            <v-combobox
                                    :items="socios"
                                    item-text="nombre"
                                    label="Seleccione una o varios Socios"
                                    multiple
                                    required
                                    v-model="newModel.socios"
                            ></v-combobox>
                            <v-combobox
                                    :items="organizaciones"
                                    item-text="nombre"
                                    label="Seleccione una o varias organizaciones"
                                    multiple
                                    required
                                    v-model="newModel.organizaciones"
                            ></v-combobox>
                        </v-flex>
                    </v-layout>
                </v-container>
                <small>* Indica que el campo es requerido</small>
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn @click="changeNewDialogVisibility" color="gray darken-1" flat>Cancelar</v-btn>
                <v-btn @click="save()" color="green darken-1" flat>Guardar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapActions, mapMutations, mapState} from 'vuex'

    export default {
        data() {
            return {
                newModel: {
                    codigoProyecto: '',
                    regional: false,
                    nombreProyecto: '',
                    montoProyecto: 0.0,
                    beneficiarios: 0,
                    estadoProyecto: '',
                    fechaAprobacion: new Date().toISOString().substr(0, 10),
                    fechaInicio: new Date().toISOString().substr(0, 10),
                    fechaFin: new Date().toISOString().substr(0, 10),
                    paises: [],
                    organizaciones: [],
                    socios: []
                },
                paises: [],
                organizaciones: [],
                socios: [],
                regionPais: null,
                datePickInicio: false,
                datePickFin : false,
                datePickApro: false
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'visibleNewDialog', 'services']),
            regionalCheck: {
                get: function () {
                    return this.newModel.regional;
                },
                set: function (newValue) {
                    this.newModel.regional = !this.newModel.regional;
                    this.newModel.paises = [];
                }
            }
        },
        methods: {
            ...mapMutations(['changeNewDialogVisibility', 'closeAllDialogs', 'showInfo', 'addAlert']),
            ...mapActions(['loadDataTable']),
            save() {
                this.$validator.validateAll()
                    .then(v => {
                        if(this.newModel.regional){
                            this.newModel.paises.push(this.regionPais);
                        }
                        if (v) {
                            this.services[this.modelSpecification.modelService].add(this.newModel, this.modelSpecification.modelParams)
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
                this.newModel.nombreProyecto = '';
                this.newModel.regional = false;
                this.newModel.montoProyecto = 0.0;
                this.newModel.beneficiarios = 0;
                this.newModel.estadoProyecto = '';
                this.newModel.fechaInicio = new Date().toISOString().substr(0, 10);
                this.newModel.fechaFin = new Date().toISOString().substr(0, 10);
                this.newModel.fechaAprobacion = new Date().toISOString().substr(0, 10);
                this.newModel.paises = [];
                this.newModel.socios = [];
                this.newModel.organizaciones = [];
                this.$validator.reset();
            }
        },
        created() {
            this.services.proyectoHelperService.getPaises()
                .then(r => {
                    this.paises = r.data;
                }).catch(e => {
                this.showInfo(e.toString());
            });
            this.services.proyectoHelperService.getOrganizaciones()
                .then(r => {
                    this.organizaciones = r.data;
                }).catch(e => {
                this.showInfo(e.toString());
            });
            this.services.proyectoHelperService.getSocios()
                .then(r => {
                    this.socios = r.data;
                }).catch(e => {
                this.showInfo(e.toString());
            });
        }
    }
</script>