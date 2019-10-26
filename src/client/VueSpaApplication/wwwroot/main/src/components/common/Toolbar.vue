<template>
    <v-app-bar dark absolute>
        <v-app-bar-nav-icon @click="changeDrawer()"></v-app-bar-nav-icon>
        <v-toolbar-title>
            <v-img @click="$router.push(`/`)" max-height="30" max-width="100" src="/dist/logo1.png" alt="Logo" srcset="https://www.fundaciondj.org/img/ca_padf_logo_01.png" ></v-img>
        </v-toolbar-title>

        <v-spacer></v-spacer>

        <v-toolbar-title>
            <v-btn text small @click="toHome">{{ this.user.Email }}</v-btn>
        </v-toolbar-title>

        <v-spacer></v-spacer>

        <v-tooltip bottom>
           <template v-slot:activator="{ on }">
               <v-btn class="mr-3" fab dark small color="indigo" v-on="on">
                    <v-icon @click="editar()">mdi-account-edit</v-icon>
                </v-btn>
            </template>
            <span>Editar Usuario</span> 
        </v-tooltip>
        <v-tooltip bottom>
           <template v-slot:activator="{ on }">
               <v-btn class="mr-3" fab dark small color="green" v-on="on">
                    <v-icon @click="change()">mdi-account-key</v-icon>
                </v-btn>
            </template>
            <span>Cambio de Email y Password</span> 
        </v-tooltip>
        <v-tooltip bottom>
            <template v-slot:activator="{ on }">
                <v-btn class="mr-3" fab dark small color="red" v-on="on">
                    <v-icon @click="logout()">mdi-account-off</v-icon>
                </v-btn>
            </template>
            <span>Logout</span> 
        </v-tooltip>
    </v-app-bar>
</template>

<script>
import { mapMutations, mapState } from "vuex";
export default {
    name: 'toolbar',
    data() {
            return {
                user: window.User,
                fab: false,
                allCookies: document.cookie.split(';'),
            }
        },
    computed: {
        ...mapState(["development"])
    },
    methods: {
        ...mapMutations(["changeDrawer"]),
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
        },
        toHome() {
            return this.$router.push('/');
        }
    }
}
</script>