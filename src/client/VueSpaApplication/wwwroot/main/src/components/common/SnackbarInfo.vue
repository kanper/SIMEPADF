<template>
    <v-snackbar :timeout="timeout" :value="snackbarInformationVisible">
        {{ snackbarInformationText }}
        <v-btn @click="closeInfo" color="pink" text>Cerrar</v-btn>
    </v-snackbar>
</template>

<script>
    import {mapMutations, mapState} from 'vuex'

    export default {
        data () {
            return {
                timeout: 15000
            }
        },
        computed: {
            ...mapState(['snackbarInformationText', 'snackbarInformationVisible']),
        },
        methods: {
            ...mapMutations(['closeInfo'])
        }
    }
</script>