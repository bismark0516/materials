<template>
  <div class="book-container">
      <book-card v-bind:book = 'book'
        v-for="book in $store.state.books" v-bind:key="book.isbn" />
  
  </div>
</template>

<script>
import BookCard from './BookCard.vue'

export default {
  components: {
    BookCard
  },
  computed: {
    books() {
      return this.$store.state.books;
    }
  }

}
</script>

<style>
.book-container {
  display: flex;
  justify-content: space-evenly;
  flex-wrap: wrap;
}
</style>