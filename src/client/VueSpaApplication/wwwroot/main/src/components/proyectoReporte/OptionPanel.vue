<template>
    <v-card class="mx-auto mb-1" outlined>
        <v-card-text>
            <div>Opciones de busqueda</div>
            <v-row justify="space-between">
                <v-col cols="2">
                    <v-select
                            v-model="year"
                            :items="years"
                            chips
                            label="Año"
                            prepend-icon="mdi-calendar"
                            @change="rebuildTableData"
                    ></v-select>
                    <v-select
                            v-model="quarter"
                            :items="quarters"
                            chips
                            label="Trimestre"
                            prepend-icon="mdi-calendar-multiple"
                            @change="rebuildTableData"
                    ></v-select>
                </v-col>
                <v-col cols="4">
                    <v-select
                            v-model="country"
                            :items="countries"
                            chips
                            label="Paises"
                            prepend-icon="mdi-flag-outline"
                            @change="rebuildTableData"
                            multiple
                            item-text="nombre"
                            item-value="id"
                    ></v-select>
                </v-col>
                <v-col cols="4">
                    <v-select
                            v-model="socio"
                            :items="socios"
                            chips
                            label="Socios Internacionales"
                            prepend-icon="mdi-domain"
                            @change="rebuildTableData"
                            multiple
                            item-text="nombre"
                            item-value="id"
                    ></v-select>
                </v-col>

                <v-col cols="auto" class="text-center pl-0">
                    <v-row class="flex-column ma-0 fill-height" justify="center">
                        <v-col class="px-0">
                            <!-- PDF -->
                        </v-col>
                    </v-row>
                </v-col>
            </v-row>
        </v-card-text>
    </v-card>
</template>

<script>
    import {mapState, mapMutations, mapActions} from 'vuex'
    export default {
        name: "OptionPanel",
        props: {

        },
        data() {
            return {
                quarters:[{text:'Q1',value:'1'}, {text:'Q2',value:'2'}, {text:'Q3',value:'3'}, {text:'Q4',value:'4'}],
                quarter: null,
                years: [],
                year: null,
                countries: [],
                country: [],
                socios: [],
                socio: []
            }
        },
        computed: {
            ...mapState(['services','modelSpecification'])
        },
        methods: {
            ...mapActions(['loadDataTable']),
            ...mapMutations(['showInfo']),
            rebuildTableData(){
                this.loadDataTable();
            }
        },
        created() {
            let currentYear = new Date().getFullYear();
            this.years.push({text:currentYear,value:currentYear});
            for(let i = 1; i < 20 ; i++){
                this.years.push({text:(currentYear - i),value:(currentYear - i) + ''});
            }
            this.services.simpleIdentificadorService.getPaises()
                .then(r => {
                    this.countries = r.data;
                })
                .catch(e => {
                    this.showInfo(e.toString());
                });
            this.services.simpleIdentificadorService.getSocios()
                .then(r => {
                    this.socios = r.data;
                })
                .catch(e => {
                    this.showInfo(e.toString());
                });
        }
    }
</script>

<style scoped>

</style>