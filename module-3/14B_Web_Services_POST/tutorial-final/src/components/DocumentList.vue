<template>
  <div class="loading" v-if="isLoading">
    <img src="../assets/hourglass.gif" />
  </div>
  <table v-else>
    <thead>
      <tr>
        <th>&nbsp;</th>
        <th>Document Name</th>
        <th>Author</th>
        <th>Last Opened by me</th>
        <th>Actions</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="doc in sortedDocs" v-bind:key="doc.id">
        <td class="docs-icon">
          <img src="../assets/icons8-google-docs-48.png" />
        </td>
        <td class="name">{{ doc.name }}</td>
        <td>
          <img v-bind:src="doc.avatar" class="avatar" />
          <span class="ownedby">{{ doc.author }}</span>
        </td>
        <td>{{ new Date(doc.lastOpened).toDateString() }}</td>
        <td>
          <button v-on:click="viewDocument(doc.id)">Edit</button>&nbsp;
          <button v-on:click="deleteDocument(doc.id)">Delete</button>
        </td>
      </tr>
    </tbody>
  </table>
</template>

<script>
import docsService from '../services/DocsService';

export default {
  data() {
    return {
      isLoading: true,
      docs: []
    };
  },
  computed: {
    sortedDocs() {
      return this.docs
        .slice()
        .sort(
          (a, b) =>
            new Date(b.lastOpened) -
            new Date(a.lastOpened)
        );
    }
  },
  methods: {
    getDocuments() {
      docsService.list().then(response => {
        this.isLoading = false;
        this.docs = response.data;
      });
    },
    viewDocument(id) {
      this.$router.push({ name: 'DocumentView', params: { id: id } });
    },
    deleteDocument(id) {
      this.isLoading = true;
      docsService
        .delete(id)
        .then(response => {
          this.isLoading = false;
          if (response.status === 200) {
            this.getDocuments();
          }
        })
        .catch(error => {
          this.loading = false;
          if (error.response.status === 404) {
            this.$router.push({ name: 'NotFoundView' });
          } else {
            console.error(error);
          }
        });
    },
  },
  created() {
    this.getDocuments();
  },
};
</script>

<style scoped>
table {
  width: 100%;
  border-collapse: collapse;
  margin: 0;
  padding: 0;
}

th {
  font-family: "Work Sans", sans-serif;
  font-weight: 500;
  text-align: left;
}

tr {
  margin: 20px;
  padding: 10px;
}

td {
  padding: 8px;
  font-family: "Work Sans", sans-serif;
}

td.name {
  font-weight: 400;
}

.docs-icon img {
  height: 32px;
}

.avatar {
  border-radius: 20px;
  width: 32px;
  vertical-align: middle;
  padding-right: 5px;
}

.ownedby {
  vertical-align: middle;
}
</style>
