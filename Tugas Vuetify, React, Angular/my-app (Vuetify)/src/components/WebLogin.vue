<template>
    <div>
        <v-container>
            <v-form v-model="valid">
                <v-text-field v-model="name" :rules="nameRules" :counter="10" label="Name" required></v-text-field>
                <v-text-field v-model="email" :rules="emailRules" label="E-mail" required></v-text-field>
                <v-textarea v-model="pesan" label="Pesan" multi-line></v-textarea>
                <v-actions>
                    <v-btn flat color="success darken-2">Login</v-btn>
                </v-actions>
            </v-form>
        </v-container>
    </div>
</template>

<script>
export default {
    data() {
        return {
            valid: false,
            name: "",
            nameRules: [
                v =>!!v || "Name is required",
                v => (v && v.length <= 10) || "Name must be less than 10 characters"
            ],
            email: "",
            emailRules: [
                v =>!!v || "E-mail is required",
                v => /.+@.+/.test(v) || "E-mail must be valid"
            ],
            pesan: ''
        }
    }
}
</script>