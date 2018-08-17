<template>
  <v-app>
    <v-toolbar app>
      <v-toolbar-title v-text="title"></v-toolbar-title>
      <v-spacer></v-spacer>
    </v-toolbar>
    <v-content>
      <v-layout row wrap>
        <template v-for="notification in notificationList">
          <v-flex xs12 sm12 md12 lg12 :key="notification.Key">
            <v-alert v-model="notification.visible" :color="getNotificationColor(notification.type)" dismissible>
              {{notification.value}}
            </v-alert>
          </v-flex>
        </template>
      </v-layout>
      <v-container>
        <v-slide-y-transition mode="out-in">
          <router-view/>
        </v-slide-y-transition>
      </v-container>
    </v-content>

  </v-app>
</template>

<script>
  import store from "./store";
  export default {
    name: "App",
    data() {
      return {
        title: "Livraria Nogueira"
      };
    },
    computed: {
      notificationList: function () {
        return store.state.notifications;
      }
    },
    methods: {
      getNotificationColor(notificationType) {
        if (notificationType == 1) {
          return "error";
        }
        if (notificationType == 2) {
          return "success";
        }
        return "warning";
      }
    }
  };
</script>