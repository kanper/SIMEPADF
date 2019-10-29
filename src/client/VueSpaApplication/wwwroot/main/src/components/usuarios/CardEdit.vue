<template xmlns:v-slot="http://www.w3.org/1999/XSL/Transform">
  <v-dialog
    fullscreen
    v-model="visibleEditDialog"
    hide-overlay
    transition="dialog-bottom-transition"
  >
    <v-card>
      <v-toolbar dark color="black">
        <v-btn icon dark @click="changeEditDialogVisibility">
          <v-icon>mdi-close</v-icon>
        </v-btn>
        <v-toolbar-title>Formulario de {{modelSpecification.modelTitle}}: Editar Registro</v-toolbar-title>
        <v-spacer></v-spacer>
        <v-toolbar-items>
          <v-btn dark text @click="update()">Actualizar</v-btn>
        </v-toolbar-items>
      </v-toolbar>
      <v-card-text>
        <v-container grid-list-md>
          <v-layout row wrap>
            <v-flex xs6>
              <v-text-field
                :error-messages="errors.collect('nombre')"
                :counter="50"
                data-vv-name="nombrePersonal"
                label="Nombres *"
                required
                v-model="CRUDModel.nombrePersonal"
                v-validate="'required|max:50'"
                outlined
              ></v-text-field>
              <v-text-field
                :error-messages="errors.collect('apellidoPersonal')"
                :counter="50"
                data-vv-name="apellidoPersonal"
                label="Apellidos *"
                required
                v-model="CRUDModel.apellidoPersonal"
                v-validate="'required|max:50'"
              ></v-text-field>
              <v-spacer></v-spacer>
              <v-text-field
                :error-messages="errors.collect('cargo')"
                :counter="50"
                data-vv-name="cargo"
                label="Cargo *"
                required
                v-model="CRUDModel.cargo"
                v-validate="'required|max:50'"
              ></v-text-field>
              <v-text-field
                :error-messages="errors.collect('phoneNumber')"
                data-vv-name="phoneNumber"
                label="Telefono *"
                required
                v-model="CRUDModel.phoneNumber"
                :rules="phoneRules"
              ></v-text-field>
            </v-flex>
            <v-spacer></v-spacer>
            <v-flex xs6>
              <v-text-field
                :error-messages="errors.collect('email')"
                data-vv-name="email"
                label="Correo *"
                required
                v-model="CRUDModel.email"
                :rules="emailRules"
              ></v-text-field>
              <v-text-field
                :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                :error-messages="errors.collect('password')"
                :type="show1 ? 'text' : 'password'"
                hint="al menos 8 caracteres"
                data-vv-name="password"
                label="Contraseña Nueva*"
                required
                @click:append="show1 = !show1"
                v-model="CRUDModel.newPassword"
                v-validate="'required|min:8'"
              ></v-text-field>
              <v-spacer></v-spacer>
              <v-combobox
                :items="paises"
                item-text="nombre"
                label="Seleccione un pais *"
                required
                v-model="pais"
                :return-object="false"
              ></v-combobox>
            </v-flex>
          </v-layout>
        </v-container>
        <small>* Indica que el campo es requerido</small>
      </v-card-text>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn @click="changeEditDialogVisibility" color="gray darken-1" text>Cancelar</v-btn>
        <v-btn @click="update()" color="green darken-1" text>Actualizar</v-btn>
      </v-card-actions>
    </v-card>
  </v-dialog>
</template>

<script>
import { mapActions, mapMutations, mapState } from "vuex";

export default {
  data() {
    return {
      paises: [],
      changepassword: '',
      show1: false,
      emailRules: [
        v => !!v || 'E-mail es Obligatorio',
        v => /.+@.+\..+/.test(v) || 'E-mail debe ser valido',
      ],
      phoneRules: [
        v => !!v || 'Telefono es Obligatorio',
        v => /\(([0-9]{3})\)([ ])([0-9]{4})+-.+[0-9]{3}/.test(v) || 'Telefono debe ser valido',
      ],
    };
  },
  computed: {
    ...mapState([
      "modelSpecification",
      "visibleEditDialog",
      "CRUDModel",
      "services"
    ]),
    pais: {
      get: function () {
          if(this.CRUDModel.pais === undefined){
              //return new Date().toISOString().substr(0, 10);
            }
          return this.CRUDModel.pais;
        },
      set: function (newValue) {
          this.CRUDModel.pais = newValue;
        }
      },
  },
  methods: {
    ...mapMutations([
      "changeEditDialogVisibility",
      "closeAllDialogs",
      "showInfo",
      "addAlert"
    ]),
    ...mapActions(["loadDataTable"]),
    update() {
      this.$validator
        .validateAll()
        .then(v => {
          if (v) {
            this.services[this.modelSpecification.modelService]
              .update(
                this.CRUDModel,
                this.CRUDModel[this.modelSpecification.modelPK],
                this.modelSpecification.modelParams
              )
              .then(r => {
                this.loadDataTable();
                if (r.data) {
                  this.addAlert({
                    value: true,
                    color: "success",
                    icon: "mdi-checkbox-marked-circle-outline",
                    text:
                      "El " +
                      this.modelSpecification.modelName +
                      " seleccionado se guardo correctamente."
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
  }
};
</script>