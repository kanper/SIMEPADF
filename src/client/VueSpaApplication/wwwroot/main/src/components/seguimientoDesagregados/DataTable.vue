<template>
    <v-card>
        <v-card-title>
            <h2 class="font-weight-light">Registro de {{modelSpecification.modelTitle}}</h2>
            <v-spacer></v-spacer>
        </v-card-title>
        <v-simple-table>
            <template v-slot:default>
                <thead>
                <tr>
                    <th>Desagregados / Socios</th>
                    <th class="text-center" v-for="item in headers" :key="item.id">{{item.text}}</th>
                    <th class="text-center">Totales Trimestre</th>
                </tr>
                </thead>
                <tbody>
                <tr v-for="item in dataTable" :key="item.id">
                    <th scope="row">{{item.id}}</th>
                    <td class="text-center" v-for="column in headers" :key="column.id">
                        <v-btn :disabled="isEditAvailable()" @click="editCellValue(item.rowId,column.value)" text>{{getSocioValue(item.socios,column.value)}}</v-btn>
                    </td>
                    <td class="text-center">{{getRowTotal(item.socios)}}</td>
                </tr>
                </tbody>
            </template>
        </v-simple-table>
        <EditCell :desagregado="desagregado" :socio="socio" :reload="loadData"/>
    </v-card>
</template>

<script>
    import { mapMutations, mapState} from 'vuex'
    import EditCell from "./EditCell";

    export default {
        components: {EditCell},
        comments: [
          EditCell
        ],
        data() {
            return {
                isTableLoading: true,
                headers: [],
                dataTable: [],
                desagregado: '',
                socio: ''
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'services'])
        },
        methods: {
            ...mapMutations(['showInfo', 'changeNewDialogVisibility', 'closeAllDialogs', 'resetTableLoader','changeCellDialogVisibility', 'setTableCellValue']),
            loadData: function() {
                this.services.proyectoSeguimientoRegistroService.getAll(this.$route.params.idProyecto,this.$route.params.idIndicador)
                    .then(r => {
                        let rows = [];
                        r.data.forEach(function (item) {
                            let ids = "S" + item.idSocio;
                            if(rows.find(function (row) {return row.id === item.nombreDesagregado;})){
                                let res = rows.find(function (f) {
                                  return f.id === item.nombreDesagregado;
                                });
                                let v = res.socios.find(function (s) {return s.nombre === ids;});
                                if(v){
                                    v.valor = item.valor;
                                }else {
                                    res.socios.push({nombre: ids, valor: item.valor});
                                }
                            } else {
                                rows.push({id:item.nombreDesagregado,rowId:item.idDesagregado,socios:[{nombre:ids, valor:item.valor}]})
                            }
                        });
                        this.dataTable = rows;
                    })
                    .catch(e => {
                        this.showInfo(e.toString());
                    })
            },
            getSocioValue(socios, value){
                return socios.find(function (item) {
                    return item.nombre === value;
                }).valor;
            },
            editCellValue(desagregado, socio){
                this.desagregado = desagregado;
                this.socio = socio.replace("S", "");
                this.services.proyectoSeguimientoRegistroService.getValor(this.$route.params.idProyecto,this.$route.params.idIndicador,desagregado,socio.replace("S", ""))
                    .then(r => {
                        this.setTableCellValue(r.data);
                    })
                    .catch(e => {
                        this.showInfo(e.toString());
                    });
                this.changeCellDialogVisibility();
            },
            getRowTotal(socios){
                let total = 0;
                socios.forEach(function (item) {
                    total += item.valor;
                });
                return total;
            },
            isEditAvailable(){
                return window.User.RolId !== '4';
            }
        },
        created() {
            this.services.proyectoSeguimientoRegistroService.getSocios(this.$route.params.idProyecto)
                .then(r => {
                    this.headers.push.apply(this.headers, r.data);
                })
                .catch(e => {
                    this.showInfo(e.toString());
                });
            this.loadData();
        },
        destroyed() {

        }
    }
</script>
