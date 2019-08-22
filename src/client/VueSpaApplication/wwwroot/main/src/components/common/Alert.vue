<template>
    <v-container>
        <v-layout>
            <v-flex>
                <v-alert :color="alert.color" :icon="alert.icon" :value="alert.value"
                         dismissible
                         outline
                         transition="scale-transition"
                         v-bind:data="alert"
                         v-bind:key="index"
                         v-for="(alert, index) in alerts"
                >
                    {{alert.text}}
                </v-alert>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
    import {mapMutations, mapState} from 'vuex'

    export default {
        name: "alert",
        computed: {
            ...mapState(['alerts'])
        },
        methods: {
            ...mapMutations(['addAlert', 'cleanAlerts'])
        }
    }
</script>

<style scoped>

</style>