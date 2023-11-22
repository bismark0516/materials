import { createStore as _createStore } from 'vuex';

export function createStore() {
  return _createStore({
    state: {
      books: [
        {
          title: "Kafka on the Shore",
          author: "Haruki Murakami",
          read: false,
          isbn: "9781784877989"
        },
        {
          title: "The Girl With All the Gifts",
          author: "M.R. Carey",
          read: true,
          isbn: "9780356500157"
        },
        {
          title: "The Old Man and the Sea",
          author: "Ernest Hemingway",
          read: true,
          isbn: "9780684830490"
        },
        {
          title: "Le Petit Prince",
          author: "Antoine de Saint-Exupéry",
          read: false,
          isbn: "9783125971400"
        }
      ]
    },
    mutations: {
      setStatus(state, { isbn, isRead }) {
        const book = state.books.find(book => book.isbn === isbn);
        if (book) {
          book.read = isRead;
        }
      },
      addBook(state, book) {
        state.books.push(book);
      }
      
    },
    actions: {
      addBook({ commit }, book) {
        commit("addBook", book);
      }
    },
    modules: {},
    // Strict should not be used in production code. It is used here as a
    // learning aid to warn you if state is modified without using a mutation.
    strict: true
  })
}
