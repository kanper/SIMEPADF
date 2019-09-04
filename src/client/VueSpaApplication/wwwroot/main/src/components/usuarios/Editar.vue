<template>
  <div>
    <v-toolbar dark color="black">
      <v-toolbar-title>Formulario de Usuarios: Editar Registro</v-toolbar-title>
      <v-spacer></v-spacer>
      <v-toolbar-items>
        <v-btn dark flat  @click="update()">Actualizar</v-btn>
      </v-toolbar-items>
    </v-toolbar>
    <v-container>
      <v-card-text>
        <v-container grid-list-md>
          <v-layout row wrap>
            <v-flex xs6>
              <v-text-field
                :counter="50"
                label="Nombres *"
                required
                v-model="form.nombrePersonal"
                :rules="NameRules"
                outlined
              ></v-text-field>
              <v-spacer></v-spacer>
              <v-text-field
                :counter="50"
                label="Cargo *"
                required
                v-model="form.cargo"
                :rules="CargoRules"
              ></v-text-field>
              <v-text-field
                label="Telefono (###) ####-####*"
                required
                v-model="form.phoneNumber"
                :rules="phoneRules"
              ></v-text-field>
            </v-flex>
            <v-spacer></v-spacer>
            <v-flex xs6>
              <v-text-field
                :counter="50"
                label="Apellidos *"
                required
                v-model="form.apellidoPersonal"
                :rules="SurnameRules"
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
      </v-card-text>
    </v-container>
    <v-container>
      <v-card-actions>
        <v-spacer></v-spacer>
        <v-btn @click="$router.push(`/`)" color="gray darken-1" flat>Cancelar</v-btn>
        <v-btn @click="update()" color="green darken-1" flat>Actualizar</v-btn>
      </v-card-actions>
    </v-container>
    <v-snackbar
      v-model="snackbar"
    >
      ¿Desea actualizar el usuario?
      <v-btn
        color="blue"
        text
        @click="aceptar()"
      >
        Aceptar
      </v-btn>
      <v-btn
        color="red"
        text
        @click="cancelar()"
      >
        Cancelar
      </v-btn>
    </v-snackbar>
  </div>
</template>

<script>
export default {
  name: "usuario-editar",
  data() {
    return {
      snackbar: false,
      paises: [],
      user: window.User,
      form: {
          nombrePersonal: null,
          apellidoPersonal: null,
          cargo: null,
          phoneNumber: null,
          pais: null,
      },
      phoneRules: [
        v => !!v || "Telefono es Obligatorio",
        v =>
          /\(([0-9]{3})\)([ ])([0-9]{4})+-.+[0-9]{3}/.test(v) ||
          "Telefono debe ser valido"
      ],
      NameRules: [
        v => !!v || 'El Nombre es Obligatorio',
        v => (v && v.length <= 50) || 'El Nombre debe tener menos de 50 caracteres',
      ],
      SurnameRules: [
        v => !!v || 'El Apellido es Obligatorio',
        v => (v && v.length <= 50) || 'El Apellido debe tener menos de 50 caracteres',
      ],
      CargoRules: [
        v => !!v || 'El Cargo es Obligatorio',
        v => (v && v.length <= 50) || 'El Cargo debe tener menos de 50 caracteres',
      ],
    };
  },
  computed: {
    pais: {
      get: function() {
        return this.user.Pais;
      },
      set: function(newValue) {
        this.form.pais = newValue;
      }
    }
  },
  methods: {
    get(id){
      this.$store.state.services.usuarioService
      .get(id)
      .then(r => {
        this.form.nombrePersonal = r.data.nombrePersonal;
        this.form.apellidoPersonal = r.data.apellidoPersonal;
        this.form.cargo = r.data.cargo;
        this.form.phoneNumber = r.data.phoneNumber;
      })
      .catch(r => {

      });
    },
    update() {
      this.snackbar = true;
    },
    cancelar() {
      this.snackbar = false,
      this.$router.push(`/`)
    },
    aceptar() {
      this.$validator
        .validateAll()
        .then(v => {
          if (v) {
            this.$store.state.services.usuarioService
              .update(this.form, this.user.UserId)
              .then(r => {
                this.$router.push('/');
                })
              .catch(e => {
              });
          }
        })
        .catch(e => {
        });
    }
  },
  created() {
    this.get(this.user.UserId);

    this.$store.state.services.proyectoHelperService
      .getPaises()
      .then(r => {
        this.paises = r.data;
      })
      .catch(e => {
        this.showInfo(e.toString());
      });
  }
};
</script>