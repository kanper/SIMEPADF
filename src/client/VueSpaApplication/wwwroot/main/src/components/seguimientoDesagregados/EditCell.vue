<template>
    <v-row justify="center">
        <v-dialog v-model="visibleCellDialog" persistent max-width="290">
            <v-card>
                <v-card-title></v-card-title>
                <v-card-text>
                    <v-text-field label="Desagregados" v-model="cellValue" :readonly="isEditAvailable()"></v-text-field>
                </v-card-text>
                <v-card-actions>
                    <v-btn color="grey darken-1" text @click="changeCellDialogVisibility">Cancelar</v-btn>
                    <v-spacer></v-spacer>
                    <v-btn :disabled="isEditAvailable()" color="green darken-1" text @click="save">Aceptar</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </v-row>
</template>

<script>
    import { mapMutations, mapState } from 'vuex'
    export default {
        name: "EditCell",
        props: ['desagregado','socio','reload','quarter'],
        data() {
            return {
                valor: 0
            }
        },
        computed: {
            ...mapState(['visibleCellDialog','services','modelSpecification','tableCellValue']),
            cellValue: {
                get: function() {
                    return this.tableCellValue;
                },
                set: function(newValue) {
                    this.setTableCellValue(newValue);
                }
            }
        },
        methods: {
            ...mapMutations(['changeCellDialogVisibility','setTableCellValue','showInfo']),
            save(){
                this.services.proyectoSeguimientoRegistroService.setValorByPais(this.$route.params.idProyecto,this.$route.params.idIndicador,this.desagregado,this.socio.replace("S", ""),this.cellValue, window.User.Pais,this.quarter)
                    .then(r => {
                        this.changeCellDialogVisibility();
                        this.showInfo("Datos guardados correctamente.");
                    })
                    .catch(e => {
                        this.showInfo(e.toString());
                    })
                    .finally(() => this.reload());
            },
            isEditAvailable(){
                return window.User.RolId !== '4';
            }
        }
    }
</script>

<style scoped>

</style>