import { createRouter as _createRouter, createWebHistory } from 'vue-router';
import ProductsView from '../views/ProductsView.vue';
import ProductDetailView from '../views/ProductDetailView.vue';
import AddReviewView from '../views/AddReviewView.vue';
import NotFoundView from '../views/NotFoundView.vue';

const routes = [
  {
    path: '/',
    name: 'products',
    component:ProductsView
  },
  {
    path: '/products/:id',
    name: 'product-detail',
    component: ProductDetailView
  },
  {
    path: '/products/:id/add-review',
    name: 'add-review',
    component: AddReviewView
  },
  {
    path: '/products',
    redirect: { name: "products" }
  },
  {
    path: '/:pathMatch(.*)*',
    name: 'notFound',
    component: NotFoundView
  }
];

export function createRouter () {
  return _createRouter({
    history: createWebHistory(),
    routes: routes
  })
}
