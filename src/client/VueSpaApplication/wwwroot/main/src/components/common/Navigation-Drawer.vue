<template>
  <v-navigation-drawer absolute app dark temporary v-model="navigation">
    <v-toolbar class="transparent" flat>
      <v-list class="pa-0">
        <v-list-tile avatar>
          <v-list-tile-avatar>
            <v-icon>mdi-account</v-icon>
          </v-list-tile-avatar>

          <v-list-tile-content>
            <v-list-tile-title>Administrador Sistema</v-list-tile-title>
          </v-list-tile-content>
        </v-list-tile>
      </v-list>
    </v-toolbar>
    <v-list :key="item.title" class="pt-0 pb-0" dense v-for="item in items">
      <v-divider light></v-divider>
      <v-list-group :prepend-icon="item.icon">
        <template v-slot:activator>
          <v-list-tile>
            <v-list-tile-title>{{item.title}}</v-list-tile-title>
          </v-list-tile>
        </template>
        <v-list-tile :key="ite.title" @click="redirect(ite.path)" v-for="ite in item.children">
          <v-list-tile-action>
            <v-icon>{{ite.icon}}</v-icon>
          </v-list-tile-action>
          <v-list-tile-title>{{ite.title}}</v-list-tile-title>
        </v-list-tile>
      </v-list-group>
    </v-list>
  </v-navigation-drawer>
</template>

<script>
import { mapState } from "vuex";
import { mapMutations } from "vuex";
export default {
    name: 'Navigation',
    data() {
            return {
                user: window.User,
                items: [
                    {
                        title: 'Usuarios',
                        icon: 'mdi-account-circle',
                        children: [
                            {icon: 'mdi-format-list-bulleted', title: 'Listar', path: '/usuarios'},
                        ]
                    },
                    {
                        title: 'Administración de Catalogos',
                        icon: 'mdi-view-dashboard',
                        children: [
                            {icon: 'mdi-city', title: 'Organizaciones', path: '/organizaciones'},
                            {icon: 'mdi-account-multiple-outline', title: 'Socios', path: '/socios'},
                            {icon: 'mdi-map-marker-radius', title: 'País', path: '/paises'},
                            {icon: 'mdi-open-in-app', title: 'Fuentes de datos', path: '/fuente-datos'},
                            {icon: 'mdi-chart-line', title: 'Nivel de impacto', path: '/niveles-impacto'},
                            {icon: 'mdi-arrange-send-backward', title: 'Desagregaciones', path: '/desagregaciones'}
                        ]
                    },
                    {
                        title: 'Plan de Monitoreo y Evaluación',
                        icon: 'mdi-compass-outline',
                        children: [
                            {icon: 'mdi-flag-variant', title: 'Indicadores', path: '/indicadores'},
                            {icon: 'mdi-calendar-multiple-check', title: 'Actividades', path: '/actividades'},
                            {icon: 'mdi-lightbulb', title: 'Resultados', path: '/resultados'},
                            {icon: 'mdi-checkbox-marked-circle-outline', title: 'Objetivos', path: '/objetivos'},
                        ]
                    },
                    {
                        title: 'Proyecto',
                        icon: 'mdi-briefcase',
                        children: [
                            {icon: 'mdi-format-list-bulleted', title: 'Listar', path:'/proyectos'},
                            {icon: 'mdi-drawing', title: 'Plan de trabajo', path:'/planes-trabajo'},
                        ]
                    },
                ],
            }
        },
    computed: {
        ...mapState(["drawer"]),
        navigation: {
            get: function () {
                return this.drawer
            },
            set: function (value) {
                this.changedrawer
            }
        }
    },
    methods: {
        ...mapMutations(["changedrawer"]),
        redirect(path) {
            if (path === undefined) return;
                this.$router.push(path);
        }
    }
}
</script>