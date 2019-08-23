<template xmlns:v-slot="http://www.w3.org/1999/XSL/Transform">
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
        >
            <template v-slot:items="props">
                <td :class="(at['align'] === 'center' ? 'text-xs-center': 'text-xs-left') + ' ' + (at['style'] !== undefined ? at['style'] : '')" v-for="at in headers">
                    {{buildTableCell(props.item,at)}}
                    <TableOption :modelId="props.item[modelSpecification.modelPK]" v-bind:data="item" v-bind:key="item.text" :model="props.item"
                                 v-for="item in options" v-if="at.value === 'action' && item.show(props.item)"/>
                </td>
            </template>
            <template v-slot:no-results>
                <v-alert :value="true" color="error" icon="mdi-alert">
                    La busqueda de "{{ search }}" no tiene resultados.
                </v-alert>
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
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'services', 'dataTable'])
        },
        methods: {
            ...mapMutations(['showInfo', 'changeNewDialogVisibility', 'closeAllDialogs']),
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
                            return value;
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
            }

        },
        created() {
            this.loadDataTable();
        }
    }
</script>
<style>
    .active-column {
        background-color: #E0E0E0;
    }
</style>