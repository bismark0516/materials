<template>
  <div class="hello">
    <h1>Pets</h1>
    <section class="container">
      <pet v-for="pet in pets" v-bind:key="pet.id" v-bind:item="pet" />
    </section>

    <button v-show="!showForm" v-on:click="showForm = true">Add Pet</button>

    <form v-on:submit.prevent="createNewPet" v-show="showForm">
      <div>
        <label for="name">Name: </label>
        <input type="text" name="name" id="name" v-model="newPet.name" />
      </div>
      <div>
        <label for="type">Type: </label>
        <input type="text" name="type" id="type" v-model="newPet.type" />
      </div>
      <div>
        <label for="age">Age: </label>
        <input type="number" name="age" id="age" v-model="newPet.age" />
      </div>

      <button type="submit">Save Pet</button>
    </form>
  </div>
</template>

<script>
import Pet from "../components/Pet.vue";

export default {
  components: { Pet },
  name: "ListPets",
  data() {
    return {
      showForm: false,
      newPet: {},
    };
  },
  computed: {
    
  },
  methods: {
    createNewPet() {
      if (this.newPet.name) {
        petService
          .addPet(this.newPet)
          .then(() => {
            this.newPet = {};
            this.showForm = false;
            this.loadPets();
          })
          .catch((error) => {
            if (error.response) {
              // error.response exists
              // Request was made, but response has error status (4xx or 5xx)
              console.log("Error adding pet: ", error.response.status);
            } else if (error.request) {
              // There is no error.response, but error.request exists
              // Request was made, but no response was received
              console.log(
                "Error adding pet: unable to communicate to server"
              );
            } else {
              // Neither error.response and error.request exist
              // Request was *not* made
              console.log("Error adding pet: make request");
            }
          });
      }
    },

  },
};
</script>

<style scoped>
</style>
