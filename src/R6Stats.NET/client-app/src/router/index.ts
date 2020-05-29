import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import PlayerStats from "../views/PlayerStats.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "Home",
    component: Home,
    meta: {
      title: "Home - R6Stats.NET"
    }
  },
  {
    path: "/player/:id",
    name: "PlayerStats",
    component: PlayerStats,
    props: true,
    meta:
    {
      title: "R6Stats.NET"
    }
  }
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes
});

router.beforeEach((to, from, next) => {
  document.title = to.meta.title || 'R6Stats.NET';
  next();
});

export default router;
