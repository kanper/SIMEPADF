<template>
    <div>
        <v-toolbar dark color="black">
            <v-toolbar-title>Formulario de Usuarios: Cambiar Contraseña</v-toolbar-title>
            <v-spacer></v-spacer>
            <v-toolbar-items>
                <v-btn dark flat @click="update()">Actualizar</v-btn>
            </v-toolbar-items>
        </v-toolbar>
        <v-container>
            <v-text-field
            :append-icon="show1 ? 'mdi-eye' : 'mdi-eye-off'"
            :type="show1 ? 'text' : 'password'"
            hint="al menos 8 caracteres"
            label="Contraseña Nueva*"
            required
            @click:append="show1 = !show1"
            v-model="form.newPassword"
            ></v-text-field>
        </v-container>
    </div>
</template>

<script>
export default {
    name: "changePass",
    data() {
        return {
            show1: false,
            form: {
                newPassword: null,
            },
        };
    },
    methods: {
        update() {
            
        }
    },
}
</script>