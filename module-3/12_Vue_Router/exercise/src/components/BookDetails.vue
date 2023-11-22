<template>
    <div class="card" v-bind:book="book">
        <h2 class="book-title">{{ book.title }}</h2>
        <h3 class="book-author">{{ book.author }}</h3>
        <img v-if="book.isbn" v-bind:src="'http://covers.openlibrary.org/b/isbn/' + book.isbn + '-M.jpg'" />
        <li><a v-bind:href="book.moreInfoLink">More information</a></li>
        <h4 class="book-pages">Number of pages: {{ book.numPages }}</h4>
        <h5 class="book-read" v-if="book.read">I have read this book</h5>
        <h5 class="book-read" v-else>I have not read this book</h5>
    </div>
</template>

<script>

export default {
    props: {
        book: Object,
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
}

.card .book-title {
    font-size: 1.5rem;
}

.card .book-author {
    font-size: 1rem;
}
</style>