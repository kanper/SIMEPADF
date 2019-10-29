<template>
    <v-card>
        <v-card-title>
            <h2 class="font-weight-light">Registro de {{modelSpecification.modelTitle}}</h2>
            <v-spacer></v-spacer>
            <v-text-field
                    append-icon="mdi-magnify"
                    label="Buscar..."
                    single-line
                    v-model="search"
            ></v-text-field>
        </v-card-title>
        <v-data-table
                :headers="headers"
                :items="dataTable"
                :search="search"
                :loading="isTableLoading"                
        >
            <template v-slot:item.action="{ item }">                
                <TableOption
                            :modelId="item[modelSpecification.modelPK]"
                            :model="item"
                            v-bind:data="opt"
                            v-bind:key="index"                            
                            v-for="(opt,index) in visibleOptions(item)"
                    />
            </template>            
        </v-data-table>
    </v-card>
</template>

<script>
    import {mapActions, mapMutations, mapState} from 'vuex'
    import TableOption from './DataTableOption'

    export default {
        props: ['headers', 'options'],
        components: {TableOption},
        data() {
            return {
                search: '',
                cellIcon:'',                
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'services', 'dataTable','isTableLoading'])                  
        },
        methods: {
            ...mapMutations(['showInfo', 'changeNewDialogVisibility', 'closeAllDialogs','resetTableLoader']),
            ...mapActions(['loadDataTable']),
            buildTableCell(item, format) {
                let value = item[format['value']];
                if(value !== undefined){
                    switch (format['type']) {
                        case 'text':
                            return value;
                        case 'number':
                            return this.numberWithCommas(value);
                        case 'date':
                            return this.formatDate(value);
                        case 'datetime':
                            return this.formatDateTime(value);
                        case 'money':
                            return '$ ' + this.numberWithCommas(value);
                        case 'percent':
                            return value + ' %';
                        case 'time':
                            return this.formatTime(value);
                        case 'boolean':
                            this.buildBooleanCell(value);
                            return '';
                        case 'array':
                            return value.map(function (item) {
                                return item['nombre'];
                            }).join(', ');
                        case 'obj':
                            return value.nombre;
                        default:
                            return value;
                    }
                }
            },
            resumeLargeText(text) {
                if (text !== undefined && text !== null) {
                    if (text.length > 100) {
                        return text.substring(0, 101).concat('...');
                    }
                }
                return text;
            },
            formatDate(text){
                return text.split('T')[0];
            },
            formatTime(text){
                return text.split('T')[1];
            },
            formatDateTime(text){
                let datetime = text.split('T');
                return datetime[0] + ' ' + datetime[1];
            },
            numberWithCommas(x) {
                return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
            },
            buildBooleanCell(bool){
                if(bool){
                    return 'mdi-checkbox-marked-circle';
                }else{
                    return 'mdi-minus-circle';
                }
            },            
            visibleOptions(row){
                return this.options.filter(function(o) {
                    return o.show(row);
                });
            }

        },
        created() {
            this.loadDataTable();
        },
        destroyed() {
            this.resetTableLoader();
        }
    }
</script>
<style>
    .active-column {
        background-color: #E0E0E0;
    }
</style>