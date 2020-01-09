<template>
    <v-app>
        <toolbar/>
        <Navigation/>
        <transition name="fade" mode="out-in">
            <v-content>
                <router-view />
            </v-content>
        </transition>
    </v-app>
</template>

<script>
    import toolbar from './components/common/Toolbar'
    import Navigation from './components/common/Navigation-Drawer'
    export default {
        name: 'App',
        components: {
            toolbar,
            Navigation
        },
    };
</script>

<style>
.fade-enter-active, .fade-leave-active {
    transition: opacity .2s;
}
.fade-enter, .fade-leave-to {
    opacity: 0;
}

.slide-fade-enter-active {
    transition: all .3s ease;
}
.slide-fade-leave-active {
    transition: all .8s cubic-bezier(1.0, 0.5, 0.8, 1.0);
}
.slide-fade-enter, .slide-fade-leave-to {
    transform: translateX(10px);
    opacity: 0;
}
</style>