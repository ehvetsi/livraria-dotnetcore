<template>
    <div>
        <v-data-table 
            :headers="headers" 
            :items="books" 
            :pagination.sync="pagination" 
            no-results-text="Sem itens para exibir" 
            rows-per-page-text="Itens por página"
            :rows-per-page="pagination.rowsPerPage" 
            :rows-per-page-items='[2,5,10,25,50,100,{"text":"Todos","value":-1}]' 
            class="elevation-4"
            >
                <template slot="headers" slot-scope="props">
                    <tr>
                        <th v-for="header in props.headers" :key="header.text" 
                            :class="['column sortable', pagination.descending ? 'desc' : 'asc', header.value === pagination.sortBy ? 'active' : '','grid-column']"
                            @click="changeSort(header.value)"
                            :style="{ width: header.width + 'px !important' }"
                            >
                            <v-icon small>arrow_upward</v-icon>
                            {{ header.text }}
                        </th>
                    </tr>
                </template>
                <template slot="items" slot-scope="props">
                    <td class="text-xs-center grid-column">{{ props.item.Id}}</td>
                    <td class="text-xs-left grid-column">{{ props.item.Name }}</td>
                    <td class="text-xs-left grid-column">{{ props.item.AuthorName }}</td>
                    <td class="text-xs-center grid-column">{{ props.item.Quantity }}</td>
                    <td class="text-xs-center grid-column">
                        <v-btn v-for="button in buttons" :key="button.id" icon class="mx-0" @click="button.action(props.item)" :title="button.name">
                            <v-icon :color="button.color">{{button.icon}}</v-icon>
                        </v-btn>
                    </td>
                </template>
                <template slot="pageText" slot-scope="props">
                    Itens {{ props.pageStart }} - {{ props.pageStop }} de {{ props.itemsLength }}
                </template>
        </v-data-table>
        <v-dialog v-model="confirmDeleteDialog" max-width="450px">
            <v-card>
                <v-card-title>
                  <h3 class="error--text">Um livro será excluído.</h3>
                </v-card-title>
                <v-card-text>
                  Deseja realmente excluir o livro "{{selectedBook.Name}}"?
                </v-card-text>
                <v-card-actions style="justify-content: flex-end">
                    <v-btn color="primary" flat @click="confirmDeleteDialog=false">Cancelar</v-btn>
                    <v-btn color="primary" flat @click="deleteBook">Excluir</v-btn>
                </v-card-actions>
            </v-card>
        </v-dialog>
    </div>
    </template>
    <script>
import BooksService from "../../services/booksService";
export default {
  data() {
    return {
      service: new BooksService(),
      headers: [
        {
          text: "Código",
          align: "left",
          sortable: false,
          value: "Id",
          width: 80
        },
        {
          text: "Nome",
          align: "left",
          sortable: false,
          value: "Name",
          width: 200
        },
        {
          text: "Autor",
          align: "left",
          sortable: false,
          value: "AuthorName",
          width: 200
        },
        {
          text: "Estoque",
          align: "left",
          sortable: false,
          value: "Quantity",
          width: 80
        },
        {
          text: "Ações",
          align: "center",
          sortable: false,
          width: 100
        }
      ],
      buttons: [
        {
          name: "Editar",
          action: item => this.$router.push(`/Edit/${item.Id}`),
          color: "teal",
          icon: "edit",
          id: "btn1"
        },
        {
          name: "Excluir",
          color: "error",
          icon: "delete",
          id: "btn2",
          action: item => {
            this.confirmDeleteDialog = true;
            this.selectedBook = item;
          }
        }
      ],
      pagination: {
        sortBy: "Name",
        rowsPerPage: 5
      },
      books: [],
      confirmDeleteDialog: false,
      selectedBook: {}
    };
  },
  methods: {
    changeSort(column) {
      if (this.pagination.sortBy === column) {
        this.pagination.descending = !this.pagination.descending;
      } else {
        this.pagination.sortBy = column;
        this.pagination.descending = false;
      }
    },

    async deleteBook() {
      this.clearAllMessages();
      let response = await this.service.delete(this.selectedBook.Id);
      let json = response.json();
      if (response.ok) {
        this.showMessage(2, "Livro removido com sucesso.");
        this.loadBooks();
      } else {
        json.forEach(msg => this.showMessage(1, msg.Value));
      }
      this.confirmDeleteDialog = false;
    },

    async loadBooks() {
      let response = await this.service.listAll();
      if (response.ok) {
        let json = await response.json().catch(erro => console.log(erro));
        this.books = [];
        this.books = json;
      } else {
        let erros = await response.json();
        erros.forEach(msg => this.showMessage(1, msg.Value));
      }
    }
  },
  created() {
    this.loadBooks();
  }
};
</script>
<style>
.grid-column {
  word-break: break-word !important;
  padding: 0px !important;
  padding-left: 10px !important;
}
table.v-table thead th {
  white-space: normal !important;
}
</style>
