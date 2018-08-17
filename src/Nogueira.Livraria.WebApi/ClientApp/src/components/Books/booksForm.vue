<template>
    <v-form ref="form" v-model="formValid" lazy-validation>
        <v-layout row wrap>
            <h3>{{id ?'Editar livro':'Novo livro'}}</h3>
        </v-layout>
        <v-layout row wrap mt-4>
            <v-flex  xs12 sm12 md12 lg12>
                <v-text-field
                    v-model="book.Name"
                    label="Nome do Livro"
                    :rules="bookRules"
                    counter="50"
                    autofocus
                    box
                    clearable
                    ref="book"
                    id="Book"
                ></v-text-field>
            </v-flex>
        </v-layout>
        <v-layout row wrap>
            <v-flex  xs12 sm12 md12 lg5>
                <v-text-field
                    v-model="book.PublicationDate"
                    label="Data de Publicação"
                    mask="##/##/####"
                    hint="dd/MM/yyyy"
                    :rules="publicationDateRules"
                    return-masked-value
                    box
                    clearable
                ></v-text-field>
            </v-flex>
            <v-flex  xs12 sm12 md12 lg6 offset-lg1>
                <v-text-field
                    v-model="book.Quantity"
                    label="Quantidade em estoque"
                    mask="#####"
                    box
                    clearable
                ></v-text-field>
            </v-flex>
        </v-layout>
        <v-layout row wrap>
            <v-flex  xs12 sm12 md12 lg12>
                <v-text-field
                    v-model="book.AuthorName"
                    label="Nome do Autor"
                    :rules="authorRules"
                    counter="50"
                    clearable
                    box
                ></v-text-field>
            </v-flex>
        </v-layout>
        <v-layout row wrap>
            <v-flex lg-1>
                <v-btn color="success" @click="save">
                    <v-icon small>save</v-icon>Salvar
                </v-btn>
                <v-btn color="default" to="/">
                    <v-icon small>arrow_back</v-icon>Cancelar
                </v-btn>
            </v-flex>
        </v-layout>        
    </v-form>  
</template>
<script>
import BooksService from "../../services/booksService";
export default {
  props: {
    id: String
  },
  data() {
    return {
      service: new BooksService(),
      book: {
        Name: "",
        AuthorName: "",
        Quantity: 0,
        PublicationDate: "",
        Id: 0
      },
      bookRules: [
        value => !!value || "O nome é obrigatório.",
        value =>
          (value ? value.length <= 50 : true) ||
          "O nome deve ter no máximo 50 caracteres."
      ],
      authorRules: [
        value =>
          (value ? value.length <= 50 : true) ||
          "O nome do autor deve ter no máximo 50 caracteres."
      ],
      quantityRules: [
        value =>
          (value ? value >= 0 : true) || "A quantidade deve ser no mínimo 0."
      ],
      publicationDateRules: [
        date =>
          (date ? moment(date, "DD/MM/YYYY").isValid() : true) ||
          "Data inválida."
      ],
      formValid: true
    };
  },
  methods: {
    async save() {
      if (this.$refs.form.validate()) {
        this.clearAllMessages();
        let response = this.id
          ? await this.service.update(this.book)
          : await this.service.add(this.book);
        if (response.ok) {
          this.$router.push("/");
          this.showMessage(2, "Livro salvo com sucesso.");
        } else {
          let json = await response.json();
          json.forEach(msg => this.showMessage(1, msg.Value));
        }
      }
    }
  },
  async created() {
    if (this.id) {
      let response = await this.service.get(this.id);
      let json = await response.json();
      if (response.ok) {
        json.PublicationDate = moment(json.PublicationDate).format("L");
        this.book = json;
      } else {
        json.forEach(msg => this.showMessage(1, msg.Value));
      }
    }
  }
};
</script>
