<template>
    <v-container>
        <v-layout>
            <v-flex>
                <v-card :color="color" class="mx-auto" dark>
                    <v-card-title>
                        <v-icon large left>{{icon}}</v-icon>
                        <span class="title font-weight-light">{{title}}</span>
                        <v-layout align-center justify-end>
                            <v-btn icon @click="show = !show">
                                <v-icon>{{ show ? 'mdi-menu-down' : 'mdi-menu-up' }}</v-icon>
                            </v-btn>
                        </v-layout>
                    </v-card-title>

                    <v-card-text class="headline font-weight-bold" v-show="show">
                        {{text}}
                    </v-card-text>
                </v-card>
            </v-flex>
        </v-layout>
    </v-container>
</template>

<script>
    export default {
        name: "BannerCard",
        props: {
            color: String,
            icon: String,
            title: String,
            text: String
        },
        data() {
            return {
                show: true
            }
        }
    }
</script>

<style scoped>

</style>