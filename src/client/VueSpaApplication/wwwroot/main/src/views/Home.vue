<template>
  <v-content>
    <v-container>
      <v-row>
        <v-col><RoleInfo/></v-col>
        <v-col v-if="showNotificationPanel()"><NotificationPanel/></v-col>
      </v-row>
    </v-container>
  </v-content>
</template>

<script>

  import RoleInfo from "../components/home/RoleInfo";
  import NotificationPanel from "../components/home/NotificationPanel";

  export default {
    components: {NotificationPanel, RoleInfo},
    comments: [
            RoleInfo,
            NotificationPanel
    ],
    name: 'Home-user',
    data() {
      return {
        user: window.User,
      }
    },
    methods:{
      showNotificationPanel(){
        return window.User.RolId !== '1';
      }
    }
  }
</script>
