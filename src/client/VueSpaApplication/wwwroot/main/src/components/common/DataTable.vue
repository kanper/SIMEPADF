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
                :loading="isTableLoading"
                :search="search"
                multi-sort
        >
            <template v-slot:item.action="{ item }">
                <TableOption
                        :model="item"
                        :modelId="item[modelSpecification.modelPK]"
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
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'services', 'dataTable', 'isTableLoading'])
        },
        methods: {
            ...mapMutations(['showInfo', 'changeNewDialogVisibility', 'closeAllDialogs', 'resetTableLoader']),
            ...mapActions(['loadDataTable']),
            visibleOptions(row) {
                return this.options.filter(function (o) {
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
