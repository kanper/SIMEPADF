<template>
    <v-card class="mx-auto mb-1" outlined>
        <v-card-title class="font-weight-light">
            Opciones de búsqueda
        </v-card-title>
        <v-card-text>
            <v-row justify="space-between">
                <v-col cols="4">
                    <v-select
                            v-model="year"
                            :items="years"
                            chips
                            label="Año"
                            prepend-icon="mdi-calendar"
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
                if(this.year !== null && this.country.length > 0 && this.socio.length > 0){
                    this.modelSpecification.modelParams = {
                        year: this.year,
                        countries: this.country.join('$'),
                        socios: this.socio.join('$')
                    };
                    this.loadDataTable();
                }
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