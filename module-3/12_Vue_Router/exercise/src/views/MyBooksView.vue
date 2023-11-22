<template>
    <ReadingList />
    <router-link v-bind:to="{ name: 'AddBook' }">Add Book To Reading List</router-link>
</template>

<script>
import ReadingList from '@/components/ReadingList.vue';

export default {
    name: 'my-books',
    components: {
        ReadingList
    }

}
</script>