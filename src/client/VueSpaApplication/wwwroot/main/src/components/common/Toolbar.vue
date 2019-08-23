<template>
    <v-toolbar app class="blue-grey darken-4" dark>
        <v-toolbar-side-icon @click="changedrawer"></v-toolbar-side-icon>
        <v-img @click="$router.push(`/`)" max-height="30" max-width="100" src="/logo1.png"></v-img>
        <v-spacer></v-spacer>
        <v-btn fab dark small color="green" >
            <v-icon @click="editar()">mdi-account-edit</v-icon>
        </v-btn>
        <v-btn fab dark small color="indigo">
            <v-icon>mdi-account-key</v-icon>
        </v-btn>
        <template>
            <v-icon large @click="logout()">mdi-logout</v-icon>
        </template>
    </v-toolbar>
</template>

<script>
import { mapMutations } from "vuex";
export default {
    name: 'toolbar',
    data() {
            return {
                user: window.User,
                fab: false,
            }
        },
    methods: {
        ...mapMutations(["changedrawer"]),
        editar(){
            this.$router.push(`/usuarios/${this.user.UserId}/editar`)
        },
        logout() {
            this.$store.state.services.usuarioService
            .get()
            .then(r => {

            })
            .catch(r => {

            });
        },
    }
}
</script>