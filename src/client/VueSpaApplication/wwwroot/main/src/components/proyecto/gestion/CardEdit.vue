<template xmlns:v-slot="http://www.w3.org/1999/XSL/Transform">
    <v-dialog fullscreen v-model="visibleEditDialog" hide-overlay transition="dialog-bottom-transition">
        <v-card>
            <v-toolbar dark color="black">
                <v-btn icon dark @click="changeEditDialogVisibility">
                    <v-icon>mdi-close</v-icon>
                </v-btn>
                <v-toolbar-title>Formulario de {{modelSpecification.modelTitle}}: Editar registro</v-toolbar-title>
                <v-spacer></v-spacer>
                <v-toolbar-items>
                    <v-btn dark text @click="update()">Actualizar</v-btn>
                </v-toolbar-items>
            </v-toolbar>
            <v-card-text>
                <v-container grid-list-md>
                    <v-layout row wrap>
                        <v-flex xs12>
                            <v-textarea :counter="500" :error-messages="errors.collect('nombre')" auto-grow filled
                                        clearable data-vv-name="nombre" label="Nombre *" required
                                        v-model="CRUDModel.nombreProyecto" v-validate="'required|max:500'"
                            ></v-textarea>
                            <v-switch v-model="CRUDModel.regional" label="Regional"></v-switch>
                        </v-flex>
                        <v-flex xs6>
                            <v-text-field
                                    :error-messages="errors.collect('montoObjetivo')"
                                    data-vv-name="monto"
                                    label="Monto"
                                    required
                                    v-model="CRUDModel.montoProyecto"
                                    v-validate="'required|min_value:0|decimal:2'"
                            ></v-text-field>
                            <v-text-field
                                    :error-messages="errors.collect('beneficiarios')"
                                    data-vv-name="beneficiarios"
                                    label="Beneficiarios"
                                    required
                                    v-model="CRUDModel.beneficiarios"
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
                                            v-model="approvedDate"
                                            v-on="on"
                                    ></v-text-field>
                                </template>
                                <v-date-picker @input="datePickApro = false" locale="es-es"
                                               v-model="approvedDate"></v-date-picker>
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
                                            v-model="startDate"
                                            v-on="on"
                                    ></v-text-field>
                                </template>
                                <v-date-picker @input="datePickInicio = false" locale="es-es"
                                               v-model="startDate"></v-date-picker>
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
                                            v-model="endDate"
                                            v-on="on"
                                    ></v-text-field>
                                </template>
                                <v-date-picker @input="datePickFin = false" locale="es-es"
                                               v-model="endDate"></v-date-picker>
                            </v-menu>
                        </v-flex>
                        <v-flex xs6>
                            <v-combobox
                                    :items="paises"
                                    item-text="nombre"
                                    label="Seleccione uno o varios paises"
                                    multiple
                                    required
                                    v-model="CRUDModel.paises"
                            ></v-combobox>
                            <v-combobox
                                    :items="socios"
                                    item-text="nombre"
                                    label="Seleccione una o varios Socios"
                                    multiple
                                    required
                                    v-model="CRUDModel.socios"
                            ></v-combobox>
                            <v-combobox
                                    :items="organizaciones"
                                    item-text="nombre"
                                    label="Seleccione una o varias organizaciones"
                                    multiple
                                    required
                                    v-model="CRUDModel.organizaciones"
                            ></v-combobox>
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
                paises: [],
                organizaciones: [],
                socios: [],
                datePickInicio: false,
                datePickFin : false,
                datePickApro: false
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'visibleEditDialog', 'CRUDModel', 'services']),
            approvedDate: {
                get: function () {
                    if(this.CRUDModel.fechaAprobacion === undefined){
                        return new Date().toISOString().substr(0, 10);
                    }
                    return this.CRUDModel.fechaAprobacion.split('T')[0];
                },
                set: function (newValue) {
                    this.CRUDModel.fechaAprobacion = newValue;
                }
            },
            startDate: {
                get: function () {
                    if (this.CRUDModel.fechaInicio === undefined){
                        return new Date().toISOString().substr(0, 10);
                    }
                    return this.CRUDModel.fechaInicio.split('T')[0];
                },
                set: function (newValue) {
                    this.CRUDModel.fechaInicio = newValue;
                }
            },
            endDate: {
                get: function () {
                    if (this.CRUDModel.fechaFin === undefined) {
                        return new Date().toISOString().substr(0, 10);
                    }
                    return this.CRUDModel.fechaFin.split('T')[0];
                },
                set: function (newValue) {
                    this.CRUDModel.fechaFin = newValue;
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