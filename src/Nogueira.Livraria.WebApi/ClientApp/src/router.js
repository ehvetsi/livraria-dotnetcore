import Vue from 'vue'
import Router from 'vue-router'
import books from './views/books.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'books',
      component: books
    },
    {
      path: '/Create/',
      name: 'Create',
      component: () => import(/* webpackChunkName: "about" */ './components/Books/booksForm.vue'),
      props:true
    },
    {
      path: '/Edit/:id',
      name: 'edit',
      component: () => import(/* webpackChunkName: "about" */ './components/Books/booksForm.vue'),
      props:true
    }
  ]
})
