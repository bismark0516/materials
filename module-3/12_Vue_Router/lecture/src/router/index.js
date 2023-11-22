import { createRouter as _createRouter, createWebHistory } from 'vue-router';
import ProductsView from '../views/ProductsView.vue';
const routes = [
  {
    path: '/',
    name: 'Products',
    component: ProductsView
  }
    
];

export function createRouter () {
  return _createRouter({
    history: createWebHistory(),
    routes: routes
  })
}
