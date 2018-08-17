<template>
    <div>
        <v-layout row wrap mb-4>
            <v-flex lg-1>
                <v-btn color="primary" to="/Create">
                    <v-icon small>save</v-icon>Novo Livro
                </v-btn>
            </v-flex>
        </v-layout>  
        <books-list/>
    </div>
</template>
<script>
import booksList from "../components/Books/booksList.vue"
export default {
    components:{
        booksList
    }
}
</script>
