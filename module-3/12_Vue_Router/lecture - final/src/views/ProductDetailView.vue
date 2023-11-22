<template>
    <h1>{{ product.name }}</h1>
    <p class="description">{{ product.description}}</p>
    <div class="actions">
        <router-link v-bind:to="{name:'products'}">Back to Products</router-link>&nbsp;|
        <router-link
            v-bind:to="{
                name: 'add-review',
                params: {
                    id: product.id
                }
            }"
            >Add Review</router-link>
    </div>
    <div class="well-display">
        <AverageSummary v-bind:reviews="product.reviews" />
        <StarSummary 
            v-for="i in 5" v-bind:key="i"
            v-bind:reviews="product.reviews" 
            v-bind:rating="i" />
    </div>
    <ReviewList v-bind:reviews="product.reviews" />
</template>

<script>
import AverageSummary from '@/components/AverageSummary.vue'
import StarSummary from '@/components/StarSummary.vue'
import ReviewList from '@/components/ReviewList.vue'

export default {
    name: 'product-detail-view',
    components: {
        AverageSummary,
        StarSummary,
        ReviewList
    },
    computed: {
        product() {
            // $route gives access to the current url
            // params will contain any variable data defined for the route
            // the name of the param is defined in the /router/index.js
            // route object 
            const productId = this.$route.params.id;
            const foundProduct = this.$store.state.products.find(p => p.id == productId);
            return foundProduct;
        }
    }
}
</script>

<style scoped>
.well-display {
  display: flex;
  justify-content: space-around;
  margin-bottom: 1rem;
}
.actions {
  margin: 2rem;
}
</style>
