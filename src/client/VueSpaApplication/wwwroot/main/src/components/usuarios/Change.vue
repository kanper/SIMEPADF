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
                label="Correo *"
                required
                v-model="form.email"
                :rules="emailRules"
              ></v-text-field>
              <v-text-field
                :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
                :type="show1 ? 'text' : 'password'"
                hint="al menos 8 caracteres"
                label="Contraseña Nueva *"
                required
                @click:append="show1 = !show1"
                v-model="form.newPassword"
                :rules="passRules"
                ></v-text-field>
            </v-flex>
          </v-layout>
        </v-container>
      </v-card-text>
      <small>* Indica que el campo es requerido</small>
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
  name: "usuario-change",
  data() {
    return {
      snackbar: false,
      show1: false,
      user: window.User,
      form: {
          email: null,
          newPassword: null
      },
      emailRules: [
        v => !!v || "E-mail es Obligatorio",
        v => /.+@.+\..+/.test(v) || "E-mail debe ser valido"
      ],
      passRules: [
        v => !!v || 'Password es Obligatorio',
        v => (v && v.length >= 8) || 'La Password debe tener minimo 8 caracteres',
      ],
    };
  },
  computed: {
  },
  methods: {
    get(id){
      this.$store.state.services.usuarioService
      .get(id)
      .then(r => {
        this.form.email = r.data.email;
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
                })
              .catch(e => {
              });
            this.$store.state.services.usuarioService
            .logout()
            .then(r => {
            })
            .catch(r => {
                console.error(r.toString());
            });
            this.$router.push('/');
          }
        })
        .catch(e => {
        });
    }
  },
  created() {
    this.get(this.user.UserId);
  }
};
</script>