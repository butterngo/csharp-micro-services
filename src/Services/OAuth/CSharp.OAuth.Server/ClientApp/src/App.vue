<template>
  <v-app id="app">
    <v-content>
      <Layout></layout>
    </v-content> 
  </v-app>
</template>

<script>
import { Layout } from "./pages";

export default {
  name: 'App',
  components: {
    Layout
  },
  beforeMount(){
    console.log("beforeMount ", this);
  },
  data: () => ({
    //
  }),
};
</script>
