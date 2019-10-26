<template>
    <v-layout row justify-center>
        <v-dialog v-model="visibleReviewLogList" persistent width="750">        
        <v-card>
            <v-card-title class="headline blue-grey darken-2 white--text" dark>Registro de revisiones</v-card-title>
            <v-card-text>
                <v-data-table
                    :items="reviewLogList"
                    class="elevation-1"
                    hide-actions
                    hide-headers
                >
                    <template v-slot:items="props">
                    <td class="text-xs-center">                        
                        <v-icon v-if="!props.item.revisado">mdi-pause-circle-outline</v-icon>
                        <v-icon v-if="props.item.revisado">mdi-checkbox-marked-circle-outline</v-icon>
                        <v-icon v-if="props.item.retornado">mdi-alert-circle</v-icon>
                    </td>
                    <td class="text-xs-center">{{ props.item.revisado ? props.item.fecha : "---/--/---- --:--" }}</td>
                    <td class="text-xs-right">{{ props.item.numero }}° Revisión</td>
                    <td class="text-xs-right">Q{{ props.item.trimestre }}</td>
                    <td class="text-xs-right">{{ props.item.pais }}</td>
                    <td class="text-xs-right" v-bind:style="{color: props.item.revisado ? 'green' : 'red'}">{{ props.item.revisado ? "Revisado" : "Pendiente" }}</td>                    
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

        }
    },
    computed: {
        ...mapState(['reviewLogList','visibleReviewLogList'])
    },
    methods: {
        ...mapMutations(['changeReviewLogListVisibility']),
        buildData() {
            
        }         
    }    
}
</script>