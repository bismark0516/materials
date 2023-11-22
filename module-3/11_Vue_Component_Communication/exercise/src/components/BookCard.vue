<template>
  <div class="card" v-bind:class="{ read: book.read }">
    <h2 class="book-title">{{ book.title }}</h2>
    <img v-bind:src="'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'" class="book-image" />
    <h3 class="book-author">{{ book.author }}</h3>
    <button @:click.prevent="markUnread" class="mark-unread" v-if="book.read">Mark Unread</button>
    <button @:click.prevent="markRead" class="mark-read" v-else>Mark Read</button>
  </div>
</template>
<script>
export default {


  name: 'BookCard',
  props: {

    book: Object
  },
  methods: {

    setRead() {
      let status = true;
      this.$store.commit("changeStatus", { book: this.book, status: status });
    },
    setUnread() {
      let status = false;
      this.$store.commit("changeStatus", { book: this.book, status: status });
    }
  }
}



</script>

<style>
.card {
  border: 2px solid black;
  border-radius: 10px;
  width: 250px;
  height: 550px;
  margin: 20px;
  position: relative;
}

.card.read {
  background-color: lightgray;
}

.card .book-title {
  font-size: 1.5rem;
}

.card .book-author {
  font-size: 1rem;
}

.book-image {
  width: 80%;
}

.mark-read,
.mark-unread {
  display: block;
  position: absolute;
  bottom: 40px;
  width: 80%;
  left: 10%;
  font-size: 1rem;
}
</style>