<template>
  <v-app id="app">
    <v-content>
      <layout></layout>
    </v-content> 
  </v-app>
</template>

<script>
import { Layout } from "./components";

export default {
  name: 'App',
  components: {
    //HelloWorld,
    Layout
  },
  beforeMount:()=>{
    console.log("beforeMount ", this);
  },
  data: () => ({
    //
  }),
};
</script>
