import Vue from "vue";
import Router from "vue-router";
import store from "../store/index";

import Login from "../views/Login.vue";
import Logout from "../views/Logout.vue";
import Register from "../views/Register.vue";

import HomeView from "../views/HomeView.vue";
import ListOwners from "../views/ListOwners.vue";
import ListPets from "../views/ListPets.vue";
import NotFound from "../views/NotFound.vue";
import EditPet from "../views/EditPet.vue";

Vue.use(Router);

const router = new Router({
  mode: "history",
  base: process.env.BASE_URL,
  routes: [
    {
      path: "/",
      name: "homeView",
      component: HomeView,
    },

    {
      path: "/login",
      name: "login",
      component: Login,
      meta: {
        requiresAuth: false,
      },
    },

    {
      path: "/logout",
      name: "logout",
      component: Logout,
      meta: {
        requiresAuth: false,
      },
    },

    {
      path: "/register",
      name: "register",
      component: Register,
      meta: {
        requiresAuth: false,
      },
    },

    {
      path: "/pets",
      name: "listPets",
      component: ListPets,
    },

    {
      path: "/owners",
      name: "listOwners",
      component: ListOwners,
    },

    {
      path: "/editPet/:petId",
      name: "editPet",
      component: EditPet,
    },

    {
      path: "*",
      name: "notFound",
      component: NotFound,
    },
  ],
});

router.beforeEach((to, from, next) => {
  // Determine if the route requires Authentication
  const requiresAuth = to.matched.some((x) => x.meta.requiresAuth);

  // If it does and they are not logged in, send the user to "/login"
  if (requiresAuth && store.state.token === "") {
    next("/login");
  } else {
    // Else let them go to their next destination
    next();
  }
});

export default router;
