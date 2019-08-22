<template>
    <v-dialog max-width="50%" persistent scrollable v-model="visibleInfoDialog">
        <v-card>
            <v-card-title class="headline blue darken-3 white--text">Registro de {{modelSpecification.modelTitle}}:
                Información
            </v-card-title>
            <v-card-text>
                <v-container fluid grid-list-lg>
                    <v-layout row wrap>
                        <v-flex xs12
                                v-for="item in modelSpecification.modelInfo"
                                v-bind:key="item.name"
                                v-bind:data="item"
                        >
                            <InfoItem
                                    :name="item.name"
                                    :value="item.value"
                                    :itemType="item.type"
                            />
                        </v-flex>
                    </v-layout>
                </v-container>
            </v-card-text>
            <v-card-actions>
                <v-spacer></v-spacer>
                <v-btn @click="changeInfoDialogVisibility" color="gray darken-1" flat>Cerrar</v-btn>
            </v-card-actions>
        </v-card>
    </v-dialog>
</template>

<script>
    import {mapMutations, mapState} from 'vuex'
    import InfoItem from './InfoItem'
    export default {
        components:{
          InfoItem
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
            }
        }
    }
</script>