<template>
    <v-card class="mx-auto">
        <v-list-item>
            <v-list-item-avatar><v-icon>mdi-account-outline</v-icon></v-list-item-avatar>
            <v-list-item-content>
                <v-list-item-title class="headline">{{getRoleName()}}</v-list-item-title>
                <v-list-item-subtitle>{{getUserFullName()}}</v-list-item-subtitle>
            </v-list-item-content>
        </v-list-item>
        <v-card-text>
            <v-timeline dense align-top>
                <v-timeline-item v-for="item in activeRoleInfo" :key="item.title" small>
                    <span slot="opposite">{{item.title}}</span>
                    <v-card class="elevation-2">
                        <v-card-title class="headline">{{item.title}}</v-card-title>
                        <v-card-text>
                            {{item.content}}
                        </v-card-text>
                    </v-card>
                </v-timeline-item>
            </v-timeline>
        </v-card-text>
    </v-card>
</template>

<script>
    export default {
        name: "RoleInfo",
        data() {
            return {
                reverse: true,
                roleInfo: [
                    {id: '1', title: 'Gestión de Usuarios', content: 'Encargado realizar mantenimientos de usuarios. Es capaz de Crear nuevos usuarios, Editar usuarios existentes, Consultar y Elimiar usuarios segun las necesidades requeridas por PADF'},
                    {id: '1', title: 'Administración de Catalogos', content: 'Encargado realizar manteminientos a los catalogos tales como: Organizaciones Responsables, Socios Internacionales, Países, Fuente de Datos, Nivel de Impacto y Desagregaciones; a los cuales podra Crear nuevos elementos, Editar elementos existentes, Consultar y Eliminar elementos segun las necesidades que presente PADF.'},
                    {id: '1', title: 'Plan de Monitoreo y Evaluación', content: 'Encargado de realizar el mantenimentos del Plan de Monitoreo y Evaluación que utiliza PADF para el desarrollo de sus proyectos tanto regionales como nacionales.El plan esta compuesto por Objetivos, Resultados, Actividades, Indicadores y Metas, a los cuales podra Crear nuevos elementos, Editar elementos existentes, Consultar y Eliminar elementos segun las necesidades que presente PADF.'},
                    {id: '2', title: 'Gestión de Proyectos', content: 'Realizar mantenimientos a proyectos tanto Regionales como Nacionales. Es capaz de Crear nuevos proyectos, Editar proyectos existentes, Activar proyectos, Consultar y Cancelar proyectos segun las necesidades requeridas por PADF.'},
                    {id: '2', title: 'Asignación de Indicadores', content: 'Encargado asignar un Indicador a proyectos tanto Reginales como Nacionales, segun las necesidades que este presente. Luego de seleccior el indicador debera configurar el mismo, seleccionara la metodologia de recolección de datos, linea base, fuente de datos, frecuencia de medición, nivel de impacto y las diversas desagregaciones que tomaran parte en el proyecto, preparando asi el posterior seguimiento del proyecto.'},
                    {id: '2', title: 'Plan de trabajo', content: 'Encargado de crear un Plan de Trabajo tanto a proyectos Regionales como Nacionales. Es capaz de crear, editar, eliminar Actividades y Productos del plan de trabajo segun las necesidades requeridas de cada proyecto. El plan de trabajo es de vital importancia para el seguimiento financiero de cada proyecto y asi cumplir con las metas que se propone cumplir PADF como Fundación.'},
                    {id: '2', title: 'Activar y Verificar Proyectos', content: 'Encargado velar que se cumplan los parametros establecidos para el desarrollo d proyectos, verificando la información general de cada proyecto  la configuración de Indicadores de estos y ademas verificar el Plan de Trabajoque estos presentan. Si la información general, configuración de Indicador y Plan de Trabajo cumplen con los parametros establecidos Activara el Proyecto para que este sea desarrollado, de lo contrario Cancelara para que vuelvan realizarce  estos procesos segun las necesidades requeridas de cada proyecto y asi cumplir con las metas que se propone cumplir PADF como Fundación.'},
                    {id: '2', title: 'Auditoria del Sistema', content: 'Encargado de velar por el correcto uso del Sistema  Informatico, evitando asi enconsistencia en la información que se maneja dentro de esta y cumplir con las metas establecidas en cada proyecto.'},
                    {id: '2', title: 'Seguimiento de Proyectos', content: 'Encargado de velar por el cumplimiento de Indicadores, teniendo un control del avance que se logra en cada trimestre, ademas verificar el cumplimiento de cada Actividad que forma parte de los Planes de Trabajo, teniendo un mejor conocimiento del uso de Fondos en el desarrollo de proyectos, logrando asi un mejor manejo de Fondos en cada trimestre y Finalizar con los parametros establecidos cada proyecto.'},
                    {id: '3', title: 'Gestión de Proyectos', content: 'Encargado realizar mantenimientos a proyectos tanto Regionales como Nacionales. Es capaz de Crear nuevos proyectos, Editar proyectos existentes, Activar proyectos, Consultar y Cancelar proyectos segun las necesidades requeridas por PADF.'},
                    {id: '3', title: 'Asignación de Indicadores', content: 'Encargado asignar un Indicador a proyectos tanto Reginales como Nacionales, segun las necesidades que este presente. Luego de seleccior el indicador debera configurar el mismo, seleccionara la metodologia de recolección de datos, linea base, fuente de datos, frecuencia de medición, nivel de impacto y las diversas desagregaciones que tomaran parte en el proyecto, preparando asi el posterior seguimiento del proyecto.'},
                    {id: '3', title: 'Plan de trabajo', content: 'Encargado de crear un Plan de Trabajo tanto a proyectos Regionales como Nacionales. Es capaz de crear, editar, eliminar Actividades y Productos del plan de trabajo segun las necesidades requeridas de cada proyecto. El plan de trabajo es de vital importancia para el seguimiento financiero de cada proyecto y asi cumplir con las metas que se propone cumplir PADF como Fundación.'},
                    {id: '3', title: 'Verificar Proyectos', content: 'Encargado velar que se cumplan los parametros establecidos para el desarrollo d proyectos, verificando la información general de cada proyecto la configuración de Indicadores de estos y ademas verificar el Plan de Trabajo que estos presentan. Si la información general, configuración de Indicador y Plan de Trabajo cumplen con los parametros establecidos debera enviar el proyecto a un Chequeo Final por parte del Usuario Monitoreo y Evaluación para que este sea desarrollado, de lo contrario Cancelara para que vuelvan realizarce estos procesos segun las necesidades requeridas de cada proyecto y asi cumplir con las metas que se propone cumplir PADF como Fundación.'},
                    {id: '3', title: 'Seguimiento de Proyectos', content: 'Encargado de velar por el cumplimiento de Indicadores, teniendo un control del avance que se logra en cada trimestre, ademas verificar el cumplimiento de cada Actividad que forma parte de los Planes de Trabajo, teniendo un mejor conocimiento del uso de Fondos en el desarrollo de proyectos, logrando asi un mejor manejo de Fondos en cada trimestre y Finalizar con los parametros establecidos cada proyecto.'},
                    {id: '4', title: 'Seguimiento de Proyectos', content: 'Encargado alimentar los indicadores de cada proyecto  en los que esta involucrado tanto Regionales como Nacionales. Debera subir la cantidad de desagregados segun se tipo al finalizar cada trimestre, para que tanto Monitoreo y Evaluación como Directores Naciones pueden estar el tanto del avance y cumplimiento de metas en cada proyecto.'},
                    {id: '4', title: 'Evidencias de Plan de Trabajo', content: 'Encargado subir los archivos o evidencias de cada de Actividad de Plan de Trabajo que cada Proyecto tanto Regional como Nacional posee, ayudando asi a mejorar el uso de Fondos para el desarrollo de proyectos.'},
                    {id: '5', title: 'Verificar Proyectos', content: 'Encargado velar que se cumplan los parametros establecidos para el desarrollo d proyectos, verificando la información general de cada proyecto la configuración de Indicadores de estos y ademas verificar el Plan de Trabajo que estos presentan. Si la información general, configuración de Indicador y Plan de Trabajo cumplen con los parametros establecidos debera enviar el proyecto a un Chequeo Final por parte del Usuario Monitoreo y Evaluación para que este sea desarrollado, de lo contrario Cancelara para que vuelvan realizarce estos procesos segun las necesidades requeridas de cada proyecto y asi cumplir con las metas que se propone cumplir PADF como Fundación.'},
                    {id: '5', title: 'Seguimiento de Plan de Trabajo', content: 'Encargado de velar por el cumplimiento de cada Actividad que forma parte de los Planes de Trabajo, teniendo un mejor conocimiento del uso de Fondos en el desarrollo de proyectos, logrando asi un mejor manejo de Fondos en cada trimestre y Finalizar con los parametros establecidos cada proyecto.'},
                ]
            }
        },
        computed: {
          activeRoleInfo: function () {
              return this.roleInfo.filter(function (i) {
                  return i.id === window.User.RolId;
              });
          }
        },
        methods: {
            getRoleName(){
                switch (window.User.RolId) {
                    case "1":
                        return 'Administrador del sistema';
                    case "2":
                        return 'Monitoreo y Evaluación';
                    case "3":
                        return 'Director de País';
                    case "4":
                        return 'Coordinador';
                    case "5":
                        return 'Director Financiero';
                    default:
                        return 'Usuario Anónimo'

                }
            },
            getUserFullName(){
                return window.User.Nombre + ' ' + window.User.Apellido;
            }
        }

    }
</script>

<style scoped>

</style>