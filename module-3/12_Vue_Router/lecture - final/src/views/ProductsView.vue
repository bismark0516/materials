<template>
    <h1>Products</h1>
    <ProductsList />
</template>

<script>
import ProductsList from '@/components/ProductsList.vue';

export default {
    name: 'product-view',
    components: {
        ProductsList
    }
}


</script>
