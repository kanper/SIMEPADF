<template>
    <v-card class="mx-auto">
        <v-list-item>
            <v-list-item-avatar><v-icon>mdi-message</v-icon></v-list-item-avatar>
            <v-list-item-content>
                <v-list-item-title class="headline">Panel de Notificaciones</v-list-item-title>
                <v-list-item-subtitle>Número de notificaciones: {{getTotalMessages()}}</v-list-item-subtitle>
            </v-list-item-content>
        </v-list-item>
        <v-list three-line>
            <v-list-item-group v-model="selected" multiple active-class="blue--text">
            <template v-for="(item, index) in notifications">
                <v-list-item :key="item.titulo">
                    <template v-slot:default="{ active, toggle }">
                        <v-list-item-content>
                            <v-list-item-title v-text="item.titulo"></v-list-item-title>
                            <v-list-item-subtitle class="text--primary" v-text="item.nombreUsuario"></v-list-item-subtitle>
                            <v-list-item-subtitle v-text="item.mensaje"></v-list-item-subtitle>
                        </v-list-item-content>

                        <v-list-item-action>
                            <v-list-item-action-text v-text="item.fechaNotificacion"></v-list-item-action-text>
                            <v-icon v-if="!active" color="grey lighten-1">mdi-comment-outline</v-icon>

                            <v-icon v-else color="yellow">mdi-comment-check-outline</v-icon>
                        </v-list-item-action>
                    </template>
                </v-list-item>
                <v-divider v-if="index + 1 < notifications.length" :key="index"></v-divider>
            </template>
            </v-list-item-group>
        </v-list>
    </v-card>
</template>

<script>
    import Notification from "./Notification";
    import {mapState,mapActions} from 'vuex'
    export default {
        components: {Notification},
        name: "NotificationPanel",
        data() {
            return {
                selected: []
            }
        },
        computed: {
          ...mapState(['notifications'])
        },
        methods: {
            ...mapActions(['findAllNotifications']),
            getTotalMessages(){
                return this.notifications.length;
            }
        },
        created() {
            this.findAllNotifications({rol: window.User.RolId, country: window.User.Pais});
        }
    }
</script>

<style scoped>

</style>