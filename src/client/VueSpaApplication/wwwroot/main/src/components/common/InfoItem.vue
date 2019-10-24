<template>
    <v-card>
        <v-card-title primary-title>
            <v-icon large left>{{icon}}</v-icon>
            <div>
                <div class="headline">{{name}}</div>
            </div>
            <v-layout align-center justify-end>
                <v-btn icon @click="show = !show">
                    <v-icon>{{ show ? 'mdi-menu-down' : 'mdi-menu-up' }}</v-icon>
                </v-btn>
            </v-layout>
        </v-card-title>
        <v-card-text v-show="show">
            {{buildCardContent(value,itemType)}}
            <ul v-if="itemType === 'list'"><li v-for="(item,index) in CRUDModel[value]" v-bind:key="index">{{item.nombre}}</li></ul>
        </v-card-text>
    </v-card>
</template>

<script>
    import {mapState} from 'vuex'

    export default {
        name: "InfoItem",
        props:{
            name: {
                type: String,
                require: false
            },
            value: {
                type: String,
                require: false,
                default: 'N/A'
            },
            itemType: {
                type: String,
                require: false,
                default: 'text'
            },
        },
        data() {
            return {
                icon: 'mdi-bookmark',
                show: true
            }
        },
        computed:{
            ...mapState(['CRUDModel'])
        },
        methods: {
            buildCardContent(nameValue, type){
                let value = this.CRUDModel[nameValue];
                if(value !== undefined){
                    switch (type) {
                        case 'text':
                            this.icon = 'mdi-file-document-box';
                            return value;
                        case 'number':
                            this.icon = 'mdi-numeric';
                            return this.numberWithCommas(value);
                        case 'date':
                            this.icon = 'mdi-calendar-multiple-check';
                            return this.formatDate(value);
                        case 'datetime':
                            this.icon = 'mdi-calendar-clock';
                            return this.formatDateTime(value);
                        case 'money':
                            this.icon = 'mdi-cash-usd';
                            return '$ ' + this.numberWithCommas(value);
                        case 'percent':
                            this.icon = ' mdi-margin';
                            return value + ' %';
                        case 'time':
                            this.icon = 'mdi-clock';
                            return this.formatTime(value);
                        case 'boolean':
                            this.icon = 'mdi-checkbox-marked-circle-outline';
                            return value;
                        case 'array':
                            this.icon = 'mdi-table';
                            return value.map(function (item) {
                                return item['nombre'];
                            }).join(', ');
                        case 'list':
                            return '';
                        case 'obj':
                            this.icon = 'mdi-package-variant-closed';
                            return value.nombre;
                        default:
                            return value;
                    }
                }
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
        }
    }
</script>

<style scoped>

</style>