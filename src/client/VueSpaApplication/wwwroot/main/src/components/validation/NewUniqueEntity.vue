<template>
    <v-alert dense text :type="getAlertType()" v-show="showAlert()">
        {{getAlertContent()}}
    </v-alert>
</template>

<script>
    import {mapState} from 'vuex'
    export default {
        name: "NewUniqueEntity",
        props: {
            identifierName: String,
            identifierValue: String
        },
        data() {
            return {
                alertType: 'success'
            }
        },
        computed: {
            ...mapState(['isUniqueEntity'])
        },
        methods: {
            showAlert(){
                if(this.identifierValue === null || this.identifierValue === undefined){
                    return false;
                }
                return this.identifierValue.length > 0
            },
            getAlertType(){
                if(this.isUniqueEntity){
                    return "success";
                }else {
                    return "error";
                }
            },
            getAlertContent(){
                if(this.isUniqueEntity){
                    return "El " + this.identifierName + " ingresado es válido.";
                }else {
                    return "El " + this.identifierName + " ingresado ya existe o no es válido. Intente con uno diferente.";
                }
            }
        }
    }
</script>

<style scoped>

</style>