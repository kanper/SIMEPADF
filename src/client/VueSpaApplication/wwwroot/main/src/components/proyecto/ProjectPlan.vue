<template>
    <v-layout row wrap>
        <v-flex xs12>
            <v-alert
            :value="true"
            color="info"
            icon="mdi-play"
            outlined
            >
            Actividad No. {{index + 1}}
            </v-alert>
        </v-flex>   
        <v-flex xs6>
            <v-text-field
                :value="plan.nombreActividad"  
                label="Actividad"
                outlined
                readonly
            ></v-text-field>            
        </v-flex>
        <v-flex xs2>
            <v-text-field
                :value="numberWithCommas(plan.monto)"  
                label="Monto"
                outlined
                readonly
                prepend-inner-icon="mdi-cash-usd"
            ></v-text-field>            
        </v-flex>
        <v-flex xs2>
            <v-text-field
                :value="formatDate(plan.fechaInicio)"  
                label="Fecha Inicio"
                outlined
                readonly
                prepend-inner-icon="mdi-calendar"
            ></v-text-field>            
        </v-flex>
        <v-flex xs2>
            <v-text-field
                :value="formatDate(plan.fechaLimite)"  
                label="Fecha Fin"
                outlined
                readonly
                prepend-inner-icon="mdi-calendar"
            ></v-text-field>            
        </v-flex>
        <v-flex xs6>
            <v-select
                v-model="plan.paises"
                :items="plan.paises"
                item-text="nombre"
                chips
                label="Paises"
                multiple
                outlined
                readonly
            ></v-select>            
        </v-flex>
        <v-flex xs6>
            <v-select
                v-model="plan.productos"
                :items="plan.productos"
                item-text="nombre"
                chips
                label="Productos"
                multiple
                outlined
                readonly
            ></v-select>            
        </v-flex>
    </v-layout>
</template>

<script>
export default {
        props:[
            'plan',
            'index'
        ],
        data() {
            return {             
            }
        },
        methods: {
            formatDate(text){
                if(text != undefined)
                return text.split('T')[0];
            },
            numberWithCommas(x) {
                if(x != undefined)
                return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
            }
        }    
}
</script>