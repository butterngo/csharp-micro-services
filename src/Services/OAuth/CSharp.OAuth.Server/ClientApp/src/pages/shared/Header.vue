<template>
  <div>
    <v-toolbar>
      <v-toolbar-title>
        <v-img
          src="https://www.c-sharp.vn//img/logo.png"
          max-height="110"
          max-width="100"
        ></v-img>
      </v-toolbar-title>

      <v-spacer></v-spacer>

      <v-toolbar-items>
        <v-btn text  @click="onNavigateClient()">Clients</v-btn>
        <v-btn text  @click="onLogout()">Logout</v-btn>
      </v-toolbar-items>
    </v-toolbar>
  </div>
</template>
<script>
export default {
    methods:{
        onNavigateClient() {
           /*this.$router.push({
              name: "MakeOneTimePayment",
              params: { summaryaccountid: summaryAccountId },
              query: { redirectTo: "/" }
            });*/
        },

        onLogout(){

        }
    }
}
</script>