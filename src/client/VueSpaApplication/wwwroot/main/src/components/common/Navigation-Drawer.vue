<template>
    <v-navigation-drawer absolute app fixed :dark="!development" temporary :value="navigation">
        <v-toolbar class="transparent" flat>
            <v-list class="pa-0">
                <v-list-tile avatar>
                    <v-list-tile-avatar>
                        <v-icon>{{getRolIcon(user.RolId)}}</v-icon>
                    </v-list-tile-avatar>

                    <v-list-tile-content>
                        <v-list-tile-title>{{getRolName(user.RolId)}}</v-list-tile-title>
                    </v-list-tile-content>
                    <v-list-tile-action>
                        <v-icon @click="changeDrawer">mdi-chevron-double-left</v-icon>
                    </v-list-tile-action>
                </v-list-tile>
            </v-list>
        </v-toolbar>

        <div>
            <v-list :key="item.title" class="pt-0 pb-0" dense v-for="item in getRolMenu(user.RolId)" two-line>
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
        </div>
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
                                icon: 'mdi-account-circle',
                                children: [
                                    {icon: 'mdi-format-list-bulleted', title: 'Listar Usuarios', path: '/usuarios'},
                                ]
                            },
                            {
                                title: 'Administración de Catalogos',
                                icon: 'mdi-view-dashboard',
                                children: [
                                    {icon: 'mdi-city', title: 'Organizaciones Responsables', path: '/organizaciones'},
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
                                    {icon: 'mdi-checkbox-marked-circle-outline', title: 'Objetivos', path: '/objetivos'},
                                    {icon: 'mdi-lightbulb', title: 'Resultados', path: '/resultados'},
                                    {icon: 'mdi-calendar-multiple-check', title: 'Actividades', path: '/actividades'},
                                    {icon: 'mdi-flag-variant', title: 'Indicadores', path: '/indicadores'},
                                ]
                            },
                        ]},
                    {id: 2, rol: 'Monitoreo y Evaluación', icon:'mdi-account',menu:[
                            {
                                title: 'Proyectos de monitoreo',
                                icon: 'mdi-briefcase',
                                children: [
                                    {icon: 'mdi-format-list-bulleted', title: 'Gestión de proyectos', path:'/proyectos/gestion'},
                                    {icon: 'mdi-repeat-off', title: 'Proyectos cancelados y finalizados', path:'/proyectos/finalizado'},
                                    {icon: 'mdi-repeat', title: 'Proyectos en proceso', path:'/proyectos/proceso'},
                                ]
                            },
                        ]},
                    {id: 3, rol: 'Director de País', icon:'mdi-account',menu:[
                            {
                                title: 'Proyectos de director',
                                icon: 'mdi-briefcase',
                                children: [
                                    {icon: 'mdi-format-list-bulleted', title: 'Gestión de proyectos', path:'/proyectos/gestion'},
                                    {icon: 'mdi-repeat-off', title: 'Proyectos cancelados y finalizados', path:'/proyectos/finalizado'},
                                    {icon: 'mdi-repeat', title: 'Proyectos en proceso', path:'/proyectos/proceso'},
                                ]
                            },
                        ]},
                    {id: 4, rol: 'Coordinador', icon:'mdi-account',menu:[
                            {
                                title: 'Proyectos de coordinador',
                                icon: 'mdi-briefcase',
                                children: [
                                    {icon: 'mdi-format-list-bulleted', title: 'Proyectos en proceso', path:'/proyectos/proceso'},
                                ]
                            },
                        ]},
                    {id: 5, rol: 'Director de Finanzas', icon:'mdi-account',menu:[
                            {
                                title: 'Proyectos de finanzas',
                                icon: 'mdi-briefcase',
                                children: [
                                    {icon: 'mdi-format-list-bulleted', title: 'Proyectos en proceso', path:'/proyectos/proceso'},
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
                if (this.development) {
                    return 'Modo desarrollador';
                }
                if (RolId > 0 && RolId < 6) {
                    return this.userRoles[RolId - 1].rol;
                } else {
                    return 'Usuario Anonimo';
                }
            },
            getRolIcon: function (RolId) {
                if (this.development) {
                    return 'mdi-account-alert';
                }
                if (RolId > 0 && RolId < 6) {
                    return this.userRoles[RolId - 1].icon;
                } else {
                    return 'mdi-account-alert';
                }
            },
            getRolMenu(RolId){
                if (this.development) {
                    let allMenu = [];
                    for (let item of this.userRoles) {
                        for(let menu of item.menu){
                            allMenu.push(menu);
                        }
                    }
                    return allMenu;
                }
                if (RolId > 0 && RolId < 6) {
                    return this.userRoles[RolId - 1].menu;
                }
            }
        }
    }
</script>