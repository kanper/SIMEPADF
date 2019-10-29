<template>
    <v-toolbar>
        <v-icon large left>{{modelSpecification.modelIcon}}</v-icon>
        <v-toolbar-title>{{modelSpecification.modelTitle}}</v-toolbar-title>

        <v-spacer></v-spacer>

        <template>
            <v-btn class="mr-1" v-if="enableAddBtn" @click="changeNewDialogVisibility" color="primary" dark>Nuevo
                <v-icon right>mdi-plus</v-icon>
            </v-btn>
            <v-btn class="ml-1" v-if="enableBackBtn" @click="$router.go(-1)" color="secondary" dark>Volver
                <v-icon right>mdi-reply</v-icon>
            </v-btn>
        </template>
    </v-toolbar>
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
