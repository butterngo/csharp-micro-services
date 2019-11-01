<template>
  <v-card-text>
    <span class="title">Clients</span>
    <div class="table-wrapper">
      <v-simple-table>
        <template v-slot:default>
          <thead>
            <tr>
              <th class="text-left">Name</th>
              <th class="text-left">Calories</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="item in desserts" :key="item.name">
              <td>{{ item.name }}</td>
              <td>{{ item.calories }}</td>
            </tr>
          </tbody>
        </template>
     </v-simple-table>
    </div>
    <div class="text-center">
          <v-pagination
            v-model="page"
            :length="6"
          ></v-pagination>
    </div>
  </v-card-text>
</template>

<script>
//import { mapActions } from 'vuex';
import "./index.scss"
export default {
 data () {
      return {
        page: 1,
        desserts: [
          {
            name: 'Frozen Yogurt',
            calories: 159,
          },
          {
            name: 'Ice cream sandwich',
            calories: 237,
          },
          {
            name: 'Eclair',
            calories: 262,
          },
          {
            name: 'Cupcake',
            calories: 305,
          },
          {
            name: 'Gingerbread',
            calories: 356,
          },
          {
            name: 'Jelly bean',
            calories: 375,
          },
          {
            name: 'Lollipop',
            calories: 392,
          },
          {
            name: 'Honeycomb',
            calories: 408,
          },
          {
            name: 'Donut',
            calories: 452,
          },
          {
            name: 'KitKat',
            calories: 518,
          },
        ],
      }
    },
  };
</script>
