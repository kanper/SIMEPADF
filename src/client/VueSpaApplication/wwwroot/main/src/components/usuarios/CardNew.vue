<template>
    <v-dialog
            fullscreen
            hide-overlay
            persistent
            transition="dialog-bottom-transition"
            v-model="visibleNewDialog"
    >
        <v-card>
            <v-toolbar color="black" dark>
                <v-btn @click="changeNewDialogVisibility" dark icon>
                    <v-icon>mdi-close</v-icon>
                </v-btn>
                <v-toolbar-title>Formulario de {{modelSpecification.modelTitle}}: Agregar nuevo</v-toolbar-title>
                <v-spacer></v-spacer>
                <v-toolbar-items>
                    <v-btn :disabled="disableSaveBtn()" @click="save()" dark text>Guardar</v-btn>
                </v-toolbar-items>
            </v-toolbar>
            <v-card-text>
                <v-container grid-list-md>
                    <v-layout row wrap>
                        <v-flex xs6>
                            <v-text-field
                                    :counter="50"
                                    :error-messages="errors.collect('nombre')"
                                    data-vv-name="nombrePersonal"
                                    label="Nombres *"
                                    required
                                    v-model="newModel.nombrePersonal"
                                    v-validate="'required|max:50'"
                            ></v-text-field>
                            <v-text-field
                                    :counter="50"
                                    :error-messages="errors.collect('apellidoPersonal')"
                                    data-vv-name="apellidoPersonal"
                                    label="Apellidos *"
                                    required
                                    v-model="newModel.apellidoPersonal"
                                    v-validate="'required|max:50'"
                            ></v-text-field>
                            <v-spacer></v-spacer>
                            <v-text-field
                                    :counter="50"
                                    :error-messages="errors.collect('cargo')"
                                    data-vv-name="cargo"
                                    label="Cargo *"
                                    required
                                    v-model="newModel.cargo"
                                    v-validate="'required|max:50'"
                            ></v-text-field>
                            <v-text-field
                                    :error-messages="errors.collect('phoneNumber')"
                                    :rules="phoneRules"
                                    data-vv-name="phoneNumber"
                                    hint="(###) ####-####"
                                    label="Teléfono *"
                                    persistent-hint
                                    required
                                    v-model="newModel.phoneNumber"
                            ></v-text-field>
                        </v-flex>
                        <v-spacer></v-spacer>
                        <v-flex xs6>
                            <NewUniqueEntity :identifierValue="this.newModel.email"
                                             identifierName="Correo electrónico"/>
                            <v-text-field
                                    :error-messages="errors.collect('email')"
                                    :rules="emailRules"
                                    @input="validateIdentifier()"
                                    data-vv-name="email"
                                    label="Correo *"
                                    required
                                    v-model="newModel.email"
                            ></v-text-field>
                            <v-text-field
                                    :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                                    :error-messages="errors.collect('password')"
                                    :type="show1 ? 'text' : 'password'"
                                    @click:append="show1 = !show1"
                                    data-vv-name="password"
                                    hint="al menos 8 caracteres"
                                    label="Contraseña *"
                                    required
                                    v-model="newModel.password"
                                    v-validate="'required|min:8'"
                            ></v-text-field>
                            <v-spacer></v-spacer>
                            <v-combobox
                                    :items="roles"
                                    :return-object="false"
                                    item-text="nombre"
                                    label="Seleccione el Rol del usuario *"
                                    required
                                    v-model="newModel.name"
                            ></v-combobox>
                            <v-combobox
                                    :items="paises"
                                    :return-object="false"
                                    item-text="nombre"
                                    label="Seleccione un país *"
                                    required
                                    v-model="newModel.pais"
                            ></v-combobox>
                        </v-flex>
                    </v-layout>
                </v-container>
                <small>* Indica que el campo es requerido</small>
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn @click="changeNewDialogVisibility" color="gray darken-1" text>Cancelar</v-btn>
                <v-btn :disabled="disableSaveBtn()" @click="save()" color="green darken-1" text>Guardar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapActions, mapMutations, mapState} from "vuex";
    import NewUniqueEntity from "../validation/NewUniqueEntity";

    export default {
        components: {NewUniqueEntity},
        data() {
            return {
                newModel: {
                    id: "",
                    nombrePersonal: "",
                    apellidoPersonal: "",
                    cargo: "",
                    email: "",
                    password: "",
                    phoneNumber: "",
                    fechaAfilacion: new Date().toISOString().substr(0, 10),
                    pais: "",
                    name: "",
                },
                emailRules: [
                    v => !!v || 'El Correo Electrónico es Obligatorio',
                    v => /.+@.+\..+/.test(v) || 'El Correo Electrónico debe ser válido',
                ],
                phoneRules: [
                    v => !!v || 'El Número de Teléfono es Obligatorio',
                    v => /\(([0-9]{3})\)([ ])([0-9]{4})+-.+[0-9]{3}/.test(v) || 'El Número de Teléfono seguir el pátron: (###) ####-####',
                ],
                show1: false,
                paises: [],
                roles: [],
                datePickInicio: false,
                datePickFin: false,
                datePickApro: false,
            };
        },
        computed: {
            ...mapState(["modelSpecification", "visibleNewDialog", "services", "isUniqueEntity"])
        },
        methods: {
            ...mapMutations([
                "changeNewDialogVisibility",
                "closeAllDialogs",
                "showInfo",
                "addAlert"
            ]),
            ...mapActions(["loadDataTable", "validateNewEntity"]),
            save() {
                this.$validator
                    .validateAll()
                    .then(v => {
                        if (v) {
                            this.services[this.modelSpecification.modelService].add(this.newModel, this.modelSpecification.modelParams)
                                .then(r => {
                                    if (r.data) {
                                        this.addAlert({
                                            value: true,
                                            color: "success",
                                            icon: "mdi-checkbox-marked-circle-outline",
                                            text:
                                                "El nuevo " +
                                                this.modelSpecification.modelName +
                                                " se guardo correctamente."
                                        });
                                    } else {
                                        this.addAlert({
                                            value: true,
                                            color: "error",
                                            icon: "mdi-close-circle-outline",
                                            text:
                                                "Ocurrio un problema al tratar de guardar el " +
                                                this.modelSpecification.modelName +
                                                " seleccionado."
                                        });
                                    }
                                    this.loadDataTable();
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
                    })
                    .finally(() => {
                      this.resetForm();
                    });
            },
            resetForm() {
                this.newModel.id = "";
                this.newModel.nombrePersonal = "";
                this.newModel.apellidoPersonal = "";
                this.newModel.cargo = "";
                this.newModel.email = "";
                this.newModel.password = "";
                this.newModel.phoneNumber = "";
                this.newModel.pais = "";
                this.newModel.name = "";
            },
            validateIdentifier() {
                if (this.newModel.email !== null)
                    if (this.newModel.email.length > 0)
                        this.validateNewEntity({entityName: "usuario", identifier: this.newModel.email});
            },
            disableSaveBtn() {
                return !this.isUniqueEntity;
            }
        },
        created() {
            this.services.proyectoHelperService.getPaises()
                .then(r => {
                    this.paises = r.data;
                })
                .catch(e => {
                    this.showInfo(e.toString());
                });
            this.services.proyectoHelperService.getRoles()
                .then(r => {
                    this.roles = r.data;
                })
                .catch(e => {
                    this.showInfo(e.toString());
                });
        }
    };
</script>