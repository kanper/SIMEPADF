<template>
    <v-toolbar app class="blue-grey darken-4" dark>
        <v-toolbar-side-icon @click="changedrawer"></v-toolbar-side-icon>
        <v-img @click="$router.push(`/`)" max-height="30" max-width="100" src="/dist/logo1.png"></v-img>
        <v-spacer></v-spacer>
        <v-tooltip bottom>
           <template v-slot:activator="{ on }">
               <v-btn fab dark small color="indigo" v-on="on">
                    <v-icon @click="editar()">mdi-account-edit</v-icon>
                </v-btn>
            </template>
            <span>Editar Usuario</span> 
        </v-tooltip>
        <v-tooltip bottom>
           <template v-slot:activator="{ on }">
               <v-btn fab dark small color="green" v-on="on">
                    <v-icon @click="change()">mdi-account-key</v-icon>
                </v-btn>
            </template>
            <span>Cambio de Email y Password</span> 
        </v-tooltip>
        <v-tooltip bottom>
            <template v-slot:activator="{ on }">
                <v-btn fab dark small color="red" v-on="on">
                    <v-icon @click="logout()">mdi-account-off</v-icon>
                </v-btn>
            </template>
            <span>Logout</span> 
        </v-tooltip>
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
                allCookies: document.cookie.split(';'),
            }
        },
    methods: {
        ...mapMutations(["changedrawer"]),
        editar(){
            this.$router.push(`/usuarios/${this.user.UserId}/editar`)
        },
        change(){
            this.$router.push(`/usuarios/${this.user.UserId}/change`)
        },
        logout() {
            this.$store.state.services.usuarioService
            .logout()
            .then(r => {
            })
            .catch(r => {
                console.error(r.toString());
            });
            this.load();
        },
        load() {
            setTimeout(function (){
                location.reload();
            }, 500);
        }
    }
}
</script>