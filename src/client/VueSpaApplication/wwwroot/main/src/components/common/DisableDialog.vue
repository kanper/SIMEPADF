<template>
    <v-dialog v-model="visibleDisableCRUDDialog" persistent hide-overlay width="400">
        <v-card color="blue-grey" dark>
            <v-card-title class="text-uppercase">
                <v-icon class="mr-2">mdi-key-remove</v-icon>
                {{modelSpecification.modelName}} Bloqueado
            </v-card-title>
            <v-card-text>
                Las modificaciones sobre el registro de {{modelSpecification.modelName}} no son permitidas mientras este en uso.
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn color="white" text @click="changeDisableDialog()">Cerrar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapState, mapMutations} from 'vuex'
    export default {
        name: "DisableDialog",
        computed: {
            ...mapState(['modelSpecification', 'visibleDisableCRUDDialog'])
        },
        methods: {
            ...mapMutations(['changeDisableDialog'])
        }
    }
</script>

<style scoped>

</style>