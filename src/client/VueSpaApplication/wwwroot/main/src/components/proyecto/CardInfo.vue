<template>
    <v-dialog v-model="visibleInfoDialog" fullscreen hide-overlay transition="dialog-bottom-transition" >
        <v-card>
            <v-toolbar class="headline blue darken-3 white--text">
                <v-btn icon dark @click="changeInfoDialogVisibility">
                    <v-icon>mdi-close</v-icon>
                </v-btn>
                <v-toolbar-title>Registro de {{modelSpecification.modelTitle}}: Información</v-toolbar-title>                                
            </v-toolbar>            
            <v-tabs fixed-tabs>
                <v-tab key="1">Datos generales</v-tab>
                <v-tab key="2">Indicadores</v-tab>
                <v-tab key="3">Plan de trabajo</v-tab>
                <v-tab-item key="1">
                <v-card-text>
                <v-container fluid grid-list-lg>
                    <v-layout row wrap>
                        <v-flex xs12>
                            <v-text-field
                                :value="CRUDModel.nombreProyecto"  
                                label="Nombre del proyecto"
                                outlined
                                readonly
                            ></v-text-field>
                        </v-flex>
                        <v-flex xs6>
                            <v-text-field
                                :value="numberWithCommas(CRUDModel.montoProyecto)"  
                                label="Monto del proyecto"
                                outlined
                                readonly
                                prepend-inner-icon="mdi-cash-usd"
                            ></v-text-field>
                            <v-text-field
                                :value="CRUDModel.estado"  
                                label="Estado del proyecto"
                                outlined
                                readonly
                            ></v-text-field>
                        </v-flex>
                        <v-flex xs6>
                            <v-text-field
                                :value="numberWithCommas(CRUDModel.beneficiarios)"
                                label="Beneficiarios"
                                outlined
                                readonly
                            ></v-text-field>
                            <v-text-field
                                :value="CRUDModel.clasificacion"
                                label="Clasificación"
                                outlined
                                readonly
                            ></v-text-field>
                        </v-flex>
                        <v-flex xs4>
                            <v-text-field
                                :value="formatDate(CRUDModel.fechaAprobacion)"
                                label="Fecha de aprobación"
                                outlined
                                readonly
                                prepend-inner-icon="mdi-calendar"
                            ></v-text-field>
                        </v-flex>
                        <v-flex xs4>
                            <v-text-field
                                :value="formatDate(CRUDModel.fechaInicio)"
                                label="Fecha de inicio"
                                outlined
                                readonly
                                prepend-inner-icon="mdi-calendar"
                            ></v-text-field>
                        </v-flex>
                        <v-flex xs4>
                            <v-text-field
                                :value="formatDate(CRUDModel.fechaFin)"
                                label="Fecha de finalización"
                                outlined
                                readonly
                                prepend-inner-icon="mdi-calendar"
                            ></v-text-field>
                        </v-flex>
                        <v-flex xs12>
                            <v-select
                                v-model="CRUDModel.paises"
                                :items="CRUDModel.paises"
                                item-text="nombre"
                                chips
                                label="Paises"
                                multiple
                                outlined
                                readonly
                            ></v-select>
                            <v-select
                                v-model="CRUDModel.organizaciones"
                                :items="CRUDModel.organizaciones"
                                item-text="nombre"
                                chips
                                label="Organizaciones"
                                multiple
                                outlined
                                readonly
                            ></v-select>
                            <v-select
                                v-model="CRUDModel.socios"
                                :items="CRUDModel.socios"
                                item-text="nombre"
                                chips
                                label="Socios internacionales"
                                multiple
                                outlined
                                readonly
                            ></v-select>
                        </v-flex>
                    </v-layout>
                </v-container>
            </v-card-text>
            </v-tab-item>            
            <v-tab-item key="2">
                <v-card-text>
                    <v-container fluid grid-list-lg v-if="checkEmptyArray(CRUDModel.indicadores)">                        
                        <ProyectoIndicador 
                        v-for="(indicador,index) in CRUDModel.indicadores" 
                        v-bind:key="indicador.indicadorId"
                        :index="index"
                        :indicador="indicador"
                        />
                    </v-container>
                    <v-container v-else>
                        <v-alert
                        :value="true"
                        color="error"
                        icon="mdi-layers-off"
                        outlined
                        >
                        No se encontraron indicadores asociados al proyecto para mostrar. 
                        </v-alert>
                    </v-container>
                </v-card-text>
            </v-tab-item>
            <v-tab-item key="3">
                <v-card-text>
                    <v-container fluid grid-list-lg v-if="checkEmptyArray(CRUDModel.planes)">
                        <ProyectoPlan 
                        v-for="(plan,index) in CRUDModel.planes"
                        v-bind:key="plan.id"
                        :index="index"
                        :plan="plan"
                        />
                    </v-container>
                    <v-container v-else>
                        <v-alert
                        :value="true"
                        color="error"
                        icon="mdi-layers-off"
                        outlined
                        >
                        No se encontraron planes de trabajo asociados al proyecto para mostrar. 
                        </v-alert>
                    </v-container>
                </v-card-text>
            </v-tab-item>                
            </v-tabs>            
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn @click="changeInfoDialogVisibility" color="gray darken-1" text>Cerrar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapMutations, mapState} from 'vuex'
    import ProyectoIndicador from './ProjectIndicador'
    import ProyectoPlan from './ProjectPlan'
   
    export default {
        components: {
            ProyectoIndicador,
            ProyectoPlan
        },
        data() {
            return {
                emptyList: []                
            }
        },
        computed: {
            ...mapState(['modelSpecification', 'visibleInfoDialog', 'CRUDModel'])
        },
        methods: {
            ...mapMutations(['changeInfoDialogVisibility']),
            formatDate(UtcDate) {
                const date = new Date(UtcDate);
                return date.getDay() + '/' + date.getMonth() + '/' + date.getFullYear() + ' ' + date.getHours() + ':' + date.getMinutes();
            },
            verifyNotEmpty(text) {
                if (text === undefined || text === null) {
                    return 'N/A'
                }
                return text;
            },
            formatDate(text){
                if(text != undefined)
                return text.split('T')[0];
            },
            formatTime(text){
                if(text != undefined)
                return text.split('T')[1];
            },
            formatDateTime(text){
                if (text != undefined){
                    let datetime = text.split('T');
                    return datetime[0] + ' ' + datetime[1];
                }                
            },
            numberWithCommas(x) {
                if(x != undefined)
                return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
            },
            checkEmptyArray(arr){
                if(arr === undefined || arr === null){
                    return false;
                }else {
                    if(arr.length === 0) return false;
                    return true;
                }                
            }
        }
    }
</script>