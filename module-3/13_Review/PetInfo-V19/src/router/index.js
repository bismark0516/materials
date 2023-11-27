import { createRouter as _createRouter, createWebHistory } from 'vue-router';
import HomeView from "../views/HomeView.vue";
import ListOwners from "../views/ListOwners.vue";
import ListPets from "../views/ListPets.vue";
import NotFound from "../views/NotFound.vue";
import EditPet from "../views/EditPet.vue";

const routes = [
  {
    path: "/",
    name: "homeView",
    component: HomeView,
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
    path: '/:pathMatch(.*)*',
    name: "notFound",
    component: NotFound,
  },
];

export function createRouter () {
  return _createRouter({
    history: createWebHistory(),
    routes: routes
  })
}
