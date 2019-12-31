<template>
    <v-navigation-drawer app fixed dark temporary width="350" :value="navigation">

        <v-list-item>
            <v-list-item-icon>
                <v-icon>{{getRolIcon(user.RolId)}}</v-icon>
            </v-list-item-icon>
            <v-list-item-content>
                <v-list-item-title class="title">
                    {{getRolName(user.RolId)}}
                </v-list-item-title>
                <v-list-item-subtitle>
                    {{getUserName()}}
                </v-list-item-subtitle>
            </v-list-item-content>

            <v-list-item-action>
                <v-icon @click="changeDrawer">mdi-chevron-double-left</v-icon>
            </v-list-item-action>
            <v-list-item-action-text>Cerrar menú</v-list-item-action-text>
        </v-list-item>

        <v-divider></v-divider>

        <v-list-item v-for="item in menuActiveItems(user.RolId, true)" @click="redirect(item.path)" :key="item.title" link>
            <v-list-item-icon>
                <v-icon>{{item.icon}}</v-icon>
            </v-list-item-icon>
            <v-list-item-content>
                <v-list-item-title>{{ item.title }}</v-list-item-title>
            </v-list-item-content>
        </v-list-item>

        <v-list-group :key="item.title" class="pt-0 pb-0" dense v-for="item in menuActiveItems(user.RolId, false)" two-line :prepend-icon="item.icon">
            <template v-slot:activator>
                <v-list-item-title>{{item.title}}</v-list-item-title>
            </template>
            <v-list-item :key="ite.title" @click="redirect(ite.path)" v-for="ite in item.children" link>
                <v-list-item-title>{{ite.title}}</v-list-item-title>
                <v-list-item-icon>
                    <v-icon>{{ite.icon}}</v-icon>
                </v-list-item-icon>
            </v-list-item>
        </v-list-group>
    </v-navigation-drawer>
</template>

<script>
    import { mapState } from "vuex";
    import { mapMutations } from "vuex";
    export default {
        name: 'Navigation',
        data() {
            return {
                userRoles: [
                    {id: 1, rol: 'Gestor del Sistema', icon:'mdi-account',menu:[
                            {
                                title: 'Usuarios',
                                icon: 'mdi-account-multiple-outline',
                                single: true ,
                                path: '/usuarios',
                                children: []
                            },
                            {
                                title: 'Administración de Catalogos',
                                icon: 'mdi-view-dashboard',
                                single: false ,
                                children: [
                                    {icon: 'mdi-city', title: 'Organizaciones Responsables', path: '/organizaciones'},
                                    {icon: 'mdi-account-multiple-outline', title: 'Socios', path: '/socios'},
                                    {icon: 'mdi-map-marker-radius', title: 'País', path: '/paises'},
                                    {icon: 'mdi-open-in-app', title: 'Fuentes de datos', path: '/fuente-datos'},
                                    {icon: 'mdi-chart-line', title: 'Nivel de impacto', path: '/niveles-impacto'},
                                    {icon: 'mdi-account-group', title: 'Desagregaciones', path: '/desagregaciones'}
                                ]
                            },
                            {
                                title: 'Plan de Monitoreo y Evaluación',
                                icon: 'mdi-compass-outline',
                                single: false ,
                                children: [
                                    {icon: 'mdi-checkbox-marked-circle-outline', title: 'Objetivos', path: '/objetivos'},
                                    {icon: 'mdi-lightbulb', title: 'Resultados', path: '/resultados'},
                                    {icon: 'mdi-calendar-multiple-check', title: 'Actividades', path: '/actividades'},
                                    {icon: 'mdi-flag-variant', title: 'Indicadores', path: '/indicadores'},
                                ]
                            },
                        ]},
                    {id: 2, rol: 'Monitoreo y Evaluación', icon:'mdi-account',menu:[
                            {
                                title: 'Proyectos',
                                icon: 'mdi-briefcase',
                                single: false ,
                                children: [
                                    {icon: 'mdi-format-list-bulleted', title: 'Gestión de proyectos', path:'/proyectos/gestion'},
                                    {icon: 'mdi-repeat', title: 'Proyectos en proceso', path:'/proyectos/proceso'},
                                    {icon: 'mdi-repeat-off', title: 'Proyectos cancelados y finalizados', path:'/proyectos/finalizado'},
                                    {icon: 'mdi-file-pdf-box', title: 'Reportes', path:'/proyecto/reporte/'},
                                ]
                            },
                            {
                                title: 'Seguimiento de Indicadores',
                                icon: 'mdi-flag-checkered',
                                single: false ,
                                children: [
                                    {icon: 'mdi-account-group', title: 'Desagregados', path:'/seguimiento-indicadores/desagregados'},
                                    {icon: 'mdi-map-marker-outline', title: 'Información por Pais', path:'/seguimiento-indicadores/pais'},
                                    {icon: 'mdi-map-marker-distance', title: 'Información por Region', path:'/seguimiento-indicadores/region'},
                                ]
                            },
                            {
                                title: 'Auditoria',
                                icon: 'mdi-account-search',
                                single: true ,
                                path: '/auditoria',
                                children: []
                            },
                        ]},
                    {id: 3, rol: 'Director de País', icon:'mdi-account',menu:[
                            {
                                title: 'Proyectos',
                                icon: 'mdi-briefcase',
                                single: false ,
                                children: [
                                    {icon: 'mdi-format-list-bulleted', title: 'Gestión de proyectos', path:'/proyectos/gestion'},
                                    {icon: 'mdi-repeat', title: 'Proyectos en proceso', path:'/proyectos/proceso'},
                                    {icon: 'mdi-repeat-off', title: 'Proyectos cancelados y finalizados', path:'/proyectos/finalizado'},
                                    {icon: 'mdi-file-pdf-box', title: 'Reportes', path:'/proyecto/reporte/'},
                                ]
                            },
                            {
                                title: 'Seguimiento de Indicadores',
                                icon: 'mdi-flag-checkered',
                                single: false ,
                                children: [
                                    {icon: 'mdi-account-group', title: 'Desagregados', path:'/seguimiento-indicadores/desagregados'},
                                    {icon: 'mdi-map-marker-outline', title: 'Información por Pais', path:'/seguimiento-indicadores/pais'},
                                ]
                            },
                        ]},
                    {id: 4, rol: 'Coordinador', icon:'mdi-account',menu:[
                            {
                                title: 'Proyectos en proceso',
                                icon: 'mdi-repeat',
                                single: true ,
                                path:'/proyectos/proceso',
                                children: []
                            },
                            {
                                title: 'Reporte de Proyectos',
                                icon: 'mdi-file-pdf-box',
                                single: true ,
                                path:'/proyecto/reporte/',
                                children: []
                            }
                        ]},
                    {id: 5, rol: 'Director de Finanzas', icon:'mdi-account',menu:[
                            {
                                title: 'Proyectos en proceso',
                                icon: 'mdi-repeat',
                                single: true ,
                                path:'/proyectos/proceso',
                                children: []
                            },
                            {
                                title: 'Seguimiento de Indicadores',
                                icon: 'mdi-flag-checkered',
                                single: false ,
                                children: [
                                    {icon: 'mdi-account-group', title: 'Desagregados', path:'/seguimiento-indicadores/desagregados'},
                                    {icon: 'mdi-map-marker-outline', title: 'Información por Pais', path:'/seguimiento-indicadores/pais'},
                                ]
                            },
                        ]},
                ],
                user: window.User,
            }
        },
        computed: {
            ...mapState(["drawer","development"]),
            navigation: {
                get: function () {
                    return this.drawer
                },
                set: function (value) {
                    this.changeDrawer()
                }
            }
        },
        methods: {
            ...mapMutations(["changeDrawer"]),
            redirect(path) {
                if (path === undefined) return;
                this.$router.push(path);
            },
            getRolName: function (RolId) {
                if (RolId > 0 && RolId < 6) {
                    return this.userRoles[RolId - 1].rol;
                } else {
                    return 'Usuario Anónimo';
                }
            },
            getUserName: function() {
                if(this.user.Email != null){
                    return this.user.Email;
                } else {
                    return 'Usuario Anónimo';
                }
            },
            getRolIcon: function (RolId) {
                if (RolId > 0 && RolId < 6) {
                    return this.userRoles[RolId - 1].icon;
                } else {
                    return 'mdi-account-alert';
                }
            },
            getRolMenu(RolId){
                if (RolId > 0 && RolId < 6) {
                    return this.userRoles[RolId - 1].menu;
                }
            },
            menuActiveItems(RolId, single){
                if (RolId > 0 && RolId < 6) {
                    return this.userRoles[RolId - 1].menu.filter(function (i) {
                        return i.single === single;
                    });
                }
            },
        }
    }
</script>