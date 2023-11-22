<template>
    <h1>Add Review</h1>
    <AddReview v-bind:productId="currentProductId" />
</template>

<script>
import AddReview from '@/components/AddReview.vue';

export default {

    components: {
        AddReview
    },
    computed: {
        currentProductId() {
            const productIdFromUrl = this.$route.params.id;
            return productIdFromUrl;
        }
    }

}
</script>

<style scoped>

</style>