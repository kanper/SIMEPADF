<template>
    <v-card class="mx-auto" outlined>
        <v-list-item three-line>
            <v-list-item-content>
                <div class="overline mb-4">{{top}}</div>
                <v-list-item-title class="headline mb-1">{{main_title}}</v-list-item-title>
                <v-list-item-subtitle>{{info}}</v-list-item-subtitle>
            </v-list-item-content>
        </v-list-item>
    </v-card>
</template>

<script>
    export default {
        name: "ExtraInfo",
        props: ['main_title','info','top']
    }
</script>

<style scoped>

</style>