<template>
    <v-dialog v-model="visibleRejectDialog" max-width="500">
        <v-card>
            <v-card-title class="headline">Retornar a coordinador</v-card-title>
            <v-card-text>
                <v-alert
                        text
                        dense
                        color="teal"
                        icon="mdi-clock-fast"
                        border="left"
                >
                    El proyecto "{{CRUDModel.nombreProyecto}}" se retornará al coordinador del país correspondiente con las siguientes observaciones.
                </v-alert>
                <v-textarea
                        v-model="observation"
                        outlined
                        name="comment"
                        label="Observaciones"
                        clearable
                        counter
                ></v-textarea>
            </v-card-text>

            <v-card-actions>
                <v-btn color="grey darken-1" text @click="cancel()">Cancelar</v-btn>
                <v-spacer></v-spacer>
                <v-btn color="green darken-1" text @click="reject()">Retornar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapState, mapMutations, mapActions} from 'vuex'
    export default {
        name: "RejectDialog",
        data () {
            return {
                observation: ''
            }
        },
        computed: {
            ...mapState(['services','CRUDModel','visibleRejectDialog','modelSpecification'])
        },
        methods: {
            ...mapMutations(['changeRejectDialogVisibility','showInfo','addAlert']),
            ...mapActions(['loadDataTable']),
            reject() {
                this.services[this.modelSpecification.modelService].reject(this.CRUDModel.id,this.observation,this.getUserFullName())
                    .then(r => {
                        this.loadDataTable();
                        this.addAlert({
                            value: true,
                            color: 'info',
                            icon: 'mdi-alert-circle',
                            text: 'Los proyecto fue retornado correctamente.'
                        });
                    })
                    .catch(e => {
                        this.addAlert({
                            value: true,
                            color: 'danger',
                            icon: 'mdi-alert',
                            text: 'No se pudo realizar los cambios, Intente nuevamente más tarde o recarge la pagína.'
                        });
                    });
                this.changeRejectDialogVisibility();
            },
            cancel() {
                this.observation = '';
                this.changeRejectDialogVisibility();
            },
            getUserFullName(){
                return window.User.Nombre + ' ' + window.User.Apellido;
            }
        }
    }
</script>

<style scoped>

</style>