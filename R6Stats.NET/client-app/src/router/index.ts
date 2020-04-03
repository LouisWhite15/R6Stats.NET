import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import PlayerStats from "../views/PlayerStats.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home
  },
  {
    path: "/player/:id",
    name: "Player Stats",
    component: PlayerStats
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

export default router;
