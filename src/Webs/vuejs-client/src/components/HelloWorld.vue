<template>
  <v-container>
    <v-layout text-center wrap>
      <div>
        <label>Display Name</label>
        <input class="form-control" v-model="newUser" v-on:keyup.enter="addUser(newUser)">
      </div>
    </v-layout>
  </v-container>
</template>

<script>
//import { mapActions } from 'vuex';
export default {
  data() {
      return {
        newUser : ''
      }
   },

  methods: {
    addUser: ()=>{
      console.log(this);
    }
  }
};
</script>
