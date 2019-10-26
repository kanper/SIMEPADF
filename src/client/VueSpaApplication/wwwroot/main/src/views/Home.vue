<template>
  <v-container grid-list-md>
    <v-container grid-list-md v-if="this.user.RolId == '1'">
            <v-card    class="mx-auto"  >
              <v-card-title class="blue-grey darken-2 white--text">
                <v-icon dark size="30" class="mr1"> mdi-account-outline </v-icon>
                <span class="title">&nbsp; Gestor del Sistema</span>
              </v-card-title>
            </v-card>
            <v-card class="elevation">
              <v-timeline dense>
                <v-timeline-item color="blue-grey darken-1" fill-dot right>
                  <v-card>
                    <v-card-title small class="blue-grey darken-1">
                      <v-icon dark size="30" class="mr1"> mdi-account-circle </v-icon>
                      <h2 class="tittle white--text"> &nbsp; Gestión de Usuarios</h2>
                    </v-card-title>
                    <v-container>
                      <v-row>
                        <v-col cols="12" md="10">Encargado realizar mantenimientos de usuarios.
                            Es capaz de Crear nuevos usuarios, Editar usuarios existentes, Consultar
                            y Elimiar usuarios segun las necesidades requeridas por PADF</v-col>
                        <v-col class="hidden-sm-and-down text-right" md="2"> </v-col>
                      </v-row>
                    </v-container>
                  </v-card>
                </v-timeline-item>

                  <v-timeline-item color="blue-grey darken-1" fill-dot left>
                    <v-card>
                      <v-card-title class="blue-grey darken-1">
                        <v-icon dark size="30" class="mr1"> mdi-view-dashboard </v-icon>
                        <h2 class="tittle white--text"> &nbsp; Administración de Catalogos</h2>
                      </v-card-title>
                      <v-container>
                        <v-row>
                          <v-col cols="12" md="10"> Encargado realizar manteminientos a los catalogos
                            tales como: Organizaciones Responsables, Socios Internacionales, Países,
                            Fuente de Datos, Nivel de Impacto y Desagregaciones; a los cuales podra
                            Crear nuevos elementos, Editar elementos existentes, Consultar y Eliminar
                            elementos segun las necesidades que presente PADF.</v-col>
                          <v-col class="hidden-sm-and-down text-right" md="2"> </v-col>
                        </v-row>
                      </v-container>
                    </v-card>
                  </v-timeline-item>

                  <v-timeline-item color="blue-grey darken-1" fill-dot right>
                    <v-card>
                      <v-card-title class="blue-grey darken-1">
                        <v-icon class="mr1" dark size="30"> mdi-compass-outline</v-icon>
                        <h2 class="tittle white--text"> &nbsp; Plan de Monitoreo y Evaluación</h2>
                      </v-card-title>
                      <v-container>
                        <v-row>
                          <v-col cols="12" md="10"> Encargado de realizar el mantenimentos del Plan de
                            Monitoreo y Evaluación que utiliza PADF para el desarrollo de sus proyectos
                            tanto regionales como nacionales.El plan esta compuesto por Objetivos,
                            Resultados, Actividades, Indicadores y Metas, a los cuales podra Crear
                            nuevos elementos, Editar elementos existentes, Consultar y Eliminar elementos
                            segun las necesidades que presente PADF. </v-col>
                          <v-col class="hidden-sm-and-down text-right" md="2"> </v-col>
                        </v-row>
                      </v-container>
                    </v-card>
                  </v-timeline-item>
              </v-timeline>
            </v-card>
          </v-container>
    <v-layout row wrap>
      <v-flex md6>
          <v-container grid-list-md v-if="this.user.RolId == '2'">
            <v-card    class="mx-auto"  >
              <v-card-title class="blue-grey darken-2 white--text">
                <v-icon dark size="30" class="mr1"> mdi-account-outline </v-icon>
                <span class="title">&nbsp; Monitoreo y Evaluacion</span>
              </v-card-title>
            </v-card>
            <v-card class="elevation">
              <v-timeline dense>
                <v-timeline-item color="blue-grey darken-1" class="mr-5" fill-dot right>
                  <v-card>
                    <v-card-title small class="blue-grey darken-1">
                      <v-icon dark size="30" class="mr1"> mdi-book </v-icon>
                      <h2 class="tittle white--text"> &nbsp; Gestión de Proyectos</h2>
                    </v-card-title>
                    <v-container>
                      <v-row>
                        <v-col>Realizar mantenimientos a proyectos tanto
                            Regionales como Nacionales. Es capaz de Crear nuevos proyectos, Editar
                            proyectos existentes, Activar proyectos, Consultar y Cancelar proyectos
                            segun las necesidades requeridas por PADF</v-col>
                      </v-row>
                    </v-container>
                  </v-card>
                </v-timeline-item>

                  <v-timeline-item color="blue-grey darken-1" class="mr-5" fill-dot left>
                    <v-card>
                      <v-card-title class="blue-grey darken-1">
                        <v-icon dark size="30" class="mr1"> mdi-flag-variant </v-icon>
                        <h2 class="tittle white--text"> &nbsp; Asignación de Indicadores</h2>
                      </v-card-title>
                      <v-container>
                        <v-row>
                          <v-col> Encargado asignar un Indicador a proyectos tanto
                            Reginales como Nacionales, segun las necesidades que este presente. Luego de
                            seleccior el indicador debera configurar el mismo, seleccionara la
                            metodologia de recolección de datos, linea base, fuente de datos, frecuencia
                            de medición, nivel de impacto y las diversas desagregaciones que tomaran
                            parte en el proyecto, preparando asi el posterior seguimiento del proyecto.
                          </v-col>
                        </v-row>
                      </v-container>
                    </v-card>
                  </v-timeline-item>

                  <v-timeline-item color="blue-grey darken-1" class="mr-5" fill-dot right>
                    <v-card>
                      <v-card-title class="blue-grey darken-1">
                        <v-icon class="mr1" dark size="30"> mdi-compass-outline</v-icon>
                        <h2 class="tittle white--text"> &nbsp; Plan de trabajo</h2>
                      </v-card-title>
                      <v-container>
                        <v-row>
                          <v-col> Encargado de crear un Plan de Trabajo tanto a proyectos
                            Regionales como Nacionales. Es capaz de crear, editar, eliminar Actividades y
                            Productos del plan de trabajo segun las necesidades requeridas de cada
                            proyecto. El plan de trabajo es de vital importancia para el seguimiento financiero
                            de cada proyecto y asi cumplir con las metas que se propone cumplir PADF
                            como Fundación. </v-col>
                        </v-row>
                      </v-container>
                    </v-card>
                  </v-timeline-item>

                  <v-timeline-item color="blue-grey darken-1" class="mr-5" fill-dot right>
                    <v-card>
                      <v-card-title class="blue-grey darken-1">
                        <v-icon class="mr1" dark size="30"> mdi-thumb-up</v-icon>
                        <h2 class="tittle white--text"> &nbsp; Activar y Verificar Proyectos</h2>
                      </v-card-title>
                      <v-container>
                        <v-row>
                          <v-col> Encargado velar que se cumplan los parametros establecidos
                            para el desarrollo d proyectos, verificando la información general de cada proyecto
                            la configuración de Indicadores de estos y ademas verificar el Plan de Trabajo
                            que estos presentan. Si la información general, configuración de Indicador y Plan
                            de Trabajo cumplen con los parametros establecidos Activara el Proyecto para que
                            este sea desarrollado, de lo contrario Cancelara para que vuelvan realizarce
                            estos procesos segun las necesidades requeridas de cada proyecto y asi cumplir
                            con las metas que se propone cumplir PADF como Fundación. </v-col>
                        </v-row>
                      </v-container>
                    </v-card>
                  </v-timeline-item>

                  <v-timeline-item color="blue-grey darken-1" class="mr-5" fill-dot right>
                    <v-card>
                      <v-card-title class="blue-grey darken-1">
                        <v-icon class="mr1" dark size="30"> mdi-format-list-bulleted-square</v-icon>
                        <h2 class="tittle white--text"> &nbsp; Auditoria del Sistema</h2>
                      </v-card-title>
                      <v-container>
                        <v-row>
                          <v-col> Encargado de velar por el correcto uso del Sistema
                            Informatico, evitando asi enconsistencia en la información que se maneja
                            dentro de esta y cumplir con las metas establecidas en cada proyecto. </v-col>
                        </v-row>
                      </v-container>
                    </v-card>
                  </v-timeline-item>

                  <v-timeline-item color="blue-grey darken-1" class="mr-5" fill-dot right>
                    <v-card>
                      <v-card-title small class="blue-grey darken-1">
                        <v-icon dark size="30" class="mr1"> mdi-arrow-up-bold-box-outline </v-icon>
                        <h2 class="tittle white--text"> &nbsp; Seguimiento de Proyectos</h2>
                      </v-card-title>
                      <v-container>
                        <v-row>
                          <v-col>Encargado de velar por el cumplimiento de Indicadores,
                            teniendo un control del avance que se logra en cada trimestre, ademas
                            verificar el cumplimiento de cada Actividad que forma parte de los Planes de
                            Trabajo, teniendo un mejor conocimiento del uso de Fondos en el desarrollo
                            de proyectos, logrando asi un mejor manejo de Fondos en cada trimestre y
                            Finalizar con los parametros establecidos cada proyecto.
                          </v-col>
                        </v-row>
                      </v-container>
                    </v-card>
                </v-timeline-item>

              </v-timeline>
            </v-card>
          </v-container>
          <v-container grid-list-md v-else-if="this.user.RolId == '3'">
            <v-card    class="mx-auto"  >
            <v-card-title class="blue-grey darken-2 white--text">
              <v-icon dark size="30" class="mr1"> mdi-account-outline </v-icon>
              <span class="title">&nbsp; Director de País</span>
            </v-card-title>
            </v-card>
              <v-card class="elevation">
                <v-timeline dense>

                  <v-timeline-item color="blue-grey darken-1" class="mr-5" fill-dot right>
                    <v-card>
                      <v-card-title small class="blue-grey darken-1">
                        <v-icon dark size="30" class="mr1"> mdi-book </v-icon>
                        <h2 class="tittle white--text"> &nbsp; Gestión de Proyectos</h2>
                      </v-card-title>
                      <v-container>
                        <v-row>
                          <v-col>Encargado realizar mantenimientos a proyectos tanto
                            Regionales como Nacionales. Es capaz de Crear nuevos proyectos, Editar
                            proyectos existentes, Activar proyectos, Consultar y Cancelar proyectos
                            segun las necesidades requeridas por PADF</v-col>
                        </v-row>
                      </v-container>
                    </v-card>
                  </v-timeline-item>

                  <v-timeline-item color="blue-grey darken-1" class="mr-5" fill-dot left>
                    <v-card>
                      <v-card-title class="blue-grey darken-1">
                        <v-icon dark size="30" class="mr1"> mdi-flag-variant </v-icon>
                        <h2 class="tittle white--text"> &nbsp; Asignación de Indicadores</h2>
                      </v-card-title>
                      <v-container>
                        <v-row>
                          <v-col> Encargado asignar un Indicador a proyectos tanto
                            Reginales como Nacionales, segun las necesidades que este presente. Luego de
                            seleccior el indicador debera configurar el mismo, seleccionara la
                            metodologia de recolección de datos, linea base, fuente de datos, frecuencia
                            de medición, nivel de impacto y las diversas desagregaciones que tomaran
                            parte en el proyecto, preparando asi el posterior seguimiento del proyecto.
                          </v-col>
                        </v-row>
                      </v-container>
                    </v-card>
                  </v-timeline-item>

                  <v-timeline-item color="blue-grey darken-1" class="mr-5" fill-dot right>
                    <v-card>
                      <v-card-title class="blue-grey darken-1">
                        <v-icon class="mr1" dark size="30"> mdi-compass-outline</v-icon>
                        <h2 class="tittle white--text"> &nbsp; Plan de trabajo</h2>
                      </v-card-title>
                      <v-container>
                        <v-row>
                          <v-col> Encargado de crear un Plan de Trabajo tanto a proyectos
                            Regionales como Nacionales. Es capaz de crear, editar, eliminar Actividades y
                            Productos del plan de trabajo segun las necesidades requeridas de cada
                            proyecto. El plan de trabajo es de vital importancia para el seguimiento financiero
                            de cada proyecto y asi cumplir con las metas que se propone cumplir PADF
                            como Fundación. </v-col>
                        </v-row>
                      </v-container>
                    </v-card>
                  </v-timeline-item>

                  <v-timeline-item color="blue-grey darken-1" class="mr-5" fill-dot right>
                    <v-card>
                      <v-card-title class="blue-grey darken-1">
                        <v-icon class="mr1" dark size="30"> mdi-thumb-up</v-icon>
                        <h2 class="tittle white--text"> &nbsp; Verificar Proyectos</h2>
                      </v-card-title>
                      <v-container>
                        <v-row>
                          <v-col> Encargado velar que se cumplan los parametros establecidos
                            para el desarrollo d proyectos, verificando la información general de cada proyecto
                            la configuración de Indicadores de estos y ademas verificar el Plan de Trabajo
                            que estos presentan. Si la información general, configuración de Indicador y Plan
                            de Trabajo cumplen con los parametros establecidos debera enviar el proyecto
                            a un Chequeo Final por parte del Usuario Monitoreo y Evaluación para que
                            este sea desarrollado, de lo contrario Cancelara para que vuelvan realizarce
                            estos procesos segun las necesidades requeridas de cada proyecto y asi cumplir
                            con las metas que se propone cumplir PADF como Fundación. </v-col>
                        </v-row>
                      </v-container>
                    </v-card>
                  </v-timeline-item>

                <v-timeline-item color="blue-grey darken-1" class="mr-5" fill-dot right>
                    <v-card>
                      <v-card-title small class="blue-grey darken-1">
                        <v-icon dark size="30" class="mr1"> mdi-arrow-up-bold-box-outline </v-icon>
                        <h2 class="tittle white--text"> &nbsp; Seguimiento de Proyectos</h2>
                      </v-card-title>
                      <v-container>
                        <v-row>
                          <v-col>Encargado de velar por el cumplimiento de Indicadores,
                            teniendo un control del avance que se logra en cada trimestre, ademas
                            verificar el cumplimiento de cada Actividad que forma parte de los Planes de
                            Trabajo, teniendo un mejor conocimiento del uso de Fondos en el desarrollo
                            de proyectos, logrando asi un mejor manejo de Fondos en cada trimestre y
                            Finalizar con los parametros establecidos cada proyecto.
                          </v-col>
                        </v-row>
                      </v-container>
                    </v-card>
                </v-timeline-item>

              </v-timeline>
              </v-card>
          </v-container>
          <v-container grid-list-md v-else-if="this.user.RolId == '4'">
            <v-card    class="mx-auto"  >
            <v-card-title class="blue-grey darken-2 white--text">
              <v-icon dark size="30" class="mr1"> mdi-account-outline </v-icon>
              <span class="title">&nbsp; Coordinador Nacional</span>
            </v-card-title>
            </v-card>
              <v-card class="elevation">
                <v-timeline dense>

                  <v-timeline-item color="blue-grey darken-1" class="mr-5" fill-dot right>
                    <v-card>
                      <v-card-title small class="blue-grey darken-1">
                        <v-icon dark size="30" class="mr1"> mdi-book </v-icon>
                        <h2 class="tittle white--text"> &nbsp; Seguimiento de Proyectos</h2>
                      </v-card-title>
                      <v-container>
                        <v-row>
                          <v-col>Encargado alimentar los indicadores de cada proyecto
                            en los que esta involucrado tanto Regionales como Nacionales. Debera subir
                            la cantidad de desagregados segun se tipo al finalizar cada trimestre, para
                            que tanto Monitoreo y Evaluación como Directores Naciones pueden estar el tanto
                            del avance y cumplimiento de metas en cada proyecto.</v-col>
                        </v-row>
                      </v-container>
                    </v-card>
                  </v-timeline-item>

                  <v-timeline-item color="blue-grey darken-1" class="mr-5" fill-dot left>
                    <v-card>
                      <v-card-title class="blue-grey darken-1">
                        <v-icon dark size="30" class="mr1"> mdi-arrow-up-bold-box-outline </v-icon>
                        <h2 class="tittle white--text"> &nbsp; Evidencias de Plan de Trabajo</h2>
                      </v-card-title>
                      <v-container>
                        <v-row>
                          <v-col> Encargado subir los archivos o evidencias de cada
                            de Actividad de Plan de Trabajo que cada Proyecto tanto Regional como
                            Nacional posee, ayudando asi a mejorar el uso de Fondos para el desarrollo
                            de proyectos.</v-col>
                        </v-row>
                      </v-container>
                    </v-card>
                  </v-timeline-item>

              </v-timeline>
              </v-card>
          </v-container>
          <v-container grid-list-md v-else-if="this.user.RolId == '5'">
              <v-card    class="mx-auto"  >
            <v-card-title class="blue-grey darken-2 white--text">
              <v-icon dark size="30" class="mr1"> mdi-account-outline </v-icon>
              <span class="title">&nbsp; Director Financiero</span>
            </v-card-title>
            </v-card>
              <v-card class="elevation">
                <v-timeline dense>

                  <v-timeline-item color="blue-grey darken-1" class="mr-5" fill-dot right>
                    <v-card>
                      <v-card-title class="blue-grey darken-1">
                        <v-icon class="mr1" dark size="30"> mdi-thumb-up</v-icon>
                        <h2 class="tittle white--text"> &nbsp; Verificar Proyectos</h2>
                      </v-card-title>
                      <v-container>
                        <v-row>
                          <v-col> Encargado velar que se cumplan los parametros establecidos
                            para el desarrollo d proyectos, verificando la información general de cada proyecto
                            la configuración de Indicadores de estos y ademas verificar el Plan de Trabajo
                            que estos presentan. Si la información general, configuración de Indicador y Plan
                            de Trabajo cumplen con los parametros establecidos debera enviar el proyecto
                            a un Chequeo Final por parte del Usuario Monitoreo y Evaluación para que
                            este sea desarrollado, de lo contrario Cancelara para que vuelvan realizarce
                            estos procesos segun las necesidades requeridas de cada proyecto y asi cumplir
                            con las metas que se propone cumplir PADF como Fundación. </v-col>
                        </v-row>
                      </v-container>
                    </v-card>
                  </v-timeline-item>
                  <v-timeline-item color="blue-grey darken-1" class="mr-5" fill-dot right>
                    <v-card>
                      <v-card-title small class="blue-grey darken-1">
                        <v-icon dark size="30" class="mr1"> mdi-arrow-up-bold-box-outline </v-icon>
                        <h2 class="tittle white--text"> &nbsp; Seguimiento de Plan de Trabajo</h2>
                      </v-card-title>
                      <v-container>
                        <v-row>
                          <v-col>Encargado de velar por el cumplimiento
                            de cada Actividad que forma parte de los Planes de Trabajo, teniendo un
                            mejor conocimiento del uso de Fondos en el desarrollo de proyectos,
                            logrando asi un mejor manejo de Fondos en cada trimestre y Finalizar con
                            los parametros establecidos cada proyecto.
                          </v-col>
                        </v-row>
                      </v-container>
                    </v-card>
                  </v-timeline-item>

              </v-timeline>
              </v-card>
          </v-container>
      </v-flex>

      <v-flex md6>
        <v-container grid-list-md v-if="this.user.RolId == '2'">
          <v-card class="mb-3">
            <v-card-title small class="teal darken-4">
              <v-icon dark size="30" class="mr1"> mdi-comment-text-multiple-outline </v-icon>
              <h2 class="tittle white--text"> &nbsp; Notificaciones</h2>
            </v-card-title>
            <v-card-text>
              <v-data-table :headers="headers" hide-actions>
              </v-data-table>
            </v-card-text>
          </v-card>
        </v-container>
        <v-container grid-list-md v-else-if="this.user.RolId == '3'">
          <v-card class="mb-3">
            <v-card-title small class="blue-grey darken-2 white--text">
              <v-icon dark size="30" class="mr1"> mdi-comment-text-multiple-outline </v-icon>
              <h2 class="tittle white--text"> &nbsp; Notificaciones</h2>
            </v-card-title>
            <v-card-text>
              <v-data-table :headers="headers" hide-actions>
              </v-data-table>
            </v-card-text>
          </v-card>
        </v-container>
        <v-container grid-list-md v-else-if="this.user.RolId == '4'">
          <v-card class="mb-3">
            <v-card-title small class="blue-grey darken-2 white--text">
              <v-icon dark size="30" class="mr1"> mdi-comment-text-multiple-outline </v-icon>
              <h2 class="tittle white--text"> &nbsp; Notificaciones</h2>
            </v-card-title>
            <v-card-text>
              <v-data-table :headers="headers" hide-actions>
              </v-data-table>
            </v-card-text>
          </v-card>
        </v-container>
        <v-container grid-list-md v-else-if="this.user.RolId == '5'">
          <v-card class="mb-3">
            <v-card-title small class="blue-grey darken-2 white--text">
              <v-icon dark size="30" class="mr1"> mdi-comment-text-multiple-outline </v-icon>
              <h2 class="tittle white--text"> &nbsp; Notificaciones</h2>
            </v-card-title>
            <v-card-text>
              <v-data-table :headers="headers" hide-actions>
              </v-data-table>
            </v-card-text>
          </v-card>
        </v-container>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script>

  export default {
    data() {
      return {
        user: window.User,
        pagination: {},
        headers: [
                    {
                        text: 'Proyecto',   //Texto a mostrar en la cabecera de la columna
                        align: 'left',      //Alineación del contenido en la columna
                        value: 'nombrePersonal',    //Nombre del atributo que se colocara en la columna
                        width: '20%',       //Tamaño de la columna
                        type: 'text'        //Tipo del contenido a mostrar en la columna
                    },
                    {text: 'Estado', align: 'center', value: 'action', sortable: false, type: 'option'}
                ],
      }
    },
  }
</script>
