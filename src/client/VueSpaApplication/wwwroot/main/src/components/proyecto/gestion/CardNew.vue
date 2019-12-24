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
                    <v-btn dark text :disabled="disableSaveBtn()" @click="save()">Guardar</v-btn>
                </v-toolbar-items>
            </v-toolbar>
            <v-card-text>
                <v-container grid-list-md>
                    <v-layout row wrap>
                        <v-flex xs12>
                            <NewUniqueEntity identifierName="Nombre del proyecto" :identifierValue="this.newModel.nombreProyecto"/>
                            <v-textarea :counter="500" :error-messages="errors.collect('nombre')" auto-grow filled
                                        clearable data-vv-name="nombre" label="Nombre *" required
                                        v-model="newModel.nombreProyecto" v-validate="'required|max:500'"
                                        @input="validateIdentifier()"
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
                                               v-model="apDate" :max="apDateLimit"></v-date-picker>
                            </v-menu>
                            <v-spacer></v-spacer>
                            <v-menu
                                    :close-on-content-click="false"
                                    :nudge-right="40"
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
                                               v-model="startDate" :max="startDateMaxLimit" :min="startDateMinLimit"></v-date-picker>
                            </v-menu>
                            <v-spacer></v-spacer>
                            <v-menu
                                    :close-on-content-click="false"
                                    :nudge-right="40"
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
                                               v-model="endDate" :min="endDateLimit"></v-date-picker>
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
                <v-btn @click="changeNewDialogVisibility" color="gray darken-1" text>Cancelar</v-btn>
                <v-btn @click="save()" color="green darken-1" text :disabled="disableSaveBtn()">Guardar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapActions, mapMutations, mapState} from 'vuex'
    import NewUniqueEntity from "../../validation/NewUniqueEntity"
    export default {
        components: {NewUniqueEntity},
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
                datePickApro: false,
                notificationModel: {
                    titulo: 'Nuevo proyecto',
                    mensaje: null,
                    tipo: 'info',
                    rol: null,
                    pais: null,
                    nombreUsuario: null
                },
                endDateLimit: "",
                startDateMaxLimit:  "",
                startDateMinLimit:  "",
                apDateLimit: ""
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'visibleNewDialog', 'services','isUniqueEntity']),
            regionalCheck: {
                get: function () {
                    return this.newModel.regional;
                },
                set: function (newValue) {
                    this.newModel.regional = !this.newModel.regional;
                    this.newModel.paises = [];
                }
            },
            startDate: {
                get: function () {
                    return this.newModel.fechaInicio;
                },
                set: function (newValue) {
                    if (Date.parse(this.newModel.fechaFin) >= Date.parse(newValue) || Date.parse(this.newModel.fechaFin) === Date.parse(this.newModel.fechaInicio)){
                        this.newModel.fechaInicio = newValue;
                        this.endDateLimit = newValue.substr(0, 10);
                        this.apDateLimit = newValue.substr(0, 10);
                    }
                }
            },
            endDate: {
                get: function () {
                    return this.newModel.fechaFin;
                },
                set: function (newValue) {
                    if (Date.parse(this.newModel.fechaInicio) <= Date.parse(newValue) || Date.parse(this.newModel.fechaFin) === Date.parse(this.newModel.fechaInicio)){
                        this.newModel.fechaFin = newValue;
                        this.startDateMaxLimit = newValue.substr(0, 10);
                    }
                }
            },
            apDate: {
                get: function () {
                    return this.newModel.fechaAprobacion;
                },
                set: function (newValue) {
                    if ( Date.parse(this.newModel.fechaInicio) >= Date.parse(newValue) || Date.parse(this.newModel.fechaAprobacion) === Date.parse(this.newModel.fechaInicio)){
                        this.newModel.fechaAprobacion = newValue;
                        this.startDateMinLimit = newValue.substr(0, 10);
                    }
                }
            }
        },
        methods: {
            ...mapMutations(['changeNewDialogVisibility', 'closeAllDialogs', 'showInfo', 'addAlert']),
            ...mapActions(['loadDataTable','validateNewEntity']),
            save() {
                this.$validator.validateAll()
                    .then(v => {
                        if(!this.newModel.regional){
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
                            this.buildNotification();
                            this.services.alertaService.add(this.notificationModel)
                                .catch(e => {
                                    this.showInfo(e.toString());
                                });
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
                this.startDateLimit = '';
                this.endDateLimit = '';
                this.apDateLimit = '';
                this.$validator.reset();
            },
            buildNotification(){
                this.notificationModel.mensaje = 'Se a creado un nuevo proyecto con nombre: "' + this.newModel.nombreProyecto + '"';
                this.notificationModel.nombreUsuario = window.User.Nombre + ' ' + window.User.Apellido;
                this.notificationModel.pais = this.newModel.paises.map(function (item) {
                    return item.nombre;
                }).join("$");
                this.notificationModel.rol = "2$3"
            },
            validateIdentifier() {
                if(this.newModel.nombreProyecto !== null)
                    if(this.newModel.nombreProyecto.length > 0)
                        this.validateNewEntity({entityName:"proyecto",identifier:this.newModel.nombreProyecto});
            },
            disableSaveBtn(){
                return !this.isUniqueEntity;
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