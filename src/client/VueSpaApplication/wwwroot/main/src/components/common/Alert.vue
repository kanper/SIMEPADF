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
                    {{showAlert(index)}}
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
        data () {
            return {
                elapse: null,
                activeTime: 5000,
                visibleTime: true
            }
        },
        computed: {
            ...mapState(['alerts'])
        },
        methods: {
            ...mapMutations(['addAlert', 'cleanAlerts']),
            showAlert (index) {
                let timer = this.showAlert.timer;
                if (timer) {
                    clearTimeout(timer)
                }
                this.showAlert.timer = setTimeout(() => {
                    this.alerts[index].value = false
                }, this.activeTime);

                this.elapse = 1;
                let t = this.showAlert.t;
                if (t) {
                    clearInterval(t)
                }

                this.showAlert.t = setInterval(() => {
                    if (this.elapse === 3) {
                        this.elapse = 0;
                        clearInterval(this.showAlert.t)
                    }
                    else {
                        this.elapse++
                    }
                }, 1000)
            }
        }
    }
</script>

<style scoped>

</style>