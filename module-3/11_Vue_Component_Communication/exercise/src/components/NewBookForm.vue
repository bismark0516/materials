<template>
    <form class="new-book-form" v-on:submit.prevent="saveBook">
        <input class="title-input" name="title-input" type="text" placeholder="Title" v-model="book.title" />
        <input class="author-input" name="author-input" type="text" placeholder="Author" v-model="book.author" />
        <input class="isbn-input" name="isbn-input" type="text" placeholder="ISBN" v-model="book.isbn" />
        <button>Submit</button>
    </form>
</template>
<script>
export default {
    data() {
        return {
            book: {}
        }
    },
    methods: {
        saveBook() {
            this.book.read = false
            this.$store.commit('addBook', this.book);
            this.book = {};
        }
    }
}

</script>