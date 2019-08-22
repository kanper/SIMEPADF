<template>
    <v-toolbar app class="blue-grey darken-4" dark>
        <v-toolbar-side-icon @click="changedrawer"></v-toolbar-side-icon>
        <v-img @click="$router.push(`/`)" max-height="30" max-width="100" src="/dist/logo1.png"></v-img>
        <v-spacer></v-spacer>
        <v-icon @click="editar()" x-large color="orange darken-2" text='Usuario'>mdi-account-box</v-icon>
        <v-icon large>mdi-logout</v-icon>
    </v-toolbar>
</template>

<script>
import { mapMutations } from "vuex";
export default {
    name: 'toolbar',
    data() {
            return {
                user: {
                    id: "1cdd904b-5541-4433-be88-a5a03f73e099",
                    nombre: "Anderson",
                    apellido: "Perez",
                    cargo: "Programador",
                    numero: "(503) 7764-5655",
                    email: "kevinander@hotmail.es",
                    pais: "El salvador"
                },
            }
        },
    methods: {
        ...mapMutations(["changedrawer"]),
        editar(){
            this.$router.push(`/usuarios/${this.user.id}/editar`)
        },
    }
}
</script>