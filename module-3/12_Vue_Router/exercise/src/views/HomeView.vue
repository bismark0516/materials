<template>
    <BestSellersList />
    <NewReleasesList />
</template>

<script>
import BestSellersList from '@/components/BestSellerList.vue';
import NewReleasesList from '@/components/NewReleasesList.vue';

export default {
    name: 'home-view',
    components: {
        BestSellersList,
        NewReleasesList
    }

}
</script>