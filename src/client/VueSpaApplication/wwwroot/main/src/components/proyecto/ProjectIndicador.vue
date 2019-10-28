<template>
    <v-layout row wrap>
        <v-flex xs12>
            <v-alert
            :value="true"
            color="info"
            icon="mdi-play"
            outlined
            >
            Indicador No. {{index + 1}}
            </v-alert>
        </v-flex>   
        <v-flex xs6>
            <v-textarea
            outlined
            readonly            
            label="Objetivo"
            :value="indicador.nombreObjetivo"
            ></v-textarea>
            <v-textarea
            outlined
            readonly            
            label="Actividad"
            :value="indicador.nombreActividad"
            ></v-textarea>
        </v-flex>
        <v-flex xs6>
            <v-textarea
            outlined
            readonly            
            label="Resultado"
            :value="indicador.nombreResultado"
            ></v-textarea>
            <v-textarea
            outlined
            readonly            
            label="Indicador"
            :value="indicador.nombreIndicador"
            ></v-textarea>
        </v-flex>
        <v-flex xs6>
            <v-text-field
                :value="indicador.metodologia"  
                label="Metodologia"
                outlined
                readonly
            ></v-text-field>
            <v-text-field
                :value="indicador.lineaBase"  
                label="Linea base"
                outlined
                readonly
            ></v-text-field>
            <v-text-field
                :value="getMapValue(indicador.fuenteDato)"  
                label="Fuente de datos"
                outlined
                readonly
            ></v-text-field>
        </v-flex>
        <v-flex xs6>
            <v-text-field
                :value="getMapValue(indicador.frecuenciaMedicion)"  
                label="Frecuencia de medición"
                outlined
                readonly
            ></v-text-field>
            <v-text-field
                :value="getMapValue(indicador.nivelImpacto)"  
                label="Nivel de impacto"
                outlined
                readonly
            ></v-text-field>
            <v-select
                v-model="indicador.desagregaciones"
                :items="indicador.desagregaciones"
                item-text="nombre"
                chips
                label="Desagregaciones"
                multiple
                outlined
                readonly
            ></v-select>            
        </v-flex>        
    </v-layout>
</template>

<script>
export default {
        props: [
            'indicador',
            'index'
        ],
        data() {
            return {             
            }
        },
        methods: {
            getMapValue(map){
                if(map === undefined || map === null){
                    return "Vacío";
                }else {
                    return map.nombre;
                }
            }
        }    
}
</script>