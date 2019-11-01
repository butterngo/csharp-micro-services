import Vue from "vue";
import VueRouter from "vue-router";
import { components } from "./components"

Vue.use(VueRouter);

let routeComponent = components();

const router = new VueRouter({
  routes: [
    {
      path: "/",
      component: routeComponent.client,
      meta: {
        requiresAuth: false,
        applicationContext: "home"
      }
    }
  ]
});

export default router;

// router.beforeEach((to, from, next) => {
//     // if(to.matched.some((record) => record.meta.requiresAuth)){
        
//     // }
// });
