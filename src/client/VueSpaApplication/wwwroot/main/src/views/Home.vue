<template>
  <v-container grid-list-md v-if="this.user.RolId == '1'">
    <v-layout row wrap>
      <v-flex xs12 sm6>
        <v-card>
          <v-img src="/Sysadmin.jpg"></v-img>
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

          </v-card-title>
          <v-card-text>

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
          <v-img src="/Monitor.jpg"></v-img>
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

          </v-card-title>
          <v-card-text>

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
          <v-img src="/director.jpg"></v-img>
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

          </v-card-title>
          <v-card-text>

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
          <v-img src="/Coordinador.jpg"></v-img>
          <v-card-title>Coordinador de Pais</v-card-title>
          <v-card-text>

          </v-card-text>
        </v-card>
      </v-flex>
      <v-flex xs12 sm6>
        <v-card>
          <v-img></v-img>
          <v-card-title>

          </v-card-title>
          <v-card-text>

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
          <v-img src="/finanzas.jpg"></v-img>
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

          </v-card-title>
          <v-card-text>

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
