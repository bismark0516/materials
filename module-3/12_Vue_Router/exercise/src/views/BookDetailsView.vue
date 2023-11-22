<template>
    <BookDetails v-bind:book= "book"/>
</template>

<script>
import BookDetails from '@/components/BookDetails.vue';

export default {
    name: 'book-details',
    components: {
        BookDetails
    },
    computed: {
        book() {
            const isbn = this.$route.params.isbn;
            let foundBook = this.$store.state.popularBooks.find(book => book.isbn == isbn);
            if (foundBook == undefined) {
                return this.$store.state.books.find(book => book.isbn == isbn);
            }
            return foundBook
        }
    }

}
</script>