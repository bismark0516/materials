<template>
  <div class="hello">
    <h1>Owners</h1>
    <section class="container">
      <owner
        v-for="owner in owners"
        v-bind:key="owner.id"
        v-bind:item="owner"
      />
    </section>

    <button v-show="!showForm" v-on:click="showForm = true">Add Owner</button>

    <form v-on:submit.prevent="createNewOwner" v-show="showForm">
      <div>
        <label for="name">Name: </label>
        <input type="text" name="name" id="name" v-model="newOwner.name" />
      </div>
      <div>
        <label for="type">Email: </label>
        <input type="text" name="email" id="email" v-model="newOwner.email" />
      </div>

      <button type="submit">Save Owner</button>
    </form>
  </div>
</template>

<script>
import Owner from "../components/Owner.vue";
import ownerService from "../services/OwnerService.js";

export default {
  components: { Owner },
  name: "ListOwners",
  data() {
    return {
      owners: [],
      showForm: false,
      newOwner: {},
    };
  },

  methods: {
    createNewOwner() {
      if (this.newOwner.name) {
        ownerService
          .addOwner(this.newOwner)
          .then(() => {
            this.newOwner = {};
            this.showForm = false;
            this.loadOwners();
          })
          .catch((error) => {
            if (error.response) {
              // error.response exists
              // Request was made, but response has error status (4xx or 5xx)
              console.log("Error adding owner: ", error.response.status);
            } else if (error.request) {
              // There is no error.response, but error.request exists
              // Request was made, but no response was received
              console.log(
                "Error adding owner: unable to communicate to server"
              );
            } else {
              // Neither error.response and error.request exist
              // Request was *not* made
              console.log("Error adding owner: make request");
            }
          });
      }
    },

    loadOwners() {
      ownerService
        .list()
        .then((response) => {
          console.log("Reached created in ListOwners.vue");
          console.log(response);
          this.owners = response.data;
        })
        .catch((error) => {
          if (error.response) {
            // error.response exists
            // Request was made, but response has error status (4xx or 5xx)
            console.log("Error loading owners: ", error.response.status);
          } else if (error.request) {
            // There is no error.response, but error.request exists
            // Request was made, but no response was received
            console.log(
              "Error loading owners: unable to communicate to server"
            );
          } else {
            // Neither error.response and error.request exist
            // Request was *not* made
            console.log("Error loading owners: make request");
          }
        });
    },
  },

  created() {
    this.loadOwners();
  },
};
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
