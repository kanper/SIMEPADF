<template>
    <v-layout row justify-center>
        <v-dialog v-model="visibleReviewLogList" width="750" persistent scrollable>
        <v-card>
            <v-card-title class="headline blue-grey darken-2 white--text" dark>Registro de revisiones</v-card-title>
            <v-card-text>                
                <v-data-table
                    :headers="headers"
                    :items="reviewLogList"
                    hide-default-footer
                    disable-pagination
                    class="elevation-1 mt-5"
                >
                <template v-slot:item.revisado="{ item }">
                  <v-chip :color="getColor(item.revisado)" dark>
                    <v-icon v-if="!item.revisado">mdi-pause-circle-outline</v-icon>
                    <v-icon v-if="item.revisado">mdi-checkbox-marked-circle-outline</v-icon>
                    <v-icon v-if="item.retornado">mdi-alert-circle</v-icon>
                  </v-chip>
                </template>
                </v-data-table>                
            </v-card-text>
            <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="grey darken-1" text @click="changeReviewLogListVisibility">Cerrar</v-btn>            
            </v-card-actions>
        </v-card>
        </v-dialog>
    </v-layout>        
</template>

<script>
import {mapState, mapMutations} from 'vuex';

export default {

    data () {
        return {
            headers: [
                { text: 'Estado',align: 'left',sortable: false,value: 'revisado',},
                { text: 'Número revisión', value: 'numero' },
                { text: 'Trimestre', value: 'trimestreF' },
                { text: 'Rol', value: 'rol' },
                { text: 'País', value: 'pais' },
                { text: 'Fecha revisión', value: 'fechaF' },
        ],
        }
    },
    computed: {
        ...mapState(['reviewLogList','visibleReviewLogList'])
    },
    methods: {
        ...mapMutations(['changeReviewLogListVisibility']),
        getColor(rev){
            if(rev){
                return 'green'
            }else {
                return 'red'
            }
        }         
    }    
}
</script>