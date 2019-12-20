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
            <v-list-item-group>
            <template v-for="(item, index) in notifications">
                <v-list-item :key="item.fechaNotificacion" @click="showNotificationMessage(item.titulo,item.mensaje)">
                    <v-list-item-content>
                        <v-list-item-title v-text="item.titulo"></v-list-item-title>
                        <v-list-item-subtitle class="text--primary" v-text="item.nombreUsuario"></v-list-item-subtitle>
                        <v-list-item-subtitle v-text="item.mensaje"></v-list-item-subtitle>
                    </v-list-item-content>

                    <v-list-item-action>
                        <v-list-item-action-text v-text="item.fechaNotificacion"></v-list-item-action-text>
                    </v-list-item-action>
                </v-list-item>
                <v-divider v-if="index + 1 < notifications.length" :key="index"></v-divider>
            </template>
            </v-list-item-group>
        </v-list>
        <v-dialog v-model="notificationMessageDialog" max-width="500">
            <v-card>
                <v-card-title class="headline">{{notificationDialogTitle}}</v-card-title>
                <v-card-text>{{notificationDialogContent}}</v-card-text>
                <v-card-actions>
                    <v-spacer></v-spacer>
                    <v-btn color="green darken-1" text @click="notificationMessageDialog = false">Cerrar</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
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
                selected: [],
                notificationMessageDialog: false,
                notificationDialogTitle: '',
                notificationDialogContent: '',
            }
        },
        computed: {
          ...mapState(['notifications'])
        },
        methods: {
            ...mapActions(['findAllNotifications']),
            getTotalMessages(){
                return this.notifications.length;
            },
            showNotificationMessage(title, content) {
                this.notificationDialogTitle = title;
                this.notificationDialogContent = content;
                this.notificationMessageDialog = true;
            }
        },
        created() {
            this.findAllNotifications({rol: window.User.RolId, country: window.User.Pais});
        }
    }
</script>

<style scoped>

</style>