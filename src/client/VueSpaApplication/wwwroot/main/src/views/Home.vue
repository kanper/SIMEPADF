<template>
  <v-container grid-list-md v-if="this.user.RolId == '1'">
    <v-card    class="mx-auto"  >
    <v-card-title class="indigo white--text">
      <span class="title">Administrador del Sistema. Funciones:</span>
    </v-card-title>
    </v-card>
       <v-card class="elevation-2">
         <v-timeline dense>
      
      <v-timeline-item color="yellow" fill-dot right>
        <v-card>
          <v-card-title class="yellow">
            <v-icon dark size="42" class="mr-4"> mdi-account-circle </v-icon>
            <h2 class="tittle white--text">Gestión de Usuarios</h2>
          </v-card-title>
          <v-container>
            <v-row>
              <v-col cols="12" md="10">Encargado realizar mantenimientos a los usuarios del sistema. Es capaz de Crear nuevos usuarios, 
                Editar usuarios existentes, Consultar y Elimiar usuarios segun las necesidades que presente PADF</v-col>
              <v-col class="hidden-sm-and-down text-right" md="2"> </v-col>
            </v-row>
          </v-container>
        </v-card>
      </v-timeline-item>
  
      <v-timeline-item color="red" fill-dot left>
        <v-card>
          <v-card-title class="red">
            <v-icon dark size="42" class="mr-4"> mdi-view-dashboard </v-icon>
            <h2 class="tittle white--text">Administración de Catalogos</h2>
          </v-card-title>
          <v-container>
            <v-row>
              <v-col cols="12" md="10"> Encargado realizar manteminientos a los catalogos del sistema tales como:
                Organizaciones Responsables, Socios Internacionales, Países, Fuente de Datos, Nivel de Impacto y 
                Desagregaciones; a los cuales podra Crear nuevos elementos, Editar elementos existentes, Consultar y Eliminar 
                elementos segun las necesidades que presente PADF.</v-col>
              <v-col class="hidden-sm-and-down text-right" md="2"> </v-col>
            </v-row>
          </v-container>
        </v-card>
      </v-timeline-item>
  
      <v-timeline-item color="blue" fill-dot right>
        <v-card>
          <v-card-title class="blue">
            <v-icon class="mr-4" dark size="42"> mdi-compass-outline</v-icon>
            <h2 class="tittle white--text">Gestión de Plan de Monitoreo y Evaluación</h2>
          </v-card-title>
          <v-container>
            <v-row>
              <v-col cols="12" md="10"> Encargado de realizar el mantenimentos del Plan de Monitoreo y Evaluación
              que utiliza PADF para el desarrollo de sus proyectos tanto regionales como nacionales.El plan esta 
              compuesto por Objetivos, Resultados, Actividades, Indicadores y Metas, a los cuales podra Crear nuevos elementos, 
              Editar elementos existentes, Consultar y Eliminar elementos segun las necesidades que presente PADF. </v-col>
              <v-col class="hidden-sm-and-down text-right" md="2"> </v-col>
            </v-row>
          </v-container>
        </v-card>
      </v-timeline-item>
  




  </v-container>
  <v-container grid-list-md v-else-if="this.user.RolId == '2'">
        <v-card    class="mx-auto"  >
    <v-card-title class="indigo white--text">
      <span class="title">Monitoto y Evaluación. Funciones:</span>
    </v-card-title>
    </v-card>
       <v-card class="elevation-2">
         <v-timeline dense>
      
      <v-timeline-item color="yellow" fill-dot right>
        <v-card>
          <v-card-title class="yellow">
            <v-icon dark size="42" class="mr-4"> mdi-briefcase </v-icon>
            <h2 class="tittle white--text">Gestión de Proyectos</h2>
          </v-card-title>
          <v-container>
            <v-row>
              <v-col cols="12" md="10">Encargado de gestionar proyectos regionales y/o nacionales. Es capaz de 
                Crear nuevos proyectos, Editar proyectos existentes, Consultar y Elimiar Proyectos. A su vez tiene 
                la función de cambiar los estados de los proyectos segun el avance o las circunstancias que los 
                proyectos presenten, tambien se encarga de asignar y coonfigurar los indicadores que se utlizan para
                dar seguimiento, monitoreo y evaluación a los proyectos.</v-col>
              <v-col class="hidden-sm-and-down text-right" md="2"> </v-col>
            </v-row>
          </v-container>
        </v-card>
      </v-timeline-item>
  
      <v-timeline-item color="red" fill-dot left>
        <v-card>
          <v-card-title class="red">
            <v-icon dark size="42" class="mr-4"> mdi-drawing </v-icon>
            <h2 class="tittle white--text">Plan de Trabajo</h2>
          </v-card-title>
          <v-container>
            <v-row>
              <v-col cols="12" md="10"> Encargado gestionar el plan de trabajo para cada proyecto. El plan de trabajo
                esta compuesto por Actividades y Productos, estos productos son la evidencia que el proyecto se esta llevando
                a cabo con normalidad las actividades con los plazos establecidos y los montos en USD son utilizados de de 
                manera correcta. Es capaz de Crear nuevas/os Actividades y Productos, Editar Actividades y Productos existentes,
                Consultar y Eliminar Actividades y Productos segun las necesidades que se presenten cada uno de los proyectos.</v-col>
              <v-col class="hidden-sm-and-down text-right" md="2"> </v-col>
            </v-row>
          </v-container>
        </v-card>
      </v-timeline-item>
  
      <v-timeline-item color="blue" fill-dot right>
        <v-card>
          <v-card-title class="blue">
            <v-icon class="mr-4" dark size="42"> mdi-compass-outline</v-icon>
            <h2 class="tittle white--text">Monitoreo y Evaluación</h2>
          </v-card-title>
          <v-container>
            <v-row>
              <v-col cols="12" md="10"> Encargado de realizar el seguimiento, monitoreo y Evaluación de proyectos; 
                verifica y valida que el Plan de Monitoreo y Evaluación y el Plan de Trabajo de cada proyecto cumpla 
                con los requerimientos, plazos y fechas estipuladas para el buen desarrollo de cada uno de los
                proyectos que se llevan a cabo por PADF. </v-col>
              <v-col class="hidden-sm-and-down text-right" md="2"> </v-col>
            </v-row>
          </v-container>
        </v-card>
      </v-timeline-item>
  </v-container>





  <v-container grid-list-md v-else-if="this.user.RolId == '3'">
    <v-layout row wrap>
      <v-flex xs12 sm6>
        <v-card>
          <v-img src="/dist/director.png" width="400" height="400" align="center"  ></v-img>
          <v-card-title>

          </v-card-title>
          <v-card-text>

          </v-card-text>
        </v-card>
      </v-flex>
      <v-flex xs12 sm6>
        <v-card>
          <v-img></v-img>
          <v-card-title>
<h1>Director Nacional</h1>
          </v-card-title>
          <v-card-text>
              <h2>Funciones:</h2>
              
              <h4>-Crear Proyectos por país.</h4>
              
              <h4>-Selecciona el/los indicador/es que se apegan al proyecto.</h4>
              
              <h4>-Crear Plan de Trabajo por país.</h4>
                    
              <h4>-Verificar y validar el cumplimiento del Plan de Monitoreo y Evaluación y Plan de
Trabajo, por país.</h4>
              
          </v-card-text>
          <v-card-actions>

          </v-card-actions>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
  <v-container grid-list-md v-else-if="this.user.RolId == '4'">
    <v-layout row wrap>
      <v-flex xs12 sm6>
        <v-card>
          <v-img src="/dist/Coordinador.png" width="400" height="400" align="center" ></v-img>
          <v-card-title>Coordinador de Pais</v-card-title>
          <v-card-text>

          </v-card-text>
        </v-card>
      </v-flex>
      <v-flex xs12 sm6>
        <v-card>
          <v-img></v-img>
          <v-card-title>
<h1>Coordinador Nacional</h1>
          </v-card-title>
          <v-card-text>
              <h2>Funciones:</h2>
              
              <h4>-Encargado del seguimiento del Plan de Monitoreo y Evaluación.</h4>
              
              <h4>-Encargado de subir las evidencias correspondientes del Plan de Trabajo.
(Documentos, Facturas, etc.).</h4>
              
              </v-card-text>
          <v-card-actions>

          </v-card-actions>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
  <v-container grid-list-md v-else-if="this.user.RolId == '5'">
    <v-layout row wrap>
      <v-flex xs12 sm6>
        <v-card>
          <v-img src="/dist/finanzas.png" width="400" height="400" align="center" ></v-img>
          <v-card-title>

          </v-card-title>
          <v-card-text>

          </v-card-text>
        </v-card>
      </v-flex>
      <v-flex xs12 sm6>
        <v-card>
          <v-img></v-img>
          <v-card-title>
<h1>Director de Finanzas</h1>
          </v-card-title>
          <v-card-text>
<h2>Funciones:</h2>
              
              <h4>-Verificar y validar el cumplimiento del Plan de Monitoreo y Evaluación y Plan de
Trabajo, regionales y por país.</h4>
              
          </v-card-text>
          <v-card-actions>

          </v-card-actions>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>

  export default {
    data() {
      return {
        user: window.User,
      }
    },
  }
</script>
