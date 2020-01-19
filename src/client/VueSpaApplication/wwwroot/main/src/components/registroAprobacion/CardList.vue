<template>
    <v-dialog v-model="visibleApprovalLogList" width="500" persistent scrollable>
        <v-card>
            <v-card-title class="headline blue-grey darken-2 white--text" dark>Aprobación del proyecto</v-card-title>
            <v-card-text>
                <v-row>
                    <v-col cols="auto">
                        <v-alert
                                icon="mdi-shuffle"
                                prominent
                                text
                                type="info"
                        >
                            El proyecto pasara automaticamente al siguiente paso cuando todos los países a los que pertenece aprueben el proyecto.
                        </v-alert>
                        <v-data-table
                                :headers="headers"
                                :items="approvalLogList"
                                hide-default-footer
                                disable-pagination
                                class="elevation-1 mt-5"
                        >
                            <template v-slot:item.aprobado="{ item }">
                                <v-chip :color="getColor(item.aprobado)" dark>
                                    <v-icon v-if="!item.aprobado">mdi-pause-circle-outline</v-icon>
                                    <v-icon v-if="item.aprobado">mdi-checkbox-marked-circle-outline</v-icon>
                                </v-chip>
                            </template>
                        </v-data-table>
                    </v-col>
                </v-row>
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="grey darken-1" text @click="changeApprovalLogListVisibility">Cerrar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapState, mapMutations} from 'vuex'
    export default {
        name: "CardList",
        data () {
            return {
                headers: [
                    { text: 'Estado',align: 'left',sortable: false,value: 'aprobado',},
                    { text: 'País', value: 'nombrePais' },
                    { text: 'Fecha aprobado', value: 'fechaF' },
                ],
            }
        },
        computed: {
            ...mapState(['approvalLogList','visibleApprovalLogList'])
        },
        methods: {
            ...mapMutations(['changeApprovalLogListVisibility']),
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

<style scoped>

</style>