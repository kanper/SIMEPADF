<template>
    <v-card class="mx-auto" color="white">
        <v-card-actions>
            <v-list-tile class="grow">
                <v-list-tile-avatar>
                    <v-icon large left>{{modelSpecification.modelIcon}}</v-icon>
                </v-list-tile-avatar>
                <v-list-tile-content>
                    <v-list-tile-title>{{modelSpecification.modelTitle}}</v-list-tile-title>
                </v-list-tile-content>
                <v-layout align-left justify-end>
                    <v-btn v-if="enableAddBtn" @click="changeNewDialogVisibility" color="primary" dark>Nuevo
                        <v-icon dark right>mdi-plus</v-icon>
                    </v-btn>
                    <v-btn v-if="enableBackBtn" @click="$router.go(-1)" color="secondary" dark>Volver
                        <v-icon dark right>mdi-reply</v-icon>
                    </v-btn>
                </v-layout>
            </v-list-tile>
        </v-card-actions>
    </v-card>
</template>

<script>
    import {mapMutations, mapState} from 'vuex'

    export default {
        props: {
            enableAddBtn: {
                type: Boolean,
                default: true
            },
            enableBackBtn:{
                type: Boolean,
                default: false
            }
        },
        computed: {
            ...mapState(['modelSpecification'])
        },
        methods: {
            ...mapMutations(['changeNewDialogVisibility']),
        }
    }
</script>