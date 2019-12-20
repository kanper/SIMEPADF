<template>
    <v-card class="mx-auto mb-1" outlined>
        <v-card-text>
            <div>Opciones de busqueda</div>
            <v-row justify="space-between">
                <v-col cols="6">
                    <v-select
                            v-model="audit"
                            :items="auditList"
                            chips
                            label="Auditar a"
                            prepend-icon="mdi-table"
                            @change="rebuildTableData"
                    ></v-select>
                </v-col>

                <v-col cols="auto" class="text-center pl-0">
                    <v-row class="flex-column ma-0 fill-height" justify="center">
                        <v-col class="px-0">
                            <AuditoriaPDFMaker />
                        </v-col>
                    </v-row>
                </v-col>
            </v-row>
        </v-card-text>
    </v-card>
</template>

<script>
    import {mapState, mapActions} from 'vuex'
    import AuditoriaPDFMaker from "../pdf/AuditoriaPDFMaker";
    export default {
        name: "OptionPanel",
        components: {AuditoriaPDFMaker},
        props: {

        },
        data() {
            return {
                auditList: [{text:'Mostrar Todos',value:'all'},{text:'Actividades',value:'actividad'},{text:'Desagregación',value:'desagregado'},{text:'Fuente Dato',value:'fuente'},{text:'Indicador',value:'indicador'},{text:'Nivel de Impacto',value:'nivel'},{text:'Objetivo',value:'objetivo'},{text:'Organización Responsable',value:'organizacion'},{text:'País',value:'pais'},{text:'Plan Trabajo: Actividad',value:'actividadPT'},{text:'Producto',value:'producto'},{text:'Proyecto',value:'proyecto'},{text:'Resultado',value:'resultado'},{text:'Socio Internacional',value:'socio'}],
                audit: {text:'Mostrar Todos',value:'all'},
            }
        },
        computed: {
            ...mapState(['modelSpecification'])
        },
        methods: {
            ...mapActions(['loadDataTable']),
            rebuildTableData(){
                this.modelSpecification.modelParams.auditClass = this.audit;
                this.loadDataTable();
            }
        },
        created() {

        }
    }
</script>

<style scoped>

</style>