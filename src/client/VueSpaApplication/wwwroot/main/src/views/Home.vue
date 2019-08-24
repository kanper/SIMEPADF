<template>
  <v-container grid-list-md v-if="this.user.RolId == '1'">
    <v-layout row wrap>
      <v-flex xs12 sm6>
        <v-card>
          <v-img src="/dist/Sysadmin.png" width="400" height="400" align="center" ></v-img>
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
              <h1>Administrador de Sistema</h1>
          </v-card-title>
          <v-card-text>
              <h2>Funciones:</h2>
              
              <h4>-Mantenimiento de usuarios.</h4>
              
              <h4>-Encargado de Auditoria del sistema.</h4>
              
              <h4>-Mantenimiento de País.</h4>
              
              <h4>-Mantenimiento de Organización responsable.</h4>
              
              <h4>-Mantenimiento de socios internacionales.</h4>
              
              <h4>-Gestionar el Plan de Monitoreo y Evaluación del Sistema.</h4>
          </v-card-text>
          <v-card-actions>

          </v-card-actions>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
  <v-container grid-list-md v-else-if="this.user.RolId == '2'">
    <v-layout row wrap>
      <v-flex xs12 sm6>
        <v-card>
          <v-img src="/dist/Monitoreo.png" width="400" height="400" align="center"  ></v-img>
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
          <h1>Monitoreo y Evaluacion</h1>
          </v-card-title>
          <v-card-text>
              <h2>Funciones:</h2>
              
              <h4>-Crear Proyectos regionales o por país.</h4>
              
              <h4>-Seleccionar el/los indicador/es que se apegan al proyecto.</h4>
              
              <h4>-Crear Plan de Trabajo regionales y por país.</h4>
              
              <h4>-Aprobar los proyectos por país.</h4>
              
              <h4>-Verificar y validar el cumplimiento del Plan de Monitoreo y Evaluación y Plan de
Trabajo, regionales y por país.</h4>
              
              <h4>-Cambiar estado de proyectos.</h4>
          </v-card-text>
          <v-card-actions>

          </v-card-actions>
        </v-card>
      </v-flex>
    </v-layout>
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
