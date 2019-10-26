<template>
    <v-dialog v-model="visibleConfirmationDialog" max-width="350" persistent>
        <v-card>
            <v-card-title class="headline justify-center">¿Desea realizar los cambios?</v-card-title>

            <v-card-actions>
                <v-btn color="grey darken-1" text @click="changeConfirmationDialogVisibility">Cancelar</v-btn>
                <v-spacer></v-spacer>
                <v-btn color="blue darken-1" text @click="executeLink">Aceptar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapState, mapMutations, mapActions} from 'vuex'
    export default {

        name: "ConfirmationDialog",
        computed: {
            ...mapState(["services","modelSpecification","visibleConfirmationDialog", "confirmationId", "confirmationAction"])
        },
        methods: {
            ...mapMutations(["changeConfirmationDialogVisibility","addAlert"]),
            ...mapActions(['loadDataTable']),
            executeLink(){
                this.services[this.modelSpecification.modelService].executeAction(this.confirmationId,this.confirmationAction,this.modelSpecification.modelParams)
                    .then(r => {
                        this.changeConfirmationDialogVisibility();
                        this.loadDataTable();
                        this.addAlert({
                            value: true,
                            color: 'info',
                            icon: 'mdi-alert-circle',
                            text: 'Los cambios se aplicaron correctamente.'
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
            }
        }
    }
</script>

<style scoped>

</style>