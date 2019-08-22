<template>
    <v-snackbar :auto-height="true" :timeout="15000" :value="snackbarInformationVisible">
        {{ snackbarInformationText }}
        <v-btn @click="closeInfo" color="pink" flat>Cerrar</v-btn>
    </v-snackbar>
</template>

<script>
    import {mapMutations, mapState} from 'vuex'

    export default {
        computed: {
            ...mapState(['snackbarInformationText', 'snackbarInformationVisible']),
        },
        methods: {
            ...mapMutations(['closeInfo'])
        }
    }
</script>